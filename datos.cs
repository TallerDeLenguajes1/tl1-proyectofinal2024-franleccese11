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

                        if (listaPersonajesJson != null)
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
}