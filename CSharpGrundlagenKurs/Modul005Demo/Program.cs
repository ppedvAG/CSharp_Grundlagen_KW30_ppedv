using System;

namespace Modul005Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Addiere(11, 22)); //33 wird ausgegeben

            Console.WriteLine(Addiere(11.5, 11.5)); //23 wird ausgegeben 





            BildeSumme(2, 5, 6, 3, 45, 23, 6, 34, 123, 432);

            BildeSumme(2, 5, 32);


            Subtraktion(11, 22, 33, 44);
            Subtraktion(11, 22, 33);
            Subtraktion(11, 22);


            Sub(23, 44, 55, 66);

            int ergebnis_subtraktion;

            int ergebnis_addition = AddiereUndSubtrahiere(22, 11, out ergebnis_subtraktion);


            Console.WriteLine(ergebnis_addition);
            Console.WriteLine(ergebnis_subtraktion);

            //Wertetypen 
            //int, float, decimal, short, uint, bool, struct, enums, 


            int alterPersonA = 22;
            int alterPersonB = 22;

            Altern(alterPersonA);

            Altern(ref alterPersonB);

            Console.WriteLine(alterPersonA);
            Console.WriteLine(alterPersonB);
        }




        /*
         * Syntax einer Funktion 
         * 
         * Rückgabetyp Funktionsname (Parameterliste) 

         */

        //Jede Funktion/Methode besteht aus einem Kopf und einem Körper
        ///Der Kopf besteht aus den MODIFIERN (public static), dem RÜCKGABEWERT (int), dem NAMEN (Addiere) sowie den ÜBERGABEPARAMETERN
        static int Addiere(int a, int b)
        {
            return a + b;
        }
        
        //Funktion, welche den gleichen Bezeichner haben, nennt man ÜBERLADENE Funktionen. Diese müssen sich in Anzahl und/oder Art der 
        ///Übergabeparameter unterscheiden, damit der Aufruf eindeutig ist.
        static int Addiere(int a, int b, int c)
            => Addiere(a, b) + c;

        //Kurzschreibweise bei Einzeilern
        static double Addiere(double a, double b)
            => a + b;

        /* 
         *  static double Addiere(double a, double b)
            {
                return a + b;
            }

         * 
         */

        static int BildeSumme(params int[] summanden)
        {
            int summe = 0;

            foreach (int currentSummand in summanden)
                summe += currentSummand;

            return summe;
        }


        static int Subtraktion (int a, int b, int c = 0, int d = 0)
        {
            return a - b - c - d;
        }

        static int? Sub(int? a, int? b, int? c=null, int? d=null)
        {
            return a.Value + b.Value + c.Value + d.Value;
        }

        static int AddiereUndSubtrahiere(int a, int b, out int different)
        {
            different = a - b; //Subtraktion 

            return a + b; //Addidition 
        }



        //Hier übergebe ich den Inhalt der Variable -> eine Kopie 
        static void Altern(int alter)
        {
            alter++;
        }


        //Übergegben ich die Speicheradresse der Variable (Und in der Speicheradresse ist auch der Inhalt zu finden) 
        static void Altern(ref int alter)
        {
             alter++;
        }

    }
}
