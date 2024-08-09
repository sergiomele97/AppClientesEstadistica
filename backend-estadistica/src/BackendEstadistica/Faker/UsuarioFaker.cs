using Bogus;

namespace BackendEstadistica.Faker;


public class UsuarioFaker : Faker<Usuario>
{

    public UsuarioFaker() 
    {

        RuleFor(u => u.Rol, f => f.PickRandom(new[] { "Admin", "Usuario", "Invitado" }));
        RuleFor(u => u.Correo, f => f.Internet.Email());
        RuleFor(u => u.Contraseña, f => f.Internet.Password());

    }
}
