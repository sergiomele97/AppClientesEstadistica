using AutoMapper;

namespace ApiBasesDeDatosProyecto.Perfiles
{
    public class usuarioperfil : Profile
    {

        public usuarioperfil()
        {
            CreateMap<Usuario, UsuarioDto>().ReverseMap();
        }
    }
}