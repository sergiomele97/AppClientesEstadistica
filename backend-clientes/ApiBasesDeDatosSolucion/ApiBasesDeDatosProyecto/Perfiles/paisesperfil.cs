
namespace ApiBasesDeDatosProyecto.Perfiles
{
    public class paisesPerfil : Profile
    {

        public paisesPerfil()
        {
            CreateMap<Pais, PaisDto>().ReverseMap();
        }
    }
}
