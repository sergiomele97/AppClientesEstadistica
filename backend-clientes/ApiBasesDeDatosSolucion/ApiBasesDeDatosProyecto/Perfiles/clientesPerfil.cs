namespace ApiBasesDeDatosProyecto.Perfiles
{
    public class clientesPerfil : Profile
    {
        public clientesPerfil()
        {
            CreateMap<Cliente, ClienteDto>().ReverseMap();
        }
    }
}
