using KontoBankoweMonety;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace KontoBankoweMonety
{
    internal class Automat
    {
        // Lista przyjmowanych nominałów - tylko tutaj zapisujemy ich wartości
        private readonly decimal[] _przyjmowaneMonety =
            new decimal[] { 5, 2, 1, 0.5m, 0.2m, 0.1m };

        // Liczba monet znajdujących się w automacie
        private int[] _iloscMonet = new int[6];

        // Maksymalna pojemność dla każdego nominału
        private int[] _pojemnoscMonet = new int[] { 2, 2, 2, 2, 2, 2 };

        // Łączna wartość monet w automacie
        private decimal _sumaMonet = 0;

        // Metoda przyjmująca wiele monet jednocześnie
        public void WrzucMonety(KontoBankowe konto, string monety)
        {
            string[] listaMonet = monety.Split(' ');

            int przyjete = 0;
            int zwrocone = 0;

            foreach (string moneta in listaMonet)
            {
                // Sprawdzamy, czy tekst jest liczbą
                bool czyUdanyParse = decimal.TryParse(
                    moneta,
                    NumberStyles.AllowDecimalPoint,
                    CultureInfo.InvariantCulture,
                    out decimal wartoscMonety);

                if (!czyUdanyParse)
                {
                    Console.WriteLine($"Nieudany odczyt: {moneta}");
                    zwrocone++;
                    continue;
                }

                bool czyPrzyjeta = false;

                // Sprawdzamy, czy nominał jest przyjmowany
                for (int i = 0; i < _przyjmowaneMonety.Length; i++)
                {
                    if (wartoscMonety == _przyjmowaneMonety[i])
                    {
                        czyPrzyjeta = true;

                        // Sprawdzamy, czy jest miejsce na monetę
                        if (_iloscMonet[i] < _pojemnoscMonet[i])
                        {
                            _iloscMonet[i]++;

                            konto.Wplac(wartoscMonety);

                            _sumaMonet += wartoscMonety;

                            Console.WriteLine($"Moneta przyjęta: {wartoscMonety} zł");

                            przyjete++;
                        }
                        else
                        {
                            Console.WriteLine($"Brak miejsca na monetę: {wartoscMonety} zł");

                            zwrocone++;
                        }

                        break;
                    }
                }

                // Jeżeli nominał nie znajduje się na liście
                if (!czyPrzyjeta)
                {
                    Console.WriteLine($"Zła moneta: {moneta}");
                    zwrocone++;
                }
            }

            Console.WriteLine();
            Console.WriteLine($"Przyjęto monet: {przyjete}");
            Console.WriteLine($"Zwrócono monet: {zwrocone}");
        }

        // Wyświetlanie monet w automacie
        public void PokazMonety()
        {
            Console.WriteLine();
            Console.WriteLine("----- MONETY W AUTOMACIE -----");

            for (int i = 0; i < _przyjmowaneMonety.Length; i++)
            {
                Console.WriteLine(
                    $"Monety {_przyjmowaneMonety[i]} zł: {_iloscMonet[i]}");
            }

            Console.WriteLine($"Łączna wartość monet: {_sumaMonet} zł");
        }
    }
}
