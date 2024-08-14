namespace BackendEstadistica.Perfiles
{
    public class Transaccion : Profile
    {

        public Transaccion() 
        {

            CreateMap<Transaccion, TransaccionDto>().ReverseMap();  

        }

    }
}
