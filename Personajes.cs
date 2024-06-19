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

     public class Info
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("pages")]
        public int Pages { get; set; }

        [JsonPropertyName("next")]
        public string Next { get; set; }

        [JsonPropertyName("prev")]
        public object Prev { get; set; }
    }

    public class Location
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class Origin
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class Result
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("species")]
        public string Species { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("origin")]
        public Origin Origin { get; set; }

        [JsonPropertyName("location")]
        public Location Location { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("episode")]
        public List<string> Episode { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("created")]
        public DateTime Created { get; set; }
    }

    public class InformacionAPI
    {
        [JsonPropertyName("info")]
        public Info Info { get; set; }

        [JsonPropertyName("results")]
        public List<Result> Results { get; set; }
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
        private static async Task<InformacionAPI> GetPjJSONs()
        {
            var url = "https://rickandmortyapi.com/api/character";
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode(); 
            string responseBody = await response.Content.ReadAsStringAsync();
            InformacionAPI PersonajesAPI = JsonSerializer.Deserialize<InformacionAPI>(responseBody);
            return PersonajesAPI;
        }

        public static Personaje CrearPersonaje( InformacionAPI PersonajesAPI)
        {
            var semilla = Environment.TickCount;
            Random random = new Random(semilla);
            int ALE = random.Next(0,PersonajesAPI.Results.Count);
            string nombre = PersonajesAPI.Results[ALE].Name;
            string genero = TraducirGenero(PersonajesAPI.Results[ALE].Gender);
            string especie = PersonajesAPI.Results[ALE].Species;
            string origen = PersonajesAPI.Results[ALE].Location.Name;
            Datos datos = new Datos(nombre,genero,especie,origen);
            int velocidad = random.Next(1,11);
            int destreza=random.Next(1,6);
            int fuerza = random.Next(1,11);
            int nivel = random.Next(1,11);
            int armadura = random.Next(1,101);
            int salud = random.Next(1,101);
            Array valores = Enum.GetValues(typeof(Arma));
            int indiceAleatorio = random.Next(valores.Length);
            Arma arma = (Arma)valores.GetValue(indiceAleatorio);
            Caracteristicas caracteristicasPJ = new Caracteristicas(velocidad,destreza,fuerza,nivel,armadura,salud,arma);
            Personaje pj = new Personaje(datos,caracteristicasPJ);
            return pj;
        }
        public static string TraducirGenero(string Gender)
        {
            Gender.ToLower();
            if (Gender == "male")
            {
                Gender = "Masculino";
            }else
            {
                if (Gender == "female")
                {
                    Gender = "Femenino";
                }else
                {
                    if (Gender == "genderless")
                    {
                        Gender = "Sin genero";
                    } else
                    {
                    
                         Gender = "Desconocido";
                        
                    }
                }
            }
            return Gender;
        }
    }

}
