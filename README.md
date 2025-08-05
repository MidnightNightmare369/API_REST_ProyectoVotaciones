# API_REST_ProyectoVotaciones

Pasos para probrar la API

1-Correr el script SQL
2-Cambiar la ubicacion del archivo "secretos.json" indicado en el archivo "DatosGenerales.cs" y cambiar tambien el Strinconexion dentro del archivo "secretos.json"
3-Iniciar la API desde asp_servicios (se recomienda hacerlo desde dotnet run)
4-Abrir postman  
5-Obtener el token de autentificacion enviando el user por medio de un Json (el user se encuentra en el archivo DatosGenerales.cs)
6-Ejecutar los end points teniendo en cuenta enviar el respectivo usuario y el token generado por este

En la carpeta "Ejemplo del uso de la API" se encuentran imagenes de guia desde la interfaz de POSTMAN
