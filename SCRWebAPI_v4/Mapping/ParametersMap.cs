using Api.Pagination;
using AutoMapper;
using SCRWebAPI_v4.Domain.AggregatesModel.Parameters;

namespace SCRWebAPI_v4.Api.Mapping;

public class ParametersMap : Profile
{
    public ParametersMap()
    {
        CreateMap<Parameters, ParametersQuery>()
               .ForMember(dest => dest.PageNumber, opt => opt.MapFrom(src => src.PageNumber))
               .ForMember(dest => dest.PageSize, opt => opt.MapFrom(src => src.PageSize));
    }
}
