using AutoMapper;
using Domain.AggregatesModel.Classificacao;
using SCRWebAPI_v4.Domain.Dto;

namespace SCRWebAPI_v4.Domain.Mapping
{
    public class RespostaSelecionadaMap : Profile
    {
        public RespostaSelecionadaMap()
        {
            CreateMap<RespostaSelecionadaDto, RespostaSelecionada>();
        }
    }
}
