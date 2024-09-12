using BackendEstadistica.Entidades;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace Estadistica.Test
{
    public class ElModeloClienteDeberia
    {
        // Método auxiliar para validar un modelo.
        private List<ValidationResult> ValidateModel(Cliente cliente)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(cliente);
            Validator.TryValidateObject(cliente, validationContext, validationResults, true);
            return validationResults;
        }

        [Fact]
        public void ValidarClienteConDatosValidos()
        {
            // Arrange
            var cliente = new Cliente
            {
                ClienteId = 1,
                Nombre = "Juan Pérez",
                Correo = "juan.perez@example.com",
                Telefono = "1234567890",
                Edad = 30,
                Sexo = "Masculino",
                Trabajo = "Ingeniero de Software",
                PaisId = 1,
                Pais = new Pais { PaisId = 1, Nombre = "México" }
            };

            // Act
            var resultado = ValidateModel(cliente);

            // Assert
            Assert.Empty(resultado); // No debe haber errores de validación.
        }

        [Fact]
        public void ValidarClienteConNombreMuyLargo()
        {
            // Arrange
            var cliente = new Cliente
            {
                Nombre = new string('A', 101) // Nombre con más de 100 caracteres.
            };

            // Act
            var resultado = ValidateModel(cliente);

            // Assert
            Assert.Contains(resultado, v => v.ErrorMessage.Contains("El nombre no puede superar los 100 caracteres."));
        }

        [Fact]
        public void ValidarClienteConCorreoInvalido()
        {
            // Arrange
            var cliente = new Cliente
            {
                Correo = "correo-invalido" // Correo con formato inválido.
            };

            // Act
            var resultado = ValidateModel(cliente);

            // Assert
            Assert.Contains(resultado, v => v.ErrorMessage.Contains("El correo no tiene un formato válido."));
        }

        [Fact]
        public void ValidarClienteConTelefonoInvalido()
        {
            // Arrange
            var cliente = new Cliente
            {
                Telefono = "telefono-invalido" // Teléfono con formato inválido.
            };

            // Act
            var resultado = ValidateModel(cliente);

            // Assert
            Assert.Contains(resultado, v => v.ErrorMessage.Contains("El teléfono no tiene un formato válido."));
        }

        [Fact]
        public void ValidarClienteConEdadFueraDeRango()
        {
            // Arrange
            var cliente = new Cliente
            {
                Edad = 150 // Edad fuera del rango permitido.
            };

            // Act
            var resultado = ValidateModel(cliente);

            // Assert
            Assert.Contains(resultado, v => v.ErrorMessage.Contains("La edad debe estar entre 0 y 120."));
        }

        [Fact]
        public void ValidarClienteConSexoMuyLargo()
        {
            // Arrange
            var cliente = new Cliente
            {
                Sexo = new string('M', 11) // Sexo con más de 10 caracteres.
            };

            // Act
            var resultado = ValidateModel(cliente);

            // Assert
            Assert.Contains(resultado, v => v.ErrorMessage.Contains("El sexo no puede superar los 10 caracteres."));
        }

        [Fact]
        public void ValidarClienteConTrabajoMuyLargo()
        {
            // Arrange
            var cliente = new Cliente
            {
                Trabajo = new string('T', 101) // Trabajo con más de 100 caracteres.
            };

            // Act
            var resultado = ValidateModel(cliente);

            // Assert
            Assert.Contains(resultado, v => v.ErrorMessage.Contains("El trabajo no puede superar los 100 caracteres."));
        }
    }
}
