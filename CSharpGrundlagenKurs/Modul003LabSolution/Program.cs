using System;
using System.Linq;

namespace Modul003LabSolution
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 1.Aufgabe: Schaltjahr-Rechner


           

            #region Eingabe des Jahres
            //Abfrage der Eingabe
            Console.WriteLine("Gib das Jahr ein:");
            int eingabe = int.Parse(Console.ReadLine());


            //DateTime.IsLeapYear(eingabe);
            #endregion

            //Deklarierung/Initialisierung der bool-Variablen
            bool istSchaltjahr = false;

            #region Prüfung 
            #region Prüfung durch 4 teilbar
            //Prüfung einer Teilbarkeit durch 4
            if (eingabe % 4 == 0)
            {
                //Setzten der Variablen auf true
                istSchaltjahr = true;
                #region Prüfung ob durch 100
                //Prüfung einer Teilbarkeit durch 100
                if (eingabe % 100 == 0)
                {
                    //Setzten der Variablen auf false
                    istSchaltjahr = false;


                    #region Prüfung ob durch 400
                    //Prüfung einer Teilbarkeit durch 400
                    if (eingabe % 400 == 0)
                        //Setzten der Variablen auf true
                        istSchaltjahr = true;
                    #endregion
                }
                #endregion
            }
            #endregion
            #endregion

            #region Ausgabe
            //Ausgabe
            Console.WriteLine($"{eingabe} ist Schaltjahr: {istSchaltjahr}");

            //Alternative (detailiertere) Ausgabe mittels Kurz-Bedingung
            string ausgabe = istSchaltjahr ? $"{eingabe} ist ein Schaltjahr." : $"{eingabe} ist kein Schaltjahr.";
            Console.WriteLine(ausgabe + "\n\n\n");

            #endregion


            #region 2. Aufgabe: Mini-Lotto

            #region Lottozahlen in Array fest definieren
            //Deklaration & Initialisierung des Arrays der Gewinnzahlen
            int[] gewinnzahlen = { 3, 16, 45, 79, 99 };
            #endregion

            #region Tipp-Eingabe
            //Abfrage des User-Tipps
            Console.Write("Bitte gib deinen Tipp ab (Ganzzahl zwischen 0 und 100): ");
            int tipp = int.Parse(Console.ReadLine());
            #endregion

            #region Validierung das Tipp zwischen den Werten 0 und 100 liegt
            //Prüfung des Zahlenbereiches des Tipps
            if (tipp < 0 || tipp > 100)
                Console.WriteLine("Dein Tipp ist außerhalb des Zahlenbereiches.");
            #endregion
            else
            {
                #region Prüfung ob Tipp eine Lottozahl trifft
                //Prüfung, ob Tipp eine Gewinnzahl ist und Ausgabe
                if (gewinnzahlen.Contains(tipp))
                    Console.WriteLine("Glückwunsch!! Du hast eine der fünf Gewinnzahlen getippt.");
                else
                    Console.WriteLine("Leider daneben. Viel Glück beim nächsten Mal.");
                #endregion
            }
            #endregion
        }
    }
}
