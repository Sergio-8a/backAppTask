# backAppTask
Esta APIREST fue diseñada con entityFramework que crea un base de datos según el modelo que se hagan de las clases,
En el controlador se puede encontrar todo el CRUD para crear una Task, en Swagger están todas la APIS para probarlas y para ejecutarlas manualmente.

# installation
Debe tener la version .NET 8 SDK
Después debe cambiar la url de conexión de la base de datos para la del computador actual
Después en la consola de administración de paquetes Nuget hacer un: dotnet ef database update 
o en su defecto: database update
Después compruebe la conexión ejecutandola la aplicación en el Swagger 