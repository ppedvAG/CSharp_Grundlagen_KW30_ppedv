using System;

namespace WiederholungTag2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class Konto
    {
        public decimal Kontostand { get; set; }

        public virtual void Einzahlen (decimal betrag)
        {
            Kontostand += betrag;
        }

        public virtual void Abheben(decimal betrag)
            => Kontostand -= betrag;
    }

    public class Girokonto : Konto
    {
        public decimal Dispo { get; set; }

        public override void Abheben(decimal betrag)
        {
            if ((Kontostand - betrag) < Dispo)
                throw new Exception("Man kann nicht mehr als das Displimit abheben");

            //Konto->Girokonto
            base.Abheben(betrag);
        }
    }

    public class Sparbuch : Konto
    {
        public decimal Zinsen { get; set; }

        public override void Abheben(decimal betrag)
        {
            if ((Kontostand - betrag) < 0)
                throw new Exception("Man kann nicht mehr als das Displimit abheben");

            base.Abheben(betrag);
        }

        //Zinseberechnungen die Kontostand modifierten
        //...
    }

}
