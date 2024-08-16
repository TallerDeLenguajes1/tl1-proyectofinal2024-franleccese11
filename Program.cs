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
// using espacioJuego;
using espacioDialogos;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;


            
Point limiteSuperior = new Point(2,2);
Point limiteInferior = new Point(197,47);
Ventana ventana = new Ventana(200,50,limiteSuperior,limiteInferior);
ventana.DibujarMarco();
AsciiJuego.EscribirTitulo(35,5);
AsciiJuego.DibujarPortada(35,13);
string frase=" Bienvenido retador! ¿Que te gustaria hacer?";
string []opciones = { "Jugar","Historial","Acerca del juego","Salir"};
Menu MenuPrincipal = new Menu(frase,opciones);
int indiceSelec= MenuPrincipal.Run(5,37);
List <Personaje> ListaPersonajes = new List<Personaje>();
try
{
    HttpClient client = new HttpClient();
    var url = "https://rickandmortyapi.com/api/character";
    HttpResponseMessage response = await client.GetAsync(url);
    response.EnsureSuccessStatusCode(); 
    string responseBody = await response.Content.ReadAsStringAsync();
    InformacionAPI PersonajesAPI = JsonSerializer.Deserialize<InformacionAPI>(responseBody);
    Random random = new Random();
    
    ListaPersonajes = PersistenciaDatosPersonajes(ventana,PersonajesAPI);
}
catch (System.Exception)
{
    ListaPersonajes = PersonajesJson.LeerPersonajes("personajes.json");
    
}



switch (indiceSelec)
{
    case 0:
        Console.Clear();
        ventana.DibujarMarco();
        int Yref=8;
        Yref =  Dialogos.EscribirCentrado(Dialogos.introduccion,ventana.LimiteInferior,Yref,30);
        Yref = Dialogos.EscribirCentrado(Dialogos.DialogoIntroduccion,ventana.LimiteInferior,Yref,30); //50
        AsciiJuego.EscribirTitulo(35,Yref+2);
        Yref = Dialogos.EscribirCentrado( ["Antes de comenzar tu aventura, por favor crea tu personaje","presiona una tecla para continuar"],ventana.LimiteInferior,42,50);
        Random random = new Random();
        Personaje personajePrincipal = CrearPJprincipal(ventana); 
        Console.ReadKey();
        Console.Clear();
        ventana.DibujarMarco();
        AsciiJuego.Capitulo2(45,5);
        int yref=16;
        yref = Dialogos.EscribirCentrado(Dialogos.DialogoInvitacion,ventana.LimiteInferior,yref,50);
        yref = Dialogos.EscribirCentrado(Dialogos.DialogoInvitacion2,ventana.LimiteInferior,yref,50);
        Console.Clear();
        ventana.DibujarMarco();
        yref = 12;
        if (personajePrincipal.Datos.Genero == "Femenino")
        {
            yref = Dialogos.EscribirCentrado(Dialogos.DialogoInvitacion3F,ventana.LimiteInferior,yref,40);
            yref = Dialogos.EscribirCentrado(Dialogos.DialogoInvitacion4F,ventana.LimiteInferior,yref,40);
            Console.Clear();
            ventana.DibujarMarco();
            AsciiJuego.DibujarCapitulo3(33,3);
            yref = Dialogos.EscribirCentrado(Dialogos.DialogoCapitulo3F,ventana.LimiteInferior,12,50);
            MostrarListaParticipantes1(ventana,ListaPersonajes);
            Dialogos.EscribirCentrado(["presione una tecla para continuar..."],ventana.LimiteInferior,46,50);
            Console.ReadKey();
            Console.Clear();
            ventana.DibujarMarco();
            MostrarListaParticipantes2(ventana,ListaPersonajes);
            yref = Dialogos.EscribirCentrado(Dialogos.DialogoCapitulo3parte2,ventana.LimiteInferior,28,40);
            Dialogos.EscribirCentrado(["presione una tecla para continuar..."],ventana.LimiteInferior,yref,0);
            Console.ReadKey();
            Console.Clear();
            ventana.DibujarMarco();
            yref = Dialogos.EscribirCentrado(Dialogos.DialogoCapitulo3parte3F,ventana.LimiteInferior,12,40);
            Thread.Sleep(3000);
            Console.Clear();
            ventana.DibujarMarco();
            AsciiJuego.DibujarCapitulo4(40,5);
            yref = Dialogos.EscribirCentrado(Dialogos.DialogoCapitulo4parte1F,ventana.LimiteInferior,20,40);
            yref = Dialogos.EscribirCentrado(["Presiona una tecla para comenzar los cuartos de final!"],ventana.LimiteInferior,yref,40);
            Console.ReadKey();

        }else
        {
            yref = Dialogos.EscribirCentrado(Dialogos.DialogoInvitacion3M,ventana.LimiteInferior,yref,40);
            yref = Dialogos.EscribirCentrado(Dialogos.DialogoInvitacion4M,ventana.LimiteInferior,yref,40);
            Console.Clear();
            ventana.DibujarMarco();
            AsciiJuego.DibujarCapitulo3(33,3);
            yref = Dialogos.EscribirCentrado(Dialogos.DialogoCapitulo3,ventana.LimiteInferior,12,40);
            MostrarListaParticipantes1(ventana,ListaPersonajes);
            Dialogos.EscribirCentrado(["presione una tecla para continuar..."],ventana.LimiteInferior,46,0);
            Console.ReadKey();
            Console.Clear();
            ventana.DibujarMarco();
            MostrarListaParticipantes2(ventana,ListaPersonajes);
            yref = Dialogos.EscribirCentrado(Dialogos.DialogoCapitulo3parte2,ventana.LimiteInferior,28,40);
            Dialogos.EscribirCentrado(["presione una tecla para continuar..."],ventana.LimiteInferior,yref,0);
            Console.ReadKey();
            Console.Clear();
            ventana.DibujarMarco();
            yref = Dialogos.EscribirCentrado(Dialogos.DialogoCapitulo3parte3,ventana.LimiteInferior,13,40);
            Thread.Sleep(3000);
            Console.Clear();
            ventana.DibujarMarco();
            AsciiJuego.DibujarCapitulo4(40,5);
            yref = Dialogos.EscribirCentrado(Dialogos.DialogoCapitulo4parte1M,ventana.LimiteInferior,20,40);
            yref = Dialogos.EscribirCentrado(["Presiona una tecla para comenzar los cuartos de final!"],ventana.LimiteInferior,yref,40);
            Console.ReadKey();
        }
        int bandera = 0;
        int saludAux = personajePrincipal.Caracteristicas.Salud;
        int saludAux2 = ListaPersonajes[0].Caracteristicas.Salud;
        do
        {
            personajePrincipal.Caracteristicas.Salud = saludAux;
            ListaPersonajes[0].Caracteristicas.Salud = saludAux2;
            Combate(ventana,personajePrincipal,ListaPersonajes[0]);
            Console.Clear();
            ventana.DibujarMarco();
            if (ListaPersonajes[0].Caracteristicas.Salud<=0)
            {  
                yref = Dialogos.EscribirCentradoDialogoAleatorio(Dialogos.DialogosGolpeFatal,ventana.LimiteInferior,16,40);
                yref = Dialogos.EscribirCentrado( ["felicidades, ganaste tu combate!"],ventana.LimiteInferior,yref,50);
                personajePrincipal.Caracteristicas.Salud = saludAux + 5;
                yref = Dialogos.EscribirCentrado( ["seras premiado con un aumento en tus estadisticas de salud!"],ventana.LimiteInferior,yref,40);
                yref = Dialogos.EscribirCentrado( ["...Salud +5"],ventana.LimiteInferior,yref,50);
                yref = Dialogos.EscribirCentrado( ["presiona una tecla para ver la tabla de semifinales!"],ventana.LimiteInferior,yref,50);
                Console.ReadKey();
                bandera =1;
                } else
                {
                    yref = Dialogos.EscribirCentrado( ["Perdiste tu batalla.","¿quieres volver a intentarlo?"],ventana.LimiteInferior,16,40);
                    string intento="";
                    do
                    {
                        yref = Dialogos.EscribirCentrado( ["-)Presiona 's' para reintentarlo","-)presiona 'n' para salir del juego"],ventana.LimiteInferior,yref,50);
                        Console.SetCursorPosition(ventana.LimiteInferior.X/2,yref);
                        intento = Console.ReadLine();
                            if (intento !="s" && intento!="n"&& intento!="N"&&intento !="S")
                            {
                                yref = Dialogos.EscribirCentrado( ["error,por favor ingresa un caracter valido!"],ventana.LimiteInferior,yref,50);
                            }
                        } while (intento !="s" && intento!="n"&& intento!="N"&&intento !="S");
                        if (intento=="n"||intento=="N")
                        {
                            yref = Dialogos.EscribirCentrado( ["presiona una tecla para salir...!"],ventana.LimiteInferior,yref,50);
                            Console.ReadKey();
                            Environment.Exit(0);
                        }else
                        {
                            yref = Dialogos.EscribirCentrado( ["Buena decision! presiona una tecla para reintentar el combate"],ventana.LimiteInferior,yref,50);
                            Console.ReadKey();
                        }
                }
                
            } while (bandera==0);
            Console.Clear();
            ventana.DibujarMarco();
            AsciiJuego.DibujarMarcoSemifinales(70,14);
            
            List<Personaje> listaAux = ListaPersonajes;
            listaAux.Remove(listaAux[0]);
            for (int i = 0; i < 5; i++)
            {
                int aleatorio= random.Next(0,listaAux.Count);
                listaAux.Remove(listaAux[aleatorio]);
            }
            List<Personaje> listaPersonajesSemifinal = listaAux;
            Dialogos.EscribirEnCoordenadasConDesborde([""+personajePrincipal.Datos.Nombre,"  VS  ",""+listaPersonajesSemifinal[0].Datos.Nombre],72,18,14,50);
            Dialogos.EscribirEnCoordenadasConDesborde([""+listaPersonajesSemifinal[1].Datos.Nombre,"  VS  ",""+listaPersonajesSemifinal[2].Datos.Nombre],90,18,14,50);
            Dialogos.EscribirCentrado(["Presiona una tecla para comenzar la semifinal!"],ventana.LimiteInferior,36,50);
            Console.ReadKey();


            int bandera2 = 0;
            saludAux = personajePrincipal.Caracteristicas.Salud;
            saludAux2 = listaPersonajesSemifinal[0].Caracteristicas.Salud;
        do
        {
            personajePrincipal.Caracteristicas.Salud = saludAux;
            listaPersonajesSemifinal[0].Caracteristicas.Salud = saludAux2;
            Combate(ventana,personajePrincipal,listaPersonajesSemifinal[0]);
            Console.Clear();
            ventana.DibujarMarco();
            if (listaPersonajesSemifinal[0].Caracteristicas.Salud<=0)
            {  
                yref = Dialogos.EscribirCentradoDialogoAleatorio(Dialogos.DialogosGolpeFatal,ventana.LimiteInferior,16,50);
                yref = Dialogos.EscribirCentrado( ["felicidades, ganaste tu combate!"],ventana.LimiteInferior,yref,50);
                personajePrincipal.Caracteristicas.Salud = saludAux + 5;
                yref = Dialogos.EscribirCentrado( ["seras premiado con un aumento en tus estadisticas de salud!"],ventana.LimiteInferior,yref,40);
                yref = Dialogos.EscribirCentrado( ["...Salud +5"],ventana.LimiteInferior,yref,50);
                yref = Dialogos.EscribirCentrado( ["presiona una tecla para ver la tabla de la final!"],ventana.LimiteInferior,yref,50);
                bandera2 =1;
                } else
                {
                    yref = Dialogos.EscribirCentrado( ["Perdiste tu batalla.","¿quieres volver a intentarlo?"],ventana.LimiteInferior,16,40);
                    string intento="";
                    do
                    {
                        yref = Dialogos.EscribirCentrado( ["-)Presiona 's' para reintentarlo","-)presiona 'n' para salir del juego"],ventana.LimiteInferior,yref,50);
                        Console.SetCursorPosition(ventana.LimiteInferior.X/2,yref);
                        intento = Console.ReadLine();
                            if (intento !="s" && intento!="n"&& intento!="N"&&intento !="S")
                            {
                                yref = Dialogos.EscribirCentrado( ["error,por favor ingresa un caracter valido!"],ventana.LimiteInferior,yref,50);
                            }
                        } while (intento !="s" && intento!="n"&& intento!="N"&&intento !="S");
                        if (intento=="n"||intento=="N")
                        {
                            yref = Dialogos.EscribirCentrado( ["presiona una tecla para salir...!"],ventana.LimiteInferior,yref,50);
                            Console.ReadKey();
                            Environment.Exit(0);
                        }else
                        {
                            yref = Dialogos.EscribirCentrado( ["Buena decision! presiona una tecla para reintentar el combate"],ventana.LimiteInferior,yref,50);
                            Console.ReadKey();
                        }
                }
                
        } while (bandera2==0);
        
        Console.Clear();
        ventana.DibujarMarco();
        Dialogos.EscribirCentrado(["Rick: Bueno, Morty, llegamos a la final. ¿Te das cuenta de lo improbable que era esto?","Es casi tan improbable como que yo pase un día sin beber." ,"Rick:ahí está la tabla. Parece que nuestro rival para la final es..."],limiteInferior,12,50);
        Thread.Sleep(1500);
        AsciiJuego.DibujarMarcoFinal(87,18);
        Dialogos.EscribirEnCoordenadasConDesborde([""+personajePrincipal.Datos.Nombre,"  VS  ",""+listaPersonajesSemifinal[2].Datos.Nombre],89,21,8,0);
        yref = Dialogos.EscribirCentrado(Dialogos.DialogoFinal1,limiteInferior,32,50);
        yref = Dialogos.EscribirCentrado(["Rick:"+personajePrincipal.Datos.Nombre+ ", Solo asegúrate de golpear fuerte y rápido.","Y si todo falla, siempre tengo una botella de ácido sulfúrico en el bolsillo. Por si acaso"],limiteInferior,yref,50);
        yref = Dialogos.EscribirCentrado(Dialogos.DialogoFinal2,limiteInferior,yref,50);
        yref=Dialogos.EscribirCentrado(["presiona una tecla para ir al combate final..."],limiteInferior,yref,50);
        Console.ReadKey();

        int bandera3 = 0;
        saludAux = personajePrincipal.Caracteristicas.Salud;
        saludAux2 = listaPersonajesSemifinal[2].Caracteristicas.Salud;
        do
        {
            personajePrincipal.Caracteristicas.Salud = saludAux;
            listaPersonajesSemifinal[2].Caracteristicas.Salud = saludAux2;
            Combate(ventana,personajePrincipal,listaPersonajesSemifinal[2]);
            Console.Clear();
            ventana.DibujarMarco();
            if (listaPersonajesSemifinal[2].Caracteristicas.Salud<=0)
            {  
                yref = Dialogos.EscribirCentradoDialogoAleatorio(Dialogos.DialogosGolpeFatal,ventana.LimiteInferior,16,50);
                yref = Dialogos.EscribirCentrado( ["felicidades, ganaste tu combate!"],ventana.LimiteInferior,yref,50);
                yref = Dialogos.EscribirCentrado( ["eres oficialmente campeon del torneo multiversal!"],ventana.LimiteInferior,yref,50);
                yref = Dialogos.EscribirCentrado( ["guardando tu personaje en el historial de ganadores..."],ventana.LimiteInferior,yref,50);
                Thread.Sleep(1500);
                PersonajeGanador ganador = new PersonajeGanador(personajePrincipal.Datos.Nombre,personajePrincipal.Datos.Especie,personajePrincipal.Datos.Origen,DateTime.Today);


                historialJSON.GuardarGanador(ganador,"historialGanadores.json");
                if(historialJSON.Existe("historialGanadores.json"))
                {
                    yref = Dialogos.EscribirCentrado( ["guardado exitosamente!"],ventana.LimiteInferior,yref,50);
                }
                yref = Dialogos.EscribirCentrado( ["..."],ventana.LimiteInferior,yref,50);
                yref = Dialogos.EscribirCentrado( Dialogos.DialogoPostFinal,ventana.LimiteInferior,yref,50);

                bandera3 =1;
                } else
                {
                    yref = Dialogos.EscribirCentrado( ["Perdiste tu batalla.","¿quieres volver a intentarlo?"],ventana.LimiteInferior,16,50);
                    string intento="";
                    do
                    {
                        yref = Dialogos.EscribirCentrado( ["-)Presiona 's' para reintentarlo","-)presiona 'n' para salir del juego"],ventana.LimiteInferior,yref,50);
                        Console.SetCursorPosition(ventana.LimiteInferior.X/2,yref);
                        intento = Console.ReadLine();
                            if (intento !="s" && intento!="n"&& intento!="N"&&intento !="S")
                            {
                                yref = Dialogos.EscribirCentrado( ["error,por favor ingresa un caracter valido!"],ventana.LimiteInferior,yref,50);
                            }
                        } while (intento !="s" && intento!="n"&& intento!="N"&&intento !="S");
                        if (intento=="n"||intento=="N")
                        {
                            yref = Dialogos.EscribirCentrado( ["presiona una tecla para salir...!"],ventana.LimiteInferior,yref,50);
                            Console.ReadKey();
                            Environment.Exit(0);
                        }else
                        {
                            yref = Dialogos.EscribirCentrado( ["Buena decision! presiona una tecla para reintentar el combate"],ventana.LimiteInferior,yref,50);
                            Console.ReadKey();
                        }
                }
                
        } while (bandera3==0);
        Console.Clear();
        ventana.DibujarMarco();
        AsciiJuego.DibujarCap5(48,5);
        if (personajePrincipal.Datos.Genero=="Femenino")
        {
            yref = Dialogos.EscribirCentrado(Dialogos.DialogoEpilogo1F,ventana.LimiteInferior,18,50);
            Console.Clear();
            ventana.DibujarMarco();
            Dialogos.EscribirCentrado(Dialogos.DialogoEpilogo2F,ventana.LimiteInferior,10,50);
            Console.ReadKey();
        }else
        {
            yref = Dialogos.EscribirCentrado(Dialogos.DialogoEpilogo1M,ventana.LimiteInferior,18,50);
            Console.Clear();
            ventana.DibujarMarco();
            Dialogos.EscribirCentrado(Dialogos.DialogoEpilogo2M,ventana.LimiteInferior,10,50);
            Console.ReadKey();
        }

        break;
    case 1:
        Console.Clear();
        ventana.DibujarMarco();
       List <PersonajeGanador> personajesGanadores =  historialJSON.LeerGanadores("historialGanadores.json");
       int k =1;
       int yref2=10;
       foreach (PersonajeGanador item in personajesGanadores)
       {
        
        string fechaSinHora = item.Hoy.ToString("yyyy-MM-dd");
        yref2= Dialogos.EscribirCentrado(["Personaje Ganador NUMERO: "+k,"nombre: "+item.Nombre,"Especie: "+item.Especie,"Origen:"+item.Origen,"Fecha de su victoria: "+fechaSinHora,"------------------------------------------------------------------"],limiteInferior,yref2,50);
        k++;
       }
        yref2=Dialogos.EscribirCentrado(["presione una tecla para salir..."],ventana.LimiteInferior,yref2,30);
        Console.ReadKey();

        break;
    case 2:
        int yref3=12;
        Console.Clear();
        ventana.DibujarMarco();
        yref3=Dialogos.EscribirCentrado(["Version:1.0.1","Creador: Francisco Jose Leccese","Hecho en c# con fines academicos"],ventana.LimiteInferior,yref3,50);
        yref3=Dialogos.EscribirCentrado(["presione una tecla para salir..."],ventana.LimiteInferior,yref3,30);
        Console.ReadKey();
        break;
    case 3:
        Environment.Exit(0);
        break;

}



static List <Personaje> PersistenciaDatosPersonajes(Ventana ventana,InformacionAPI PersonajesAPI)
{
    
    string nombreArchivo = "personajes.json";
    List <Personaje> ListaPersonajes;
    ListaPersonajes = new List<Personaje>();       
  
    if (PersonajesJson.Existe(nombreArchivo))
    {
        ListaPersonajes = PersonajesJson.LeerPersonajes(nombreArchivo);
        Console.Clear();
        ventana.DibujarMarco();      
    }else
    {
        for (int i = 0; i < 9; i++)
        {
            Personaje pjALE = FabricaDePersonajes.CrearPersonajeAleatorio(PersonajesAPI);
            ListaPersonajes.Add(pjALE);     
        }
            PersonajesJson.GuardarPersonajes(ListaPersonajes,nombreArchivo);
            Console.ReadKey();
            Console.Clear();
            ventana.DibujarMarco();
    }
    
    return ListaPersonajes;
}


static Personaje CrearPJprincipal(Ventana ventana)
{
    Console.Clear();
    ventana.DibujarMarco();
    Personaje personajePrincipal = FabricaDePersonajes.personajePrincipal();
    return personajePrincipal;
}
static void MostrarListaParticipantes1(Ventana ventana,List<Personaje> ListaPersonajes)
{
    AsciiJuego.DibujarMarcoDePelea(ventana.LimiteSuperior.X+36,24);
    Dialogos.EscribirEnCoordenadasConDesborde(["Nombre: "+ListaPersonajes[1].Datos.Nombre,"Especie: "+ListaPersonajes[1].Datos.Especie,"Origen: "+ListaPersonajes[1].Datos.Origen,"Destreza: "+ListaPersonajes[1].Caracteristicas.Destreza,"Fuerza: "+ListaPersonajes[1].Caracteristicas.Fuerza,"Armadura: "+ListaPersonajes[1].Caracteristicas.Armadura,"Salud: "+ListaPersonajes[1].Caracteristicas.Salud],ventana.LimiteSuperior.X+41,27,20,0);

    AsciiJuego.DibujarMarcoDePelea(ventana.LimiteSuperior.X+70,24);
    Dialogos.EscribirEnCoordenadasConDesborde(["Nombre: "+ListaPersonajes[2].Datos.Nombre,"Especie: "+ListaPersonajes[2].Datos.Especie,"Origen: "+ListaPersonajes[2].Datos.Origen,"Destreza: "+ListaPersonajes[2].Caracteristicas.Destreza,"Fuerza: "+ListaPersonajes[2].Caracteristicas.Fuerza,"Armadura: "+ListaPersonajes[2].Caracteristicas.Armadura,"Salud: "+ListaPersonajes[2].Caracteristicas.Salud],ventana.LimiteSuperior.X+75,27,20,0);

    AsciiJuego.DibujarMarcoDePelea(ventana.LimiteSuperior.X+104,24);
    Dialogos.EscribirEnCoordenadasConDesborde(["Nombre: "+ListaPersonajes[3].Datos.Nombre,"Especie: "+ListaPersonajes[3].Datos.Especie,"Origen: "+ListaPersonajes[3].Datos.Origen,"Destreza: "+ListaPersonajes[3].Caracteristicas.Destreza,"Fuerza: "+ListaPersonajes[3].Caracteristicas.Fuerza,"Armadura: "+ListaPersonajes[3].Caracteristicas.Armadura,"Salud: "+ListaPersonajes[3].Caracteristicas.Salud],ventana.LimiteSuperior.X+109,27,20,0);

    AsciiJuego.DibujarMarcoDePelea(ventana.LimiteSuperior.X+138,24);
    Dialogos.EscribirEnCoordenadasConDesborde(["Nombre: "+ListaPersonajes[4].Datos.Nombre,"Especie: "+ListaPersonajes[4].Datos.Especie,"Origen: "+ListaPersonajes[4].Datos.Origen,"Destreza: "+ListaPersonajes[4].Caracteristicas.Destreza,"Fuerza: "+ListaPersonajes[4].Caracteristicas.Fuerza,"Armadura: "+ListaPersonajes[4].Caracteristicas.Armadura,"Salud: "+ListaPersonajes[4].Caracteristicas.Salud],ventana.LimiteSuperior.X+142,27,20,0);

}

static void MostrarListaParticipantes2(Ventana ventana,List<Personaje> ListaPersonajes)
{
    AsciiJuego.DibujarMarcoDePelea(ventana.LimiteSuperior.X+10,5);
    Dialogos.EscribirEnCoordenadasConDesborde(["Nombre: "+ListaPersonajes[5].Datos.Nombre,"Especie: "+ListaPersonajes[5].Datos.Especie,"Origen: "+ListaPersonajes[5].Datos.Origen,"Destreza: "+ListaPersonajes[5].Caracteristicas.Destreza,"Fuerza: "+ListaPersonajes[5].Caracteristicas.Fuerza,"Armadura: "+ListaPersonajes[5].Caracteristicas.Armadura,"Salud: "+ListaPersonajes[5].Caracteristicas.Salud],ventana.LimiteSuperior.X+15,8,20,0);

    AsciiJuego.DibujarMarcoDePelea(ventana.LimiteSuperior.X+44,5);
    Dialogos.EscribirEnCoordenadasConDesborde(["Nombre: "+ListaPersonajes[6].Datos.Nombre,"Especie: "+ListaPersonajes[6].Datos.Especie,"Origen: "+ListaPersonajes[6].Datos.Origen,"Destreza: "+ListaPersonajes[6].Caracteristicas.Destreza,"Fuerza: "+ListaPersonajes[6].Caracteristicas.Fuerza,"Armadura: "+ListaPersonajes[6].Caracteristicas.Armadura,"Salud: "+ListaPersonajes[6].Caracteristicas.Salud],ventana.LimiteSuperior.X+49,8,20,0);

    AsciiJuego.DibujarMarcoDePelea(ventana.LimiteSuperior.X+78,5);
    Dialogos.EscribirEnCoordenadasConDesborde(["Nombre: "+ListaPersonajes[7].Datos.Nombre,"Especie: "+ListaPersonajes[7].Datos.Especie,"Origen: "+ListaPersonajes[7].Datos.Origen,"Destreza: "+ListaPersonajes[7].Caracteristicas.Destreza,"Fuerza: "+ListaPersonajes[7].Caracteristicas.Fuerza,"Armadura: "+ListaPersonajes[7].Caracteristicas.Armadura,"Salud: "+ListaPersonajes[7].Caracteristicas.Salud],ventana.LimiteSuperior.X+83,8,20,0);

    AsciiJuego.DibujarMarcoDePelea(ventana.LimiteSuperior.X+112,5);
    Dialogos.EscribirEnCoordenadasConDesborde(["Nombre: "+ListaPersonajes[8].Datos.Nombre,"Especie: "+ListaPersonajes[8].Datos.Especie,"Origen: "+ListaPersonajes[8].Datos.Origen,"Destreza: "+ListaPersonajes[8].Caracteristicas.Destreza,"Fuerza: "+ListaPersonajes[8].Caracteristicas.Fuerza,"Armadura: "+ListaPersonajes[8].Caracteristicas.Armadura,"Salud: "+ListaPersonajes[8].Caracteristicas.Salud],ventana.LimiteSuperior.X+116,8,20,0);

    AsciiJuego.DibujarMarcoDePelea(ventana.LimiteSuperior.X+146,5);
    Dialogos.EscribirEnCoordenadasConDesborde(["Nombre: "+ListaPersonajes[0].Datos.Nombre,"Especie: "+ListaPersonajes[0].Datos.Especie,"Origen: "+ListaPersonajes[0].Datos.Origen,"Destreza: "+ListaPersonajes[0].Caracteristicas.Destreza,"Fuerza: "+ListaPersonajes[0].Caracteristicas.Fuerza,"Armadura: "+ListaPersonajes[0].Caracteristicas.Armadura,"Salud: "+ListaPersonajes[0].Caracteristicas.Salud],ventana.LimiteSuperior.X+151,8,20,0);
}


static void Combate(Ventana ventana,Personaje personajePrincipal,Personaje adversario)
{
    Random random = new Random();
    int ataqueProtagonista = personajePrincipal.Caracteristicas.Destreza *personajePrincipal.Caracteristicas.Fuerza * personajePrincipal.Caracteristicas.Nivel;
    int ataqueAdversario =adversario.Caracteristicas.Destreza *adversario.Caracteristicas.Fuerza * adversario.Caracteristicas.Nivel;
    int defensaProtagonista = personajePrincipal.Caracteristicas.Armadura * personajePrincipal.Caracteristicas.Velocidad;
    int defensaAdversario = adversario.Caracteristicas.Armadura * adversario.Caracteristicas.Velocidad;
    int yref;
    int turno = 1;
    
    while (personajePrincipal.Caracteristicas.Salud >0 && adversario.Caracteristicas.Salud>0)
    {
        
        Console.Clear();
        ventana.DibujarMarco();
        AsciiJuego.DibujarMarcoDePelea(ventana.LimiteSuperior.X+52,ventana.LimiteSuperior.Y+5);
        AsciiJuego.DibujarVersus(ventana.LimiteSuperior.X+92,ventana.LimiteSuperior.Y+10);
        AsciiJuego.DibujarMarcoDePelea(ventana.LimiteSuperior.X+117,ventana.LimiteSuperior.Y+5);

        Dialogos.EscribirEnCoordenadasConDesborde(["Nombre: "+personajePrincipal.Datos.Nombre,"Especie: "+personajePrincipal.Datos.Especie,"Origen: "+personajePrincipal.Datos.Origen,"Destreza: "+personajePrincipal.Caracteristicas.Destreza,"Fuerza: "+personajePrincipal.Caracteristicas.Fuerza,"Armadura: "+personajePrincipal.Caracteristicas.Armadura,"Salud: "+personajePrincipal.Caracteristicas.Salud],ventana.LimiteSuperior.X+57,ventana.LimiteSuperior.Y+8,20,0);

        Dialogos.EscribirEnCoordenadasConDesborde(["Nombre: "+adversario.Datos.Nombre,"Especie: "+adversario.Datos.Especie,"Origen: "+personajePrincipal.Datos.Origen,"Destreza: "+adversario.Caracteristicas.Destreza,"Fuerza: "+adversario.Caracteristicas.Fuerza,"Armadura: "+adversario.Caracteristicas.Armadura,"Salud: "+adversario.Caracteristicas.Salud],ventana.LimiteSuperior.X+122,ventana.LimiteSuperior.Y+8,20,0);
        
        yref = Dialogos.EscribirCentrado( ["Turno numero: "+turno],ventana.LimiteInferior,27,150);
        if (adversario.Caracteristicas.Salud < 5 && turno >1)
        {
           yref= Dialogos.EscribirCentradoDialogoAleatorio(Dialogos.DialogosPocaVidaEnemigo,ventana.LimiteInferior,yref,50);
        }
        
        int efectividad = random.Next(1,101);
        int danio = Ataque(ataqueProtagonista,efectividad,defensaAdversario);
        if (efectividad >= 75)
        {
            yref = Dialogos.EscribirCentrado( [personajePrincipal.Datos.Nombre+" Realizo un ataque altamente efectivo"],ventana.LimiteInferior,yref,50);
            yref = Dialogos.EscribirCentrado( ["El daño provocado es:"+danio],ventana.LimiteInferior,yref,50);
            yref = Dialogos.EscribirCentradoDialogoAleatorio(Dialogos.DialogosGolpeAltaEfectividad,ventana.LimiteInferior,yref,50);
        } else
        {
            if (efectividad >= 35)
            {
                yref = Dialogos.EscribirCentrado( [personajePrincipal.Datos.Nombre+" Realizo un ataque con efectividad"],ventana.LimiteInferior,yref,50);
                yref = Dialogos.EscribirCentrado( ["El daño provocado es:"+danio],ventana.LimiteInferior,yref,50);
            } else
            {
                yref = Dialogos.EscribirCentrado( [personajePrincipal.Datos.Nombre+" Realizo un ataque con muy poca efectividad"],ventana.LimiteInferior,yref,50);
                yref = Dialogos.EscribirCentrado( ["El daño provocado es:"+danio],ventana.LimiteInferior,yref,50);
                yref = Dialogos.EscribirCentradoDialogoAleatorio(Dialogos.DialogosGolpePocaEfectividad,ventana.LimiteInferior,yref,50);
            }
        }
        adversario.Caracteristicas.Salud =adversario.Caracteristicas.Salud - danio;


        int efectividad2 = random.Next(1,101);
        int danio2 = Ataque(ataqueAdversario,efectividad2,defensaProtagonista);
        if (efectividad2 >= 75)
        {
            yref = Dialogos.EscribirCentrado( [adversario.Datos.Nombre+" Realizo un ataque altamente efectivo"],ventana.LimiteInferior,yref,50);
            yref = Dialogos.EscribirCentrado( ["El daño provocado es: "+danio2],ventana.LimiteInferior,yref,50);
        } else
        {
            if (efectividad2 >= 35)
            {
                yref = Dialogos.EscribirCentrado( [adversario.Datos.Nombre+" Realizo un ataque con efectividad"],ventana.LimiteInferior,yref,50);
                yref = Dialogos.EscribirCentrado( ["El daño provocado es: "+danio2],ventana.LimiteInferior,yref,50);
            } else
            {
                yref = Dialogos.EscribirCentrado( [adversario.Datos.Nombre+" Realizo un ataque con muy poca efectividad"],ventana.LimiteInferior,yref,50);
                yref = Dialogos.EscribirCentrado( ["El daño provocado es: "+danio2],ventana.LimiteInferior,yref,50);
            }
        }
        personajePrincipal.Caracteristicas.Salud =personajePrincipal.Caracteristicas.Salud - danio2;
        turno++;
        Thread.Sleep(3000);
        
    };
    
  
}

static int Ataque(int ataque,int efectividad,int defensa)
{
    int csteAjuste = 500;
    int danio = ((ataque*efectividad)-defensa)/csteAjuste;
    return danio;
}

