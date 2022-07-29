using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul013Demo
{
    public class BusinessLogicComponentB
    {
        public event EventHandler<MyPercentEventArgs> PercentValueChanged;

        public event EventHandler<MyCompletedMessageArgs> ProcessCompleted;

        public void StartProcess()
        {
            for (int i = 0; i < 100; i++)
            {
                OnPercentValueChanged(i);
            }

            OnProcessCompleted("Bin fertig");
        }

        protected virtual void OnPercentValueChanged(int i)
        {
            if (PercentValueChanged != null)
                PercentValueChanged.Invoke(this, new MyPercentEventArgs() { PercentValue = i });
        }

        protected virtual void OnProcessCompleted(string msg)
        {
            if (ProcessCompleted != null)
                ProcessCompleted.Invoke(this, new MyCompletedMessageArgs() { Message = msg });
        }
    }

    public class MyPercentEventArgs : EventArgs
    {
        public int PercentValue { get; set; }
    }

    public class MyCompletedMessageArgs : EventArgs
    {
        public string Message { get; set; }
    }
}
