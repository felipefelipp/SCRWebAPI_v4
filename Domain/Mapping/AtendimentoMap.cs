using AutoMapper;
using Domain.AggregatesModel.Atendimento;
using SCRWebAPI_v4.Domain.Dto;

namespace SCRWebAPI_v4.Domain.Mapping
{
    public class AtendimentoMap : Profile
    {
        public AtendimentoMap()
        {
            CreateMap<AtendimentoDto, AtendimentoPaciente>()
                .ForMember(dest => dest.PacienteId, opt => opt.MapFrom(scr => scr.PacienteId));
        }
    }
}
