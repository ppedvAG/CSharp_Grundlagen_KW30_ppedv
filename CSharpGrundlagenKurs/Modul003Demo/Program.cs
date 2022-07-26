using System;
using System.Linq;

namespace Modul003Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Was ist ein Array und wie definiert man es
            //ARRAYS
            ///Arrays sind Collections, welche mehrere Variablen eines Datentyps speichern können. Die Größe des Arrays muss bei der
            ///Initialisierung entweder durch eine Zahl oder durch eine bestimmte Anzahl von spezifischen Elementen definiert werden.

            //Array-Deklaration ohne direkte Initialisierung der Positionen (Größe muss angegeben werden) //
            string[] worte = new string[5];
            int[] valueArray = new int[10]; // Array hat 10 Felder aber noch keine Werte dazu  

            int[] zahlen = { 2, 4, -123, -8, 0, 1111 }; // Array hat 6 Felder 
            #endregion

            #region Array-Index
            Console.WriteLine(zahlen[2]); //Index beginnt bei 0 -> also das dritte Element (-123) wird ausgegeben
            
            valueArray[2] = 1234;
            Console.WriteLine(valueArray[2]);
            #endregion

            #region Mithilfe von System.Linq haben wir noch weitere Methoden
            Console.WriteLine(zahlen.Contains(-123)); //bool (true oder false) als String ausgegeben -> 
            Console.WriteLine(zahlen.Contains(555));

            //Ausgabe der Länge (Anzahl der Elemente) des Arrays
            Console.WriteLine(zahlen.Length);


            #endregion

            #region Durchlauf euiens arrays mithilfe der for-Schleife
            //for + TAB + TAB -> Shortcut
            for (int i = 0; i < zahlen.Length; i++)
            {
                Console.WriteLine(zahlen[i]);
            } //i gilt nur innerhalt der Schleife
            #endregion
            
            //Mehrdimensionales Array

            #region Mehrdimensionales Array
            int[,] zweiDimArray = new int[3, 5];

            zweiDimArray[0, 0] = 1; 

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    zweiDimArray[i, j] = i * j;
                }
            }


            for (int i = 0; i < zweiDimArray.GetLength(0); i++)
            {
                for (int j = 0; j < zweiDimArray.GetLength(1); j++)
                {
                    zweiDimArray[i, j] = i * j;
                }
            }

            #endregion




            #region Bedingungen (If/Else)

            int a = 23;

            int b = 23;

            //IF-ELSEIF-ELSE-Block
            ///Das Programm wird den ersten Block ausführen, bei welchem er auf eine wahre Bedingung trifft und dann am Ende des Blocks mit
            ///dem Code weiter machen
            ///

            if (a < b)
            {
                Console.WriteLine("A ist kleiner als B");
            }
            else if (a > b)
            {
                Console.WriteLine("A ist größer als B");
            }
            else
            {
                Console.WriteLine("Beide sind gleich");
            }


            //Kurznotation 

            //Syntax 
            //Bedinung ? Rückgabewert bei TRUE :  Rückgabewert bei FALSE;

            string ergebnis = (a == b) ? "A ist gleich B" : "A is ungleich B";


            //string-Bgleichen

            string name1 = "Hannes";
            string name2 = "Hannes";

            if (name1 == name2)
            {
                Console.WriteLine("Gleich");
            }

            if (name1.Equals(name2))
                Console.WriteLine("Gleich");

            if (455 % 5 == 0) //Modulo ermittelt die REST-Zahl beim Teilen 
            {
                //455 ist durch 5 teilbar 
            }
            #endregion
        }
    }
}
