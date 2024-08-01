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
using espacioMenu;
using espacioJuego;

Point limiteSuperior = new Point(2,2);
Point limiteInferior = new Point(197,47);
Ventana ventana = new Ventana(200,50,limiteSuperior,limiteInferior);
ventana.DibujarMarco();
AsciiJuego asciiGame = new AsciiJuego();
asciiGame.EscribirTitulo(35,5);
// Console.SetCursorPosition(limiteSuperior.X + 5,limiteSuperior.Y+3);
// Ascii.dibujar(Ascii.titulo,0);
asciiGame.DibujarPortada(35,13);
string frase=" Bienvenido retador! ¿Que te gustaria hacer?";
string []opciones = { "Jugar","Historial","Acerca del juego","Salir"};
Menu MenuPrincipal = new Menu(frase,opciones);
int indiceSelec= MenuPrincipal.Run(5,37);
Juego juego = new Juego();
switch (indiceSelec)
{
    case 0:
       await Juego.Jugar(ventana);
        break;
    case 1:
        break;
    case 2:
        break;
    case 3:
        break;

}

Console.ReadKey();









