using AutoMapper;
using Jourlay.Domain.Entities;

namespace Jourlay.Application.Mappings;

public class EntityToDtoMapping : Profile
{
    protected EntityToDtoMapping()
    {
        //CreateMap<ContactUsEntity, ContactUsDto>()
        //       .ForMember(dest => dest.Offices, opt => opt.MapFrom(src => src.Offices));

        //CreateMap<ContactUsEntity, ContactUsListDto>()
        //        .ForMember(dest => dest.OfficeCount, opt => opt.MapFrom(src => src.Offices.Count));

        //CreateMap<OfficeInfoEntity, OfficeInfoDto>();



    }
}
