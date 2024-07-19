using System.Drawing;
namespace espacioConsola
{
    public class Ventana
    {
        private int ancho;
        private int largo;
        private Point limiteSuperior;
        private Point limiteInferior;

        public Ventana(int ancho,int largo,Point limiteSuperior,Point limiteInferior)
        {
            this.ancho = ancho;
            this.largo = largo;
            this.limiteSuperior = limiteSuperior;
            this.limiteInferior = limiteInferior;
            init();
        }
        private void init()
        {
            Console.SetWindowSize(ancho,largo);
            Console.Title= "Rick and Morty Space battle";
        }

        public void DibujarMarco()
        {
            Console.ForegroundColor = ConsoleColor.Green; 
            for (int i = limiteSuperior.X; i < limiteInferior.X; i++)
            {
                Console.SetCursorPosition(i,limiteSuperior.Y);
                Console.Write("═");
                Console.SetCursorPosition(i,limiteInferior.Y);
                Console.Write("═");
            }

            for (int i = limiteSuperior.Y; i < limiteInferior.Y; i++)           
            {
                Console.SetCursorPosition(limiteSuperior.X,i);
                Console.Write("║");
                Console.SetCursorPosition(limiteInferior.X,i);
                Console.Write("║");
            }
            Console.SetCursorPosition(limiteSuperior.X,limiteSuperior.Y);
            Console.Write("╔");
            Console.SetCursorPosition(limiteSuperior.X,limiteInferior.Y);
            Console.Write("╚");
            Console.SetCursorPosition(limiteInferior.X,limiteSuperior.Y);
            Console.Write("╗");
            Console.SetCursorPosition(limiteInferior.X,limiteInferior.Y);
            Console.Write("╝");

        }
    }
}