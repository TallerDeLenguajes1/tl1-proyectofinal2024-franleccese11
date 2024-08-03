using System.Drawing;
using espacioPersonaje;
namespace espacioASCII
{
    public static class AsciiJuego
    {
        public static string[] titulo = new string[]
        {
            @"
    ____  _      __      ___              __   __  ___           __           __          __  __  __                                 
   / __ \(_)____/ /__   /   |  ____  ____/ /  /  |/  /___  _____/ /___  __   / /_  ____ _/ /_/ /_/ /__     _________  ____ _________ 
  / /_/ / / ___/ //_/  / /| | / __ \/ __  /  / /|_/ / __ \/ ___/ __/ / / /  / __ \/ __ `/ __/ __/ / _ \   / ___/ __ \/ __ `/ ___/ _ \
 / _, _/ / /__/ ,<    / ___ |/ / / / /_/ /  / /  / / /_/ / /  / /_/ /_/ /  / /_/ / /_/ / /_/ /_/ /  __/  (__  ) /_/ / /_/ / /__/  __/
/_/ |_/_/\___/_/|_|  /_/  |_/_/ /_/\__,_/  /_/  /_/\____/_/   \__/\__, /  /_.___/\__,_/\__/\__/_/\___/  /____/ .___/\__,_/\___/\___/ 
                                                                 /____/                                     /_/                      
                                                                                                                                                                                                             
 
            "
        };

        public static string[] capitulo2 = new string[]
        {
             @"
   ____            _ _         _         ____       _            _ _             _   __        
  / ___|__ _ _ __ (_) |_ _   _| | ___   |___ \ _   (_)_ ____   _(_) |_ __ _  ___(_) /_/  _ __  
 | |   / _` | '_ \| | __| | | | |/ _ \    __) (_)  | | '_ \ \ / / | __/ _` |/ __| |/ _ \| '_ \ 
 | |__| (_| | |_) | | |_| |_| | | (_) |  / __/ _   | | | | \ V /| | || (_| | (__| | (_) | | | |
  \____\__,_| .__/|_|\__|\__,_|_|\___/  |_____(_)  |_|_| |_|\_/ |_|\__\__,_|\___|_|\___/|_| |_|
            |_|                                                                                
              "
        };

        public static void Capitulo2(int x,int y)
        {
            Console.SetCursorPosition(x,y);
            Console.Write(@"   ____            _ _         _         ____       _            _ _             _   __        ");
            Console.SetCursorPosition(x,y+1);
            Console.Write(@"  / ___|__ _ _ __ (_) |_ _   _| | ___   |___ \ _   (_)_ ____   _(_) |_ __ _  ___(_) /_/  _ __  ");
            Console.SetCursorPosition(x,y+2);
            Console.Write(@" | |   / _` | '_ \| | __| | | | |/ _ \    __) (_)  | | '_ \ \ / / | __/ _` |/ __| |/ _ \| '_ \ ");
            Console.SetCursorPosition(x,y+3);
            Console.Write(@" | |__| (_| | |_) | | |_| |_| | | (_) |  / __/ _   | | | | \ V /| | || (_| | (__| | (_) | | | |");
            Console.SetCursorPosition(x,y+4);
            Console.Write(@"  \____\__,_| .__/|_|\__|\__,_|_|\___/  |_____(_)  |_|_| |_|\_/ |_|\__\__,_|\___|_|\___/|_| |_|");
            Console.SetCursorPosition(x,y+5);
            Console.Write(@"            |_|                                                                                ");
            Console.SetCursorPosition(x,y+6);
        }

        public static void EscribirTitulo(int x, int y)
        {
            Console.SetCursorPosition(x,y);
            Console.Write(@"    ____  _      __      ___              __   __  ___           __           __          __  __  __ ");
            Console.SetCursorPosition(x,y+1);
            Console.Write(@"   / __ \(_)____/ /__   /   |  ____  ____/ /  /  |/  /___  _____/ /___  __   / /_  ____ _/ /_/ /_/ /__     _________  ____ _________ ");
            Console.SetCursorPosition(x,y+2);
            Console.Write(@"  / /_/ / / ___/ //_/  / /| | / __ \/ __  /  / /|_/ / __ \/ ___/ __/ / / /  / __ \/ __ `/ __/ __/ / _ \   / ___/ __ \/ __ `/ ___/ _ \");
            Console.SetCursorPosition(x,y+3);
            Console.Write(@" / _, _/ / /__/ ,<    / ___ |/ / / / /_/ /  / /  / / /_/ / /  / /_/ /_/ /  / /_/ / /_/ / /_/ /_/ /  __/  (__  ) /_/ / /_/ / /__/  __/");
            Console.SetCursorPosition(x,y+4);
            Console.Write(@"/_/ |_/_/\___/_/|_|  /_/  |_/_/ /_/\__,_/  /_/  /_/\____/_/   \__/\__, /  /_.___/\__,_/\__/\__/_/\___/  /____/ .___/\__,_/\___/\___/ ");
            Console.SetCursorPosition(x,y+5);
            Console.Write(@"                                                                 /____/                                     /_/                      ");
        
        }

        public static void DibujarPortada(int x,int y)
        {
            Console.SetCursorPosition(x,y);
            Console.Write(@"                .   ,- wubba lubba dub dub!");
            Console.SetCursorPosition(x,y+1);
            Console.Write(@"               .'.");
            Console.SetCursorPosition(x,y+2);
            Console.Write(@"               |o|");
            Console.SetCursorPosition(x,y+3);
            Console.Write(@"              .'o'.");
            Console.SetCursorPosition(x,y+4);
            Console.Write(@"              |.-.|");
            Console.SetCursorPosition(x,y+5);
            Console.Write(@"              '   '");
            Console.SetCursorPosition(x,y+6);
            Console.Write(@"               ( )");
            Console.SetCursorPosition(x,y+7);
            Console.Write(@"                )");
            Console.SetCursorPosition(x,y+8);
            Console.Write(@"               ( )");
            Console.SetCursorPosition(x,y+9);
            Console.Write(@"                   ");
            Console.SetCursorPosition(x,y+10);
            Console.Write(@"               .       .");
            Console.SetCursorPosition(x,y+11);
            Console.Write(@"     +  :      .");
            Console.SetCursorPosition(x,y+12);
            Console.Write(@"               :       _");
            Console.SetCursorPosition(x,y+13);
            Console.Write(@"           .   !   '  (_)");
            Console.SetCursorPosition(x,y+14);
            Console.Write(@"              ,|.'");
            Console.SetCursorPosition(x,y+15);
            Console.Write(@"    -  -- ---(-O-`--- --  -");
            Console.SetCursorPosition(x,y+16);
            Console.Write(@"             ,`|'`.");
            Console.SetCursorPosition(x,y+17);
            Console.Write(@"           ,   !    .");
            Console.SetCursorPosition(x,y+18);
            Console.Write(@"        :      :       :  ");


        }

        public static string[] dibujo1 = new string[]
        {
            @"
                .   ,- wobalobadodod!
               .'.
               |o|
              .'o'.
              |.-.|
              '   '
               ( )
                )
               ( )

               .       . 
     +  :      .
               :       _
           .   !   '  (_)
              ,|.' 
    -  -- ---(-O-`--- --  -  
             ,`|'`.
           ,   !    .
        :      :       :  " 
           
        };

    public static string[] marco = new string[]
    {
        @"
        ╒═══════════════════════════╕
        │                           │
        │                           │
        │                           │
        │                           │                                       
        │                           │
        │                           │                                 
        │                           │
        │                           │
        │                           │
        │                           │
        │                           │
        │                           │                               
        ╘═══════════════════════════╛ 
        "
    };

    public static string[] versus = new string[]
    {
        @"
                    
 __     ______  
 \ \   / / ___| 
  \ \ / /\___ \ 
   \ V /  ___) |
    \_/  |____/   
        "
    };

        public static void DibujarMarcoDePelea(int x,int y)
        {
            Console.SetCursorPosition(x,y);
            Console.Write(@"╒═══════════════════════════╕");
            Console.SetCursorPosition(x,y+1);
            Console.Write(@"│                           │");
            Console.SetCursorPosition(x,y+2);
            Console.Write(@"│                           │");
            Console.SetCursorPosition(x,y+3);
            Console.Write(@"│                           │");
            Console.SetCursorPosition(x,y+4);
            Console.Write(@"│                           │");
            Console.SetCursorPosition(x,y+5);
            Console.Write(@"│                           │");
            Console.SetCursorPosition(x,y+6);
            Console.Write(@"│                           │");
            Console.SetCursorPosition(x,y+7);
            Console.Write(@"│                           │");
            Console.SetCursorPosition(x,y+8);
            Console.Write(@"│                           │");
            Console.SetCursorPosition(x,y+9);
            Console.Write(@"│                           │");
            Console.SetCursorPosition(x,y+10);
            Console.Write(@"│                           │");
            Console.SetCursorPosition(x,y+11);
            Console.Write(@"│                           │");
            Console.SetCursorPosition(x,y+12);
            Console.Write(@"│                           │");
            Console.SetCursorPosition(x,y+13);
            Console.Write(@"│                           │");
            Console.SetCursorPosition(x,y+14);
            Console.Write(@"╘═══════════════════════════╛");
        }

        public static void DibujarVersus(int x,int y)
        {
            Console.SetCursorPosition(x,y+1);
            Console.Write(@" __     ______");
            Console.SetCursorPosition(x,y+2);
            Console.Write(@" \ \   / / ___|");
            Console.SetCursorPosition(x,y+3);
            Console.Write(@"  \ \ / /\___ \");
            Console.SetCursorPosition(x,y+4);
            Console.Write(@"   \ V /  ___) |");
            Console.SetCursorPosition(x,y+5);
            Console.Write(@"    \_/  |____/");
        }
    }


}