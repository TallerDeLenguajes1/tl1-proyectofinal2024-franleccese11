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
         List <Personaje> ListaPersonajes = new List<Personaje>();
        ListaPersonajes = PersistenciaDatosPersonajes(ventana,PersonajesAPI);
        Combate(ventana,ListaPersonajes[1],ListaPersonajes[2]);
        Console.ReadKey();
        Personaje personajePrincipal = CrearPJprincipal(ventana, PersonajesAPI);
        Console.ReadKey();
        Console.Clear();
        ventana.DibujarMarco();
        AsciiJuego.Capitulo2(40,5);
        int yref=16;
        yref = Dialogos.EscribirCentrado(Dialogos.DialogoInvitacion,ventana.LimiteInferior,yref,40);
        yref = Dialogos.EscribirCentrado(Dialogos.DialogoInvitacion2,ventana.LimiteInferior,yref,40);
        Console.Clear();
        ventana.DibujarMarco();
        yref = 5;
        if (personajePrincipal.Datos.Genero == "Femenino")
        {
            yref = Dialogos.EscribirCentrado(Dialogos.DialogoInvitacion3F,ventana.LimiteInferior,yref,40);
            yref = Dialogos.EscribirCentrado(Dialogos.DialogoInvitacion4F,ventana.LimiteInferior,yref,40);
        }else
        {
            yref = Dialogos.EscribirCentrado(Dialogos.DialogoInvitacion3M,ventana.LimiteInferior,yref,40);
            yref = Dialogos.EscribirCentrado(Dialogos.DialogoInvitacion4M,ventana.LimiteInferior,yref,40);
        }
        
        break;
    case 1:
        break;
    case 2:
        break;
    case 3:
        break;

}

Console.ReadKey();


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
        Yref = Dialogos.EscribirCentrado(["Personajes cargados exitosamente desde el archivo existente!"],ventana.LimiteInferior,5,0);      
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
            Yref = Dialogos.EscribirCentrado(["Personajes cargados exitosamente desde la API!"],ventana.LimiteInferior,5,0);
            Console.ReadKey();
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

static void Combate(Ventana ventana,Personaje personajePrincipal,Personaje adversario)
{
    // while (personajePrincipal.Caracteristicas.Salud >0 && adversario.Caracteristicas.Salud>0)
    //{
        Console.Clear();
        ventana.DibujarMarco();
        AsciiJuego.DibujarMarcoDePelea(ventana.LimiteSuperior.X+52,ventana.LimiteSuperior.Y+7);
        AsciiJuego.DibujarVersus(ventana.LimiteSuperior.X+92,ventana.LimiteSuperior.Y+10);
        AsciiJuego.DibujarMarcoDePelea(ventana.LimiteSuperior.X+117,ventana.LimiteSuperior.Y+7);
        Dialogos.EscribirCentrado( ["Antes de comenzar tu aventura, por favor crea tu personaje","presiona una tecla para continuar"],ventana.LimiteInferior,35,50);
        Console.ReadKey();
        
    // };
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