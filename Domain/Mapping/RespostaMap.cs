using AutoMapper;
using Domain.AggregatesModel.Classificacao;
using SCRWebAPI_v4.Domain.Dto;

namespace SCRWebAPI_v4.Domain.Mapping
{
    public class RespostaMap : Profile
    {
        public RespostaMap()
        {
            CreateMap<RespostaDto, Resposta>()
                .ReverseMap();
        }
    }
}
