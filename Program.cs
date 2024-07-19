// See https://aka.ms/new-console-template for more information
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
Point limiteSuperior = new Point(2,2);
Point limiteInferior = new Point(197,47);
Ventana ventana = new Ventana(200,50,limiteSuperior,limiteInferior);
ventana.DibujarMarco();
AsciiJuego asciiGame = new AsciiJuego();
asciiGame.EscribirTitulo(35,5);
// Console.SetCursorPosition(limiteSuperior.X + 5,limiteSuperior.Y+3);
// Ascii.dibujar(Ascii.titulo,0);
asciiGame.DibujarPortada(35,13);
Console.ReadKey();









