using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cw_2
{
    internal class Kontener : IHazardNotifier
    {
        //Wszystkie
        private float masaLadunku;
        private float wysokosc;
        private float wagaWlasna;
        private float glebokosc;
        public string nrSeryjny { get; } = "KON-";
        private static int IdCount=0;
        private float maxLadownosc;
        public string rodzaj { get; }

        //Plyny
        public bool niebezpieczny{ get; set; } // Auto-property
        //Gaz
        public float cisnienie{ get; set; }
        //Chlodniczy
        public string rodzajProduktu{ get; set; }
        public float aktualnaTemp{ get; set; }
        public float wymaganaTemp{ get; set; }

        public Kontener(float wys, float wagaWlas, float gleb, float maxLad, string rodzaj)
        {
            //Wszystkie
            this.wysokosc = wys;
            this.wagaWlasna = wagaWlas;
            this.glebokosc = gleb;
            this.maxLadownosc = maxLad;
            this.nrSeryjny += rodzaj + "-"+IdCount++;
            this.rodzaj = rodzaj;
        }

        public void Zaladunek(float ladunek)
        {
            Console.WriteLine($"Zaladunek {nrSeryjny}");
            if (rodzaj.Equals("L")) //plyny
            {
                if (niebezpieczny)
                {
                    Console.WriteLine("Kontener z niebezpiecznym ladunkiem - do 50% pojemnosci: "+maxLadownosc/2 + " kg.");
                    if (ladunek > maxLadownosc / 2)
                    {
                        this.masaLadunku = maxLadownosc / 2;
                        Console.WriteLine("Zaladowano tylko: "+ masaLadunku+"kg ladunku.");
                        NotifyHazard();
                        Console.ReadLine();
                    }
                    else
                    {
                        this.masaLadunku = ladunek;
                    }
                }
                else
                {
                    Console.WriteLine("Kontener z bezpiecznym ladunkiem - do 90% pojemnosci: " + maxLadownosc*0.9 + " kg.");
                    if (ladunek > maxLadownosc * 0.9)
                    {
                        this.masaLadunku = (float)(maxLadownosc * 0.9);
                        Console.WriteLine("Zaladowano tylko: " + masaLadunku + "kg ladunku.");
                        NotifyHazard();
                        Console.ReadLine();
                    }
                    else
                    {
                        this.masaLadunku = ladunek;
                    }
                }
            }else if (rodzaj.Equals("G")) //gaz
            {
                Console.WriteLine("Podaj cisnienie w atmosferach: ");
                this.cisnienie = float.Parse(Console.ReadLine());

                if (ladunek > maxLadownosc)
                {
                    this.masaLadunku = maxLadownosc;
                    Console.WriteLine("Kontener zaladowany w 100%.");
                    NotifyHazard();
                    Console.ReadLine();
                } else
                {
                    this.masaLadunku = ladunek;
                }
            }
            else if (rodzaj.Equals("C")) //chlodniczy
            {
                Console.Write("Podaj rodzaj produktu: ");
                string rodzajLadunku = Console.ReadLine();
                if (!rodzajLadunku.Equals(rodzajProduktu))
                {
                    Console.WriteLine("Bledny rodzaj produktu.");
                    NotifyHazard();
                    Console.ReadLine();
                }
                else if (aktualnaTemp < wymaganaTemp)
                {
                    Console.WriteLine("Temperatura kontenera za niska");
                    Console.ReadLine();
                }
                else 
                {
                    if (ladunek > maxLadownosc)
                    {
                        this.masaLadunku = maxLadownosc;
                        Console.WriteLine("Kontener zaladowany w 100%.");
                        NotifyHazard();
                        Console.ReadLine();
                    }
                    else
                    {
                        this.masaLadunku = ladunek;
                    }
                }
            }
        }

        public void Oproznienie()
        {
            if (rodzaj.Equals("G"))//przy oproznianiu gazu zostawiamy 5%
            {
                masaLadunku = (float)(masaLadunku * 0.05);
            }
            else
            {
                masaLadunku = 0;
            }
        }

        public void NotifyHazard()
        {
            //throw new Exception("Proba wykonania niebezpiecznej sytuacji. Kontener: "+this.nrSeryjny);
            Console.WriteLine("Proba wykonania niebezpiecznej sytuacji. Kontener: "+this.nrSeryjny);
        }

        public void ToString()
        {
            string wynik = $"Nr Seryjny: {nrSeryjny} " +
                           $"(Masa Ładunku: {masaLadunku} kg, " +
                           $"Wysokość: {wysokosc} m, " +
                           $"Waga Własna: {wagaWlasna} kg, " +
                           $"Głębokość: {glebokosc} m, " +
                           $"Maksymalna Ładowność: {maxLadownosc} kg, ";

            // Warunki dla różnych typów ładunków
            if (rodzaj == "L")
            {
                wynik += $"Niebezpieczny: {niebezpieczny})";
            }
            else if (rodzaj == "G")
            {
                wynik += $"Ciśnienie: {cisnienie} atmosfer)";
            }
            else if (rodzaj == "C")
            {
                wynik += $"Rodzaj Produktu: {rodzajProduktu}, " +
                         $"Aktualna Temperatura: {aktualnaTemp} C, " +
                         $"Wymagana Temperatura: {wymaganaTemp} C)";
            }

            Console.WriteLine(wynik);
        }
    }
}
