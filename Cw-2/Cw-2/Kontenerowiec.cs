using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cw_2
{
    internal class Kontenerowiec
    {
        public string nazwa { get; }
        public List<Kontener> kontenery { get; } = new List<Kontener>();  //lista kontenerow na statku
        private float maxPredkosc;
        private float maxLiczbaKontenerow;
        private float maxWagaKontenerow; //w tonach


        public Kontenerowiec(string nazwa, float predkosc, float liczbaKontenerow, float maxWagaKon)
        {
            this.nazwa = nazwa;
            this.maxPredkosc = predkosc;
            this.maxLiczbaKontenerow = liczbaKontenerow;
            this.maxWagaKontenerow = maxWagaKon;
        }

        public void DodajKontener(Kontener kontener)
        {
            kontenery.Add(kontener);
        }

        public void ZdejmijKontener()
        {
            string nazwaKontenera = Console.ReadLine();
            var kontener = kontenery.Find(k => k.nrSeryjny == nazwaKontenera);
            if (kontener == null)
            {
                Console.WriteLine("Kontener nie istnieje. Wciśnij Enter.");
                Console.ReadLine();
                return;
            }
            //TO DO: Remove
        }

        public void UsunKontener(int nrSeryjny)
        {
            for (int i = 0; i < kontenery.Count; i++)
            {
                if (kontenery[i].nrSeryjny.Equals(nrSeryjny))
                {
                    kontenery.RemoveAt(i);
                }
            }
        }

        public void ToString()
        {
            Console.WriteLine($"Nazwa: {nazwa} (speed: {maxPredkosc}, maxKont: {maxLiczbaKontenerow}, maxWaga: {maxWagaKontenerow}" );
        }

        public void WypiszKontenery()
        {
            foreach(Kontener i in kontenery)
            {
                i.ToString(); 
            }
        }
    }
}
