using Microsoft.Extensions.DependencyInjection;
using System;

namespace Modul10DependencyInversionPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Programmierer testet seinen CarService
            ICar testCar = new TestCar();
            ICar car = new Car() { Marke = "Porsche", Modell = "311", Baujahr = 1977, Farbe = "rot"};
            
            
            ICarService carService  = new CarService();
            carService.Repair(testCar);
            carService.Repair(car);


            //Was ist ein IOC-Container 

            IServiceCollection collection = new ServiceCollection();

            collection.AddSingleton<ICar, TestCar>(); //Von TestCar wird eine Instanz aufgebaut 

            //Initialisierungphase ist beendet
            IServiceProvider serviceProvider = collection.BuildServiceProvider();
            ICar meinTestObject = serviceProvider.GetService<ICar>();



            //ServiceProvider serviceProvider2 = collection.BuildServiceProvider();

        }
    }




    #region Anti-Beispiel -> Feste Kopplung (Eine Klasse kennt die andere Klasse) 


    //Programmierer A: 5 Tage -> Tag 1 bis Tag5 
    public class BadCar
    {
        public string Marke { get; set; }
        public string Modell { get; set; }
        public int Baujahr { get; set; }
    }


    //Programmierer B: 3 Tage -> Tag 5/6 -> 8/9 
    public class BadCarService
    {
        public void Repair (BadCar car)
        {
            //Auto wird repariert 
        }
    }
    #endregion


    #region Best Practise 

    //Programmierer A und B definieren zusammen Interfaces 
    public interface ICar
    {
        string Marke { get; set; }
        string Modell { get; set; }
        int Baujahr { get; set; }

        //Nicht gut!
        string Farbe { get; set; }
    }

    public interface ICarService
    {
        void Repair (ICar car);
    }


    //Programmierer A -> 5 Tage -> Tag 1 - Tag 5
    public class Car : ICar
    {
        public string Marke { get; set; }
        public string Modell { get; set; }
        public int Baujahr { get; set; }

        //Nicht gut!
        public string Farbe { get; set; }

    }



    //Programmierer B -> 3 Tage -> Tag 1 - Tag 3 
    public class CarService : ICarService
    {
        public void Repair(ICar car)
        {
            Console.WriteLine("Auto wird repariert");
        }
    }

    public class TestCar : ICar
    {
        public string Marke { get; set; } = "VW";
        public string Modell { get; set; } = "Polo";
        public int Baujahr { get; set; } = 2021;
        //Nicht gut!
        public string Farbe { get; set; } = "schwarz";
    }
    #endregion

    //Weitereführende Themen -> IOC Container -> Autofac oder Ninject
}
