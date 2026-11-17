using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace KontoBankoweMonety
{
    internal class KontoBankowe
    {
        private static int _licznikKont = 0;

        private decimal _saldo;

        // Historia wpłat
        private List<decimal> _historiaWplat = new List<decimal>();

        public KontoBankowe()
        {
            _licznikKont++;
            NumerKonta = _licznikKont;
        }

        public int NumerKonta { get; }

        public decimal StanKonta()
        {
            return _saldo;
        }

        public void Wplac(decimal kwota)
        {
            _saldo += kwota;

            // Zapisujemy wpłatę w historii
            _historiaWplat.Add(kwota);
        }

        // Wyświetlanie historii wpłat
        public void PokazHistorieWplat()
        {
            Console.WriteLine("----- HISTORIA WPŁAT -----");

            Console.WriteLine($"Liczba wpłat: {_historiaWplat.Count}");

            foreach (decimal kwota in _historiaWplat)
            {
                Console.WriteLine($"Wpłata: {kwota} zł");
            }
        }
    }
}
