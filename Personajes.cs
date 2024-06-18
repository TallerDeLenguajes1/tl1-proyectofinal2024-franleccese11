using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http;
using System.Threading.Tasks;


namespace espacioPersonaje 
{
    enum Arma
    {
        Espada,
		Neutrogun,
		Portalgun,
		Exoesqueleto
    }

    

    public class PersonajeJSON
    {
        [JsonPropertyName("id")]
         public int Id { get; set; }

        [JsonPropertyName("name")]

        public string Name{ get; set;}

        [JsonPropertyName("gender")]
        public string Gender{ get; set;}

        [JsonPropertyName("species")]
        public string Species{ get; set;}

        [JsonPropertyName("location")]
        public string Location{ get; set;}

    }

    public class Personaje
    {   
        private Datos datos;
        private Caracteristicas caracteristicas;

        public Personaje(Datos datos,Caracteristicas caracteristicas)
        {
            this.caracteristicas = caracteristicas;
            this.datos = datos;
        }
    }

    public class Datos
    {
        
        private string nombre;
        private string genero;
        private string especie;

        private string origen;

        public Datos(string nombre,string genero,string especie,string origen)
        {
            this.nombre = nombre;
            this.genero = genero;
            this.especie = especie;
            this.origen = origen;
        }
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

    public class FabricaDePersonajes
    {
        
        private static readonly HttpClient client = new HttpClient();
        private static async Task<List<PersonajeJSON>> GetPjJSONs()
        {
            var url = "https://rickandmortyapi.com/api/character";
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode(); 
            string responseBody = await response.Content.ReadAsStringAsync();
            List<PersonajeJSON> listaPersonajes = JsonSerializer.Deserialize<List<PersonajeJSON>>(responseBody);
            return listaPersonajes;
        }

        public static Personaje CrearPersonaje(List <PersonajeJSON>listaPersonajes)
    {
        var semilla = Environment.TickCount;
        Random random = new Random(semilla);
        int N = random.Next(0,listaPersonajes.Count);

    }


    }

}



