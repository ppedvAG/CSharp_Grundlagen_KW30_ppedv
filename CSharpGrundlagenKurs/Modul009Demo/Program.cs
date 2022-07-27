using System;
using System.Collections.Generic;

namespace Modul009Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Mensch mensch = new Mensch("Otto", "Walkes", "Homosapiens", "Lassange", DateTime.Now, "italienisch");

            //Beispiel: Was ist virtual -> 

            Console.WriteLine(mensch.ToString());


            //Lebewesen lebewesen = new Lebewesen("Bär", "Fisch", DateTime.Now, string.Empty) ;
            //Console.WriteLine(lebewesen.ToString());


            #region Polymorphie in Verbindung mit abstract Methoden
            Freelancer freelancer1 = new Freelancer() { HoursPerMonth = 140, SalaryPerHour = 75 };
            Freelancer freelancer2 = new Freelancer() { HoursPerMonth = 140, SalaryPerHour = 55 };
            Practice practice1 = new Practice() { AzubiJahr = 1 };
            ContractEmployee contractEmployee = new ContractEmployee() { CustomizedSalara = 5000 };


            List<Employee> alleMitarbeiterInMeinerFirma = new List<Employee>();

            alleMitarbeiterInMeinerFirma.Add(contractEmployee);
            alleMitarbeiterInMeinerFirma.Add(freelancer2);
            alleMitarbeiterInMeinerFirma.Add(freelancer1);
            alleMitarbeiterInMeinerFirma.Add(practice1);


            int summe = 0;
            foreach(Employee employee in alleMitarbeiterInMeinerFirma)
            {
               
                if (employee is Practice)
                {
                    //Variante 1
                    ((Practice)employee).GoToBerufschule();

                    //Veriante 2 ist besser
                    //Referenz wird nur 
                    Practice azubi = (Practice)employee;

                    azubi.GoToBerufschule();

                    azubi.AzubiJahr = 2;
                }

                //Azubi soll zweites Leerjahr
                summe += employee.Salary();
            }


            Console.WriteLine($"Gesamtkosten der Firma sind {summe}");


            #endregion
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
