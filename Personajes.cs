using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http;
using System.Threading.Tasks;


namespace espacioPersonaje 
{
    public enum Arma
    {
        Espada,
		Neutrogun,
		Portalgun,
		Exoesqueleto
    }

    public class PersonajeAPI
    {
        public class Info
        {
            [JsonPropertyName("count")]
            public int count { get; set; }

            [JsonPropertyName("pages")]
            public int pages { get; set; }

            [JsonPropertyName("next")]
            public string next { get; set; }

            [JsonPropertyName("prev")]
            public object prev { get; set; }
        }

        public class Location
        {
            [JsonPropertyName("name")]
            public string name { get; set; }

            [JsonPropertyName("url")]
            public string url { get; set; }
        }

        public class Origin
        {
            [JsonPropertyName("name")]
            public string name { get; set; }

            [JsonPropertyName("url")]
            public string url { get; set; }
        }

        public class Result
        {
            [JsonPropertyName("id")]
            public int id { get; set; }

            [JsonPropertyName("name")]
            public string name { get; set; }

            [JsonPropertyName("status")]
            public string status { get; set; }

            [JsonPropertyName("species")]
            public string species { get; set; }

            [JsonPropertyName("type")]
            public string type { get; set; }

            [JsonPropertyName("gender")]
            public string gender { get; set; }

            [JsonPropertyName("origin")]
            public Origin origin { get; set; }

            [JsonPropertyName("location")]
            public Location location { get; set; }

            [JsonPropertyName("image")]
            public string image { get; set; }

            [JsonPropertyName("episode")]
            public List<string> episode { get; set; }

            [JsonPropertyName("url")]
            public string url { get; set; }

            [JsonPropertyName("created")]
            public DateTime created { get; set; }
        }

    }

    // public class PersonajeAPI
    // {
    //     [JsonPropertyName("id")]
    //      public int Id { get; set; }

    //     [JsonPropertyName("name")]

    //     public string Name{ get; set;}

    //     [JsonPropertyName("gender")]
    //     public string Gender{ get; set;}

    //     [JsonPropertyName("species")]
    //     public string Species{ get; set;}

    //     [JsonPropertyName("location")]
    //     public string Location{ get; set;}

    // }

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

        public Caracteristicas(int velocidad,int destreza,int fuerza,int nivel,int armadura,int salud,Arma arma)
        {
            this.velocidad = velocidad;
            this.destreza = destreza;
            this.fuerza = fuerza;
            this.nivel = nivel;
            this.armadura = armadura;
            this.salud = salud;
            this.arma = arma;
        }
    }

    public class FabricaDePersonajes
    {
        
        private static readonly HttpClient client = new HttpClient();
        private static async Task<List<PersonajeAPI>> GetPjJSONs()
        {
            var url = "https://rickandmortyapi.com/api/character?page=2";
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode(); 
            string responseBody = await response.Content.ReadAsStringAsync();
            List<PersonajeAPI> listaPersonajes = JsonSerializer.Deserialize<List<PersonajeAPI>>(responseBody);
            return listaPersonajes;
        }

        public static Personaje CrearPersonaje(List <PersonajeAPI>listaPersonajes)
        {
            var semilla = Environment.TickCount;
            Random random = new Random(semilla);
            int ALE = random.Next(0,listaPersonajes.Count);
            PersonajeAPI personajeAPI = listaPersonajes[ALE];
            if (personajeAPI.Gender == "male")
            {
                personajeAPI.Gender = "masculino";
            }else
            {
                if (personajeAPI.Gender == "female")
                {
                    personajeAPI.Gender = "femenino";
                }
            }
            Datos datos = new Datos(personajeAPI.Name,personajeAPI.Gender,personajeAPI.Species,personajeAPI.Location);

            int velocidad = random.Next(1,11);                     //1 a 10
            int destreza=random.Next(1,6);                        //1 a 5
            int fuerza = random.Next(1,11);                       //1 a 10
            int nivel = random.Next(1,11);                       //1 a 10
            int armadura = random.Next(1,101);                  //1 a 100 
            int salud = random.Next(1,101);                     //1 a 100
            int indiceArma = random.Next(0,4);
            
        }
    }

}



