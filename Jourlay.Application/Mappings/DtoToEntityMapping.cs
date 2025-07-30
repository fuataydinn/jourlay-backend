using AutoMapper;
using Jourlay.Domain.Entities;

namespace Jourlay.Application.Mappings;

public class DtoToEntityMapping : Profile
{
    public DtoToEntityMapping()
    {
        //CreateMap<CreateContactUsDto, ContactUsEntity>()
        //      .ForMember(dest => dest.Id, opt => opt.Ignore())
        //      .ForMember(dest => dest.Offices, opt => opt.Ignore())
        //      .ForMember(dest => dest.CreationTime, opt => opt.Ignore())
        //      .ForMember(dest => dest.LastModifyTime, opt => opt.Ignore())
        //      .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
        //      .ForMember(dest => dest.IsDeleted, opt => opt.Ignore());

        //CreateMap<UpdateContactUsDto, ContactUsEntity>()
        //      .ForMember(dest => dest.Offices, opt => opt.Ignore())
        //      .ForMember(dest => dest.CreationTime, opt => opt.Ignore())
        //      .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
        //      .ForMember(dest => dest.LastModifyTime, opt => opt.Ignore())
        //      .ForMember(dest => dest.IsDeleted, opt => opt.Ignore());

        //CreateMap<CreateOfficeInfoDto, OfficeInfo>()
        //        .ForMember(dest => dest.Id, opt => opt.Ignore())
        //        .ForMember(dest => dest.ContactUs, opt => opt.Ignore())
        //        .ForMember(dest => dest.CreationTime, opt => opt.Ignore())
        //        .ForMember(dest => dest.LastModifyTime, opt => opt.Ignore())
        //        .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
        //        .ForMember(dest => dest.IsDeleted, opt => opt.Ignore());

        //CreateMap<UpdateOfficeInfoDto, OfficeInfo>()
        //      .ForMember(dest => dest.ContactUsId, opt => opt.Ignore())
        //      .ForMember(dest => dest.ContactUs, opt => opt.Ignore())
        //      .ForMember(dest => dest.CreationTime, opt => opt.Ignore())
        //      .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
        //      .ForMember(dest => dest.LastModifyTime, opt => opt.Ignore())
        //      .ForMember(dest => dest.IsDeleted, opt => opt.Ignore());
    }
}
