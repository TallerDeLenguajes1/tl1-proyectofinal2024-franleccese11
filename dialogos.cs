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
        private static Random random = new Random();
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
                    Thread.Sleep(Velocidad);// Tiempo que demora hasta escribir otra letra
                    BloquearTeclas(); 
                }
                Y++;
            }
            Y++;
            return Y;
        }

        public static int EscribirEnCoordenadas(string[] Texto,int x, int y,int desborde, int Velocidad)
        {
            foreach (string Linea in Texto)
            {
                Console.SetCursorPosition(x,y);

                foreach (char Letra in Linea)
                {
                    Console.Write(Letra);
                    Thread.Sleep(Velocidad);// Tiempo que demora hasta escribir otra letra
                    BloquearTeclas(); 
                }
                y++;
            }
            y++;
            return y;
        }

        public static int EscribirEnCoordenadasConDesborde(string[] Texto, int x, int y, int desborde, int Velocidad)
        {
            foreach (string Linea in Texto)
            {
                int longitudRestante = Linea.Length;
                int inicio = 0;
                while (longitudRestante > 0)
                {
                    Console.SetCursorPosition(x, y);
                    int longitudActual = Math.Min(desborde, longitudRestante);
                    string parteLinea = Linea.Substring(inicio, longitudActual);

                    foreach (char Letra in parteLinea)
                    {
                        Console.Write(Letra);
                        Thread.Sleep(Velocidad); // Tiempo que demora hasta escribir otra letra
                        BloquearTeclas();
                    }
                    inicio += longitudActual;
                    longitudRestante -= longitudActual;
                    y++;
                }
                y++;
            }
            return y;
        }

        public static int EscribirCentradoDialogoAleatorio(string[] Texto,Point LimiteInferior , int Y, int Velocidad)
        {
            int indiceAleatorio = random.Next(1,Texto.Length);
            string DialogoAleatorio = Texto[indiceAleatorio];
            if (!string.IsNullOrEmpty(DialogoAleatorio))
            {
                Console.SetCursorPosition(( LimiteInferior.X - DialogoAleatorio.Length) / 2, Y);
                foreach (char Letra in DialogoAleatorio)
                {
                    Console.Write(Letra);
                    Thread.Sleep(Velocidad);// Tiempo que demora hasta escribir otra letra
                }
                Y++;
                return Y+1;
            }else
            {
                return Y;
            }
            
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

        };

         public static  string[] DialogoIntroduccion = new  string[] 
         { 
        "RICK: Morty, escucha bien. Nos han invitado al Torneo del Multiverso.","Todos los genios locos,guerreros interdimensionales y criaturas mágicas"," estarán allí, y el premio es la Esfera de la Realidad.",
        "MORTY: Oh, hombre, Rick. ¿Eso no es demasiado peligroso?", 
        "Rick: Sí, Morty. Pero la Esfera de la Realidad podría resolver cualquier problema.","Podríamos arreglar el multiverso de una vez por todas.", " Así que agarra tu arma y prepárate, porque vamos a patear algunos traseros interdimensionales. "
        };

        public static string[] DialogoInvitacion = new string[]
        {
            "Rick se encontraba en su laboratorio, inmerso en un proyecto que involucraba tecnología alienígena","y una buena cantidad de explosivos cuando el portal interdimensional comenzó a parpadear.","Rick levantó la vista, con una mezcla de curiosidad y fastidio","mientras Morty, su nieto, entraba apresuradamente en el garaje."
        };

        public static string[] DialogoInvitacion2 = new string[]
        {
            "Rick: ¡Maldita sea, Morty! ¿No ves que estoy ocupado?",

            "Morty: Rick, ¿qué está pasando? El portal está haciendo cosas raras."

            ,"Rick: Es la señal de una invitación interdimensional, Morty. Solo la envían cuando algo grande está por suceder.",

            "En ese momento, el portal se abrió completamente, revelando una figura encapuchada", "que entregó un pergamino a Rick antes de desaparecer. Rick desenrolló el pergamino" ,"y sus ojos se iluminaron con una mezcla de interés y codicia.",

            "Rick: ¡Ja! Justo como sospechaba, es una invitación al Torneo del Multiverso."
                ,
            "Morty: ¿Torneo del Multiverso? Eso suena peligroso, Rick."
                ,
            "Rick: Claro que lo es, Morty. Los competidores más poderosos de todas las dimensiones luchan por la Esfera de la Realidad.","Con ella, podríamos resolver cualquier problema en el multiverso."
                ,
            "Morty: Oh Rick, No estoy seguro de esto..."
            ,
            "Rick: No te preocupes, Morty. No vamos solos. Tengo en mente a alguien que podría ser la clave para ganar este torneo."
        };

        public static string[] DialogoInvitacion3M = new string[]
        {
            "Rick ajustó su pistola de portales y, con un gesto decidido, abrió otro portal.","Ambos lo atravesaron y llegaron a un laboratorio subterráneo en una dimensión alternativa.","Allí, un joven científico trabajaba incansablemente en una máquina."
        };
        public static string[] DialogoInvitacion3F = new string[]
        {
            "Rick ajustó su pistola de portales y, con un gesto decidido, abrió otro portal.","Ambos lo atravesaron y llegaron a un laboratorio subterráneo en una dimensión alternativa.","Allí, un joven científico trabajaba incansablemente en una máquina."
        };

        public static string[] DialogoInvitacion4M = new string[]
        {
            "Rick: Eres justo la persona que estaba buscando.",

            "El joven científico levantó la vista, sorprendido por la aparición de Rick y Morty en su laboratorio.",

            "Rick: Soy Rick Sanchez. Este es mi nieto, Morty.Nos han invitado al Torneo del Multiverso","y necesitamos a alguien con tu talento para unirte a nuestro equipo. ¿Te interesa?",

            "El joven científico, intrigado por la propuesta, asintió con la cabeza."
            ,
            "Rick: Perfecto. Entonces, ¡prepárate! Porque vamos a patear algunos traseros interdimensionales.",

            "Morty: Espera, Rick. ¿Por qué no podemos luchar nosotros también?"
                ,
            "Rick: Ah, Morty, verás... Según las reglas del torneo, cada equipo debe tener al menos un miembro que no sea un completo imbécil."
            ,
            "Morty: ¡¿Qué?!"
                ,
            "Rick: Sí, Morty. Y, bueno, tú y yo... no cumplimos con ese criterio. Aun asi tendremos influencia en este torneo", "ya que seremos los estrategas, mientras nuestro nuevo amigo aquí se encarga de la acción."
                ,
            "Morty: Eso suena... ¿espera, estás diciendo que él es el único que no es un imbécil?",

            "Rick: Exacto, Morty. Ahora deja de quejarte y vamos a ganar ese maldito torneo.",

            "Así, nuestro protagonista se unió a Rick y Morty en su misión de ganar el Torneo del Multiverso","y obtener la Esfera de la Realidad. El destino del multiverso ahora dependía de ellos."
        };

        public static string[] DialogoInvitacion4F = new string[]
        {
            "Rick: Eres justo la persona que estaba buscando.",

            "El joven científico levantó la vista, sorprendido por la aparición de Rick y Morty en su laboratorio.",

            "Rick: Soy Rick Sanchez. Este es mi nieto, Morty.Nos han invitado al Torneo del Multiverso","y necesitamos a alguien con tu talento para unirte a nuestro equipo. ¿Te interesa?",

            "El joven científico, intrigado por la propuesta, asintió con la cabeza."
            ,
            "Rick: Perfecto. Entonces, ¡prepárate! Porque vamos a patear algunos traseros interdimensionales.",

            "Morty: Espera, Rick. ¿Por qué no podemos luchar nosotros también?"
                ,
            "Rick: Ah, Morty, verás... Según las reglas del torneo, cada equipo debe tener al menos un miembro que no sea un completo imbécil.",
            
            "Morty: ¡¿Qué?!"
                ,
            "Rick: Sí, Morty. Y, bueno, tú y yo... no cumplimos con ese criterio. Aun asi tendremos influencia en este torneo", "ya que seremos los estrategas, mientras nuestro nuevo amigo aquí se encarga de la acción."
                ,
            "Morty: Eso suena... ¿espera, estás diciendo que él es el único que no es un imbécil?",

            "Rick: Exacto, Morty. Ahora deja de quejarte y vamos a ganar ese maldito torneo.",

            "Así, nuestro protagonista se unió a Rick y Morty en su misión de ganar el Torneo del Multiverso","y obtener la Esfera de la Realidad. El destino del multiverso ahora dependía de ellos."
        };

        public static string[] DialogosGolpeAltaEfectividad = new string[]
        {
            "",
            "",
            "Rick: ¡Boom! Así se hace. Ese golpe debería venir con una advertencia de salud",
            "Rick: Eso fue más efectivo que un desayuno de vodka, Morty.",
            "Morty: ¡Increíble! Ese golpe fue tan fuerte que yo lo sentí.",
            "Morty: ¡Wow, ese fue un golpe de campeonato! ¡Sigue así!",
            "Morty: ¡Buen golpe! Sigue así y ganarás seguro."

        };

        public static string[] DialogosGolpePocaEfectividad = new string[]
        {
            "Rick: Si sigues así, el enemigo se morirá... de risa.",
            "Morty: Creo que hasta yo podría haber golpeado más fuerte... y eso es decir mucho.",
            "Rick: Genial, con ese golpe tal vez puedas asustar a una mosca.",
            "Rick:  ¿Qué fue eso? ¿Un golpe o un masaje suave?",
            "",
            "",
            "",
            "",
            ""
        };

        public static string[] DialogosGolpeFatal = new string[]
        {
            "Rick: Nada como un buen golpe mortal para recordarme por qué sigo aquí... además del alcohol.",
            "Rick: El universo es un lugar oscuro y cruel, pero ese golpe final fue una luz brillante.",
            "Rick: ¡Sí! ¡Así se hace! Esa victoria fue más dulce que una botella de Kirkland.",
            "Morty: Eso fue brutal. Me gusta tu estilo.",
            "Morty: ¡Increíble! ¡Ese golpe final fue asombroso!"
        };

        public static string[] DialogosPocaVidaEnemigo = new string[]
        {
            "Rick: Vamos, tiene poca vida, mejor le damos el golpe final antes de que el universo lo haga por nosotros.",
            "Rick: Está en las últimas. Hazlo rápido, quiero beber para celebrar.",
            "Morty: ¡Está a punto de caer! ¡No te detengas!",
            "Rick: Mira, Morty, está al borde. Un empujoncito más y lo mandamos al olvido.",
            "Rick: Ese pobre desgraciado está al límite. Vamos a ponerle fin rápido.",
            "","","","","","","",""
        };
    }
}
