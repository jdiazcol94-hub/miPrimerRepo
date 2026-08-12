using System.IO;
using Newtonsoft.Json.Linq;

const string settingsFile = "appsettings.json";

if (!File.Exists(settingsFile))
{
    Console.WriteLine($"No se encontró el archivo de configuración: {settingsFile}");
    return;
}

var json = File.ReadAllText(settingsFile);
var settings = JObject.Parse(json);
var connectionString = settings["ConnectionStrings"]?["DefaultConnection"]?.ToString();

if (string.IsNullOrWhiteSpace(connectionString))
{
    Console.WriteLine("No se encontró la cadena de conexión DefaultConnection en appsettings.json.");
    return;
}

Console.WriteLine("Simulación de cadena de conexión leída desde appsettings.json:");
Console.WriteLine(connectionString);
