using espacioASCII;
using System.Drawing;
using System.Reflection.Metadata;
using System.Text;
using espacioMenu;
using espacioPersonaje;
using espacioConsola;

namespace espacioDialogos
{
    public static 
    class Dialogos
    {
        public static void Escribir(string Texto, int Velocidad)
        {
            foreach (char Letra in Texto)
            {
                Console.Write(Letra);
                Thread.Sleep(Velocidad);  //tiempo que tarda en escribir cada letra
                BloquearTeclas();
            }
            Console.WriteLine(); 
        }

        public static void EscribirCentrado(string[] Texto,Point LimiteInferior , int Y, int Velocidad)
        {
            foreach (string Linea in Texto)
            {
                Console.SetCursorPosition(( LimiteInferior.X - Linea.Length) / 2, Y);

                foreach (char Letra in Linea)
                {
                    Console.Write(Letra);
                    Thread.Sleep(Velocidad); // Tiempo que demora hasta escribir otra letra, en ms
                }
                Y++;
            }
        }

        public static void BloquearTeclas()
        {
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }
        }

        public static string introduccion = "hola";




    }
}
