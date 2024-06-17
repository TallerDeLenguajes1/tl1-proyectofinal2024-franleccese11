using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http;
using System.Threading.Tasks;


namespace espacioPersonaje 
{
    enum Arma
    {
        Espada,
		Pistola,
		Portalgun,
		Guante
    }

    

    public class PersonajesJSON
    {
        [JsonPropertyName("id")]
         public int Id { get; set; }

        [JsonPropertyName("name")]

        public string Name{ get; set;}

        [JsonPropertyName("gender")]
        public string Gender{ get; set;}

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

        private int nivel; //1 a 10
        private int armadura; //1 a 100
        private int salud; //1 a 100
        private Arma arma;
    }

    public class obtenerPersonajesAPI
    {
        
        private static readonly HttpClient client = new HttpClient();
         private static async Task<List<PersonajesJSON>> GetPjJSONs()
         {
            var url = "https://rickandmortyapi.com/api/character";
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode(); 
            string responseBody = await response.Content.ReadAsStringAsync();
            List<PersonajesJSON> listaPersonajes = JsonSerializer.Deserialize<List<PersonajesJSON>>(responseBody);
            return listaPersonajes;
         }
    }
}


