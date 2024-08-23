
using BackendEstadistica.Entidades;

namespace Estadistica.Test
{
    public class ElModeloDeEstadisticaDeberia
    {
      
        [Fact]
        public void EsCorreoValido_CuandoCorreoEsCorrecto_DebeRetornarVerdadero()
        {
            // Arrange
            var usuario = new Usuario { Correo = "usuario@ejemplo.com" };

            // Act
            var resultado = usuario.EsCorreoValido();

            // Assert
            Assert.True(resultado);
        }

        [Fact]
        public void EsCorreoValido_CuandoCorreoEsIncorrecto_DebeRetornarFalso()
        {
            // Arrange
            var usuario = new Usuario { Correo = "usuario.ejemplo.com" };

            // Act
            var resultado = usuario.EsCorreoValido();

            // Assert
            Assert.False(resultado); 
        }


        [Theory]
        [InlineData("12345")]
        [InlineData("789012234")]
        [InlineData("34578")]
        [InlineData("987654234")]
        public void EsContraseñaValida_DatosVariados_RetornaResultadoEsperado(string contraseña)
        {
            // Arrange
            var usuario = new Usuario { Contraseña = contraseña };

            // Act
            var resultado = usuario.EsContraseñaValida();

            // Assert
            bool esperado = contraseña.Length >= 6;

            Assert.Equal(esperado, resultado);
        }


        [Fact]

        public void EsContraseñaValida_CuandoContraseñaTieneMasDe6Caracteres_DebeRetornarVerdadero()
        {
            // Arrange
            var usuario = new Usuario { Contraseña = "1234567" };

            // Act
            var resultado = usuario.EsContraseñaValida();

            // Assert
            Assert.True(resultado);
        }

        [Fact]
        public void EsContraseñaValida_CuandoContraseñaTieneMenosDe6Caracteres_DebeRetornarFalso()
        {
            // Arrange
            var usuario = new Usuario { Contraseña = "123" };

            // Act
            var resultado = usuario.EsContraseñaValida();

            // Assert
            Assert.False(resultado);
        }
    }

    

}