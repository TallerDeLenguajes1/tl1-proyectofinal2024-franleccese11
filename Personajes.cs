using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http;
using System.Threading.Tasks;
using espacioDialogos;
using espacioConsola;
using System.Drawing;
namespace espacioPersonaje 
{
    // public enum Arma
    // {
    //     Espada,
	// 	Neutrogun,
	// 	Portalgun,
	// 	Exoesqueleto
    // }

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

        [JsonPropertyName("datos")]
        public Datos Datos { get; set; }
    
        [JsonPropertyName("caracteristicas")]
        public Caracteristicas Caracteristicas { get; set; }

        public Personaje(Datos datos,Caracteristicas caracteristicas)
        {
            Caracteristicas = caracteristicas;
            Datos = datos;
        }

    }

    public class Datos
    {
        [JsonPropertyName("nombre")]
        public string Nombre { get; set; }

        [JsonPropertyName("genero")]
        public string Genero { get; set; }

        [JsonPropertyName("especie")]
        public string Especie { get; set; }

        [JsonPropertyName("origen")]
        public string Origen { get; set; }
        

        public Datos(string nombre,string genero,string especie,string origen)
        {
            Nombre = nombre;
            Genero = genero;
            Especie = especie;
            Origen = origen;
        }
    }


    public class Caracteristicas
    {

        [JsonPropertyName("velocidad")]
        public int Velocidad { get; set; }

        [JsonPropertyName("destreza")]
        public int Destreza { get; set; }

        [JsonPropertyName("fuerza")]
        public int Fuerza { get; set; }

        [JsonPropertyName("nivel")]
        public int Nivel { get; set; }

        [JsonPropertyName("armadura")]
        public int Armadura { get; set; }

        [JsonPropertyName("salud")]
        public int Salud { get; set; }

       

        public Caracteristicas(int velocidad,int destreza,int fuerza,int nivel,int armadura,int salud)
        {
            Velocidad = velocidad;
            Destreza = destreza;
            Fuerza = fuerza;
            Nivel = nivel;
            Armadura = armadura;
            Salud = salud;
        }
    }

    public class FabricaDePersonajes
    {
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
            PersonajesAPI.Results.Remove(PersonajesAPI.Results[ALE]);
            Datos datosPJ = new Datos(nombre,genero,especie,origen);
            int velocidad = random.Next(1,11);
            int destreza=random.Next(1,6);
            int fuerza = random.Next(1,11);
            int nivel = random.Next(1,11);
            int armadura = random.Next(1,101);
            int salud = random.Next(1,101);
            Caracteristicas caracteristicasPJ = new Caracteristicas(velocidad,destreza,fuerza,nivel,armadura,salud);
            Personaje personajeAleatorio = new Personaje(datosPJ,caracteristicasPJ);
            return personajeAleatorio;
        }

        public static Personaje personajePrincipal()
        {
            int yref;
            Point limiteInferior =new Point(197,47);
            var semilla = Environment.TickCount;
            Random random = new Random(semilla);
            string nombrePJ;
            do
            {
                 yref = Dialogos.EscribirCentrado(["Ingresa el nombre de tu personaje: "],limiteInferior,5,0);
                nombrePJ= Console.ReadLine();
            } while (nombrePJ == null);
            
             
            string generoPJ ;
            do
            {
                yref = Dialogos.EscribirCentrado(["Ingresa su genero(F= femenino , M= masculino , S= Sin genero):  "],limiteInferior,yref,0);
                generoPJ = Console.ReadLine();
                generoPJ.ToUpper();
                if (generoPJ != "F" && generoPJ !="S" && generoPJ != "M")
                {
                    yref = Dialogos.EscribirCentrado(["Error, por favor ingrese un caracter valido!" ],limiteInferior,yref,0);
                    Console.WriteLine();
                }

            } while (generoPJ != "F" && generoPJ !="S" && generoPJ != "M" );
            generoPJ = TraducirGenero(generoPJ);   
            

            string especiePJ;
            yref = Dialogos.EscribirCentrado(["Ingresa su especie: (Presiona ENTER para seleccionar una especie aleatoria):  " ],limiteInferior,yref,0);
            especiePJ = Console.ReadLine();
            if (string.IsNullOrEmpty(especiePJ))
            {
                especiePJ = EspecieAleatoria(especiePJ);
                yref = Dialogos.EscribirCentrado(["Tu especie es: "+especiePJ],limiteInferior,yref,0);
            }

            string origenPJ;
            yref = Dialogos.EscribirCentrado(["ingresa su planeta de origen:(Presiona ENTER para seleccionar un planeta aleatorio):  "],limiteInferior,yref,0);
            origenPJ = Console.ReadLine();
            if (string.IsNullOrEmpty(origenPJ))
            {
                origenPJ= EspecieAleatoria(especiePJ);
                yref = Dialogos.EscribirCentrado(["Tu origen es: "+origenPJ],limiteInferior,yref,0);  
            }

            Datos datosPJ = new Datos(nombrePJ,generoPJ,especiePJ,origenPJ);
            yref = Dialogos.EscribirCentrado(["Personaje principal creado con exito! sus caracteristicas de pelea son:"],limiteInferior,yref,0); 
            int velocidadPJ = random.Next(1,11);
            int destrezaPJ=random.Next(1,6);
            int fuerzaPJ = random.Next(1,11);
            int nivelPJ = random.Next(1,11);
            int armaduraPJ = random.Next(1,101);
            int saludPJ = random.Next(1,101);
            yref = Dialogos.EscribirCentrado(["Velocidad= "+velocidadPJ,"Destreza= "+destrezaPJ,"Fuerza="+fuerzaPJ,"nivel="+nivelPJ,"armadura="+armaduraPJ,"Salud="+saludPJ],limiteInferior,yref,0);
            yref = Dialogos.EscribirCentrado(["presiona una tecla para continuar..."],limiteInferior,yref,0);
            Caracteristicas caracteristicasPJ = new Caracteristicas(velocidadPJ,destrezaPJ,fuerzaPJ,nivelPJ,armaduraPJ,saludPJ);
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
