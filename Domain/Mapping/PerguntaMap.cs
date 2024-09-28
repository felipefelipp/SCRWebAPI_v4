using AutoMapper;
using Domain.AggregatesModel.Classificacao;
using SCRWebAPI_v4.Domain.Dto;

namespace SCRWebAPI_v4.Domain.Mapping
{
    public class PerguntaMap : Profile
    {
        public PerguntaMap() 
        {
            CreateMap<PerguntaDto, Pergunta>()
                .ForMember(dest => dest.DescricaoPergunta, opt => opt.MapFrom(src => src.TextoPergunta))
                .ForMember(dest => dest.CategoriaPerguntaId, opt => opt.MapFrom(src => src.CategoriaPerguntaId));
        }
    }
}
