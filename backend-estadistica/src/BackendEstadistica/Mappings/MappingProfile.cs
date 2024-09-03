namespace BackendEstadistica.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {

        CreateMap<ClienteDto, Cliente>()
            .ForMember(dest => dest.Pais, opt => opt.Ignore()) // Ignora la propiedad Pais en el DTO para evitar problemas de referencia
            .ForMember(dest => dest.TransaccionesOrigen, opt => opt.Ignore())
            .ForMember(dest => dest.TransaccionesDestino, opt => opt.Ignore())
            .ForMember(dest => dest.Conversiones, opt => opt.Ignore());

        CreateMap<Cliente, ClienteDto>()
            .ForMember(dest => dest.Pais, opt => opt.MapFrom(src => src.Pais))
            .ForMember(dest => dest.TransaccionesOrigen, opt => opt.MapFrom(src => src.TransaccionesOrigen))
            .ForMember(dest => dest.TransaccionesDestino, opt => opt.MapFrom(src => src.TransaccionesDestino))
            .ForMember(dest => dest.Conversiones, opt => opt.MapFrom(src => src.Conversiones));

        CreateMap<TransaccionDto, Transaccion>()
            .ForMember(dest => dest.ClienteOrigen, opt => opt.Ignore())
            .ForMember(dest => dest.ClienteDestino, opt => opt.Ignore());

        CreateMap<Transaccion, TransaccionDto>()
            .ForMember(dest => dest.ClienteOrigen, opt => opt.MapFrom(src => src.ClienteOrigen))
            .ForMember(dest => dest.ClienteDestino, opt => opt.MapFrom(src => src.ClienteDestino));

        CreateMap<ConversionDto, Conversion>()
            .ForMember(dest => dest.Cliente, opt => opt.Ignore());
        CreateMap<Conversion, ConversionDto>()
            .ForMember(dest => dest.Cliente, opt => opt.MapFrom(src => src.Cliente));


        CreateMap<PaisDto, Pais>();
        CreateMap<Pais, PaisDto>();

        CreateMap<DivisaDto, Divisa>();
        CreateMap<Divisa, DivisaDto>();



    }
}