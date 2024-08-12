namespace BackendEstadistica.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Mapear entidades a DTOs y viceversa
        CreateMap<Cliente, ClienteDto>().ReverseMap();
        CreateMap<Conversion, ConversionDto>().ReverseMap();
        CreateMap<Transaccion, TransaccionDto>().ReverseMap();
        CreateMap<Pais, PaisDto>().ReverseMap();
    }
}
