using System;
using System.Xml.Linq;

namespace Kohde.Assessment
{
    public class Human: Animal
    {

        public string Gender { get; set; }

        public Human(string name, int age, string gender)//wrote constructor to handle creation of objects.
        {
            Name = name;
            Age = age;
            Gender = gender;
        }
        public Human()//wrote default constructor.
        {
            Name = String.Empty;
            Age = 0;
            Gender = String.Empty;

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