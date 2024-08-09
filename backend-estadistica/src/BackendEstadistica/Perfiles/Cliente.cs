namespace BackendEstadistica.Perfiles
{
    public class Cliente : Profile
    {

        public Cliente() 
        {
        
            CreateMap<Cliente, ClienteDto>().ReverseMap();   

        }

    }
}
