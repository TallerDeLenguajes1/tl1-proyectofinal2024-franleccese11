namespace espacioPersonaje
{
    enum Tipo
    {
        shinigami,
		humano,
		quincy,
		arrancar
    }
    
    public class Personajes
    {   
        private Datos datos;
        private Caracteristicas caracteristicas;
    }

    public class Datos
    {
        private Tipo tipo;
        private string nombre;
        private string genero;
        private string? cumpleaños;

        private string altura;

        private string peso;
    }


    public class Caracteristicas
    {
        private int velocidad;   //1 a 10
        private int destreza;   //1 a 5
        private int fuerza;  //1 a 10

        private int nivel; //1 a 10
        private int armadura; //1 a 100
        private int salud; //1 a 100
    }
}
