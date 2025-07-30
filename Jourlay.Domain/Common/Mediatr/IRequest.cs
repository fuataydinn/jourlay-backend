namespace Jourlay.Domain.Common.Mediatr;

public interface IRequest<out TResponse>
{
}
public interface IRequest : IRequest<Unit>
{
}