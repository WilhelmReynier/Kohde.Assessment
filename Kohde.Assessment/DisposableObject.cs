using System;
using System.Linq;

namespace Kohde.Assessment
{
    public delegate void MyEventHandler(string foo);

    public class DisposableObject : IDisposable
    {
        public event MyEventHandler SomethingHappened;

        public int Counter { get; private set; }

        public void PerformSomeLongRunningOperation()
        {
            this.SomethingHappened += HandleSomethingHappened;//Moved outside so event handler is only called once to avoid multiple subscriptions.
            foreach (var i in Enumerable.Range(1, 10))
            {
               //some long running code 
            }
        }

        public void RaiseEvent(string data)
        {
           SomethingHappened?.Invoke(data);//condensed code
        }

        private void HandleSomethingHappened(string foo)
        {
            this.Counter++;//condensed counter increase
            Console.WriteLine("HIT {0} => HandleSomethingHappened. Data: {1}", this.Counter, foo);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
               if(SomethingHappened != null)//making sure that the event handler is properly unsubscribed by checking if it is not null before attempting to remove event handlers.
                {
                    foreach(var d in SomethingHappened.GetInvocationList())//get list of delegates subscribed to event and remove them from the event invocation list
                    {
                        SomethingHappened -= (MyEventHandler)(d);
                    }
                }
            }

            // Free native resources
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~DisposableObject()
        {
            Dispose(false);
        }
    }
}