using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul015Demo.Persons.Extentions
{
    public static class PersonExtentions
    {
        public static void SavePerson(this Person person, string saveFilePath)
        {
            Debug.WriteLine(person.Id);
            Debug.WriteLine(person.Name);
            Debug.WriteLine(person.Alter);
        }
    }
}
