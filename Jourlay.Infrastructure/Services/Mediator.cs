using Jourlay.Domain.Common.Mediatr;
using Jourlay.Domain.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Concurrent;
using System.Reflection;

namespace Jourlay.Infrastructure.Services;

public class Mediator : IMediator
{
    private readonly IServiceProvider _serviceProvider;
    private static readonly ConcurrentDictionary<Type, Type> _handlerCache = new();
    private static readonly ConcurrentDictionary<Type, Type[]> _notificationHandlerCache = new();

    public Mediator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);

        var requestType = request.GetType();
        var handlerType = GetHandlerType(requestType, typeof(TResponse));

        var handler = _serviceProvider.GetService(handlerType);
        if (handler == null)
        {
            throw new HandlerNotFoundException($"Handler for {requestType.Name} not found. Make sure it's registered in DI container.");
        }

        var method = handlerType.GetMethod("Handle");
        if (method == null)
        {
            throw new InvalidOperationException($"Handle method not found in {handlerType.Name}");
        }

        try
        {
            var result = method.Invoke(handler, [request, cancellationToken]);
            if (result is Task<TResponse> task)
            {
                return await task;
            }

            throw new InvalidOperationException($"Handler method should return Task<{typeof(TResponse).Name}>");
        }
        catch (TargetInvocationException ex)
        {
            throw ex.InnerException ?? ex;
        }
    }

    public async Task Send<TRequest>(TRequest request, CancellationToken cancellationToken = default) where TRequest : IRequest
    {
        await Send<Unit>(request, cancellationToken);
    }

    public async Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default) where TNotification : INotification
    {
        ArgumentNullException.ThrowIfNull(notification);

        var notificationType = notification.GetType();
        var handlerTypes = GetNotificationHandlerTypes(notificationType);

        var tasks = new List<Task>();

        foreach (var handlerType in handlerTypes)
        {
            var handlers = _serviceProvider.GetServices(handlerType);
            foreach (var handler in handlers)
            {
                var method = handlerType.GetMethod("Handle");
                if (method != null)
                {
                    try
                    {
                        var result = method.Invoke(handler, [notification, cancellationToken]);
                        if (result is Task task)
                        {
                            tasks.Add(task);
                        }
                    }
                    catch (TargetInvocationException ex)
                    {
                        throw ex.InnerException ?? ex;
                    }
                }
            }
        }

        await Task.WhenAll(tasks);
    }

    private static Type GetHandlerType(Type requestType, Type responseType)
    {
        return _handlerCache.GetOrAdd(requestType, _ =>
        {
            return typeof(IRequestHandler<,>).MakeGenericType(requestType, responseType);
        });
    }

    private static Type[] GetNotificationHandlerTypes(Type notificationType)
    {
        return _notificationHandlerCache.GetOrAdd(notificationType, _ =>
        {
            var handlerType = typeof(INotificationHandler<>).MakeGenericType(notificationType);
            return [handlerType];
        });
    }
}
