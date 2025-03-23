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
        public float maxPredkosc { get; }
        public float maxLiczbaKontenerow { get; }
        public float maxWagaKontenerow { get; } //w tonach


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

        public void UsunKontener(string nrSeryjny)
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
