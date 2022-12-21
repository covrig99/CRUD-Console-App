using AppService.Implementations;
using DataAccessLayer.DataStores.Repository;
using DataAccessLayer.DataStores;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cumvreau.Menu
{
    public static class CarteMenu
    {
        public static void MenuCarte()
        {

            var dapperRepository = new CarteRepository("Server=.;Database=librarie;Trusted_Connection=True;");
            var dataStore = new DataStoreCarte("Server=.;Database=librarie;Trusted_Connection=True;");
            var cartemembruService = new CarteService(dapperRepository);
            string optiuneacarte = string.Empty;

            while (optiuneacarte != "7")
            {
                Console.Clear();
                Console.WriteLine("1. Afiseaza lista cartilor");
                Console.WriteLine("2. Afiseaza carte dupa ID-ul introdus");
                Console.WriteLine("3. Cautati o carte dupa titlu");
                Console.WriteLine("4. Introduceti o carte");
                Console.WriteLine("5. Update la Carte");
                Console.WriteLine("6. Stergeti o Carte");
                Console.WriteLine("7. Revenire la Meniul principal");
                Console.WriteLine("8. Iesire din program");
                Console.WriteLine("Alege operatiunea dorita: ");
                optiuneacarte = Console.ReadLine();

                switch (optiuneacarte)
                {
                    case "1":
                       
                        break;


                    case "2":
                        Console.Clear();
                        Console.WriteLine("Introdu Id-ul cautat");
                        int searchID;
                        while (!int.TryParse(Console.ReadLine(), out searchID))
                        {
                            Console.Write("Ati introdus un ID gresit,Incercati din nou : ");
                        }
                        var rezultat = cartemembruService.GetCarteByID(searchID);
                        if (rezultat != null)
                        {
                            Console.Write(rezultat.IdCarte);
                            Console.Write(" | ");
                            Console.Write(rezultat.Titlu);
                            Console.Write(" | ");
                            Console.Write(rezultat.Autor);
                            Console.Write(" | ");
                            Console.Write(rezultat.AnPublicare);
                            Console.Write(" | ");
                            Console.WriteLine(rezultat.Categorie);
                        }
                        else
                        {
                            Console.WriteLine("Eroare");
                        }
                        Console.WriteLine("Apasa orice tasta pentru a reveni la meniu");
                        Console.ReadKey(true);
                        break;
                    case "3":
                        Console.WriteLine("Introdu Titlu");

                        var searchName = Console.ReadLine();
                        while (string.IsNullOrWhiteSpace(searchName))
                        {
                            Console.WriteLine("Ati introdus un Titlu gresit,Incercati din nou : ");
                            Console.Write("Titlu = ");
                            searchName = Console.ReadLine();
                        }
                        var rezultatTitlu = cartemembruService.GetCarteByName(searchName);

                        if (rezultatTitlu.Count != 0)
                        {
                            foreach (var result in rezultatTitlu)
                            {
                                Console.Write(result.IdCarte);
                                Console.Write(" | ");
                                Console.Write(result.Titlu);
                                Console.Write(" | ");
                                Console.WriteLine(result.AnPublicare);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Nu exista carte cu acest nume");
                        }

                        Console.WriteLine("Apasa orice tasta pentru a reveni la meniu");
                        Console.ReadKey(true);
                        break;
                    case "4":
                        var carte1 = new Carte();
                        try
                        {
                            Console.Write("Id = ");
                            carte1.IdCarte = int.Parse(Console.ReadLine());
                        }
                        catch
                        {
                            Console.WriteLine("Ati introdus un Id gresit,Incercati din nou : ");
                            Console.Write("Id = ");
                            carte1.IdCarte = int.Parse(Console.ReadLine());
                        }
                        Console.Write("Titlu = ");
                        carte1.Titlu = Console.ReadLine();
                        while (string.IsNullOrWhiteSpace(carte1.Titlu))
                        {
                            Console.Write("Ati introdus un Titlu gresit,Incercati din nou : ");
                            Console.WriteLine("Titlu = ");
                            carte1.Titlu = Console.ReadLine();
                        }
                        Console.Write("Autor = ");
                        carte1.Autor = Console.ReadLine();
                        while (string.IsNullOrWhiteSpace(carte1.Autor))
                        {
                            Console.Write("Ati introdus un Autor gresit,Incercati din nou : ");
                            Console.WriteLine("Autor = ");
                            carte1.Autor = Console.ReadLine();
                        }
                        
                        Console.Write("AnPublicare = ");
                        int valoare;
                        while (!int.TryParse(Console.ReadLine(),out valoare))
                        {
                            Console.Write("Ati introdus un An gresit,Incercati din nou : ");
                        }
                        carte1.AnPublicare = valoare;
                        Console.Write("Categorie = ");
                        carte1.Categorie = Console.ReadLine();
                        while (string.IsNullOrWhiteSpace(carte1.Categorie))
                        {
                            Console.Write("Ati introdus o categorie gresita,Incercati din nou : ");
                            Console.WriteLine("Categorie = ");
                            carte1.Categorie = Console.ReadLine();
                        }
                        
                       cartemembruService.AddCarte(carte1);
                        break;
                    case "5":

                        Console.Write("\nCare carte doriti sa o editati? IdCarte = ");
                        int IdCarte;
                       
                        while (!int.TryParse(Console.ReadLine(), out IdCarte))
                        {
                            Console.Write("Ati introdus un ID gresit,Incercati din nou : ");
                        }
                        Console.WriteLine("Ce anume doriti sa editati?");
                        Console.WriteLine("1.Titlu?");
                        Console.WriteLine("2.Autor?");
                        Console.WriteLine("3.An Publicare?");
                        Console.WriteLine("4.Categorie");
                        Console.Write("Alegeti optiunea: ");
                        
                        string toUpdate = Console.ReadLine();
                        int AnPublicare = 0;
                        string Titlu = null;
                        string Autor = null;
                        string Categorie = null;
                        if (toUpdate.Contains('1'))
                        {
                           
                            Console.Write("Titlu = ");
                            Titlu = Console.ReadLine();
                            while (string.IsNullOrWhiteSpace(Titlu))
                            {
                                Console.WriteLine("Ati introdus un Titlu gresit,Incercati din nou : ");
                                Console.Write("Titlu = ");
                                Titlu = Console.ReadLine();
                            }
                        }
                        if (toUpdate.Contains('2'))
                        {
                            Console.Write("Autor = ");
                            Autor = Console.ReadLine();
                            while (string.IsNullOrWhiteSpace(Autor))
                            {
                                Console.WriteLine("Ati introdus un Autor gresit,Incercati din nou : ");
                                Console.Write("Autor = ");
                                Autor = Console.ReadLine();
                            }
                        }
                        if (toUpdate.Contains('3'))
                        {
                           
                            Console.Write("An Publicare = ");
                           int  valoare12;
                            while (!int.TryParse(Console.ReadLine(), out valoare12 ))
                            {
                                Console.Write("Ati introdus un An gresit,Incercati din nou : ");
                          
                            }
                             AnPublicare = valoare12;
                        }
                        if (toUpdate.Contains('4'))
                        {
                            Console.Write("Categorie = ");
                            Categorie = Console.ReadLine();
                            while (string.IsNullOrWhiteSpace(Categorie))
                            {
                                Console.WriteLine("Ati introdus o Categorie gresita,Incercati din nou : ");
                                Console.Write("Categorie = ");
                                Categorie = Console.ReadLine();
                            }
                        }

                        cartemembruService.UpdateCarte(IdCarte, AnPublicare, Titlu, Autor, Categorie);
                        break;

                    case "6":

                        Console.Write("\nCare membru doriti sa il stergeti? Id = ");
                        int idsters;
                        while (!int.TryParse(Console.ReadLine(), out idsters))
                        {
                            Console.Write("Ati introdus un ID gresit,Incercati din nou : ");

                        }
                        cartemembruService.DeleteCarte(idsters); break;

                    case "7":
                        Console.Clear();
                        break;

                    case "8":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Ati intodrus o optiune gresita.Apasa orice tasta pentru a reveni la menu.");
                    break;
                }
            }
      
        
        }
    public static void GetALLCArti()
        {
            Console.Clear();
            var cartemembruService = new CarteService(dapperRepository);
            var carti = cartemembruService.GetAllCarti();

            foreach (var carte in carti)
            {

                Console.Write(carte.IdCarte);
                Console.Write(" | ");
                Console.Write(carte.Titlu);
                Console.Write(" | ");
                Console.Write(carte.Autor);
                Console.Write(" | ");
                Console.Write(carte.AnPublicare);
                Console.Write(" | ");
                Console.WriteLine(carte.Categorie);
            }

            Console.WriteLine("Apasa orice tasta pentru a reveni la meniu");
            Console.ReadKey(true);
        }
    
    }
}
