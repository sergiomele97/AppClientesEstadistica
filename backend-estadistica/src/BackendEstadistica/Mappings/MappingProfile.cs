namespace BackendEstadistica.Mappings;

/// <summary>
/// Configuración de AutoMapper para mapear entre entidades y DTOs.
/// </summary>
public class MappingProfile : Profile
{
    /// <summary>
    /// Inicializa el perfil de mapeo.
    /// </summary>
    public MappingProfile()
    {
        // Mapea de ClienteDto a Cliente
        CreateMap<ClienteDto, Cliente>()
            .ForMember(dest => dest.Pais, opt => opt.Ignore())
            .ForMember(dest => dest.TransaccionesOrigen, opt => opt.Ignore())
            .ForMember(dest => dest.TransaccionesDestino, opt => opt.Ignore())
            .ForMember(dest => dest.Conversiones, opt => opt.Ignore());

        // Mapea de Cliente a ClienteDto
        CreateMap<Cliente, ClienteDto>()
            .ForMember(dest => dest.Pais, opt => opt.MapFrom(src => src.Pais))
            .ForMember(dest => dest.TransaccionesOrigen, opt => opt.MapFrom(src => src.TransaccionesOrigen))
            .ForMember(dest => dest.TransaccionesDestino, opt => opt.MapFrom(src => src.TransaccionesDestino))
            .ForMember(dest => dest.Conversiones, opt => opt.MapFrom(src => src.Conversiones));

        // Mapea de TransaccionDto a Transaccion
        CreateMap<TransaccionDto, Transaccion>()
            .ForMember(dest => dest.ClienteOrigen, opt => opt.Ignore())
            .ForMember(dest => dest.ClienteDestino, opt => opt.Ignore());

        // Mapea de Transaccion a TransaccionDto
        CreateMap<Transaccion, TransaccionDto>()
            .ForMember(dest => dest.ClienteOrigen, opt => opt.MapFrom(src => src.ClienteOrigen))
            .ForMember(dest => dest.ClienteDestino, opt => opt.MapFrom(src => src.ClienteDestino));

        // Mapea de ConversionDto a Conversion
        CreateMap<ConversionDto, Conversion>()
            .ForMember(dest => dest.Cliente, opt => opt.Ignore());

        // Mapea de Conversion a ConversionDto
        CreateMap<Conversion, ConversionDto>()
            .ForMember(dest => dest.Cliente, opt => opt.MapFrom(src => src.Cliente));

        // Mapea de PaisDto a Pais
        CreateMap<PaisDto, Pais>();

        // Mapea de Pais a PaisDto
        CreateMap<Pais, PaisDto>();

        // Mapea de DivisaDto a Divisa
        CreateMap<DivisaDto, Divisa>();

        // Mapea de Divisa a DivisaDto
        CreateMap<Divisa, DivisaDto>();
    }
}
