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

        public static Personaje CrearPersonajeAleatorio( InformacionAPI PersonajesAPI)
        {
            var semilla = Environment.TickCount;
            Random random = new Random(semilla);
            int ALE = random.Next(0,PersonajesAPI.Results.Count);
            string nombre = PersonajesAPI.Results[ALE].Name;
            PersonajesAPI.Results[ALE].Gender.ToLower();
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
            Personaje personajeAleatorio = new Personaje(datos,caracteristicasPJ);
            return personajeAleatorio;
        }

        public static Personaje personajePrincipal()
        {
            var semilla = Environment.TickCount;
            Random random = new Random(semilla);
            string nombrePJ;
            do
            {
                Console.WriteLine("Ingresa el nombre de tu personaje");
                nombrePJ= Console.ReadLine();
            } while (nombrePJ != null);
            
             
            string generoPJ ;
            do
            {
                Console.WriteLine("Ingresa su genero(F= femenino , M= masculino , S= Sin genero)");
                generoPJ = Console.ReadLine();
                generoPJ.ToUpper();
                if (generoPJ != "F" || generoPJ !="S" || generoPJ != "M")
                {
                    Console.WriteLine("Error, por favor ingrese un caracter valido!");
                }

            } while (generoPJ != "F" || generoPJ !="S" || generoPJ != "M" );
            generoPJ = TraducirGenero(generoPJ);   
            string especiePJ;
            
            Console.WriteLine("Ingresa su especie: (Presiona ENTER para seleccionar una especie aleatoria)");
            especiePJ = Console.ReadLine();
            if (string.IsNullOrEmpty(especiePJ))
            {
                especiePJ = EspecieAleatoria(especiePJ);
                Console.WriteLine("Tu especie es:"+especiePJ);  
            }

            string origenPJ;
            Console.WriteLine("ingresa su planeta de origen:(Presiona ENTER para seleccionar un planeta aleatorio)");
            origenPJ = Console.ReadLine();
            if (string.IsNullOrEmpty(origenPJ))
            {
                origenPJ= EspecieAleatoria(especiePJ);
                Console.WriteLine("Tu origen es:"+origenPJ);  
            }

            Datos datosPJ = new Datos(nombrePJ,generoPJ,especiePJ,origenPJ);
             int velocidadPJ = random.Next(1,11);
            int destrezaPJ=random.Next(1,6);
            int fuerzaPJ = random.Next(1,11);
            int nivelPJ = random.Next(1,11);
            int armaduraPJ = random.Next(1,101);
            int saludPJ = random.Next(1,101);
            Array valores = Enum.GetValues(typeof(Arma));
            int indiceAleatorio = random.Next(valores.Length);
            Arma arma = (Arma)valores.GetValue(indiceAleatorio);
            Caracteristicas caracteristicasPJ = new Caracteristicas(velocidadPJ,destrezaPJ,fuerzaPJ,nivelPJ,armaduraPJ,saludPJ,arma);
            Personaje personajePrincipal = new Personaje(datosPJ,caracteristicasPJ); 
            return personajePrincipal;  
        }

        
        public static string TraducirGenero(string Gender)
        {
            
            if (Gender == "male" || Gender == "M")
            {
                Gender = "Masculino";
            }else
            {
                if (Gender == "female"|| Gender == "F")
                {
                    Gender = "Femenino";
                }else
                {
                    if (Gender == "genderless" || Gender == "S")
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

        public static string EspecieAleatoria(string especieAleatoria)
        {
            string[] ArrayEspecies= {"Borpociano","Cromulon","Cronenberg","Fleeb","Meeseek","Robodrilo","Kozbiano","Gromflomito"};
            var semilla = Environment.TickCount;
            Random random = new Random(semilla);
            int indiceAleatorio = random.Next(ArrayEspecies.Length);
            especieAleatoria = ArrayEspecies[indiceAleatorio];
            return(especieAleatoria);
        }

        public static string OrigenAleatorio(string origenAleatorio)
        {
            string[] ArrayOrigen= {"41-Kepler B","Alpha Centaurus","Planet Squanch","Snake Planet","Gaia","Jupiter","Venus"};
            var semilla = Environment.TickCount;
            Random random = new Random(semilla);
            int indiceAleatorio = random.Next(ArrayOrigen.Length);
            origenAleatorio = ArrayOrigen[indiceAleatorio];
            return(origenAleatorio);
        }


    }

}
