namespace ApiBasesDeDatosProyecto.Tests;

public class UsuariosTest
{
    private readonly Contexto _contexto;
    private readonly UsuarioRepository _usuariosRepository;

    public UsuariosTest(Contexto contexto, UsuarioRepository usuariosRepository)
    {
        _contexto = contexto;
        _usuariosRepository = usuariosRepository;
    }

    public async Task GetUsuariosFake()
    {
        var usuariosRepositorio = new UsuarioRepository(_contexto);
        var usuario = new UserFaker().Generate();
        _contexto.Usuarios.Add(usuario);
        _contexto.SaveChanges();

        var usuarioRecuperado = await usuariosRepositorio.ObtenerPorId(usuario.Id);

        usuarioRecuperado.Should().BeEquivalentTo(usuario, 
            options => options.ComparingByMembers<Usuario>());
    }
}
