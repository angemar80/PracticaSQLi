

# Práctica: consultas parametrizadas vs. inyección SQL en C#

## Descripción
Proyecto que busca practicar la seguridad de una aplicacion,
se ejecuta con el comando dotnet run
buscando evidenciar la diferencia entre la consulta concatenada y la parametrizada

## Tecnologías
-C#, 
-.NET 10
-SQLite

## Cómo ejecutarlo
validar si se tiene el sdk instalado comando dotnet --version.
si no se tiene instalado:
Instalar el sdk de .net
comando winget install Microsoft.DotNet.SDK.10 
Para ejecutar comando dotnet


## Resultado esperado
version segura muestra las filas que devuelve filtradas
la version insegura muestra todas las filas

## Qué aprendí
Con este mini proyecto practique una practica segura para evitar inyección SQL que  es parametrizar los valores para filtrar en 
las consultas, el valor viaja aparte y no se interpreta como SQL
