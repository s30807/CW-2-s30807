using Cw_2;

class Kontenery
{
    static List<Kontenerowiec> kontenerowce = new List<Kontenerowiec>();
    static List<Kontener> kontenery = new List<Kontener>();
    static void Main(string[] args)
    { 
        while (true)
        {
            Console.Clear();

            //Wypisanie Ekranu glownego
            if (kontenerowce.Count == 0)
            {
                Console.WriteLine("Brak");
            }
            else
            {
                Console.WriteLine("Lista kontenerowcow: ");
                foreach (Kontenerowiec k in kontenerowce)
                {
                    k.ToString();
                }
                Console.WriteLine("Lista kontenerow: ");
                if (kontenery.Count == 0)
                {
                    Console.WriteLine("Brak");
                }
                else 
                {
                    foreach (Kontener k in kontenery)
                    {
                        k.ToString();
                    } 
                }
                    
            }

            //Mozliwe akcje
            Console.WriteLine("Akcje:");
            // Dodaj kontenerowiec - dostepne zawsze
            Console.WriteLine("1. Dodaj kontenerowiec");
            // Usun kontenerowiec - mozliwe kiedy jest minimum jeden kontenerowiec
            // Dodaj kontener - mozliwe kiedy jest minimum jeden kontenerowiec
            if (kontenerowce.Count > 0)
            {
                Console.WriteLine("2. Usun kontenerowiec");
                Console.WriteLine("3. Dodaj kontener");
            }
            // Usun kontener - mozliwe kiedy jest minimum jeden kontener
            // Dodaj kontener na statek - mozliwe kiedy istnieje min 1 kontenerowiec i min 1 kontener
            // Zdejmij kontener ze statku - mozliwe kiedy istnieje min 1 kontenerowiec i min 1 kontener
            // Zaladuj kontener - mozliwe kiedy istnieje min 1 kontener
            // Oproznij kontener - mozliwe kiedy istnieje min 1 kontener
            if (kontenery.Count > 0)
            {
                Console.WriteLine("4. Usun kontener");
                if (kontenerowce.Count > 0)
                {
                    Console.WriteLine("5. Dodaj kontener na statek");
                    Console.WriteLine("6. Zdejmij kontener ze statku");
                }
                Console.WriteLine("7. Zaladuj kontener");
                Console.WriteLine("8. Oproznij kontener");
            }
            // Zastap kontener - mozliwe kiedy istnieje min 2 kontenery i min 1 kontenerowiec
            if (kontenery.Count >= 2)
            {
                if (kontenerowce.Count > 0)
                {
                    Console.WriteLine("9. Zastap kontener");
                }
            }
            // Przenies kontener - mozliwe kiedy istnieje min 1 kontener i min 2 kontenerowce
            if (kontenerowce.Count >= 2)
            {
                if (kontenery.Count > 0)
                {
                    Console.WriteLine("10. Przenies kontener");
                }
            }
            if (kontenerowce.Count > 0)
            {
                Console.WriteLine("11. Informacje o kontenerowcu");
            }


            //Podjeta akcja
            string akcja = Console.ReadLine();

            switch (akcja)
            {
                case "1":
                    DodajKontenerowiec();
                    break;
                case "2":
                    UsunKontenerowiec();
                    break;
                case "3":
                    StworzKontener();
                    break;
                case "4":
                    UsunKontener();
                    break;
                case "5":
                    DodajKontener();
                    break;
                case "6":
                    ZdejmijKontener();
                    break;
                case "7":
                    ZaladujKontener();
                    break;
                case "8":
                    OproznijKontener();
                    break;
                case "9":
                    ZastapKontener();
                    break;
                case "10":
                    PrzeniesKontener();
                    break;
                case "11":
                    WypiszInformacjeOStatku();
                    break;
                default:
                    Console.WriteLine("Nieznana akcja. Wciśnij Enter, aby kontynuować.");
                    Console.ReadLine();
                    break;
            }

        }


        static void DodajKontenerowiec()
        {
            Console.Write("Podaj nazwę statku: ");
            string nazwa = Console.ReadLine();
            Console.Write("Podaj maksymalną prędkość: ");
            float predkosc = float.Parse(Console.ReadLine());
            Console.Write("Podaj maksymalną liczbę kontenerów: ");
            float maxKont = float.Parse(Console.ReadLine());
            Console.Write("Podaj maksymalną wagę ładunku (w tonach): ");
            float maxWaga = float.Parse(Console.ReadLine());

            kontenerowce.Add(new Kontenerowiec(nazwa, predkosc, maxKont, maxWaga));
            Console.WriteLine("Dodano nowy kontenerowiec.");
        }

        static void UsunKontenerowiec()
        {
            Console.Write("Podaj nazwę statku do usunięcia: ");
            string nazwa = Console.ReadLine();
            var statek = kontenerowce.Find(k => k.nazwa == nazwa);
            if (statek != null)
            {
                kontenerowce.Remove(statek);
                Console.WriteLine("Usunięto kontenerowiec.");
            }
            else
                Console.WriteLine("Nie znaleziono statku.");
        }

        static void StworzKontener()
        {
            Console.Write("Podaj wysokość kontenera: ");
            float wys = float.Parse(Console.ReadLine());
            Console.Write("Podaj wagę własną kontenera: ");
            float waga = float.Parse(Console.ReadLine());
            Console.Write("Podaj głębokość kontenera: ");
            float gleb = float.Parse(Console.ReadLine());
            Console.Write("Podaj maksymalną ładowność kontenera: ");
            float maxLad = float.Parse(Console.ReadLine());
            Console.Write("Podaj typ kontenera (L/G/C): ");
            string typ = Console.ReadLine().ToUpper();

            Kontener nowyKontener = new Kontener(wys, waga, gleb, maxLad, typ);

            if (typ.Equals("C"))
            {
                Console.WriteLine("Podaj rodzaj produktu (mieso,banan,itp.)");
                nowyKontener.rodzajProduktu = Console.ReadLine();

                Console.WriteLine("Podaj minimalna wymagana temperature");
                nowyKontener.wymaganaTemp = float.Parse(Console.ReadLine());

                Console.WriteLine("Podaj aktualna temperature");
                nowyKontener.aktualnaTemp = float.Parse(Console.ReadLine());
            }

            kontenery.Add(nowyKontener);
            //switch (typ) //TODO
            //{
            //    case "L": Console.WriteLine("Plyn bezpieczny? (tak/nie)");
            //        string typ2 = Console.ReadLine();
            //        if (typ2.Equals("tak")){ nowyKontener.niebezpieczny = false;  } else { nowyKontener.niebezpieczny = true; }
            //            break;
            //    //case "G": Console.WriteLine(

            //}


        }

        static void UsunKontener()
        {
            Console.Write("Podaj nazwę kontenera do usunięcia: ");
            string nazwaKontenera = Console.ReadLine();
            var kontener = kontenery.Find(k => k.nrSeryjny == nazwaKontenera);
            if (kontener != null)
            {
                kontenery.Remove(kontener);
                Console.WriteLine("Usunięto kontenerowiec.");
            }
            else
                Console.WriteLine("Nie znaleziono statku.");
        }

        static void DodajKontener()
        {
            //ustaklenie kontenera
            Console.Write("Podaj nazwę kontenera, który chcesz dodać na kontenerowiec: ");
            string nazwaKontenera = Console.ReadLine();
            var kontener = kontenery.Find(k => k.nrSeryjny == nazwaKontenera);
            if (kontener == null)
            {
                Console.WriteLine("Kontener nie istnieje. Wciśnij Enter.");
                Console.ReadLine();
                return;
            }

            //ustaklenie kontenerowca
            Console.Write("Podaj nazwę statku, na który dodać kontener: ");
            string nazwaStatku = Console.ReadLine();
            var statek = kontenerowce.Find(k => k.nazwa == nazwaStatku);
            if (statek == null)
            {
                Console.WriteLine("Statek nie istnieje. Wciśnij Enter.");
                Console.ReadLine();
                return;
            }

            statek.DodajKontener(kontener);
            Console.WriteLine("Kontener dodany.");
        }

        static void ZdejmijKontener()
        {
            //ustaklenie kontenerowca
            Console.Write("Podaj nazwę statku, z ktorego chcesz zdjac: ");
            string nazwaStatku = Console.ReadLine();
            var statek = kontenerowce.Find(k => k.nazwa == nazwaStatku);
            if (statek == null)
            {
                Console.WriteLine("Statek nie istnieje. Wciśnij Enter.");
                Console.ReadLine();
                return;
            }

            //ustaklenie kontenera
            Console.Write("Podaj nazwę kontenera, który chcesz zdjac: ");
            string nazwaKontenera = Console.ReadLine();
            var kontener = kontenery.Find(k => k.nrSeryjny == nazwaKontenera);
            if (kontener == null)
            {
                Console.WriteLine("Kontener nie istnieje. Wciśnij Enter.");
                Console.ReadLine();
                return;
            }

            statek.UsunKontener(kontener.nrSeryjny);
        }

        static void ZaladujKontener()
        {
            Console.Write("Podaj nazwę kontenera, do ktorego chcesz cos zaladowac: ");
            string nazwaKontenera = Console.ReadLine();
            var kontener = kontenery.Find(k => k.nrSeryjny == nazwaKontenera);
            if (kontener == null)
            {
                Console.WriteLine("Kontener nie istnieje. Wciśnij Enter.");
                Console.ReadLine();
                return;
            }
            Console.WriteLine("Podaj mase ladunku: ");
            float masa = float.Parse(Console.ReadLine());
            kontener.Zaladunek(masa);
        }

        static void OproznijKontener()
        {
            Console.Write("Podaj nazwę kontenera, ktorego chcesz oproznic: ");
            string nazwaKontenera = Console.ReadLine();
            var kontener = kontenery.Find(k => k.nrSeryjny == nazwaKontenera);
            if (kontener == null)
            {
                Console.WriteLine("Kontener nie istnieje. Wciśnij Enter.");
                Console.ReadLine();
                return;
            }

            kontener.Oproznienie();
        }

        static void ZastapKontener()
        {
            //ustaklenie kontenerowca
            Console.Write("Podaj nazwę statku, z na ktorym chcesz zamienic kontenery: ");
            string nazwaStatku = Console.ReadLine();
            var statek = kontenerowce.Find(k => k.nazwa == nazwaStatku);
            if (statek == null)
            {
                Console.WriteLine("Statek nie istnieje. Wciśnij Enter.");
                Console.ReadLine();
                return;
            }

            //ustaklenie kontenera
            Console.Write("Podaj nazwę kontenera, który chcesz zdjac: ");
            string nazwaKontenera = Console.ReadLine();
            var kontener = kontenery.Find(k => k.nrSeryjny == nazwaKontenera);
            if (kontener == null)
            {
                Console.WriteLine("Kontener nie istnieje. Wciśnij Enter.");
                Console.ReadLine();
                return;
            }

            //ustaklenie nowego kontenera
            Console.Write("Podaj nazwę kontenera, który chcesz zaladowac: ");
            string nazwaNowegoKontenera = Console.ReadLine();
            var nowyKontener = kontenery.Find(k => k.nrSeryjny == nazwaNowegoKontenera);
            if (nowyKontener == null)
            {
                Console.WriteLine("Kontener nie istnieje. Wciśnij Enter.");
                Console.ReadLine();
                return;
            }

            statek.UsunKontener(kontener.nrSeryjny);
            
            foreach(Kontenerowiec k in kontenerowce)
            {
                foreach(Kontener i in k.kontenery)
                {
                    if (i.nrSeryjny == nowyKontener.nrSeryjny) ;
                    k.UsunKontener(i.nrSeryjny);
                }
            }
            
            statek.DodajKontener(nowyKontener);


        }

        static void PrzeniesKontener()
        {
            //ustaklenie kontenera
            Console.Write("Podaj nazwę kontenera, którego chcesz przeniesc: ");
            string nazwaKontenera = Console.ReadLine();
            var kontener = kontenery.Find(k => k.nrSeryjny == nazwaKontenera);
            if (kontener == null)
            {
                Console.WriteLine("Kontener nie istnieje. Wciśnij Enter.");
                Console.ReadLine();
                return;
            }
            //ustaklenie kontenerowca
            Console.Write("Podaj nazwę statku, z ktorego chcesz zabrac kontener: ");
            string nazwaStatku = Console.ReadLine();
            var statek = kontenerowce.Find(k => k.nazwa == nazwaStatku);
            if (statek == null)
            {
                Console.WriteLine("Statek nie istnieje. Wciśnij Enter.");
                Console.ReadLine();
                return;
            }
            //ustaklenie nowego kontenerowca
            Console.Write("Podaj nazwę statku, na ktory chcesz przeniesc kontener: ");
            string nazwaNowegoStatku = Console.ReadLine();
            var nowyStatek = kontenerowce.Find(k => k.nazwa == nazwaNowegoStatku);
            if (nowyStatek == null)
            {
                Console.WriteLine("Statek nie istnieje. Wciśnij Enter.");
                Console.ReadLine();
                return;
            }

            statek.UsunKontener(kontener.nrSeryjny);
            nowyStatek.DodajKontener(kontener);
        }

        static void WypiszInformacjeOStatku()
        {
            //ustaklenie kontenerowca
            Console.Write("Podaj nazwę statku: ");
            string nazwaStatku = Console.ReadLine();
            var statek = kontenerowce.Find(k => k.nazwa == nazwaStatku);
            if (statek == null)
            {
                Console.WriteLine("Statek nie istnieje. Wciśnij Enter.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine($"Nazwa: {statek.nazwa}, Prędkość: {statek.maxPredkosc}, Maksymalna liczba kontenerów: {statek.maxLiczbaKontenerow}, Maksymalna waga: {statek.maxWagaKontenerow}");
            Console.WriteLine("Lista kontenerów:");
            foreach (var kontener in statek.kontenery)
            {
                kontener.ToString();
            }
            Console.WriteLine("Wciśnij Enter.");
            Console.ReadLine();
        }
    }
}
