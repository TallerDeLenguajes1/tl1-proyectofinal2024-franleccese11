// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http;
using System.Threading.Tasks;
using espacioPersonaje;




//   private string nombre;
//         private string genero;
//         private string especie;

//         private string origen;
//         private int velocidad;   //1 a 10
//         private int destreza;   //1 a 5
//         private int fuerza;  //1 a 10

//         private int nivel; //1 a 10
//         private int armadura; //1 a 100
//         private int salud; //1 a 100
//         private Arma arma;
 for (int i = 0; i < 10; i++)
 {
     Array valores = Enum.GetValues(typeof(Arma));
     int indiceAleatorio = random.Next(valores.Length);
     Arma arma = (Arma)valores.GetValue(indiceAleatorio);
     Console.WriteLine(arma);
 }  



