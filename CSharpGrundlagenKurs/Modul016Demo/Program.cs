using System;

namespace Modul016Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region struct vs class
            PersonC cPerson = new PersonC("Heiko", 35);

            PersonS sPerson = new PersonS("Anna", 35);

            PersonS sPersonB;

            //Hier wird jede einzelne Property/Fields seperat kopiert. (langsamer Weg)
            sPersonB = sPerson;

            //Mit einer Zuweisung kann ich die komplette Struktur übergegben (Referenz übergeben)
            ref PersonS sPersonAsReference = ref sPerson;


            //Ausgabe
            Console.WriteLine($"{cPerson.Name}: {cPerson.Alter}"); //35
            Console.WriteLine($"{sPerson.Name}: {sPerson.Alter}"); //35 

            Altern(cPerson); //Refrenz
            Altern(sPerson);

            //Erneute Ausgabe: Nur das Klassenobjekt (Referenztyp) hat sich verändert
            Console.WriteLine($"{cPerson.Name}: {cPerson.Alter}");
            Console.WriteLine($"{sPerson.Name}: {sPerson.Alter}");



            //Übergabe des Wertetyps als Refernz mittels Ref-Stichwort
            Altern(ref sPerson);
            Console.WriteLine($"{sPerson.Name}: {sPerson.Alter}");
            #endregion


            #region Sind Arrays Refernztypen
            //array = Referenztyp
            int[] array = { 2, 4, 6, 8 };

            ChangeArray(array);
            #endregion


            #region records vs classes
            PersonRecord personRecord1 = new PersonRecord(1, "Mario Bart");
            PersonRecord personRecord2 = new PersonRecord(1, "Mario Bart");

            PersonClass myPerson1Class = new PersonClass(1, "Helge Schneider");
            PersonClass myPerson2Class = new PersonClass(1, "Helge Schneider");

            #region Class vs Record  -> = - Operator
            if (myPerson1Class == myPerson2Class)
            {
                Console.WriteLine("myPerson1Class == myPerson2Class -> gleich");
            }
            else
            {
                Console.WriteLine("myPerson1Class == myPerson2Class -> ungleich");
            }


            if (personRecord1 == personRecord2)
            {
                Console.WriteLine("personRecord1 == personRecord2 -> gleich");
            }
            else
            {
                Console.WriteLine("personRecord1 == personRecord2 -> ungleich");
            }
            #endregion

            if (myPerson1Class.Equals(myPerson2Class))
            {
                Console.WriteLine("myPerson1Class.Equals(myPerson2Class) -> gleich");
            }
            else
            {
                Console.WriteLine("myPerson1Class.Equals(myPerson2Class) -> ungleich");
            }

            if (personRecord1.Equals(personRecord1))
            {
                Console.WriteLine("personRecord1.Equals(personRecord2) -> gleich");
            }
            else
            {
                Console.WriteLine("personRecord1.Equals(personRecord2) -> ungleich");
            }

            personRecord1.GetHashCode(); //Ist in Records ausimplementiert // In Klassen muss GetHastCode überschrieben werden. 



            (int id, string name) = personRecord1; //Dekonstruktion per Default mit dabei 


            EmployeeRecord employeeRecord1 = new EmployeeRecord(1, "Alf", 10);
            EmployeeRecord employeeRecord2 = new EmployeeRecord(1, "Alf", 10);

            if (employeeRecord1 == employeeRecord2)
            {
                Console.WriteLine(" if (employeeRecord1 == employeeRecord2) -> gleich");
            }
            else
                Console.WriteLine(" if (employeeRecord1 == employeeRecord2) -> ungleich");


            if (employeeRecord1.Equals(employeeRecord2))
            {
                Console.WriteLine("employeeRecord1.Equals(employeeRecord2) -> gleich");
            }
            else
            {
                Console.WriteLine("employeeRecord1.Equals(employeeRecord2) -> ungleich");
            }

            (int id1, string name2) = employeeRecord1; // In EmployeeRecord kann es kein Deconstruct geben, weil es in der Basis-Klasse diese 'Methode' schon gibt



            //Bei ausgeschriebenen Klassen wie bei ProgrammerRecord muss man Deconstruct manuell nachprogrammieren 
            ProgrammerRecord programmerRecord = new ProgrammerRecord(1, "Hannes", 7500);
            (int programmerId, string programmerName, decimal programmerGehalt) = programmerRecord;


            //PersonRecord verwendet Init -> Es gibt eine Möglichkeit die Werte indirekt zu verändert 
            PersonRecord personRecord3 = new PersonRecord(1, "Mario Bart");

            
            PersonRecord personRecord4 = personRecord3 with { Name = "John" };

            #endregion
        }
        #region Beispiel-Funktionen zu struct vs. classes UND arrays als Referenztypen
        public static void Altern(PersonC cPerson)
            => cPerson.Alter++;

        public static void Altern(PersonS sPerson)
            => sPerson.Alter++;


        //Mittels des REF-Stichworts können Wertetypen als Referenz an Methoden übergeben werden. D.h. die übergebene Speicherstelle selbst 
        ///wird manipuliert und nicht, wie normalerweise bei Wertetypen, eine Kopie des Werts.
        public static void Altern(ref PersonS sPerson)
        {
            sPerson.Alter++;
        }


        public static void ChangeArray(int[] testArray)
        {
            if (testArray.Length > 0)
                testArray[0] = 1;
        }

        #endregion
    }

    #region Referenz Structs/Classes 
    public class PersonC //Referenztypen
    {
        public string Name { get; set; }
        public int Alter { get; set; }

        public PersonC(string name, int alter)
        {
            this.Name = name;
            this.Alter = alter;
        }
    }

    //STRUCTS sind Klassenähnliche Konstrukte, welche nicht, wie Klassen, als Referenztypen behandelt werden, sondern ein Wertetyp sind. D.h
    //bei Übergabe eines Structs an eine Methode oder Variable wird eine Kopie dieses Objekts erstellt
    public struct PersonS
    {
        public string Name { get; set; }
        public int Alter { get; set; }

        public PersonS(string name, int alter)
        {
            this.Name = name;
            this.Alter = alter;
        }
    }
    #endregion

    //Kürzeste Schreibweise eines Records 
    public record PersonRecord(int Id, string Name);
    public record AutoRecord(int Id, string Marke, PersonRecord person, string Model, DateTime Baujahr);
    public record EmployeeRecord : PersonRecord
    {
        public decimal Gehalt { get; set; } //Records können auch set verwenden 

        public EmployeeRecord(int id, string name)
            : base(id, name)    
        {

        }

        public EmployeeRecord(int id, string name, decimal gehalt)
            :this(id, name)
        {
            Gehalt = gehalt;
        }
    }

    public record ProgrammerRecord
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public decimal Gehalt { get; init; }

        public ProgrammerRecord(int id, string name, decimal gehalt)
        {
            Id = id;
            Name = name;
            Gehalt = gehalt;
        }
        public void Deconstruct(out int Id, out string Name, out decimal Gehalt)
        {
            Id = this.Id;
            Name = this.Name;
            Gehalt = this.Gehalt;
        }

        public void KarlGustav(out int Id, out string Name, out decimal Gehalt)
        {
            Id = this.Id;
            Name = this.Name;
            Gehalt = this.Gehalt;
        }
    }

    public class PersonClass
    {
        public PersonClass(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
