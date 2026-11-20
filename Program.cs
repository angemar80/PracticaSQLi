using Microsoft.Data.Sqlite;

using var conn = new SqliteConnection("Data Source=clientes.db");
conn.Open();

// Crear tabla y datos de práctica
var setup = conn.CreateCommand();
setup.CommandText = @"
DROP TABLE IF EXISTS clientes;
CREATE TABLE clientes (id_cliente INTEGER PRIMARY KEY, nombre TEXT, ciudad TEXT);
INSERT INTO clientes VALUES (1,'Ana Ríos','Cali'),(2,'Luis Mora','Cali'),(3,'Marta Gil','Palmira');";
setup.ExecuteNonQuery();

// Esto es lo que un atacante escribiría en un campo de texto
string entrada = "x' OR '1'='1";
string entradaCiudad = "Cali' OR '1'='1";


// 1) INSEGURA: concatena el texto dentro del SQL
Console.WriteLine("=== INSEGURA (concatenando) ===");
var inseguro = conn.CreateCommand();
inseguro.CommandText =
    "SELECT id_cliente, nombre, ciudad FROM clientes WHERE nombre = '" + entrada + "'";
using (var r = inseguro.ExecuteReader())
{
    while (r.Read())
        Console.WriteLine($"{r.GetInt32(0)} | {r.GetString(1)} | {r.GetString(2)}");
}

// 2) SEGURA: el texto viaja como parámetro, nunca como SQL
Console.WriteLine("=== SEGURA (parametrizada) ===");
var seguro = conn.CreateCommand();
seguro.CommandText =
    "SELECT id_cliente, nombre, ciudad FROM clientes WHERE nombre = @nombre";
seguro.Parameters.AddWithValue("@nombre", entrada);
using (var r = seguro.ExecuteReader())
{
    while (r.Read())
        Console.WriteLine($"{r.GetInt32(0)} | {r.GetString(1)} | {r.GetString(2)}");
}





var ciudad = conn.CreateCommand();
ciudad.CommandText =
    "SELECT id_cliente, nombre, ciudad FROM clientes WHERE ciudad = @ciudad";
ciudad.Parameters.AddWithValue("@ciudad",entradaCiudad );
using (var r = ciudad.ExecuteReader())
{
    while (r.Read())
        Console.WriteLine($"{r.GetInt32(0)} | {r.GetString(1)} | {r.GetString(2)}");
}
Console.WriteLine("(fin)");


