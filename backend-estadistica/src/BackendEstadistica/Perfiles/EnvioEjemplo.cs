namespace BackendEstadistica.Perfiles;

public class EnvioEjemplo : Profile
{
    public EnvioEjemplo()
    {

        CreateMap<EnvioEjemplo, EnvioEjemploDto>().ReverseMap();

    }

}
