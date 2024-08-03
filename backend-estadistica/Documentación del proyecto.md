# Backend Estadística

## Descripción
Este proyecto es una aplicación backend para gestionar estadísticas. Está organizada en varios directorios y archivos para mantener el código limpio y estructurado.

## Estructura del Proyecto

- **Contexto/**: Define el contexto de la base de datos y su configuración.
- **Controllers/**: Contiene los controladores que gestionan las solicitudes HTTP.
- **Entidades/**: Define las entidades de la base de datos.
- **Migrations/**: Contiene las migraciones de la base de datos.
- **Models/**: Define los modelos de datos utilizados en la aplicación (fuera de la BBDD).
- **Perfiles/**: Configura los perfiles de mapeo de objetos (convertir usuario a usuarioDto y viceversa).
- **Properties/**: Archivos de configuración de la aplicación.
- **Servicios/**: Define los servicios que contienen la lógica del negocio.
- **Utilidades/**: Herramientas y utilidades auxiliares.

## Archivos Sueltos

- **BackendEstadistica.csproj**: Archivo de proyecto de .NET que define las configuraciones del proyecto.
- **BackendEstadistica.http**: Archivo que contiene ejemplos de solicitudes HTTP para probar las APIs.
- **GlobalUsings.cs**: Define los "usings" globales para el proyecto.
- **Program.cs**: Archivo principal que configura y ejecuta la aplicación.
- **appsettings.Development.json**: Configuraciones específicas para el entorno de desarrollo.
- **appsettings.json**: Configuraciones generales de la aplicación.

## Instalación
1. Clona el repositorio.
2. Configura las dependencias locales necesarias siguiendo la guia "requerimientos.txt".
3. Compila la aplicación.

## Contribuciones
Las contribuciones son bienvenidas. Por favor, abre un issue o un pull request para sugerencias y mejoras.

## Licencia
Este proyecto está licenciado bajo la [MIT License](LICENSE).
