using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http;
using System.Threading.Tasks;
namespace espacioPersonaje
{
    enum Tipo
    {
        shinigami,
		humano,
		quincy,
		arrancar
    }

    public class PersonajesJSON
    {
        [JsonPropertyName("id")]
         public string Id { get; set; }

        [JsonPropertyName("name")]
        public Name Name{ get; set;}

        [JsonPropertyName("gender")]
        public string Gender{ get; set;}

        [JsonPropertyName("height")]
        public string height{ get; set;}

        [JsonPropertyName("height")]
        public string weight{ get; set;}



    }

    public class Name
    {
        [JsonPropertyName("english")]
        public string English { get; set; }

        [JsonPropertyName("kanji")]
        public string Kanji { get; set; }

        [JsonPropertyName("romaji")]
        public string Romaji { get; set; }
    }

    public class Personajes
    {   
        private Datos datos;
        private Caracteristicas caracteristicas;

        public Personajes(Datos datos,Caracteristicas caracteristicas)
        {
            this.caracteristicas = caracteristicas;
            this.datos = datos;
        }
    }

    public class Datos
    {
        private Tipo tipo;
        private string nombre;
        private string genero;
        private string cumpleaños;

        private string altura;

        private string peso;
    }


    public class Caracteristicas
    {
        private int velocidad;   //1 a 10
        private int destreza;   //1 a 5
        private int fuerza;  //1 a 10

        private int nivelReatsu; //1 a 10
        private int armadura; //1 a 100
        private int salud; //1 a 100
    }

    public class obtenerPersonajesAPI
    {
        private static readonly HttpClient client = new HttpClient();
         private static async Task<List<PersonajesJSON>> GetPjJSONs()
         {
            var url = "https://bleach-api-8v2r.onrender.com/characters";
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode(); 
            string responseBody = await response.Content.ReadAsStringAsync();
            List<PersonajesJSON> listaPersonajes = JsonSerializer.Deserialize<List<PersonajesJSON>>(responseBody);
            return listaPersonajes;
         }
    }
}


