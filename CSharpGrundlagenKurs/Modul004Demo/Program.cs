using System;

namespace Modul004Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 0;
            int b = 10;


            #region Kopfgesteuerte Schleifen
            //WHILE-Schleife
            ///Die WHILE-Schleife wird wiederholt, solange die Bedingung wahr ist. Ist die Bedingung von vornherein unwahr, dann wird die Schleife
            ///übersprungen
            
            while (a < b)
            {
                Console.WriteLine("A ist kleiner B"); // 10x wird ausgegeben
                a++;

                
            }
            Console.WriteLine("Schleifenende");


            //FOR-Schleife
            ///Der FOR-Schleife wird ein Laufindex (i) sowie eine Bedingung und eine Anweisung übergeben. Am Ende jedes Durchlaufes wird die
            ///Anweisung ausgeführt. Wenn die Bedingung nicht (mehr) wahr ist, wird kein (weiterer) Schleifendurchlauf begonnen.

            for (int i = 0; i < 10; i += 2)
            {
                Console.WriteLine(i);


                if (i > 5)
                    break; //Bei den Wert 5 verlassen wir die Schleife 

                i++;
            }

            for (int i = 0; i < 10; i ++)
            {
                Console.WriteLine(i);


                if (i == 5)
                {
                    continue;
                }

                Console.WriteLine(i);
            }

            int[] zahlen = { 2, 3, 5, 4 };
            //FOREACH-Schleifen können über Collections laufen und sprechen dabei jedes Element genau einmal an
            foreach (int item in zahlen)
            {
                Console.WriteLine(item);
            }


            #endregion


            #region fussgesteuerte Schleife
            a = -45;

            do
            {
                Console.WriteLine(a);
                a--;

                continue; // Ich führe den nächsten Schleifen intervall aus

            } while (a > 0);
            #endregion


            //Enums sind spezialisierte selbst-definierte Datentypen mit festgelegten möglichen Zuständen.
            ///Dabei ist jeder Zustand an einen Integer-Wert gekoppelt, wodurch eine explizite Umwandlung (Cast) möglich ist. (vgl. Datentyp-Definition unten)
            ///
            string[] wochentagArray = new string[7];
            wochentagArray[0] = "Montag";
            wochentagArray[1] = "Dienstag";

            //Bessere Variante als bei Arrays
            Wochentage heutigerTag = Wochentage.Di;

            Console.WriteLine($"Der Tag ist {heutigerTag}"); //Dienstag wird ausgegeben
            //2 wird übergeben 
            int heutigerTagAlsZahl = (int)heutigerTag;

            //Mi wird gespeichert
            Wochentage dritterTagDerWoche = (Wochentage)3;
            Console.WriteLine($"Der Tag ist {dritterTagDerWoche}"); //Dienstag wird ausgegeben

            Console.WriteLine(typeof(Wochentage));


            //Gebe alle Enum-Einträge aus
            for (int i = 1; i < 8; i++)
            {
                Console.WriteLine($"{i}: {(Wochentage)i}");
            }

            //Speichern einer Benutzereingabe (Int) als Enumerator
            //Cast: Int -> Wochentag
            heutigerTag = (Wochentage)int.Parse(Console.ReadLine());
            Console.WriteLine($"Dein Lieblingstag ist also {heutigerTag}.");

            //SWITCHs sind eine verkürzte Schreibweise für IF-ELSE-Blöcke. Mögliche Zustände der übergebenen Variablen werden 
            //in den CASES definiert

            switch(heutigerTag)
            {
                case Wochentage.Mo:
                    Console.WriteLine("Wochenstart");
                    break;
                case Wochentage.Di:
                case Wochentage.Mi:
                case Wochentage.Do:
                    Console.WriteLine("normaler Wochentag");
                    break;
                case Wochentage.Fr:
                case Wochentage.Sa:
                case Wochentage.So:
                    Console.WriteLine("Wochenende");
                    break;

                default:
                    Console.WriteLine("Fehlerhafte Eingabe");
                    break;
            }

            //Mittels des WHEN-Stichworts kann auf Eigenschaften des betrachteten Objekts näher eingegangen werden
            int zahl = -45;

            switch (zahl)
            {
                case 5:
                    Console.WriteLine("a ist 5");
                    break;

                //1. Prüfung ist zahl ein int - Datentyp
                //2. Wenn ja, wird z den Wert -45 erhalten 
                //3. when leitet zweite Condition ein 
                //4. z < 0? 
                case int z when z < 0:
                    Console.WriteLine("a < 0");
                    break;
                default:
                    break; 
            }


            Tischgegenstände alleElektornischeGeräte = Tischgegenstände.Notebook | Tischgegenstände.GameBoy;

            Tischgegenstände alleGegenstände = Tischgegenstände.Blumenvase | Tischgegenstände.Notebook | Tischgegenstände.GameBoy | Tischgegenstände.Zeitschrift | Tischgegenstände.Tasse;


            Console.WriteLine("{0} includes {1}: {2}",
                        alleElektornischeGeräte, alleElektornischeGeräte, alleElektornischeGeräte.HasFlag(alleElektornischeGeräte));

            foreach (Tischgegenstände currentGegenstand in Enum.GetValues(typeof(Tischgegenstände)))
            {
                if (alleElektornischeGeräte.HasFlag(currentGegenstand))
                    Console.WriteLine($"{currentGegenstand} befindet sich bei den elektronischen Geräten");
            }
        }
    }

    public enum Wochentage { Mo=1, Di, Mi, Do, Fr, Sa, So }



    //https://docs.microsoft.com/de-de/dotnet/api/system.flagsattribute?view=net-6.0
    [Flags]
    public enum Tischgegenstände
    {
        None = 0,
        Blumenvase = 1,
        Notebook = 2,
        GameBoy = 4,
        Zeitschrift = 8,
        Tasse = 16
    }
}
