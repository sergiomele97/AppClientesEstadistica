# Proyecto ChachiData

# Resumen del Proyecto

Este proyecto ofrece una solución integral combinando análisis estadístico avanzado y clustering con un backend robusto y un frontend interactivo. Utiliza una arquitectura moderna basada en microservicios, integrando tecnologías como Python y .NET, con un frontend desarrollado en Angular. La integración continua y el despliegue automático se gestionan a través de GitHub Actions, y todo el sistema está desplegado en Azure. La metodología ágil Scrum, gestionada con Azure DevOps, permite una entrega continua de valor y una rápida adaptación a los cambios.

Desarrollado en Angular, el frontend proporciona una experiencia de usuario dinámica e intuitiva.

## Contribuciones del Equipo

- **Iranzu Arbizu:** Product Owner. Encargada del diseño de funcionalidades de la aplicación, así como del desarrollo del servicio de predicción y clustering (Python con Flask). También se ocupó de la integración del servicio con el frontend y la implementación de pruebas en el backend.
- **Roberto López:** Desarrollador principal del frontend en Angular, encargado de la integración de SignalR para la comunicación en tiempo real. Desarrolló el módulo de Outliers y la visualización de datos, así como la generación de datos de prueba con Bogus para el backend y frontend.
- **Carlos Ibáñez:** Implementador de funcionalidades clave en el backend y frontend. En el frontend, diseñó el menú, gráficas y tablas, además de trabajar en el debug y optimización del sistema para asegurar la integración fluida entre los componentes.
- **Sergio Melero:** Scrum Master. Responsable de la gestión del despliegue y la integración continua, incluyendo la configuración de servicios en Azure y la implementación de workflows en GitHub Actions. También trabajó en la implementación inicial de login, registro y el área estadística, y en la generación continua de datos.

## Metodología de Trabajo

Se sigue la metodología ágil Scrum, gestionada con Azure DevOps para la planificación y ejecución de sprints, así como la gestión del backlog. Esta metodología fomenta la colaboración del equipo, mejora la eficiencia y asegura una entrega constante de valor al cliente.

## Implementación y Despliegue

El frontend se despliega como una aplicación estática en Azure Static Web Apps, garantizando un acceso rápido y escalable desde cualquier parte del mundo.

## Componentes del Proyecto

### Servicio de Predicción y Clustering (Python con Flask)

- **Funcionalidades:**
    - **Predicción de Series Temporales:** Utiliza modelos ARIMA para realizar predicciones basadas en datos históricos, con resultados y sus intervalos de confianza.
    - **Clustering de Datos:** Implementa el algoritmo K-means para segmentar datos en clusters, y evalúa la calidad de los clusters mediante el índice de Davies-Bouldin.

### Backend Estadístico (C# con .NET)

- **Gestión de Usuarios y Seguridad:**
    - Utiliza Identity Core para la autenticación y gestión de usuarios, con soporte para JWT y permisos, permitiendo un manejo seguro y escalable de la autenticación.
    - Integración con Entity Framework Core y SQL Server para una gestión segura de los usuarios y sus datos.
    - Implementación del registro y autenticación de usuarios a través del `UsuariosController`, incluyendo la validación de contraseñas y generación de tokens JWT.
- **Comunicación en Tiempo Real:**
    - SignalR se emplea para enviar notificaciones y actualizaciones instantáneas, sincronizando el frontend con los eventos del backend.
- **Servicios de Log y Monitoreo:**
    - Serilog se utiliza para registrar eventos y errores, facilitando la trazabilidad y el monitoreo de la aplicación. Los logs se generan en consola y en archivos.
- **Migraciones Automáticas:**
    - Configuración de migraciones automáticas para mantener el esquema de la base de datos actualizado con los últimos cambios al iniciar la aplicación.
- **Políticas de Seguridad y CORS:**
    - Configuración de políticas de CORS para asegurar interacciones seguras entre el frontend y backend desde diferentes entornos.
- **Documentación de API:**
    - Swagger se integra para documentar automáticamente la API, facilitando la exploración y prueba de los endpoints.

### Automatización y Despliegue (CI/CD con GitHub Actions y Azure)

- **Workflows de GitHub Actions:**
    - **Build y Deploy del Frontend:** Configurado para construir y desplegar automáticamente el frontend en Azure Static Web Apps cuando se detectan cambios en la rama de producción.
    - **Build y Deploy de Backends:** Workflows independientes para los servicios backend en Python y .NET, asegurando un despliegue correcto en Azure App Services.

### Estructura del Routing y Comunicación

La estructura de routing del frontend organiza la navegación en módulos específicos para una experiencia de usuario coherente:

- **Protección de Rutas:**
    - Utiliza AuthGuard para proteger rutas y asegurar que solo usuarios autenticados accedan a las secciones críticas del sistema.
- **Comunicación en Tiempo Real:**
    - Implementa SignalR para la comunicación en tiempo real, actualizando el frontend con datos del backend para mejorar la interactividad.

### Frontend Interactivo

- **Login y Registro:**
    - Al iniciar la aplicación, los usuarios son redirigidos a la página de login. Aquellos que no cuentan con una cuenta pueden optar por registrarse.
    - La página del registro solicita unos campos para crear la cuenta así como aceptar los términos y condiciones de la app. Una vez hecho el registro redirige al login.
        
        ![registro.PNG.png](https://prod-files-secure.s3.us-west-2.amazonaws.com/14508b69-9364-45cc-a340-7ad8815068c0/07b61e0f-d2d2-4d15-8924-b7964361522d/registro.PNG.png)
        
    - Ya con los datos disponibles podemos iniciar sesión. La página de login ofrece una opción para mantener la sesión iniciada, facilitando el acceso continuo a la aplicación.
        
        ![login.PNG](https://prod-files-secure.s3.us-west-2.amazonaws.com/14508b69-9364-45cc-a340-7ad8815068c0/2c38fea4-65b5-4d53-95ea-e5756f3539af/360f3a06-0a0f-43db-a1ab-014d1560f42e.png)
        
        ![Aviso cuando no inicias sesión correctamente](https://prod-files-secure.s3.us-west-2.amazonaws.com/14508b69-9364-45cc-a340-7ad8815068c0/5b867da3-152f-4534-bff4-68c0c261c4f5/aviso.png)
        
        Aviso cuando no inicias sesión correctamente
        
- **Página de Inicio**
    - Después del login, los usuarios acceden a una página de bienvenida que proporciona una visión general de las funcionalidades disponibles en la aplicación.
        
        ![bienvenidaMenu.png](https://prod-files-secure.s3.us-west-2.amazonaws.com/14508b69-9364-45cc-a340-7ad8815068c0/0a7c6cc9-02bf-4a8e-901f-8133a994e07f/bienvenidaMenu.png)
        
- **Gráficos:**
    
    En la pantalla de gráficas podemos acceder a la visualización de los datos clickando en la celda vacía. Podemos elegir cuatro tipos de gráficos: 
    
    - **Gráfico de Datos de Clientes:** Muestra la distribución de clientes por parámetros como sexo, edad y profesión.
    - **Gráfico de Volumetría:** Representa el volumen de transacciones y conversiones mensuales, permitiendo la evaluación de tendencias a lo largo del tiempo.
    - **Mapa de Distribución Global de Clientes:** Ilustra la distribución geográfica de los clientes según su país de origen, proporcionando una visión global de la base de usuarios.
    - **Gráfico de Transacciones por Cliente:** Detalla las transacciones realizadas por cada cliente, incluyendo un promedio, para analizar patrones de comportamiento.
    
    Todas ellas se pueden borrar dando clic en la cruz roja.
    
    ![graficas.png](https://prod-files-secure.s3.us-west-2.amazonaws.com/14508b69-9364-45cc-a340-7ad8815068c0/962a3e76-cd21-4f44-89b9-e50374c20ded/447a93fe-4d18-4e55-ac35-fd5f2c5322c3.png)
    
- **Transacciones:**
    - Muestra una tabla con todas las transacciones realizadas. Los usuarios pueden filtrar por fecha o cliente y acceder a la información detallada del cliente relacionado con cada transacción.
        
        ![transacciones.PNG](https://prod-files-secure.s3.us-west-2.amazonaws.com/14508b69-9364-45cc-a340-7ad8815068c0/10338e90-7821-4b08-b288-db43fd59b90f/transacciones.png)
        

- **Clientes:**
    - Proporciona información detallada de cada cliente, incluyendo su balance. Además, un gráfico muestra los ingresos y gastos del cliente.
        
        ![clientes.PNG](https://prod-files-secure.s3.us-west-2.amazonaws.com/14508b69-9364-45cc-a340-7ad8815068c0/83e1dd51-4e53-4daa-85dc-ec6384e94b96/clientes.png)
        

- **Divisas:**
    - Presenta la evolución del valor (respecto al dólar) de cada divisa a lo largo del tiempo y ofrece predicciones futuras para cada una con su intervalo de confianza (95%). Las predicciones se han hecho a partir de un ARIMA con cinco retrocesos para captar el patrón de comportamiento.
        
        ![divisas.PNG](https://prod-files-secure.s3.us-west-2.amazonaws.com/14508b69-9364-45cc-a340-7ad8815068c0/f7b3cc70-52d4-4849-a961-ea3e4ec104c5/divisas.png)
        
- **Clusters:**
    - Permite visualizar la agrupación de clientes utilizando el algoritmo K-means, con la opción de seleccionar el valor de K entre 1 y 5 a través de un menú desplegable. Para evaluar la calidad de los clusters, se incorpora el índice de Davies-Bouldin, que mide el equilibrio entre la separación y la compacidad de los mismos.
        
        ![clusterBien.PNG](https://prod-files-secure.s3.us-west-2.amazonaws.com/14508b69-9364-45cc-a340-7ad8815068c0/ac9d7340-72c8-4e85-beb8-9ad87bdf1d13/clusterBien.png)
        
    - En la tabla se presenta información adicional, donde además de los datos de los clientes, se muestra la etiqueta del cluster al que pertenecen. Esto facilita el análisis segmentado por grupos.

- **Outliers:**
    - Se incluye un menú desplegable en el sidebar que muestra alertas y logs, en el cual se indica y contabiliza el número de alertas disponibles para asegurar su visualización en todo momento.
        
        ![Dropdown](https://prod-files-secure.s3.us-west-2.amazonaws.com/14508b69-9364-45cc-a340-7ad8815068c0/51124afb-8192-49e9-8777-8bfb27161adf/Screenshot_2024-09-04_at_10-44-20_ClientesEstadisticaApp.png)
        
        Dropdown
        
    - En la sección de alertas, se presenta un listado de todos los outliers detectados sin resolver, ofreciendo opciones para visualizar los detalles de cada caso y proceder a su validación.
        
        ![Avisos de outliers](https://prod-files-secure.s3.us-west-2.amazonaws.com/14508b69-9364-45cc-a340-7ad8815068c0/5871f65c-7463-471b-a3e0-da3dbfacfdc2/a93524f1-3cc8-41c8-a273-fb531124c2f6.png)
        
        Avisos de outliers
        
    - Al entrar en detalle, es posible verificar los datos de la transacción para confirmar si se trata de un comportamiento inusual. En caso de ser necesario, se dispone de la opción de resolver la incidencia correspondiente.
        
        ![outlierDetalles.PNG](https://prod-files-secure.s3.us-west-2.amazonaws.com/14508b69-9364-45cc-a340-7ad8815068c0/603877b2-6324-47ce-a998-ce5b4e11ef21/outlierDetalles.png)
        
    - Los outliers resueltos se registran en logs para su revisión posterior y poder mantener un seguimiento de estos.
        
        ![Incidencias ya resueltas](https://prod-files-secure.s3.us-west-2.amazonaws.com/14508b69-9364-45cc-a340-7ad8815068c0/f4ee40cc-c580-48ed-b9f0-69fe51d746ce/logsOutliers.png)
        
        Incidencias ya resueltas
        
- Sesión
    
    Al finalizar el uso de la aplicación, la sesión permanecerá activa si así se seleccionó. Alternativamente, se puede cerrar la sesión desde el perfil del usuario.
    
    ![cerrarSesion.PNG](https://prod-files-secure.s3.us-west-2.amazonaws.com/14508b69-9364-45cc-a340-7ad8815068c0/12c4e2a1-66ab-4d46-a9bb-e36e080f93ba/cerrarSesion.png)
    

## Video del proyecto en funcionamiento

[ChachiData Canción Regguetton ‐ Hecho con Clipchamp (1).mp4](https://prod-files-secure.s3.us-west-2.amazonaws.com/14508b69-9364-45cc-a340-7ad8815068c0/5e02d710-2563-481c-896f-fce3653b1643/ChachiData_Cancin_Regguetton__Hecho_con_Clipchamp_(1).mp4)
