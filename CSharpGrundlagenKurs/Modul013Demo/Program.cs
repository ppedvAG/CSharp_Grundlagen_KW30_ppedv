using System;
using System.Collections.Generic;

namespace Modul013Demo
{
    //Delegate - Datentyp 

    //Bindet eine oder mehrere Methoden die eine selbe Signature aufweisen -> (Rückgabetyp und Übergabeparameter) 

    //Bildet die Grundlage für -> 
    public delegate int MeinDelegate(int a, int b);
    public delegate void MeinDelegate2(string cmd);


    public delegate void CallbackDelegate(string msg);
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Delegate Grundlagen
            //Deklaration einer Delegate-Variablen
            MeinDelegate delegateVariabte = null;

            delegateVariabte = Addiere; //Die Speicheradresse der Methode/Funktion wird an dem Delegate übergaben -> Funktionszeiger 

            int erg = delegateVariabte(11, 22);

            //tauschen Methode aus
            delegateVariabte = Subtrahieren;
            erg = delegateVariabte(11, 22);

            //Fügen eine weitere Methode mitholfe des += Operators hinzu 
            delegateVariabte += Addiere;
            erg = delegateVariabte(11, 22);

            //
            foreach (var item in delegateVariabte.GetInvocationList())
            {
                Console.WriteLine(item.Method);
                Console.WriteLine(item.DynamicInvoke(11,12));

            }

            //Subtrahierungsmehtode wird entfernt
            delegateVariabte -= Subtrahieren;
            erg = delegateVariabte(11, 22);
            #endregion

            #region Action / Func - Delegates
            //Action können nur mit Methoden zusammenarbeiten, die ein void zurückgegbeen (KEIN RÜCKGABEWERT) 
            Action<string> sendActionDelegate = new Action<string>(SendMessage);
            sendActionDelegate("Hallo Welt");

            Func<int, int, int> mathFuncDelegate = new Func<int, int, int>(Addiere);

            mathFuncDelegate += Subtrahieren;

            foreach(var item in mathFuncDelegate.GetInvocationList())
            {
                Console.WriteLine(item.Method);
                Console.WriteLine(item.DynamicInvoke(22,11));
            }
            #endregion

            #region Callbacks mit Delegates
            MyProcess myProcess = new MyProcess();

            //callbackDelegate ruft von überall die SendMessage auf.
            CallbackDelegate callbackDelegate = new CallbackDelegate(SendMessage);

            MyProcess.PercentDelegate percentDelegate = new MyProcess.PercentDelegate(ShowPercentProgress);
            myProcess.TuWas(callbackDelegate, percentDelegate);
            #endregion

            #region Event Delegate
            BusinessLogicComponentA businessLogicComponentA = new BusinessLogicComponentA();
            businessLogicComponentA.ChangePercentEventDelegate += BusinessLogicComponentA_ChangePercentEventDelegate;
            businessLogicComponentA.ResultCompletedEventDelegatge += BusinessLogicComponentA_ResultCompletedEventDelegatge;
            #endregion

            #region EventHandler 
            BusinessLogicComponentB businessLogicComponentB = new BusinessLogicComponentB();
            businessLogicComponentB.PercentValueChanged += BusinessLogicComponentB_PercentValueChanged;
            businessLogicComponentB.ProcessCompleted += BusinessLogicComponentB_ProcessCompleted;
            businessLogicComponentB.StartProcess();
            #endregion



            

            
        }

        private static void BusinessLogicComponentB_ProcessCompleted(object sender, MyCompletedMessageArgs e)
        {
            Console.WriteLine(e.Message);
        }

        private static void BusinessLogicComponentB_PercentValueChanged(object sender, MyPercentEventArgs e)
        {
            Console.WriteLine(e.PercentValue);
        }

        private static void BusinessLogicComponentA_ResultCompletedEventDelegatge(string msg)
        {
            Console.WriteLine(msg);
        }

        private static void BusinessLogicComponentA_ChangePercentEventDelegate(int value)
        {
            Console.WriteLine(value);
        }



        #region int Methode (int, int)
        public static int Addiere(int a, int b)
            => a + b;

        public static int Subtrahieren(int a, int b)
            => a - b;
        #endregion

        public static void SendMessage(string msg)
            => Console.WriteLine(msg);

        public static void ShowPercentProgress(int value)
            => Console.WriteLine(value);

    
    }

    #region Wird für Callbacks verwendet

    public class MyProcess
    {
        public delegate void PercentDelegate(int percentValue);
        public void TuWas(CallbackDelegate callbackDelegate, PercentDelegate percentDelegate) //Callback-Delegate wird via Parameter angegeben 
        {
            for (int i = 0; i <1000; i++)
            {
                percentDelegate(i);
            }

            //Wenn er fertig ist, wird das Callback, die Methode aufrufen, die am Callback-Delegate dranhängt
            callbackDelegate("Bin fertig mit TuWas");
        }
    }

    #endregion


}
