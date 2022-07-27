using System;

namespace Modul008Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mensch mensch = new Mensch("Otto", "Walkes", "Homosapiens", "Lassange", DateTime.Now);

        }
    }


    public class Lebewesen
    {
        public Lebewesen(string name, string lieblingsessen, DateTime geburtsdatum)
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


    public class Mensch : Lebewesen
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public Mensch Mutter { get; set; }

        public Mensch(string vorname, string nachname, string name, string lieblingsessen, DateTime geburtsdatum, Mensch mutter = null)
            :base(name, lieblingsessen, geburtsdatum)
        {
            Vorname = vorname;
            Nachname = nachname;
            Mutter = mutter;
        }

        public void Reden()
        {
            Console.WriteLine("Mensch spricht");
        }
    }
}
