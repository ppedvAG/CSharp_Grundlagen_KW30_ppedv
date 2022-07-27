using System;
using DemoModul006Lib.ErstesNamespace;
using DemoModul006Lib.People;
using DemoModul006Lib.ZweitesNamespace;
namespace DemoModul006
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Namespaces - Sample + Namespaces_Sample2_Alias.cs 
            //Die Klasse Player wird gefunden, weil diese nur im Namespace 'DemoModul006Lib.ErstesNamespace' zu finden ist
            

            //Mit absoluter Angabe des Namespace kann man auf jede Klasse zugreifen
            DemoModul006Lib.ErstesNamespace.Club club;
            #endregion

            #region Objekte erstellen und einfach eine Variable direkt initialisieren
            //Speicher wird reserviert -> Deklaration 
            BadLebewesen lebewesen1;

            //Instanziierung und ab hier können wir die Klasse verwenden
            lebewesen1 = new BadLebewesen();
            lebewesen1.Gewicht = 55;
            lebewesen1.Geburtsjahr = 2001;

            //Instanziierung mit manueller Initialisierung 
            BadLebewesen lebewesen2 = new BadLebewesen() 
            { 
                //Durch meine Belegung der Variablen, kann ich manuell alle Puplic Variable oder Properties (kommt gleich) initialiseren 
                Geburtsjahr = 2003, 
                Gewicht = 11
            };

            Console.WriteLine(lebewesen2.ToString());
            #endregion

            #region Erstes richtig Objekt mit Membervariablen und Properties
            Lebewesen lebewesen = new ();
            lebewesen.Gewicht = 123;

            Lebewesen lebewesen3 = new Lebewesen(12, DateTime.Now, "Rex", 5);
            #endregion

            

            Player player = new Player("Uwe", "Seeler", Position.ST, 222);

            DemoModul006Lib.ErstesNamespace.Club club1 = new DemoModul006Lib.ErstesNamespace.Club(player);

            DemoModul006Lib.ErstesNamespace.Club spielvereinigung1FCEigentTor = new DemoModul006Lib.ErstesNamespace.Club(new DemoModul006Lib.ErstesNamespace.Club(player), new DemoModul006Lib.ErstesNamespace.Club(player));

            Console.WriteLine(player.FirstName);
        }
    }


    public class BadLebewesen
    {
        //Variablen werden klein geschrieben und sind private
        public int Geburtsjahr;
        public double Gewicht; 
    }


    public class Lebewesen
    {
        #region Membervariablen
        //Membervariablen sind privat und können nur innerhalb der Klassen aufgerufen werden
        private DateTime geburtstdatum;
        private double gewicht;
        private double hoehe;

        #endregion

        #region Properties
        //private string name; 

        //Properties können verwendet werden um Variablen auszulesen oder zu setzen
        # region Ausgeschriebene Schreibweise
        public double Gewicht
        {
            //Schreiben
            set
            {
                if (value < 0)
                {
                    //Wenn das Gewicht negativ sein sollte, wird der Default-Wert von 0.1 verwendet
                    gewicht = 0.1;
                }
                gewicht = value;
            }

            //Lesen
            get
            {
                return gewicht;
            }
        }
        #endregion

        #region Kurzschreibweise, wenn nur gelesen und zugewiesen wird und keine Validierung verwendet werden muss
        public DateTime Geburtsdatum 
        { 
            get => geburtstdatum; 
            set => geburtstdatum = value; 
        }
        #endregion

        #region Auto-Property
        //Auto-Property 
        // Der Kompilier legt beim kompilieren eine Member-Variable uns an und verwendet diese intern. (It magic) 
        public string Name { get; set; } = "Vogel"; // Default Zuweisung
        public double Bewegungsgeschwindigkeit { get; set; } 
        public double Hoehe { get => hoehe; set => hoehe = value; }

        //In Version 2.0 (Versionierung) 
        public string Lieblingsnahrung { get; set; }
        #endregion

        #region Properties können auch nur ein GET - Modifier verwenden
        public int AlterInJahren
        {
            get { return ((DateTime.Now - this.Geburtsdatum).Days / 365); }
        }
        #endregion
        #endregion

        #region Konstruktoren

        //Default Konstruktor -> Wenn wir diesen nicht hinschreiben, wird dieser vom Kompilier trotzdem hinzugefügt
        public Lebewesen()
        {
            //Im Konstruktor werden die Properties befüllt
            Bewegungsgeschwindigkeit = 0;
        }

        public Lebewesen(double gewicht, DateTime geburtsdatum, string name, double hoehe)
            : this() // 
        {
            Gewicht = gewicht;
            Geburtsdatum = geburtsdatum;
            Name = name;
            Hoehe = hoehe;
        }


        //Bei Versionierungen verwenden 
        public Lebewesen(double gewicht, DateTime geburtsdatum, string name, double hoehe, string lieblingsnahrung)
          : this(gewicht, geburtsdatum, name, hoehe) // 
        {
            
            Lieblingsnahrung = lieblingsnahrung;
        }







        #endregion

        #region Methoden
        public void Atmen()
        {
            Console.WriteLine($"{Name} atmet");
        }

        #endregion
    }

}





