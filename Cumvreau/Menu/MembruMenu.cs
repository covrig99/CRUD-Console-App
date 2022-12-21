using AppService.Implementations;
using DataAccessLayer.DataStores;
using DataAccessLayer.DataStores.Repository;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cumvreau.Menu
{
    
    public class MembruMenu
    {
        private readonly  PersonRepository dapperRepository;
        private readonly  MembruService membruService;
        public MembruMenu()
        {
            dapperRepository = new PersonRepository("Server=.;Database=librarie;Trusted_Connection=True;");
            membruService = new MembruService(dapperRepository);
        }
        
        public static void Menu()
        {


            string optiunea = string.Empty;

            while (optiunea != "7")
            {
                Console.Clear();
                Console.WriteLine("1. Afiseaza lista membrilor");
                Console.WriteLine("2. Afiseaza membrul dupa ID-ul introdus");
                Console.WriteLine("3. Cautati membru dupa Prenume");
                Console.WriteLine("4. Introduceti un membru");
                Console.WriteLine("5. Update la Membru");
                Console.WriteLine("6. Stergeti un Membru");
                Console.WriteLine("7. Revenire la Meniul principal");
                Console.WriteLine("8. Iesire din program");
                Console.WriteLine("Alege operatiunea dorita: ");
                optiunea = Console.ReadLine();

                switch (optiunea)
                {
                    case "1":
                        Console.Clear();
                        
                        var membri = membruService.GetAllMembri();
                        

                        foreach (var membru in membri)
                        {

                            Console.Write(membru.Id);
                            Console.Write(" | ");
                            Console.Write(membru.Prenume);
                            Console.Write(" | ");
                            Console.Write(membru.Nume);
                            Console.Write(" | ");
                            Console.Write(membru.Adresa);
                            Console.Write(" | ");
                            Console.WriteLine(membru.NumarTelefon);
                            
                       
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
                        var rezultat = membruService.GetMembruByID(searchID);
                        if (rezultat != null)
                        {
                            Console.Write(rezultat.Id);
                            Console.Write(" | ");
                            Console.Write(rezultat.Prenume);
                            Console.Write(" | ");
                            Console.Write(rezultat.Nume);
                            Console.Write(" | ");
                            Console.Write(rezultat.Adresa);
                            Console.Write(" | ");
                            Console.WriteLine(rezultat.NumarTelefon);
                        }
                        else
                        {
                            Console.WriteLine("Membru cu acest Id nu a fost gasit!");
                        }
                        Console.WriteLine("Apasa orice tasta pentru a reveni la meniu");
                        Console.ReadKey(true);
                        break;

                    case "3":

                        Console.WriteLine("Introdu Prenumele");

                        var searchName = Console.ReadLine();
                        while (string.IsNullOrWhiteSpace(searchName))
                        {
                            Console.WriteLine("Ati introdus un Prenume gresit,Incercati din nou : ");
                            Console.Write("Prenume = ");
                            searchName = Console.ReadLine();
                        }
                        var rezultatPrenume = membruService.GetMembruByName(searchName);

                        if (rezultatPrenume.Count != 0)
                        {
                            foreach (var result in rezultatPrenume)
                            {
                                Console.Write(result.Id);
                                Console.Write(" | ");
                                Console.Write(result.Prenume);
                                Console.Write(" | ");
                                Console.WriteLine(result.NumarTelefon);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Nu exista membru cu acest nume");
                        }

                        Console.WriteLine("Apasa orice tasta pentru a reveni la meniu");
                        Console.ReadKey(true);
                        break;

                    case "4":
                        var membru1 = new Membru();
                        try
                        {
                            Console.Write("Id = ");
                            membru1.Id = int.Parse(Console.ReadLine());
                        }
                        catch
                        {
                            Console.WriteLine("Ati introdus un Id gresit,Incercati din nou : ");
                            Console.Write("Id = ");
                            membru1.Id = int.Parse(Console.ReadLine());
                        }


                        Console.Write("Prenume = ");

                        membru1.Prenume = Console.ReadLine();
                        while (string.IsNullOrWhiteSpace(membru1.Prenume))
                        {
                            Console.Write("Ati introdus un Prenume gresit,Incercati din nou : ");
                            Console.WriteLine("Prenume = ");
                            membru1.Prenume = Console.ReadLine();
                        }
                        Console.Write("Nume = ");
                        membru1.Nume = Console.ReadLine();
                        while (string.IsNullOrWhiteSpace(membru1.Nume))
                        {
                            Console.Write("Ati introdus un Nume gresit,Incercati din nou : ");
                            Console.WriteLine("Nume = ");
                            membru1.Nume = Console.ReadLine();
                        }

                        Console.Write("Adresa = ");
                        membru1.Adresa = Console.ReadLine();
                       
                        while (string.IsNullOrWhiteSpace(membru1.Adresa))
                        {
                            Console.Write("Ati introdus un Adresa gresit,Incercati din nou : ");
                            Console.WriteLine("Nume = ");
                            membru1.Adresa = Console.ReadLine();
                        }


                        Console.Write("Numar de telefon = ");
                        membru1.NumarTelefon = Console.ReadLine();
                        while (string.IsNullOrWhiteSpace(membru1.NumarTelefon))
                        {
                            Console.Write("Ati introdus un Numar de Telefon gresit,Incercati din nou : ");
                            Console.WriteLine("NumarTelefon = ");
                            membru1.NumarTelefon = Console.ReadLine();
                        }
                        membruService.AddPerson(membru1);
                        break;
                    case "5":

                        Console.Write("\nCare membru doriti sa il editati? ID = ");
                        int Id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Ce anume doriti sa editati?");
                        Console.WriteLine("1.Prenume?");
                        Console.WriteLine("2.Nume?");
                        Console.WriteLine("3.Adresa");
                        Console.WriteLine("4.Numarul de Telefon");
                        Console.Write("Alegeti optiunea: ");
                        string toUpdate = Console.ReadLine();
                        string Prenume = null;
                        string Nume = null;
                        string Adresa = null;
                        string NumarTelefon = null;

                        if (toUpdate.Contains('1'))
                        {
                            Console.Write("Prenume = ");
                            Prenume = Console.ReadLine();
                            while (string.IsNullOrWhiteSpace(Prenume))
                            {
                                Console.WriteLine("Ati introdus un Prenume gresit,Incercati din nou : ");
                                Console.Write("Prenume = ");
                                Prenume = Console.ReadLine();
                            }
                        }
                        if (toUpdate.Contains('2'))
                        {
                            Console.Write("Nume = ");
                            Nume = Console.ReadLine();
                            while (string.IsNullOrWhiteSpace(Nume))
                            {
                                Console.WriteLine("Ati introdus un Nume gresit,Incercati din nou : ");
                                Console.Write("Prenume = ");
                                Nume = Console.ReadLine();
                            }
                        }
                        if (toUpdate.Contains('3'))
                        {
                            Console.Write("Adresa = ");
                            Adresa = Console.ReadLine();
                            while (string.IsNullOrWhiteSpace(Adresa))
                            {
                                Console.WriteLine("Ati introdus o Adresa gresit,Incercati din nou : ");
                                Console.Write("Adresa = ");
                                Adresa = Console.ReadLine();
                            }
                        }
                        if (toUpdate.Contains('4'))
                        {
                            Console.Write("NumarTelefon = ");
                            NumarTelefon = Console.ReadLine();
                            while (string.IsNullOrWhiteSpace(NumarTelefon))
                            {
                                Console.WriteLine("Ati introdus un Numar de Telefon gresit,Incercati din nou : ");
                                Console.Write("NumarTelefon = ");
                                NumarTelefon = Console.ReadLine();
                            }
                        }

                        membruService.UpdateMembru(Id, Prenume, Nume, Adresa, NumarTelefon);
                        break;

                    case "6":

                        Console.Write("\nCare membru doriti sa il stergeti? Id = ");
                        int idsters;
                        while (!int.TryParse(Console.ReadLine(), out idsters))
                        {
                            Console.Write("Ati introdus un ID gresit,Incercati din nou : ");

                        }
                        membruService.DeleteMembru(idsters); break;

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
