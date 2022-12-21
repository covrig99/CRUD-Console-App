using AppService.Implementations;
using Domain.Models;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;
using DataAccessLayer.DataStores;
using Cumvreau.Menu;

var posibility = string.Empty;

while (posibility != "4")
{
    Console.WriteLine("BIBLIOTECA");
    Console.WriteLine("1.Compartimentul Membri");
    Console.WriteLine("2.Compartimentul Carti");
    Console.WriteLine("3.Compartimentul Imprumuturi");
    Console.WriteLine("4.Inchidere Program");

    Console.Write("\nAlege o optiune: ");
    posibility = Console.ReadLine();

    switch(posibility)
    {
        case "1":
            MembruMenu.Menu();
            break;
        case "2":
            CarteMenu.MenuCarte();
            break;
        case "3":
            ImprumutMenu.Menu();
            break;
        case "4":
            break;
        default:
            Console.WriteLine("Ati intodrus o optiune gresita.Apasa orice tasta pentru a reveni la menu.");
            break;






    }
}



