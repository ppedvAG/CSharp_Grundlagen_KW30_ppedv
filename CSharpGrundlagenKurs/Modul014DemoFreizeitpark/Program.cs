using System;
using System.Collections.Generic;
using System.IO;

namespace Modul014DemoFreizeitpark
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Besucher besucher = new Besucher("Max", 17);
            besucher.AddJahrmarktstandToDoTO(new AutoScooter() {});
            besucher.AddJahrmarktstandToDoTO(new GruselKabinet());
            besucher.AddJahrmarktstandToDoTO(new GrößteAchterbabhnDerWelt());
            besucher.AddJahrmarktstandToDoTO(new Wildwasserbahn());


            Besucher besucher2 = new Besucher("Lisa", 19);
            besucher2.AddJahrmarktstandToDoTO(new AutoScooter(16));
            besucher2.AddJahrmarktstandToDoTO(new GruselKabinet());
            besucher2.AddJahrmarktstandToDoTO(new GrößteAchterbabhnDerWelt());
            besucher2.AddJahrmarktstandToDoTO(new Wildwasserbahn());


            //IConeable Vorteil 
            AutoScooter autoScooter1 = new AutoScooter();
            autoScooter1.MitarbeiterAnzahl = 2;
            autoScooter1.AnzahlAutos = 16;
            autoScooter1.NameDerAttraktion = "AutoScooter";
            autoScooter1.Quatratmeter = 200;
            autoScooter1.Betreiber = "Otto";

            AutoScooter autoScooter2 = autoScooter1; //hier übergeben wir eine Referenz -> Ist keine Kopie

            AutoScooter autoScooter3 = new AutoScooter();
            autoScooter3.MitarbeiterAnzahl = autoScooter1.MitarbeiterAnzahl;
            autoScooter3.Quatratmeter = autoScooter1.Quatratmeter;



            //using (StreamWriter stream = new StreamWriter("C:\\Temp\\log.txt"))
            //{
            //    //Wenn hier ein Fehler passieren würde
            //} //Dispose von StreamWriter wird aufgerufen -> FileHander auf log.txt wird freigegeben 

            using (AutoScooter autoScooter = new AutoScooter(16))
            {
                
            }



            #region Explizietes Beispiel
            PseudoAttraktion pseudoAttraktion = new PseudoAttraktion();

            IFSK18Check pseudoAttraktionFSK18 = new PseudoAttraktion();
            pseudoAttraktionFSK18.AgeCheck(18);

            IFSK16Check pseudoAttraktionFSK16 = new PseudoAttraktion();
            pseudoAttraktionFSK16.AgeCheck(18);
            #endregion

        }
    }


    public class Besucher
    {
        public string NameDesBesuchers { get; set; }
        public int? Alter { get; set; }
        private List<Jahrmarkstand> MeineToDoListe { get; set; }

        public Besucher()
        {
            MeineToDoListe = new List<Jahrmarkstand>();
        }

        public Besucher(string name, int alter)
            :this()
        {
            this.Alter = alter;
            this.NameDesBesuchers = name;   
        }

        public void AddJahrmarktstandToDoTO (Jahrmarkstand jahrmarkstand)
        {
            if (!Alter.HasValue)
                throw new Exception("Bitte das Alter noch in den Besucherpass eintragen lassen");


            //Polymorphie -> jahrmarkstand ist Gruselkabinett oder Achterbahn
            if (jahrmarkstand is IFSK18Check jahrmarkstandMitFSK18Check)
            {
                if (!jahrmarkstandMitFSK18Check.AgeCheck(Alter.Value))
                    Console.WriteLine($"Liebe/r {NameDesBesuchers}, du bist leider noch zu Jung für {jahrmarkstand.NameDerAttraktion}");
                else
                    MeineToDoListe.Add(jahrmarkstand);
            }
            else
                MeineToDoListe.Add(jahrmarkstand);

        }
    }

    public interface IFSK18Check
    {
        public bool AgeCheck(int alter);
    }

    public interface IFSK16Check
    {
        public bool AgeCheck(int alter);
    }

    public interface IFotoService
    {
        public void MakeFoto();
    }

    //Basisklasse
    public class Jahrmarkstand
    {

        public Jahrmarkstand(string name)
        {
            this.NameDerAttraktion = name;
        }
        public string Betreiber { get; set; }

        public int Quatratmeter { get; set; }

        public int MitarbeiterAnzahl { get; set; }

        public string NameDerAttraktion { get; set; }
    }

    public class AutoScooter : Jahrmarkstand, ICloneable, IDisposable
    {


        public AutoScooter()
            : base(string.Empty)
        {

        }

        public AutoScooter(int anzahlAutos)
            :base("AutoScooter")
        {
            this.AnzahlAutos = anzahlAutos;
        }
        public int AnzahlAutos { get; set; }

        public object Clone()
        {
            //return this; //Referenz (Selbe Speicheradresse von mir übergeben ich = keine Kopie 
            return new AutoScooter(AnzahlAutos); //Gebe eine Kopie weiter
        }

        public void Dispose()
        {
            Console.WriteLine("AutoScooter wird vom Jahrmarkt abgebaut");
        }
    }

    public class GruselKabinet : Jahrmarkstand, IFSK18Check, IFotoService
    {

        public GruselKabinet()
            :base("Grusel Kabinett")
        {
        }
        int AnzahlDerSchocker { get; set; }

        public bool AgeCheck(int alter)
        {
            return alter >= 18 ? true : false;
        }

        public void MakeFoto()
        {
            Console.WriteLine("Ein Foto beim Erschecken wurde gemacht");
        }
    }

    public class Wildwasserbahn : Jahrmarkstand, IFotoService
    {

        public Wildwasserbahn()
            :base("Wildwasserbahn")
        {
        }

        public int Wasserbedarf { get; set; }

        public int Laenge { get; set; }

        public void MakeFoto()
        {
            Console.WriteLine("Foto bei Wildwasserbahn");
        }
    }


    public class GrößteAchterbabhnDerWelt : Jahrmarkstand, IFSK18Check, IFotoService
    {
        public GrößteAchterbabhnDerWelt()
            :base("Achterbahn")
        {
        }

        public int HoheDerBahn { get; set; }

        public int Kmh { get; set; }

        public bool AgeCheck(int alter)
        {
            return alter >= 18 ? true : false;
        }

        public void MakeFoto()
        {
            Console.WriteLine("Foto in der Schnellsten Abfahrt wird geknipst");
        }
    }


    #region Beispiel für Expliziete Nutzung von Interfaces

    public class PseudoAttraktion : IFSK16Check, IFSK18Check
    {
        bool IFSK18Check.AgeCheck(int alter)
        {
            return true;
        }

        bool IFSK16Check.AgeCheck(int alter)
        {
            return true;
        }
    }
    #endregion
}
