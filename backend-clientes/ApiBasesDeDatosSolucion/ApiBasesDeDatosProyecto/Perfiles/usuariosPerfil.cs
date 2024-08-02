namespace ApiBasesDeDatosProyecto.Perfiles
{
    public class usuariosPerfil : Profile
    {

        public usuariosPerfil()
        {
            CreateMap<Usuario, UsuarioDto>().ReverseMap();
        }
    }
}
