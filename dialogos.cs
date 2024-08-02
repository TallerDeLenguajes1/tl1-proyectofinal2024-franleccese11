using espacioASCII;
using System.Drawing;
using System.Reflection.Metadata;
using System.Text;
using espacioMenu;
using espacioPersonaje;
using espacioConsola;
namespace espacioDialogos
{
    public static class Dialogos
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

        public static int EscribirCentrado(string[] Texto,Point LimiteInferior , int Y, int Velocidad)
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
            Y++;
            return Y;
        }

        public static void BloquearTeclas()
        {
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }
        }

        public static  string[] introduccion = new  string[] 
        {
            "En un rincón olvidado del multiverso, un torneo legendario está a punto de comenzar.",
            " Los competidores más fuertes de todas las dimensiones se reúnen para luchar por el objeto más valioso del multiverso: "
            ,"la Esfera de la Realidad.",
            "Esta esfera tiene el poder de alterar cualquier aspecto del tiempo, el espacio y la existencia misma."
            ,"Aquél que la posea podrá remodelar el multiverso a su voluntad."
            ,

        };

         public static  string[] DialogoIntroduccion = new  string[] 
         { 
        "RICK: Morty, escucha bien. Nos han invitado al Torneo del Multiverso.","Todos los genios locos,guerreros interdimensionales y criaturas mágicas"," estarán allí, y el premio es la Esfera de la Realidad.",
        "MORTY: Oh, hombre, Rick. ¿Eso no es demasiado peligroso?", 
        "Rick: Sí, Morty. Pero la Esfera de la Realidad podría resolver cualquier problema.","Podríamos arreglar el multiverso de una vez por todas.", " Así que agarra tu arma y prepárate, porque vamos a patear algunos traseros interdimensionales. "
        };
    }
}
