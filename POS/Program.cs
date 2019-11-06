using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace POS
{
    class Program
    {
        static void Main(string[] args)
        {
            List<(string sifra, string naziv, int cena, int kolicina)> POS = new List<(string sifra, string naziv, int cena, int kolicina)>();
            List<(string pnaziv, int pkolicina, int pcena)> pPOS = new List<(string pnaziv, int pkolicina, int pcena)>();
            File.Exists("POS.txt");
            int ukupno = 0;


            while (true)
            {
                Console.Write("Meni\n" +
                    "*******************\n" +
                    "1 - Unos artikla\n" +
                    "2 - Pregled artikla\n" +
                    "3 - Izdavanja racuna\n" +
                    "4 - Izlaz\n" +
                    "Izaberite broj : \n"
                    + "*******************\n");

                char chose = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (chose)
                {

                    case '1':
                        Console.WriteLine("Unesite naziv artikla:  ");
                        string naziv = Console.ReadLine();
                        Console.WriteLine("Unesite sifru artikla: ");
                        string sifra = Console.ReadLine();
                        Console.WriteLine("Unesite cenu artikla: ");
                        int cena = int.Parse(Console.ReadLine());
                        Console.WriteLine("Unesite kolicinu artikla: ");
                        int kolicina = int.Parse(Console.ReadLine());
                        POS.Add((sifra, naziv, cena, kolicina));
                        break;
                    case '2':
                        Console.WriteLine("Cenovnik: ");
                        foreach ((string naziv, string sifra, int cena, int kolicina) broj in POS)
                        {
                            Console.WriteLine($"Naziv: {broj.naziv}\t Sifra: {broj.sifra}\t Cena: {broj.cena}\t Kolicina: {broj.kolicina}\t");
                            Console.ReadKey();
                        }

                        break;
                    case '3':
                        while (true)
                        {
                            Console.WriteLine("Unesite sifru artikla: ");
                            string unos = Console.ReadLine();
                            Console.WriteLine("Unesite kolicinu artikla: ");
                            int kol = int.Parse(Console.ReadLine());

                            for (int i = 0; i < POS.Count; i++)
                            {
                                if (POS[i].sifra.Contains(unos))
                                {
                                    string pnaziv = POS[i].naziv;
                                    int pkolicina = kol;
                                    int pcena = POS[i].cena * kol;
                                    ukupno += pcena;

                                    kol -= pkolicina;
                                    pPOS.Add((pnaziv, pkolicina, pcena));
                                }
                                else
                                {
                                    Console.WriteLine($"Nije moguce izvrsiti upis. Ne postoji artikal s sifrom: {unos}");
                                }
                            }
                            Console.WriteLine("Da li zelite da dodate artikal: \n 1-DA \n 2-NE \n");
                            int izbor = int.Parse(Console.ReadLine());
                            if (izbor != 1)
                                break; 
                        }
                        foreach ((string pnaziv, int pkolicina, int pcena) pbroj in pPOS)
                        {
                            Console.WriteLine($"Naziv: {pbroj.pnaziv}\t Kolicina: {pbroj.pkolicina}\t Cena: {pbroj.pcena}\n ******************");
                        }
                        Console.WriteLine($"Ukupno: {ukupno}\n ");
                        break;
                }

            }
            Console.ReadKey();
        }
    }
}
