using System.Runtime.InteropServices;

namespace espacioMenu
{
    public class Menu
    {
        private int indice;
        private string[] opciones;
        private string frase;

        public Menu(string frase,string[]opciones)
        {
            this.opciones = opciones;
            this.frase = frase;
            indice = 0;
        }

        private void Display(int x,int y)
        {
            Console.SetCursorPosition(x,y);
            Console.WriteLine(frase);
            for(int i = 0; i< opciones.Length; i++)
            {
                Console.SetCursorPosition(x,y+i+2);
                string opcionActual = opciones[i];
                string prefijo;
                if (i == indice )
                {
                    prefijo = "*";
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }else
                {
                    prefijo=" ";
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine(prefijo+"<<"+opcionActual+">>");
            }
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;

        }



        public int Run(int x,int y)
        {
            ConsoleKey KeySeleccionada;
            do
            {
                // Console.Clear();
                Display(x,y);
                ConsoleKeyInfo keyInfo = Console.ReadKey(true); //true para que la tecla seleccionada no aparezca en consola
                KeySeleccionada = keyInfo.Key;

                if (KeySeleccionada == ConsoleKey.UpArrow)
                {
                    indice--;
                    if (indice == -1)
                    {
                        indice = opciones.Length -1;
                    }
                }
                if (KeySeleccionada == ConsoleKey.DownArrow)
                {
                    indice++;
                    if (indice==opciones.Length)
                    {
                        indice = 0;
                    }
                }


            } while (KeySeleccionada !=ConsoleKey.Enter);
            return(indice);
        }

    }
}