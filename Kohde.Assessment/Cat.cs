using System;

namespace Kohde.Assessment
{
    public class Cat:Animal, IHasNameAndAge
    {
        public string Food { get; set; }

        public Cat(string name, int age, string food)//wrote constructor to handle creation of objects.
        {
            Name = name;
            Age = age;
            Food = food;
        }

        public Cat()//wrote default constructor.
        {
            Name = String.Empty;
            Age = 0;
            Food = String.Empty;
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