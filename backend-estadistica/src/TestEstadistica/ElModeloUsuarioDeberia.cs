using BackendEstadistica.Entidades;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace Estadistica.Test
{
    public class ElModeloUsuarioDeberia
    {
        // Método auxiliar para validar un modelo.
        private List<ValidationResult> ValidateModel(Usuario usuario)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(usuario);
            Validator.TryValidateObject(usuario, validationContext, validationResults, true);
            return validationResults;
        }

        [Fact]
        public void ValidarUsuarioConDatosValidos()
        {
            // Arrange
            var usuario = new Usuario
            {
                Correo = "test@example.com",
                Contraseña = "password123*A",
                Telefono = "1234567890"
            };

            // Act
            var resultado = ValidateModel(usuario);

            // Assert
            Assert.Empty(resultado); // No debe haber errores de validación.
        }

        [Fact]
        public void ValidarUsuarioConCorreoInvalido()
        {
            // Arrange
            var usuario = new Usuario
            {
                Correo = "correo-invalido",
                Contraseña = "password123",
                Telefono = "1234567890"
            };

            // Act
            var resultado = ValidateModel(usuario);

            // Assert
            Assert.Contains(resultado, v => v.ErrorMessage.Contains("El correo no tiene un formato válido."));
        }

        [Fact]
        public void ValidarUsuarioConContraseñaCorta()
        {
            // Arrange
            var usuario = new Usuario
            {
                Correo = "test@example.com",
                Contraseña = "123",
                Telefono = "1234567890"
            };

            // Act
            var resultado = ValidateModel(usuario);

            // Assert
            Assert.Contains(resultado, v => v.ErrorMessage.Contains("La contraseña debe tener al menos 6 caracteres."));
        }

        [Fact]
        public void ValidarUsuarioConTelefonoInvalido()
        {
            // Arrange
            var usuario = new Usuario
            {
                Correo = "test@example.com",
                Contraseña = "password123",
                Telefono = "telefono-invalido"
            };

            // Act
            var resultado = ValidateModel(usuario);

            // Assert
            Assert.Contains(resultado, v => v.ErrorMessage.Contains("El teléfono no tiene un formato válido."));
        }
    }
}
