using System;
using System.Web;

namespace Kohde.Assessment
{
    public class Dog :Animal, IDisposable, IHasNameAndAge//made Dog implement IDisposable
    {
        public string Food { get; set; }

        public Dog(string name, int age, string food)//wrote constructor to handle creation of objects.
        {
            Name = name;
            Age = age;
            Food = food;
        }

        public Dog() //wrote default constructor.
        {
            Name = String.Empty;
            Age = 0;
            Food = String.Empty;
        
        }

        public void Dispose()//added Dispose method to handle object diposal
        {
            Dispose(true);
            GC.SuppressFinalize(this);        
        } 
        
        protected virtual void Dispose(bool disposing)
        {

        }

        ~Dog()
        {
            Dispose(false);
        }

        public override string GetDetails()
        {
            return "Name: " + Name + "Age: " + Age;
        }

        public override string ToString()
        {
            return GetDetails();
        }
    }
}