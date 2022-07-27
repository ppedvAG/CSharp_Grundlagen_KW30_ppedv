using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul009Demo
{

     
    public abstract class Employee
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        
        public abstract int Salary(); //abstrakte Methode


        public virtual int Gehalt()
        {
            return 12 * 160;
        }

    }

    public class Freelancer : Employee
    {
        public int HoursPerMonth { get; set; }
        public int SalaryPerHour { get; set; }

        public override int Salary()
        {
            return HoursPerMonth * SalaryPerHour;
        }

        
    }


    public class Practice : Employee
    {
        public int AzubiJahr { get; set; }


        public void GoToBerufschule()
        {
            Console.WriteLine("Azubi geht zur Berufschule");
        }
        public override int Salary()
        {
            //Laut IHK Niedersachsen 
            switch (AzubiJahr)
            {
                case 1:
                    return 1200;
                case 2:
                    return 1400;
                case 3:
                    return 1560;
                default:
                    return -500;

            }
        }

        
    }

    public class ContractEmployee : Employee
    {
        public int CustomizedSalara { get; set; }
        public override int Salary()
        {
            return CustomizedSalara;
        }
    }




}
