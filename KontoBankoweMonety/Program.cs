using System;
using KontoBankoweMonety;

namespace KontoBankoweMonety
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Tworzymy konto
            KontoBankowe kontoBankowe = new KontoBankowe();

            // Tworzymy automat
            Automat automat = new Automat();

            // Wrzucamy kilka monet naraz
            automat.WrzucMonety(kontoBankowe, "5 2 1 0.5 abc 3");

            Console.WriteLine();

            // Ponownie wrzucamy monety
            // Trzecia próba wrzucenia 5 zł pokaże brak miejsca.
            automat.WrzucMonety(kontoBankowe, "5 5 5 0.2 0.1");

            Console.WriteLine();

            // Wyświetlamy informacje o koncie
            Console.WriteLine("----- KONTO BANKOWE -----");

            Console.WriteLine($"Numer konta: {kontoBankowe.NumerKonta}");
            Console.WriteLine($"Stan konta: {kontoBankowe.StanKonta()} zł");

            Console.WriteLine();

            // Wyświetlamy historię wpłat
            kontoBankowe.PokazHistorieWplat();

            // Wyświetlamy monety w automacie
            automat.PokazMonety();

            Console.WriteLine();

            // Tworzymy drugie konto
            KontoBankowe drugieKonto = new KontoBankowe();

            Console.WriteLine("----- DRUGIE KONTO -----");

            Console.WriteLine($"Numer drugiego konta: {drugieKonto.NumerKonta}");

            Console.ReadKey();
        }
    }
}
