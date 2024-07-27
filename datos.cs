using System.Text.Json;
using System.Text.Json.Serialization;
using espacioPersonaje;


namespace espacioDatos
{
    public class PersonajesJson
    {
        public static void GuardarPersonajes(List<Personaje>listaPersonajes,string nombreArchivo)
        {
            string listaPersonajesJson = JsonSerializer.Serialize(listaPersonajes);
            using (FileStream archivo = new FileStream(nombreArchivo,FileMode.Create))
            {
                using (StreamWriter strWriter = new StreamWriter(archivo))
                {
                    strWriter.WriteLine("{0}",listaPersonajesJson);
                    strWriter.Close();
                    Console.WriteLine("personajes guardados exitosamente!");
                }
            }
        }

        public static List<Personaje> LeerPersonajes(string nombreArchivo)
        {
            using (FileStream archivo = new FileStream(nombreArchivo,FileMode.Open))
            {
                using (StreamReader strReader = new StreamReader(archivo))
                {
                    string listaPersonajesJson = strReader.ReadToEnd();
                    archivo.Close();
                    Console.WriteLine("lista de personajes encontrada con exito!");
                    List <Personaje>listaPersonajes = JsonSerializer.Deserialize<List<Personaje>>(listaPersonajesJson);
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


    public class personajeGanador(Personaje pj,DateTime hoy)
    {
        private Personaje personaje =  pj;
        DateTime hoy = hoy;
        public Personaje Personaje { get => personaje; set => personaje = value; }
        public DateTime Hoy { get => hoy; set => hoy = value; }
    }


    public class historialJSON
    {
        public static void GuardarGanador(personajeGanador personajeGanador, string nombreArchivo)
        {
            List <personajeGanador> ListaPersonajesGanadores = LeerGanadores(nombreArchivo);
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

        public static List <personajeGanador> LeerGanadores(string nombreArchivo)
        {
            if(!Existe(nombreArchivo))
            {
                return new List<personajeGanador>();
            }
            using (FileStream Archivo = new FileStream(nombreArchivo,FileMode.Open))
            {
                using(StreamReader StrReader = new StreamReader(Archivo))
                {
                    string personajesGanadoresJSON = StrReader.ReadToEnd();
                    Archivo.Close();
                    List <personajeGanador> ListaPersonajesGanadores = JsonSerializer.Deserialize<List<personajeGanador>>(personajesGanadoresJSON);
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