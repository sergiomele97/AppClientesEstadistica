namespace ApiBasesDeDatosProyecto.Tests;

public class PaisesTest
{
    private readonly Contexto _contexto;
    private readonly PaisRepository _paisRepository;

    public PaisesTest(Contexto contexto, PaisRepository paisRepository)
    {
        _contexto = contexto;
        _paisRepository = paisRepository;
    }

    public async Task GetPaisesFake()
    {
        var paisesRepositorio = new PaisRepository(_contexto);
        var pais = new PaisFaker().Generate();
        _contexto.Paises.Add(pais);
        _contexto.SaveChanges();

        var paisRecuperado = await paisesRepositorio.ObtenerPorId(pais.Id);

        paisRecuperado.Should().BeEquivalentTo(pais, 
            option => option.ComparingByMembers<Pais>());
    }
}
