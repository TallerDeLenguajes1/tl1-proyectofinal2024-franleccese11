// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http;
using System.Threading.Tasks;
using espacioPersonaje;
Console.WriteLine("Hello, World!");
HttpClient client = new HttpClient();
var url = "https://rickandmortyapi.com/api/character";
HttpResponseMessage response = await client.GetAsync(url);
response.EnsureSuccessStatusCode(); 
string responseBody = await response.Content.ReadAsStringAsync();
InformacionAPI PersonajesAPI = JsonSerializer.Deserialize<InformacionAPI>(responseBody);
var semilla = Environment.TickCount;
Random random = new Random(semilla);

 for (int i = 0; i < 10; i++)
 {
     Array valores = Enum.GetValues(typeof(Arma));
     int indiceAleatorio = random.Next(valores.Length);
     Arma arma = (Arma)valores.GetValue(indiceAleatorio);
     Console.WriteLine(arma);
 }  



