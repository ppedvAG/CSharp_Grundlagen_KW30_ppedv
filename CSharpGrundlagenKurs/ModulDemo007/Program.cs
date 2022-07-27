using System;

namespace ModulDemo007
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instanz lebewesen1
            Lebewesen lebewesen1 = new("Fisch", "Pflanzen", new DateTime(2021, 11, 11));
            

           


            //Instanz lebewesen1
            Lebewesen lebewesen2 = new("Bär", "Fisch", new DateTime(2018, 4, 4));

            Lebewesen lebewesen3 = new Lebewesen("Wolf", "Schafe", DateTime.Now);
            lebewesen3 = null;



            //Nullsetzung der Variablen (um das Lebewesenobjekt freizugeben und die GC demonstrieren zu können)
            lebewesen1 = null;

            //Aufruf der GC und Programmpause, bis alle Destruktoren beendet wurden

            Lebewesen lebewesen4;
            
            for (int i=0; i < 1000; i++)
            {
                lebewesen4 = new Lebewesen("Wolf", "Schafe", DateTime.Now);
            }




            
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.WriteLine(Lebewesen.ZeigeAnzahlLebewesen());

        } //Hier würde der GC alle Objekte abbauen 
    }


    public class Lebewesen
    {


        public Lebewesen (string name, string lieblingsessen, DateTime geburtsdatum)
        {
            Geburtsdatum = geburtsdatum;
            Name = name;
            Lieblingsessen = lieblingsessen;
            AnzahlDerLebewesen++;
        }

        public DateTime Geburtsdatum { get; set; }
        public string Name { get; set; }
        public string Lieblingsessen { get; set; }


        #region Statische Member
        //STATISCHE Variablen und Methoden hängen an der Klasse selbst und nicht an instanziierten Objekten. Sie existieren demnach unabhängig von der Anzahl
        ///Objekte genau einmal. Der Aufruf erfolgt über den Klassenbezeichner.

        public static int AnzahlDerLebewesen { get; set; } = 0;

        public static string ZeigeAnzahlLebewesen()
        {
            return $"Es gibt {AnzahlDerLebewesen} Lebewesen";
        }
        #endregion


        //MEMBERMETHODEN sind Funktionen, welche jedes Objekt einer Klasse besitzt und speziell mit diesem Objekt interagiert
        public Lebewesen GebäreKind(string kindname)
        {
            return new Lebewesen(kindname, Lieblingsessen, DateTime.Now);
        }

        public void Essen()
        {
            Console.WriteLine($"{Name} isst am liebsten {Lieblingsessen}");
        }

        //public void Dispose()
        //{
        //    Console.WriteLine($"{this.Name} ist gestorben.");
        //    AnzahlDerLebewesen--;
        //}

        ~Lebewesen()
        {
            Console.WriteLine($"{this.Name} ist gestorben.");
            AnzahlDerLebewesen--;
        }
    }
}
