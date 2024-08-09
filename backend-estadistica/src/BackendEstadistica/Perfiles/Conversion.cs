namespace BackendEstadistica.Perfiles
{
    public class Conversion : Profile
    {

        public Conversion() 
        { 
        
            CreateMap<Conversion, ConversionDto>().ReverseMap();

        }

    }
}
