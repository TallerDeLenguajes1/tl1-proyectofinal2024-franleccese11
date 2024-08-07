using espacioASCII;
using System.Drawing;
using System.Reflection.Metadata;
using System.Text;
using espacioMenu;
using espacioPersonaje;
using espacioConsola;
using espacioDatos;
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
        "Rick: Sí, Morty. Pero la Esfera de la Realidad podría resolver cualquier problema.","Podríamos arreglar el multiverso de una vez por todas.", " Así que pon a cargar la pistola de portales y prepárate, porque vamos a patear algunos traseros interdimensionales. "
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
            "Rick ajustó su pistola de portales y, con un gesto decidido, abrió otro portal.","Ambos lo atravesaron y llegaron a un laboratorio subterráneo en una dimensión alternativa.","Allí, una joven científica trabajaba incansablemente en una máquina."
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

            "La joven científica levantó la vista, sorprendida por la aparición de Rick y Morty en su laboratorio.",

            "Rick: Soy Rick Sanchez. Este es mi nieto, Morty.Nos han invitado al Torneo del Multiverso","y necesitamos a alguien con tu talento para unirte a nuestro equipo. ¿Te interesa?",

            "La joven científica, intrigada por la propuesta, asintió con la cabeza."
            ,
            "Rick: Perfecto. Entonces, ¡prepárate! Porque vamos a patear algunos traseros interdimensionales. Tu seras el musculo y nosotros el cerebro.",

            "Morty: Espera, Rick. ¿Por qué no podemos luchar nosotros también?"
                ,
            "Rick: Ah, Morty, verás... Según las reglas del torneo, cada equipo debe tener al menos un miembro que no sea un completo imbécil.",
            
            "Morty: ¡¿Qué?!"
                ,
            "Rick: Sí, Morty. Y, bueno, tú y yo... no cumplimos con ese criterio. Aun asi tendremos influencia en este torneo", "ya que seremos los estrategas, mientras nuestro nuevo amigo aquí se encarga de la acción."
                ,
            "Morty: Eso suena... ¿espera, estás diciendo que éllla es la única que no es una imbécil?",

            "Rick: Exacto, Morty. Ahora deja de quejarte y vamos a ganar ese maldito torneo.",

            "Así, nuestra protagonista se unió a Rick y Morty en su misión de ganar el Torneo del Multiverso","y obtener la Esfera de la Realidad. El destino del multiverso ahora dependía de ellos."
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
            "","",""
        };

         public static string[] DialogoCapitulo3 = new string[]
         {
            "Tras recibir la invitación para participar en el torneo, nuestro protagonista," , "acompañado por Rick y Morty, se dirige al centro de registro."," Allí, una pantalla gigante muestra la lista de los rivales inscriptos",", cada uno más extraño y formidable que el anterior"
            ,
            "Rick, con su usual indiferencia, revisa la lista mientras toma un trago de su botella de Kirkland. ","Veamos, Morty, quiénes son los desafortunados que se enfrentarán a nuestro pequeño guerrero",

            "La lista incluye una variedad de personajes de diferentes dimensiones, algunos conocidos y otros totalmente nuevos:",
         };

         public static string[] DialogoCapitulo3F = new string[]
         {
            "Tras recibir la invitación para participar en el torneo, nuestra protagonista," , "acompañada por Rick y Morty, se dirige al centro de registro."," Allí, una pantalla gigante muestra la lista de los rivales inscriptos",", cada uno más extraño y formidable que el anterior"
            ,
            "Rick, con su usual indiferencia, revisa la lista mientras toma un trago de su botella de Kirkland. ","Veamos, Morty, quiénes son los desafortunados que se enfrentarán a nuestro pequeño guerrero",

            "La lista incluye una variedad de personajes de diferentes dimensiones, algunos conocidos para nuestro duo y otros totalmente nuevos:",
         };

        public static string[] DialogoCapitulo3parte2 = new string[]
        {
            "Morty, con los ojos abiertos de par en par, comenta:","Oh, Dios mío, Rick, ¡estos son algunos de los tipos más duros que hemos conocido!", 
            "Rick: Relájate, Morty. Solo necesitamos un buen plan y un poco de suerte."," Además, ¿cuántas veces hemos estado en situaciones más peligrosas?"
            
        };

        public static string[] DialogoCapitulo3parte3 = new string[]
        {
            "El día había llegado. Rick, Morty y el jugador, cuyo nombre resonaba con un aura de misterio","y determinación, estaban listos para embarcarse en su primer desafío. ","La nave de Rick zumbaba con un suave brillo azul mientras se deslizaba entre las dimensiones,"," el trío estaba preparado para enfrentar lo que se les presentara.",
            
            "Rick: Recuerda, en las peleas por turnos, cada decisión cuenta."," Evalúa tus habilidades y actúa en consecuencia.",

            "La nave atraviesa varias dimensiones, cada una más extraña que la anterior."," En una, ven un mundo donde los perros gobiernan y los humanos son ","sus mascotas. En otra, una dimensión completamente hecha de queso.", 

            "Rick, ajustando algunos controles en la nave, murmura: Morty, asegúrate de no tocar nada.","La última vez que lo hiciste, terminamos en una dimensión donde las personas tienen cabezas de pepinillo...", 

            "Morty: Rick, ¿estás seguro de que tenemos una oportunidad contra estos tipos?",

            "Rick: Morty, siempre tenemos una oportunidad. ","Solo necesitamos ser más inteligentes, más rápidos y, en tu caso, menos... Morty.",

            "Despues un largo viaje Finalmente llegan a la arena del torneo..."
        };

        public static string[] DialogoCapitulo3parte3F = new string[]
        {
            "El día había llegado. Rick, Morty y la jugadora, cuyo nombre resonaba con un aura de misterio","y determinación, estaban listos para embarcarse en su primer desafío. ","La nave de Rick zumbaba con un suave brillo azul mientras se deslizaba entre las dimensiones,"," el trío estaba preparado para enfrentar lo que se les presentara.",
            
            "Rick: Recuerda, en las peleas por turnos, cada decisión cuenta."," Evalúa tus habilidades y actúa en consecuencia.",

            "La nave atraviesa varias dimensiones, cada una más extraña que la anterior."," En una, ven un mundo donde los perros gobiernan y los humanos son ","sus mascotas. En otra, una dimensión completamente hecha de queso.", 

            "Rick, ajustando algunos controles en la nave, murmura: Morty, asegúrate de no tocar nada.","La última vez que lo hiciste, terminamos en una dimensión donde las personas tienen cabezas de pepinillo...", 

            "Morty, nervioso pero intentando mantener la compostura: Rick, ¿estás seguro de que tenemos una oportunidad contra estos tipos?",

            "Rick: Morty, siempre tenemos una oportunidad. ","Solo necesitamos ser más inteligentes, más rápidos y, en tu caso, menos... Morty.",

            "Despues de un largo viaje Finalmente llegan a la arena del torneo..."
        };

        public static string[] DialogoCapitulo4parte1M = new string[]
        {
            "Despues de un largo viaje Finalmente llegan a la arena del torneo, la atmósfera es electrizante.","La gigantesca estructura flotante se ubica en medio de una nebulosa multicolor. ","La tensión en el aire es palpable mientras los combatientes se preparan para los cuartos de final.",
            "El primer combate es entre nuestro protagonista y uno de los adversarios mas prometedores del certamen." ,

            "Nuestro protagonista, con determinación en sus ojos, avanza hacia el centro del coliseo. ","Rick y Morty, observando desde la línea de espectadores, intercambian miradas expectantes.","Rick murmura sarcásticamente: Bueno, Morty, aquí vamos. Espero que nuestro campeón sepa lo que hace.","Morty, nervioso pero esperanzado, responde: ¡Vamos, tú puedes hacerlo!¡Hazlo por nosotros! ","La batalla está por comenzar, y la tensión en el aire es palpable..." 
        };

        public static string[] DialogoCapitulo4parte1F = new string[]
        {
            "Despues un largo viaje Finalmente llegan a la arena del torneo, la atmósfera es electrizante.","La gigantesca estructura flotante se ubica en medio de una nebulosa multicolor. ","La tensión en el aire es palpable mientras los combatientes se preparan para los cuartos de final.",
            "El primer combate es entre nuestra protagonista y uno de los adversarios mas prometedores del certamen." ,
            "Nuestra protagonista, con determinación en sus ojos, avanza hacia el centro del coliseo. ","Rick y Morty, observando desde la línea de espectadores, intercambian miradas expectantes.","Rick murmura sarcásticamente: Bueno, Morty, aquí vamos. Espero que nuestra campeóna sepa lo que hace.","Morty, nervioso pero esperanzado, responde: ¡Vamos, tú puedes hacerlo!¡Hazlo por nosotros! ","La batalla está por comenzar, y la tensión en el aire es palpable..." 
        };


         public static string[] DialogoFinal1 = new string[]
         {
            "Morty: ¡Rick, no puede ser! ¿Cómo vamos a enfrentar a ese monstruo?",
            "Rick: Morty, cálmate. Sí, es un oponente fuerte, pero nada que no podamos manejar con un poco de ingenio",
         };

         public static string[] DialogoFinal2 = new string[]
         {
            "Morty: ¿Qué? ¿Ácido sulfúrico? ¡Rick, eso no es un plan B!",
            "Rick: Calma, Morty. Solo estoy bromeando. O tal vez no. Nunca lo sabrás."
         };

        public static string[] DialogoPostFinal = new string[]
        {
            "Morty: wow. Ganamos! ¡Eres increíble!"
            ,
            "Rick: Sabía que tenías potencial. Ahora tenemos la Esfera de la Realidad."," ¿Te das cuenta de lo que podemos hacer con esto?"
            ,
            "Rick: Es una victoria para todos nosotros. Aunque, técnicamente,","es más una victoria mía, ya sabes, por la genialidad genética y todo eso."
            ,
            "Morty: Rick, esto es sobre él ¡Es el verdadero héroe aquí!"
            ,
            "Rick: Claro, Morty, claro. Pero vamos, alguien tiene que manejar la esfera, ¿no?"
        };

        public static string[] DialogoEpilogo1M = new string[]
        {
            "Tras la victoria en la final, el equipo celebra con entusiasmo.","  Rick se da cuenta del inmenso poder que tienen en sus manos con la Esfera de la Realidad.", "La discusión sobre quién debe quedarse con la esfera comienza de inmediato.",

            "Rick: Muy bien, equipo, tenemos la Esfera de la Realidad. Obviamente, debería ser yo quien la conserve."," Ya saben, por el bien de la ciencia y el equilibrio del multiverso.",

            "Morty: ¡Rick, no puedes simplemente quedarte con ella! ¡Él también tiene derecho a decidir!",

            "Rick: Morty, Morty, Morty... la Esfera es demasiado poderosa para dejarla en manos de cualquiera.", "Incluso si ese cualquiera es un cientifico que respeto y ha demostrado ser un campeón.",

            "Morty: ¡Pero Rick, eso no es justo! ¡Él se lo ganó!",

            
        };

        public static string[] DialogoEpilogo1F = new string[]
        {
            "Tras la victoria en la final, el equipo celebra con entusiasmo.","  Rick se da cuenta del inmenso poder que tienen en sus manos con la Esfera de la Realidad.", "La discusión sobre quién debe quedarse con la esfera comienza de inmediato.",

            "Rick: Muy bien, equipo, tenemos la Esfera de la Realidad. Obviamente, debería ser yo quien la conserve."," Ya saben, por el bien de la ciencia y el equilibrio del multiverso.",

            "Morty: Rick, no puedes simplemente quedarte con la esfera. ¡Élla también tiene derecho a decidir!",

            "Rick: Morty, Morty, Morty... la Esfera es demasiado poderosa para dejarla en manos de cualquiera.", "Incluso si esa cualquiera es una cientifica que respeto y ha demostrado ser una campeóna.",

            "Morty: ¡Pero Rick, eso no es justo! ¡Élla se lo ganó!",

            
        };

        public static string[] DialogoEpilogo2M = new string[]
        {
            "Rick: Está bien, Morty. Aquí está el trato: él tiene derecho a usar la Esfera para un deseo." ,"Lo que sea que necesite para su universo. Después de eso, yo la guardaré para proteger la integridad del multiverso.",

            "El protagonista asiente, reconociendo la sabiduría en la decisión de Rick, pero también deseando algo muy personal.", "Con la Esfera de la Realidad, el protagonista pide un deseo para restaurar la paz y el equilibrio en su propio universo,", "asegurando un futuro mejor para su gente. Con el deseo concedido, la esfera queda en manos de Rick.",
            "Rick: Bien, deseo concedido. Ahora, la Esfera de la Realidad estará segura bajo mi cuidado.","Prometo no hacer demasiadas locuras... al menos no más de lo habitual.",

            "Morty: Esperemos que puedas mantener esa promesa, Rick.",

           " Rick: Vamos, Morty, tengo todo bajo control. ¡Ahora, a celebrar! ","¡Ganamos el torneo y tenemos el poder del multiverso a nuestro alcance!",

            "El equipo se dirige de regreso a su nave, con el protagonista satisfecho por haber salvado su mundo","y Rick más feliz que nunca con una nueva herramienta de poder.","Las aventuras continúan, pero con un nuevo campeón en la historia del multiverso."
            ,"   ...FIN!",
            "presiona una tecla para salir."
        };


        public static string[] DialogoEpilogo2F = new string[]
        {
            "Rick: Está bien, Morty. Aquí está el trato: élla tiene derecho a usar la Esfera para un deseo." ,"Lo que sea que necesite para su universo. Después de eso, yo la guardaré para proteger la integridad del multiverso.",

            "La protagonista asiente, reconociendo la sabiduría en la decisión de Rick, pero también deseando algo muy personal.", "Con la Esfera de la Realidad, la protagonista pide un deseo para restaurar la paz y el equilibrio en su propio universo,", "asegurando un futuro mejor para su gente. Con el deseo concedido, la esfera queda en manos de Rick.",
            "Rick: Bien, deseo concedido. Ahora, la Esfera de la Realidad estará segura bajo mi cuidado.","Prometo no hacer demasiadas locuras... al menos no más de lo habitual.",

            "Morty: Esperemos que puedas mantener esa promesa, Rick.",

           " Rick: Vamos, Morty, tengo todo bajo control. ¡Ahora, a celebrar! ","¡Ganamos el torneo y tenemos el poder del multiverso a nuestro alcance!",

            "El equipo se dirige de regreso a su nave, con la protagonista satisfecha por haber salvado su mundo","y Rick más feliz que nunca con una nueva herramienta de poder.","Las aventuras continúan, pero con un nuevo campeón en la historia del multiverso."
            ,"   ...FIN!",
            "presiona una tecla para salir."
        };
    }
}
