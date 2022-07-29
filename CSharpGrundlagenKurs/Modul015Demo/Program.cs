using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Modul015Demo.Persons.Extentions;

namespace Modul015Demo
{
    internal class Program
    {
        private static IList<Person> personenListe = new List<Person>();
        static void Main(string[] args)
        {
            //Linq 101 Samples 
            //https://linqsamples.com/linq-to-objects/element/First-conditional
            //https://github.com/dotnet/try-samples/tree/main/101-linq-samples

            personenListe.Add(new Person(1, "Otto", 44));
            personenListe.Add(new Person(2, "Eva", 21));
            personenListe.Add(new Person(3, "Karl", 34));
            personenListe.Add(new Person(4, "Hannes", 56));
            personenListe.Add(new Person(5, "Andre", 78));
            personenListe.Add(new Person(6, "Bill", 12));
            personenListe.Add(new Person(7, "James", 32));
            personenListe.Add(new Person(8, "Anna", 23));
            personenListe.Add(new Person(9, "Lena", 29));

            //Was ist ein Linq-Statement  -> using System.Linq;

            IList<Person> personenUnter30 = (from p in personenListe
                                             where p.Alter < 30
                                             orderby p.Name
                                             select p).ToList();

            //Linq Functions mit Lambda-Statement/Epxressions
            personenUnter30 = personenListe.Where(person => person.Alter < 30) 
                           .OrderBy(person => person.Name) // hier werden alle Personen die unter 30 sind, sotiert 
                           .ToList();

            //Lambda via Func 
            IList<Person> personenUeber30 = GetPersonByWhereStatment(persons => persons.Alter > 30);


            //Erweiterungsklassen werden erst angezeigt, wenn man das Namespace hinzufügt. 

            personenUeber30[0].SavePerson("PersonenDatei.abc");
        }

        public static IList<Person> GetPersonByWhereStatment(Func<Person, bool> predicate)
        {
            return personenListe.Where(predicate).ToList();
        }

        
    }

    public class Person
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public int Alter { get; set; }

        public Person(int id, string name, int alter)
        {
            Id = id;
            Name = name;
            Alter = alter;
        }
    }
}


