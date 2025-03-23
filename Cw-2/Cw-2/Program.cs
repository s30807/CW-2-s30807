using Cw_2;

class Kontenery{
    static List<Kontenerowiec> kontenerowce = new List<Kontenerowiec>();
    static List<Kontener> kontenery = new List<Kontener>();
    static void Main(string[] args)
    {
        //TODO - tworzenie kontenera chlodzacego, dopisac opcje
        

        Kontenerowiec kn1 = new Kontenerowiec("a", 1, 3, 100);
        Kontenerowiec kn2 = new Kontenerowiec("b", 1, 3, 100);
        Kontenerowiec kn3 = new Kontenerowiec("c", 1, 3, 100);

        kontenerowce.Add(kn1);
        

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
            foreach (Kontener k in kontenery)
            {
                k.ToString();
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
         if (kontenery.Count > 0)
         {
            Console.WriteLine("4. Usun kontener");
                if (kontenerowce.Count > 0)
                {
                    Console.WriteLine("5. Dodaj kontener na statek");
                }
                    
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
                //ZdejmijKontener();
                break;
            case "7":
                ZaladujKontener();
                break;
            case "8":
                //OproznijKontener();
                break;
            case "10":
                //ZastapKontener();
                break;
            case "11":
                //PrzeniesKontener();
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
            
            switch (typ) //TODO
            {
                case "L": Console.WriteLine("Plyn bezpieczny? (tak/nie)");
                    string typ2 = Console.ReadLine();
                    if (typ2.Equals("tak")){ nowyKontener.niebezpieczny = false;  } else { nowyKontener.niebezpieczny = true; }
                        break;
                //case "G": Console.WriteLine(
                
            }

            
            
            
            
            kontenery.Add(nowyKontener);
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
            Console.Write("Podaj nazwę kontenera, który dodać kontenerowiec: ");
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
    }
}