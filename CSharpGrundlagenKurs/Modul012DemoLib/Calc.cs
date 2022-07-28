using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul012DemoLib
{
    public class Calc
    {
        public double Addieren (double a, double b)
            => a + b;

        public double Subtrahieren(double a, double b)
            => a - b;

        public double Dividiere(double a, double b)
        {
            try
            {
                ValidateDividiere(a);
            }
            //Wir fangen den Fehler auf
            catch (CalcDivideByZeroException calcDivideByZeroException)
            {

                //log für Entwickler (Wir schreiben es hier einmal in den Debug-Output (VS) 
                Debug.WriteLine("Nur Message:");
                Debug.WriteLine(calcDivideByZeroException.Message);

                Debug.WriteLine("Nur StackTrace:");
                Debug.WriteLine(calcDivideByZeroException.StackTrace);

                Debug.WriteLine("Nur ToString():");
                Debug.WriteLine(calcDivideByZeroException.ToString());

                throw calcDivideByZeroException; //Geben wir den selben Fehler an die Oberfläche weiter 
                //throw new CalcException("Lieber Benutzer, bitte gebe als Divident keinen 0 ein");
            }
            catch (CalcException calcException)
            {
                //Für allgemeine Fehler in meiner Library die irgendwas mit Calculation in Verbindungen stehen


                Debug.WriteLine("Nur Message:");
                Debug.WriteLine(calcException.Message);

                Debug.WriteLine("Nur StackTrace:");
                Debug.WriteLine(calcException.StackTrace);

                Debug.WriteLine("Nur ToString():");
                Debug.WriteLine(calcException.ToString());

                throw calcException; //Geben wir den selben Fehler an die Oberfläche weiter 
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Nur Message:");
                Debug.WriteLine(ex.Message);

                Debug.WriteLine("Nur StackTrace:");
                Debug.WriteLine(ex.StackTrace);

                Debug.WriteLine("Nur ToString():");
                Debug.WriteLine(ex.ToString());


                //Für unerwartete Fehler
                throw ex;
            }

            return a / b;

        }

        public void MakeFormatException()
        {
            throw new FormatException();
        }

        private void ValidateDividiere (double a)
        {
            if (a == 0)
                throw new CalcDivideByZeroException("For Developers: Divident dar nicht den Wert 0 vorweisen");
        }
    }


    public class CalcException : Exception
    {
        public CalcException(string message)
            : base(message)
        {
        }
    }

    public class CalcDivideByZeroException : CalcException
    {
        public CalcDivideByZeroException(string message)
            : base(message)
        {
        }
    }



}
