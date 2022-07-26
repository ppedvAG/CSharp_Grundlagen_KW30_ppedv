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
            Wochentage heutigerTag = Wochentage.Di;

            Console.WriteLine($"Der Tag ist {heutigerTag}"); //Dienstag wird ausgegeben
            //2 wird übergeben 
            int heutigerTagAlsZahl = (int)heutigerTag;

            //Mi wird gespeichert
            Wochentage dritterTagDerWoche = (Wochentage)3;
            Console.WriteLine($"Der Tag ist {dritterTagDerWoche}"); //Dienstag wird ausgegeben

            Console.WriteLine(typeof(Wochentage));
        }
    }

    enum Wochentage { Mo=1, Di, Mi, Do, Fr, Sa, So }
}
