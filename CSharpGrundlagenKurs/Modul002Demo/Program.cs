//  Mittels der USING-Anweisungen kann ein vereinfachter Zugriff auf Programm-Externe Klassen ermöglicht werden. Es muss nun nicht mehr der
/// vollständige Pfad angegeben werden, sondern es reicht der Klassenbezeichner
using System;

//Namespaces: Die Umgebung im aktuellen Programm. Alles innerhalb des Namespaces gehört zu dem Programm
namespace Modul002Demo
{

    //Die PROGRAM-Klasse beinhaltet den Einstiegspunkt des Programms und muss in jedem C#-Programm vorhanden sein
    class Program
    {
        //Die MAIN()-Methode ist der Einstiegspunkt jedes C#-Programms: Hier beginnt das Programm IMMER
        static void Main(string[] args)
        {
            Console.WriteLine( "Hello World!");

            #region Variablen Basics
            //Deklaration einer Integer-Variable 
            int alter;

            //Initialisierung der Integer-Variablen
            alter = 32;

            //Gleichzeitige Deklaration und Initialisierung einer String-Variablen
            string stadt = "Berlin";


            // Ausgabe einer Variablen
            Console.WriteLine(alter);
            Console.WriteLine(stadt);

            //Deklaration und Initialisierung einer Integer-Variablen mithilfe einer anderen Integer-Variablen
            int doppeltesAlter = alter * 2; //64

            //Impliziet
            Console.WriteLine(alter * 2);

            
            char textzeichen = 'A';
            Console.WriteLine(textzeichen);

            //Beispiel-Double-Variable
            double Kosten = 78.123;
            Console.WriteLine(Kosten);

            float floatValue = 12.99f;


            //decimal für Geldbeträge
            decimal money = 19.99m;
            Console.WriteLine("Geltbetrag: " + money);

            #endregion
            
            
            //'traditionell' über Stringverknüpfung (+-Operator)
            string satz = "Ich bin " + alter + " Jahre alt und wohne in " + stadt + ".";
            Console.WriteLine(satz);

            //$-Operator (Variablen werden direkt in {} Klammern geschrieben
            satz = $"Ich bin {alter} Jahre alt und wohne in {stadt}";


            //Ausgabe einer Berchnung in Strings
            int a = 45;
            int b = 12;
            Console.WriteLine($"{a} + {b} = {a + b}"); // Ausgabe -> 45 + 12 = 57


            #region String-Ausgabe Lehre
            //Bitte nicht
            Console.WriteLine("Ich bin " + alter + " Jahre alt und wohne in " + stadt + ".");

            //früher so
            Console.WriteLine("Ich bin {0} Jahre alt und wohne in {1}", alter, stadt); //c -> printf 

            //heute so
            Console.WriteLine($"Ich bin {alter} Jahre alt und wohne in {stadt}");
            #endregion

            #region String-Tabulatoren 
            //https://docs.microsoft.com/de-de/cpp/c-language/escape-sequences?view=msvc-170

            string bsp = "Dies ist ein \t Tabulator und dies ein \n Zeilenumbruch";
            Console.WriteLine(bsp);
            #endregion


            #region Verbatim - String

            string path_frueher = "C:\\Windows\\Temp";
            string path_heute = @"C:\Windows\Temp"; //Verbatim-String schlatet die Escape Sequencen aus

            //Kompinarbar mit $-Zeichen
            string folder = "windows";
            string subFolder = "temp";
            string path_komplex = @$"C:\{folder}\{subFolder}";
            #endregion


            #region Konsoleneingaben und Konventierung string nach integer 
            Console.Write("Bitte geben Sie einen Namen ein: ");
            string myName = Console.ReadLine(); //Der Rest der Zeile verwende ich für die Eingabe 
            Console.WriteLine(myName);

            Console.Write("Geben Sie Zahl1 ein: ");

            //früher Convert 
            int zahl1 = Convert.ToInt32(Console.ReadLine());
            string zahlAlsString = zahl1.ToString();
            //heute int.Parse + int.TryParse 
            zahl1 = int.Parse(Console.ReadLine());

            string strZahl = "123";

            

            if (int.TryParse(Console.ReadLine(), out zahl1))
            {
                //Wenn ich hier drinne bin, weiß ich zu 100%, dass die Konventierung geklappt hat 
                Console.WriteLine(zahl1);
            }
            #endregion


            #region Casting (implziet und expliziet) 

            //https://code-maze.com/csharp-intparse-vs-convert-toint32/
            //Bsp für numerische Umwandlung (impliziet, da kein Datenverlust)

            int intZahl = 78;
            double doubleZahl = intZahl;



            //Bsp für numerische Umwandlung mittels Cast (expliziet, da möglicherweise Datenverlust)
            doubleZahl = 45.75;

            intZahl = (int)doubleZahl;

            Console.WriteLine($"(int)doubleZahle -> {intZahl}");

            intZahl = Convert.ToInt32(doubleZahl);
            Console.WriteLine($"Convert.ToInt32(doubleZahl) -> {intZahl}");

            //benötigt ein explizieten cast

            intZahl = (int) Math.Floor(doubleZahl);
            Console.WriteLine($"(int)Math.Floor -> {intZahl}");

            #endregion

            #region nullable Datatypes


            int value; //Wert 0

            value = 123; // Wert 123

            Console.WriteLine(value);

            int? nullableValue = null;

            nullableValue = 123;
            if (nullableValue.HasValue)
            {
                //cool ich habe wirklich einen Wert und kann damit war sinniges anstellen

                //Value Property greifen wir auf Wert zu
                Console.WriteLine(nullableValue.Value);
            }


            string nullableString = null;

            string leererString = "";
            leererString = string.Empty;

            if (!string.IsNullOrEmpty(leererString) && !string.IsNullOrEmpty(nullableString))
            {
                //strings sind befüllt 
            }

            #endregion


            #region Inkrementieren 
            int x = 100;
            int y = 100;

            // x = x + 1;


            //Hier wird zuerst ausgegeeben und danach um 1 erhöht
            Console.WriteLine(x++);
            
            //Hier wird zuerst erhöht dann Variable ausgegeben 
            Console.WriteLine(++y);
            
            #endregion

            Console.ReadLine();


            
        }
    }
}
