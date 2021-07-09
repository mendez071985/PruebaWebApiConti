# Instrucciones

## Creación de la base de datos

1. Se descargó de Nugget el paquete de sqllite
2. Realizamos los atributos con su clave primaria.
3. Hicimos un metodo DbContext
4. Llamamos en el Startup a la conexión a la base de datos.
5. Ejecutamos en la consola de administrador de paquetes
6. Ejecutamos la sentencia Add-Migration nombre de la base (se crea una carpeta de migración)
7. Luego se ejecuto la sentencia Update-Database

Luego de realizar esto se crearon todas las tablas y claves, también la base de datos.
Este proceso solo debe realizarse una vez.

Cabe mencionar que si quieren hacer nuevamente todo el proceso, deben usar la sentencia remove-Migration, quitar la base de datos y volver a hacer los pasos mencionados más arriba.

## Ejecutar el proyecto

Luego de crear la base de datos, basta con ejecutar el proyecto para poder probarlo.
