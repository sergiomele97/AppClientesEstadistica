namespace BackendEstadistica.Perfiles
{
    public class Divisa : Profile
    {
        public Divisa()
        {
            CreateMap<Divisa, DivisaDto>().ReverseMap();
        }
    }
}
