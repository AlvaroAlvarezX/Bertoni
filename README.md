
Examen Bertoni Solutions

# Estructura 
La aplicación contiene dos componentes Web (todalmente desacoplados entre si ) y una librería de clases donde se encuentran los modelos comunes para cada aplicación.  .

Los componentes web (Bertoni.Api) y (Bertoni.Web) son aplicaciones ASP.NET Core 3.2

#  Consideraciones especiales en Bertoni.Api:
Se configuró CORS para poder atender las peticiones desde otros dominios .
Se usó el patrón CQRS para manejar las peticiones entre el API y las funcionalidades CORE, descrito acá por Martin Fowler : https://martinfowler.com/bliki/CQRS.html
Por restricciones de tiempo se colocaron los Query y los Commands dentro del API, pero en un mejor escenario las hubiera colocado en una libreria a parte  para aumentar el desacoplamiento de la aplicación. ( El API es solo una de las interfaces posibles para un CORE ). 

#  Consideraciones especiales en Bertoni.Web:
Se configuró Dependency Injection para establecer el origen de datos de las Fotos, Albumes y Comentarios.  Esto permite cambiar el origen de datos  con tan solo cambiar la implementación de la interfaz . Esta interfaz es inyectada cada vez que llamamos al controlador AlbumController. 


# Otras consideraciones de arquitectura. 
En una aplicación un poco más ajustada al mundo real (y con un poquito más de tiempo) , las funcionalidades de la app (CQ/CR) hubieran sido colocadas en una libreria CORE aparte.
Si usara entity framework tendría una libreria llamada Infraestructure, que implemente la interfaz del contexto de datos de entity framework, y aplica las configuraciones del DBContext, de tal forma que la aplicación pueda intercambiar distintos orígenes de datos, y no estar estrictamente acoplado a SQL Server. Podríamos usar POSTGre, MySQL, MariaDB, etc sin tener que reescribir código. 

# Descripción

Descargue el código, compilelo y ejecútelo. 

Enjoy!
