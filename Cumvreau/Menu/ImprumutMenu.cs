using AppService.Implementations;
using DataAccessLayer.DataStores.Repository;
using DataAccessLayer.DataStores;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cumvreau.Menu
{
    public static class ImprumutMenu
    {
        public static void Menu()
        {
            var dapperRepository = new ImprumutRepository("Server=.;Database=librarie;Trusted_Connection=True;");
            var dataStore = new DataStoreImprumut("Server=.;Database=librarie;Trusted_Connection=True;");
            var imprumutmembruService = new ImprumutService(dapperRepository);
            string optiunea2 = string.Empty;

            while (optiunea2 != "7")
            {
                Console.Clear();
                Console.WriteLine("1. Afiseaza lista imprumuturilor");
                Console.WriteLine("2. Afiseaza imprumuntul dupa Id-ul membrului");
                Console.WriteLine("3. Cautati un imprumut dupa data");
                Console.WriteLine("4. Introduceti un imprumut");
                Console.WriteLine("5. Update la imprumut");
                Console.WriteLine("6. Stergeti un imprumut");
                Console.WriteLine("7. Revenire la Meniul principal");
                Console.WriteLine("8. Iesire din program");
                optiunea2 = Console.ReadLine();

                switch (optiunea2)
                {
                    case "1":
                        Console.Clear();
                        var imprumuturi = imprumutmembruService.GetAllImprumuturi();

                        foreach (var imprumut in imprumuturi)
                        {

                            Console.Write(imprumut.MembruId);
                            Console.Write(" | ");
                            Console.Write(imprumut.CarteId);
                            Console.Write(" | ");
                            Console.WriteLine(imprumut.DataImprumut);

                        }

                        Console.WriteLine("Apasa orice tasta pentru a reveni la meniu");
                        Console.ReadKey(true);
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("Introdu Id-ul cautat");
                        int searchID;
                        while (!int.TryParse(Console.ReadLine(), out searchID))
                        {
                            Console.Write("Ati introdus un ID gresit,Incercati din nou : ");
                        }
                        var rezultat = imprumutmembruService.GetImprumutByID(searchID);
                        if (rezultat != null)
                        {
                            Console.Write(rezultat.MembruId);
                            Console.Write(" | ");
                            Console.Write(rezultat.CarteId);
                            Console.Write(" | ");
                            Console.Write(rezultat.DataImprumut);
                            Console.WriteLine(" | ");

                        }
                        else
                        {
                            Console.WriteLine("Eroare");
                        }
                        Console.WriteLine("Apasa orice tasta pentru a reveni la meniu");
                        Console.ReadKey(true);
                        break;

                    case "3":
                        Console.WriteLine("Introdu data");

                        var searchName = DateTime.MinValue;

                        while (!DateTime.TryParse(Console.ReadLine(), out searchName))
                        {
                            Console.Write("Ati introdus un An gresit,Incercati din nou : ");
                        }

                        var rezultatData = imprumutmembruService.GetImprumutByDate(searchName);

                        if (rezultatData.Count != 0)
                        {
                            foreach (var result in rezultatData)
                            {
                                Console.Write(result.ImprumutId);
                                Console.Write(" | ");
                                Console.Write(result.MembruId);
                                Console.Write(" | ");
                                Console.Write(result.CarteId);
                                Console.Write(" | ");
                                Console.WriteLine(result.DataImprumut);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Nu exista imprumuturi efectuate pe aceasta data");
                        }

                        Console.WriteLine("Apasa orice tasta pentru a reveni la meniu");
                        Console.ReadKey(true);
                        break;


                    case "4":
                        var imprumut1 = new Imprumut();
                        try
                        {
                            Console.Write("MembruId = ");
                            imprumut1.MembruId = int.Parse(Console.ReadLine());
                        }
                        catch
                        {
                            Console.WriteLine("Ati introdus un Id gresit,Incercati din nou : ");
                            Console.Write("MembruId = ");
                            imprumut1.MembruId = int.Parse(Console.ReadLine());
                        }

                        Console.Write("CarteId = ");
                        int valoare;
                        while (!int.TryParse(Console.ReadLine(), out valoare))
                        {
                            Console.Write("Ati introdus un CarteId gresit,Incercati din nou : ");
                        }

                        imprumut1.CarteId = valoare;
                        Console.Write("Data = ");
                        var valdata = DateTime.MinValue;
                        while (!DateTime.TryParse(Console.ReadLine(), out valdata)) 
                        {
                            Console.Write("Ati introdus o data gresita,Incercati din nou : ");
                        }

                        imprumut1.DataImprumut = valdata;
                        imprumutmembruService.AddImprumut(imprumut1);
                        break;

                    case "5":

                        Console.Write("\nCare imprumut doriti sa il editati? IdImprumut = ");
                        int IdImprumut = int.Parse(Console.ReadLine());
                        Console.WriteLine("Ce anume doriti sa editati?");
                        Console.WriteLine("1.Id?");
                        Console.WriteLine("2.Membru id?");
                        Console.WriteLine("3.Carte id?");
                        Console.WriteLine("4.Data Imprumutului");
                        Console.Write("Alegeti optiunea: ");
                        string toUpdate = Console.ReadLine();
                        string ImprumutId = null;
                        string MembruId = null;
                        string CarteId = null;
                        string Data = null;

                        if (toUpdate.Contains('1'))
                        {
                            Console.Write("ImprumutId = ");
                            int valoareupd;
                            while (!int.TryParse(Console.ReadLine(), out valoareupd))
                            {
                                Console.Write("Ati introdus un ImprumutId  gresit,Incercati din nou : ");
                            }
                            ImprumutId = Convert.ToString(valoareupd);
                           
                        }
                        if (toUpdate.Contains('2'))
                        {
                            Console.Write("Id = ");
                            int valoareupd;
                            while (!int.TryParse(Console.ReadLine(), out valoareupd))
                            {
                                Console.Write("Ati introdus un MembruId gresit,Incercati din nou : ");
                            }
                            MembruId = Convert.ToString(valoareupd);    
                        }
                        if (toUpdate.Contains('3'))
                        {
                            Console.Write("CarteId = ");
                            int valoareupd;
                            while (!int.TryParse(Console.ReadLine(), out valoareupd))
                            {
                                Console.Write("Ati introdus un MembruId gresit,Incercati din nou : ");
                            }
                            CarteId = Convert.ToString(valoareupd);
                        }
                
                        if (toUpdate.Contains('4'))
                        {
                            Console.Write("Data = ");
                            var valoaredata = DateTime.MinValue;
                            while (!DateTime.TryParse(Console.ReadLine(), out valoaredata))
                            {
                                Console.Write("Ati introdus un CarteId gresit,Incercati din nou : ");
                            }

                            Data = Convert.ToString(valoaredata);
                        }

                        imprumutmembruService.UpdateImprumut(ImprumutId, MembruId, CarteId, Data);
                        break;
                    case "6":

                        Console.Write("\nCare membru doriti sa il stergeti? Id = ");
                        int idsters;

                        while (!int.TryParse(Console.ReadLine(), out idsters))
                        {
                            Console.Write("Ati introdus un ID gresit,Incercati din nou : ");

                        }
                        imprumutmembruService.DeleteImprumut(idsters);
                        break;
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
    }
}
