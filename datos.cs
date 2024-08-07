using System.Text.Json;
using System.Text.Json.Serialization;
using espacioPersonaje;


namespace espacioDatos
{

   /* public class PersonajeGanador
    {
         public PersonajeGanador(Personaje pj,DateTime fecha)
        {
            Personaje = pj;
            Hoy = fecha;
        }

        [JsonPropertyName("personaje")]
        public Personaje Personaje { get; set;}
                

        [JsonPropertyName("Hoy")]
        public DateTime Hoy { get; set; }
    }
*/
    public class PersonajeGanador
    {
         public PersonajeGanador(string nombre,string especie,string origen,DateTime hoy)
        {
            Nombre = nombre;
            Especie = especie;
            Origen = origen;
            Hoy = hoy;
        }

        [JsonPropertyName("nombre")]
        public string Nombre { get; set; }


        [JsonPropertyName("especie")]
        public string Especie { get; set; }

        [JsonPropertyName("origen")]
        public string Origen { get; set; }
                

        [JsonPropertyName("Hoy")]
        public DateTime Hoy { get; set; }
    }
    
    public class PersonajesJson
    {
        public static void GuardarPersonajes(List<Personaje>listaPersonajes,string nombreArchivo)
        {
            var listaPersonajesJson = JsonSerializer.Serialize(listaPersonajes);
            using (FileStream archivo = new FileStream(nombreArchivo,FileMode.Create))
            {
                using (StreamWriter strWriter = new StreamWriter(archivo))
                {
                    strWriter.WriteLine("{0}", listaPersonajesJson);
                    strWriter.Flush();
                    strWriter.Close();
                }
            }
        }
// 
        public static List<Personaje> LeerPersonajes(string nombreArchivo)
        {
            using (FileStream archivo = new FileStream(nombreArchivo,FileMode.Open))
            {
                using (StreamReader strReader = new StreamReader(archivo))
                {
                    string listaPersonajesJson = strReader.ReadToEnd();
                    
                    List <Personaje>listaPersonajes = JsonSerializer.Deserialize<List<Personaje>>(listaPersonajesJson);
                    archivo.Close();
                    return listaPersonajes;
                }
            }
        }

        public static bool Existe(string nombreArchivo)
        {
            if (File.Exists(nombreArchivo))
            {
                using (FileStream archivo = new FileStream(nombreArchivo, FileMode.Open))
                {
                    using (StreamReader StrReader = new StreamReader(archivo))
                    {
                        string listaPersonajesJson = StrReader.ReadToEnd();
                        archivo.Close();

                        if (string.IsNullOrEmpty(listaPersonajesJson)!= true)
                        {
                            return true; //tiene datos y existe 
                        }else
                        {
                            return false;  //no tiene datos
                        }
                    }
                }
            }else
            {
                return false; //no existe el archivo
            }
        }
    }


    

    


    public class historialJSON
    {      

        

        public static void GuardarGanador(PersonajeGanador personajeGanador, string nombreArchivo)
        {
            List <PersonajeGanador> ListaPersonajesGanadores = LeerGanadores(nombreArchivo);
            ListaPersonajesGanadores.Add(personajeGanador);
            string listaPersonajesGanadoresJSON = JsonSerializer.Serialize(ListaPersonajesGanadores);
            using (FileStream Archivo = new FileStream(nombreArchivo,FileMode.Create))
            {
                using(StreamWriter StrWriter = new StreamWriter(Archivo))
                {
                    StrWriter.WriteLine("{0}", listaPersonajesGanadoresJSON);
                    StrWriter.Close();
                }
            }
        }

        public static List <PersonajeGanador> LeerGanadores(string nombreArchivo)
        {
            if(!Existe(nombreArchivo))
            {
                return new List<PersonajeGanador>();
            }
            using (FileStream Archivo = new FileStream(nombreArchivo,FileMode.Open))
            {
                using(StreamReader StrReader = new StreamReader(Archivo))
                {
                    string personajesGanadoresJSON = StrReader.ReadToEnd();
                    Archivo.Close();
                    List <PersonajeGanador> ListaPersonajesGanadores = JsonSerializer.Deserialize<List<PersonajeGanador>>(personajesGanadoresJSON);
                    return ListaPersonajesGanadores;

                }
            }
        }




        public static bool Existe(string NombreArchivo)
        {
            if(File.Exists(NombreArchivo))
            {
                using (FileStream Archivo = new FileStream(NombreArchivo,FileMode.Open))
                {
                    using (StreamReader StrReader = new StreamReader(Archivo))
                    {
                        string listaPersonajesJson = StrReader.ReadToEnd();
                        Archivo.Close();

                        if(string.IsNullOrEmpty(listaPersonajesJson)!= true)
                        {
                            return true;
                        }else
                        {
                            return false;
                        }
                    }
                }
            }else
            {
                return false;
            }
        }   
    }
}