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

HttpClient client = new HttpClient();
var url = "https://rickandmortyapi.com/api/character";
HttpResponseMessage response = await client.GetAsync(url);
response.EnsureSuccessStatusCode(); 
string responseBody = await response.Content.ReadAsStringAsync();
InformacionAPI PersonajesAPI = JsonSerializer.Deserialize<InformacionAPI>(responseBody);
            
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

switch (indiceSelec)
{
    case 0:
        Random random = new Random();
         List <Personaje> ListaPersonajes = new List<Personaje>();
        ListaPersonajes = PersistenciaDatosPersonajes(ventana,PersonajesAPI);
        Console.ReadKey();
        Personaje personajePrincipal = CrearPJprincipal(ventana, PersonajesAPI); 
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
            yref = Dialogos.EscribirCentrado(Dialogos.DialogoInvitacion3F,ventana.LimiteInferior,yref,50);
            yref = Dialogos.EscribirCentrado(Dialogos.DialogoInvitacion4F,ventana.LimiteInferior,yref,50);
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
            yref = Dialogos.EscribirCentrado(Dialogos.DialogoCapitulo3parte2,ventana.LimiteInferior,28,50);
            Dialogos.EscribirCentrado(["presione una tecla para continuar..."],ventana.LimiteInferior,yref,0);
            Console.ReadKey();
            Console.Clear();
            ventana.DibujarMarco();
            yref = Dialogos.EscribirCentrado(Dialogos.DialogoCapitulo3parte3F,ventana.LimiteInferior,12,50);
            Thread.Sleep(3000);
            Console.Clear();
            ventana.DibujarMarco();
            AsciiJuego.DibujarCapitulo4(40,5);
            yref = Dialogos.EscribirCentrado(Dialogos.DialogoCapitulo4parte1F,ventana.LimiteInferior,20,50);
            yref = Dialogos.EscribirCentrado(["Presiona una tecla para comenzar los cuartos de final!"],ventana.LimiteInferior,yref,50);
            Console.ReadKey();

        }else
        {
            yref = Dialogos.EscribirCentrado(Dialogos.DialogoInvitacion3M,ventana.LimiteInferior,yref,50);
            yref = Dialogos.EscribirCentrado(Dialogos.DialogoInvitacion4M,ventana.LimiteInferior,yref,50);
            Console.Clear();
            ventana.DibujarMarco();
            AsciiJuego.DibujarCapitulo3(33,3);
            yref = Dialogos.EscribirCentrado(Dialogos.DialogoCapitulo3,ventana.LimiteInferior,12,50);
            MostrarListaParticipantes1(ventana,ListaPersonajes);
            Dialogos.EscribirCentrado(["presione una tecla para continuar..."],ventana.LimiteInferior,46,0);
            Console.ReadKey();
            Console.Clear();
            ventana.DibujarMarco();
            MostrarListaParticipantes2(ventana,ListaPersonajes);
            yref = Dialogos.EscribirCentrado(Dialogos.DialogoCapitulo3parte2,ventana.LimiteInferior,28,50);
            Dialogos.EscribirCentrado(["presione una tecla para continuar..."],ventana.LimiteInferior,yref,0);
            Console.ReadKey();
            Console.Clear();
            ventana.DibujarMarco();
            yref = Dialogos.EscribirCentrado(Dialogos.DialogoCapitulo3parte3,ventana.LimiteInferior,13,50);
            Thread.Sleep(3000);
            Console.Clear();
            ventana.DibujarMarco();
            AsciiJuego.DibujarCapitulo4(40,5);
            yref = Dialogos.EscribirCentrado(Dialogos.DialogoCapitulo4parte1M,ventana.LimiteInferior,20,50);
            yref = Dialogos.EscribirCentrado(["Presiona una tecla para comenzar los cuartos de final!"],ventana.LimiteInferior,yref,50);
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
                yref = Dialogos.EscribirCentradoDialogoAleatorio(Dialogos.DialogosGolpeFatal,ventana.LimiteInferior,16,50);
                yref = Dialogos.EscribirCentrado( ["felicidades, ganaste tu combate!"],ventana.LimiteInferior,yref,50);
                personajePrincipal.Caracteristicas.Salud = saludAux + 5;
                yref = Dialogos.EscribirCentrado( ["seras premiado con un aumento en tus estadisticas de salud!"],ventana.LimiteInferior,yref,50);
                yref = Dialogos.EscribirCentrado( ["...Salud +5"],ventana.LimiteInferior,yref,50);
                yref = Dialogos.EscribirCentrado( ["presiona una tecla para ver la tabla de semifinales!"],ventana.LimiteInferior,yref,50);
                bandera =1;
                } else
                {
                    yref = Dialogos.EscribirCentrado( ["Perdiste tu batalla.","¿quieres volver a intentarlo?"],ventana.LimiteInferior,16,50);
                    string intento="";
                    do
                    {
                        yref = Dialogos.EscribirCentrado( ["-)Presiona 's' para reintentarlo","-)presiona 'n' para salir del juego"],ventana.LimiteInferior,yref,50);
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
            Dialogos.EscribirEnCoordenadasConDesborde([""+personajePrincipal.Datos.Nombre,"  VS  ",""+listaPersonajesSemifinal[0].Datos.Nombre],72,18,14,0);
            Dialogos.EscribirEnCoordenadasConDesborde([""+listaPersonajesSemifinal[1].Datos.Nombre,"  VS  ",""+listaPersonajesSemifinal[2].Datos.Nombre],90,18,14,0);
            
            Console.WriteLine(listaPersonajesSemifinal.Count);
            foreach (var item in listaPersonajesSemifinal)
            {
                Console.WriteLine(item.Datos.Nombre);
            }
            Console.ReadKey();
        
        break;
    case 1:
        break;
    case 2:
        break;
    case 3:
        break;

}



static List <Personaje> PersistenciaDatosPersonajes(Ventana ventana,InformacionAPI PersonajesAPI)
{
    Console.Clear();
    ventana.DibujarMarco();
    string nombreArchivo = "personajes.json";
    List <Personaje> ListaPersonajes;
    ListaPersonajes = new List<Personaje>();       
    int Yref;
    if (PersonajesJson.Existe(nombreArchivo))
    {
        ListaPersonajes = PersonajesJson.LeerPersonajes(nombreArchivo);
        if (ListaPersonajes == null)
        {
            Console.WriteLine("personajes nulos"); 
        }
        Yref = Dialogos.EscribirCentrado(["Personajes cargados exitosamente desde el archivo existente!"],ventana.LimiteInferior,5,50);
        Console.Clear();
        ventana.DibujarMarco();      
    }else
    {
        for (int i = 0; i < 9; i++)
        {
            Personaje pjALE = FabricaDePersonajes.CrearPersonajeAleatorio(PersonajesAPI);
            ListaPersonajes.Add(pjALE);     
        }
        if (ListaPersonajes == null)
        {
            Console.WriteLine("personajes nulos"); 
        }
            PersonajesJson.GuardarPersonajes(ListaPersonajes,nombreArchivo);
            Yref = Dialogos.EscribirCentrado(["Personajes cargados exitosamente desde la API!"],ventana.LimiteInferior,5,50);
            Console.ReadKey();
            Console.Clear();
            ventana.DibujarMarco();
    }
    Yref =  Dialogos.EscribirCentrado(Dialogos.introduccion,ventana.LimiteInferior,Yref,30);
     Yref = Dialogos.EscribirCentrado(Dialogos.DialogoIntroduccion,ventana.LimiteInferior,Yref,30); //50
    AsciiJuego.EscribirTitulo(35,Yref+2);
    Yref = Dialogos.EscribirCentrado( ["Antes de comenzar tu aventura, por favor crea tu personaje","presiona una tecla para continuar"],ventana.LimiteInferior,42,50);
    Console.ReadKey();
    return ListaPersonajes;
}


static Personaje CrearPJprincipal(Ventana ventana,InformacionAPI PersonajesAPI)
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
            Dialogos.EscribirCentradoDialogoAleatorio(Dialogos.DialogosPocaVidaEnemigo,ventana.LimiteInferior,yref,50);
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



/*static void PersistenciaDatosPersonajes(Ventana ventana,InformacionAPI PersonajesAPI)
{
    Console.Clear();
    ventana.DibujarMarco();
    string nombreArchivo = "personajes.json";
            
    List <Personaje> ListaPersonajes;
    ListaPersonajes = new List<Personaje>();
    for (int i = 0; i < 9; i++)
    {
        Personaje pjALE = FabricaDePersonajes.CrearPersonajeAleatorio(PersonajesAPI);
        ListaPersonajes.Add(pjALE);     
    }
    if (ListaPersonajes == null)
    {
        Console.WriteLine("personajes nulos"); 
    }
    PersonajesJson.GuardarPersonajes(ListaPersonajes,nombreArchivo);       
    int Yref;
    if (PersonajesJson.Existe(nombreArchivo))
    {
        ListaPersonajes = PersonajesJson.LeerPersonajes(nombreArchivo);
        Yref = Dialogos.EscribirCentrado(["Personajes cargados exitosamente desde el archivo existente!"],ventana.LimiteInferior,5,0);      
    }else
    {
        PersonajesJson.GuardarPersonajes(ListaPersonajes,nombreArchivo);
        Yref = Dialogos.EscribirCentrado(["Personajes cargados exitosamente desde la API!"],ventana.LimiteInferior,5,0);
        Console.ReadKey();
    }
        Yref =  Dialogos.EscribirCentrado(Dialogos.introduccion,ventana.LimiteInferior,Yref,30);
        Yref = Dialogos.EscribirCentrado(Dialogos.DialogoIntroduccion,ventana.LimiteInferior,Yref,30); //50
        AsciiJuego.EscribirTitulo(35,Yref+2);
        Yref = Dialogos.EscribirCentrado( ["Antes de comenzar tu aventura, por favor crea tu personaje","presiona una tecla para continuar"],ventana.LimiteInferior,42,50);
        Console.ReadKey();
}*/