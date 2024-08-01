using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http;
using System.Threading.Tasks;
using espacioPersonaje;
using espacioConsola;
using espacioDatos;
using espacioASCII;
using System.Drawing;
using System.Reflection.Metadata;
using System.Text;
using espacioMenu;
using espacioDialogos;

namespace espacioJuego
{
    public class Juego
    {
        public static async Task Jugar(Ventana ventana)
        {
            Console.Clear();
            ventana.DibujarMarco();
            string nombreArchivo = "personajes.json";
            List <Personaje> personajes;
            Personaje personajePrincipal;
            if (PersonajesJson.Existe(nombreArchivo))
            {
                personajes = PersonajesJson.LeerPersonajes(nombreArchivo);
                Console.WriteLine("Personajes cargados exitosamente desde el archivo existente!");
            }else
            {
                InformacionAPI personajesAPI = await FabricaDePersonajes.GetPjJSONs();
                personajes = new List<Personaje>();
                FabricaDePersonajes fabrica = new FabricaDePersonajes();
                for (int i = 0; i < 9; i++)
                {
                    personajes.Add(FabricaDePersonajes.CrearPersonajeAleatorio( personajesAPI));
                }
                PersonajesJson.GuardarPersonajes(personajes,nombreArchivo);
                Console.WriteLine("Personajes cargados exitosamente desde la API!");
            }

        }
    }
}
