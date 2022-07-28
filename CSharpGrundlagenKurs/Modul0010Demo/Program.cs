using System;

namespace Modul0010Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }


    public abstract class Lebewesen
    {

        public Lebewesen(string name, string lieblingsessen, DateTime geburtsdatum, string kommunikation)
        {
            Geburtsdatum = geburtsdatum;
            Name = name;
            Lieblingsessen = lieblingsessen;
            AnzahlDerLebewesen++;
            Kommunikation = kommunikation;
        }

        public DateTime Geburtsdatum { get; set; }
        public string Name { get; set; }
        public string Lieblingsessen { get; set; }


        //Virtual ist eine Auto-Property 
        public virtual string Kommunikation { get; set; } = string.Empty;


        #region Statische Member
        //STATISCHE Variablen und Methoden hängen an der Klasse selbst und nicht an instanziierten Objekten. Sie existieren demnach unabhängig von der Anzahl
        ///Objekte genau einmal. Der Aufruf erfolgt über den Klassenbezeichner.

        public static int AnzahlDerLebewesen { get; set; } = 0;

        public static string ZeigeAnzahlLebewesen()
        {
            return $"Es gibt {AnzahlDerLebewesen} Lebewesen";
        }
        #endregion


        public abstract void Essen();


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


        public override string ToString()
        {
            return $"{Name} is am {Geburtsdatum} geboren";
        }
    }


    public class Mensch : Lebewesen
    {


        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public Mensch Mutter { get; set; }



        public override string Kommunikation
        {
            get => base.Kommunikation;

            set
            {
                if (string.IsNullOrEmpty(value))
                    base.Kommunikation = "Englisch";
                else
                    base.Kommunikation = value;
            }
        }

        public Mensch(string vorname, string nachname, string name, string lieblingsessen, DateTime geburtsdatum, string kommunikation, Mensch mutter = null)
            : base(name, lieblingsessen, geburtsdatum, kommunikation)
        {
            Vorname = vorname;
            Nachname = nachname;
            Mutter = mutter;
        }

        public void Reden()
        {
            Console.WriteLine("Mensch spricht");
        }


        public override string ToString()
        {
            //string basisAusgabeWennGebraucht =  base.ToString();

            return $"{Vorname} {Nachname} ist am {Geburtsdatum} geboren";
        }

        public override void Essen()
        {
            Console.WriteLine($"{Vorname} {Nachname} isst {Lieblingsessen}");
        }
    }
}
