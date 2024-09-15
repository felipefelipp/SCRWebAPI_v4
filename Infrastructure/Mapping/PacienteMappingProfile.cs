using AutoMapper;
using Domain.AggregatesModel.Cliente;
using Infrastructure.Models.Cliente;

namespace Application.Mapping
{
    public class PacienteMappingProfile : Profile
    {
        public PacienteMappingProfile()
        {
            CreateMap<PacienteModel, Paciente>()
                .ForMember(dest => dest.PacienteId, opt => opt.MapFrom(src => src.PacienteId))
                .ForMember(dest => dest.Telefone, opt => opt.MapFrom(src => src.Telefone))
                .ForMember(dest => dest.Rua, opt => opt.MapFrom(src => src.Rua))
                .ForMember(dest => dest.Numero, opt => opt.MapFrom(src => src.Numero))
                .ForMember(dest => dest.Bairro, opt => opt.MapFrom(src => src.Bairro))
                .ForMember(dest => dest.Municipio, opt => opt.MapFrom(src => src.Municipio))
                .ForMember(dest => dest.UF, opt => opt.MapFrom(src => src.UF))
                .ForMember(dest => dest.CEP, opt => opt.MapFrom(src => src.CEP))
                .ForMember(dest => dest.Sexo, opt => opt.MapFrom(src => src.Sexo))
                .ForMember(dest => dest.Profissao, opt => opt.MapFrom(src => src.Profissao))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.DataNascimento, opt => opt.MapFrom(src => src.DataNascimento))
                .ForMember(dest => dest.CPF, opt => opt.MapFrom(src => src.CPF))
                .ForMember(dest => dest.RG, opt => opt.MapFrom(src => src.RG))
                .ForMember(dest => dest.Celular, opt => opt.MapFrom(src => src.Celular))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
        }
    }
}
