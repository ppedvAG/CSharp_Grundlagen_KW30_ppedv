using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul013Demo
{
    public class BusinessLogicComponentA
    {
        public delegate void ChangePercentValue(int value);
        public delegate void ResultDelegate(string msg);

        //Das ist unser Event, das wir nach draußen anbieten 
        public event ChangePercentValue ChangePercentEventDelegate;
        public event ResultDelegate ResultCompletedEventDelegatge;

        public void Process()
        {
            for(int i = 0; i < 100; i++)
            {
                //Einmal soll die Komponente jeden Procentwert nach draußen kommunizieren können

              
                OnChangePercentEventDelegate(i);
            }


            //Callback für Processende
            OnResultCompletedEventDelegatge("BusinessLogicComponentA.Process ist fertig");
        }

        public void OnChangePercentEventDelegate(int value)
        {
            if (ChangePercentEventDelegate != null)
                ChangePercentEventDelegate.Invoke(value);    //Program.BusinessLogicComponentA_ChangePercentEventDelegate wird aufgerufen
        }

        public void OnResultCompletedEventDelegatge(string msg)
        {
            ResultCompletedEventDelegatge?.Invoke(msg);  //Program.BusinessLogicComponentA_ResultCompletedEventDelegatge wird aufgerufen
        }
    }
}
