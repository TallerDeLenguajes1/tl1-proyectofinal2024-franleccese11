using System.Text.Json;
using System.Text.Json.Serialization;
using espacioPersonaje;

namespace datos
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
    }
}