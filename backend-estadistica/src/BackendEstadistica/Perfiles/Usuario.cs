using AutoMapper;

namespace ApiBasesDeDatosProyecto.Perfiles
{
    /* Los perfiles en AutoMapper definen las configuraciones para mapear entre diferentes 
     * tipos de objetos, facilitando la conversión automática de datos entre ellos. 
     * En el código, la clase usuarioperfil hereda de Profile y configura un mapeo bidireccional
     * entre Usuario y UsuarioDto. El método CreateMap<Usuario, UsuarioDto>().ReverseMap() indica 
     * que Usuario se puede mapear a UsuarioDto y viceversa.
     */

    public class usuarioperfil : Profile
    {

        public usuarioperfil()
        {
            CreateMap<Usuario, UsuarioDto>().ReverseMap();
        }
    }
}