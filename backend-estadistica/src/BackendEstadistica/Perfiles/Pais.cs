namespace BackendEstadistica.Perfiles
{
    public class Pais : Profile
    {


        public Pais() 
        { 
        
            CreateMap<Pais, PaisDto>().ReverseMap();

        }

    }
}
