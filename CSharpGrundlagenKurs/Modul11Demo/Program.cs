using System;
using System.Collections;
using System.Collections.Generic;

namespace Modul11Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region List<T>
            //Generische Listen sind zu finden in -> using System.Collections.Generic

            List<string> städteListe = new List<string>();
            städteListe.Add("Hannover");
            städteListe.Add("Frankfurt am Main");
            städteListe.Add("Berlin");

            //Ausgabe der Anzahl der Elemente in einer Liste
            Console.WriteLine(städteListe.Count);

            //Wir können mit einem Index auf die Liste zugreifen (for - schleifen verwendbar)
            Console.WriteLine(städteListe[0]);

            
            try
            {
                //Typischer Fehler bei Array oder Listen (meist for-Schleifen)  ->   for (int i = 0; i <= städteListe.Count; i++)
                städteListe[3] = "München";
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
               
                Console.WriteLine(ex.Message);
            }
            finally
            {

            }

            foreach(string currentStadt in städteListe)
                Console.WriteLine(currentStadt);


            var stadt = städteListe[0];


            string[] strArray = städteListe.ToArray();

            List<string> cooleStädte = new List<string>();
            cooleStädte.AddRange(strArray);
            #endregion


            #region Dictionary

            //Key | Value - Struktur 

            //Key muss eindeutig sein
            //Value ist der Eintrag


            Dictionary<int, string> dictClubs = new Dictionary<int, string>();

            //Use Case -> ID und dessen Eintrag / Objekt
            dictClubs.Add(1, "HSV");
            dictClubs.Add(2, "St. Pauli");
            dictClubs.Add(3, "Hannover 96");
            dictClubs.Add(4, "Rapid Wien");

            //Kein Index, sondern nach dem Key wird hier gesucht
            string firstClubInDictionary = dictClubs[1]; //Wir erhalten ein Value HSV

            foreach(KeyValuePair<int, string> currentEntry in dictClubs)
            {
                Console.WriteLine(currentEntry.Key);
                Console.WriteLine(currentEntry.Value);
            }


            if (!dictClubs.ContainsKey(5))
                dictClubs.Add(5, "Eintracht Frankfurt");


            #endregion

            #region Hashtable
            Hashtable hashtable = new();

            hashtable.Add("123", DateTime.Now);
            hashtable.Add(DateTime.Now, "123");
            hashtable.Add(12345, 1231231);

            
            #endregion

        }


    }
}
