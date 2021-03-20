using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptTest2
{
    public class InheritanceQuestions
    {
        public void Execute()
        {
            Console.WriteLine("\nInheritance Questions:");
            var animals = AnimalFactory.GetAnimals();
            if (animals != null)
            {
                foreach (var animal in animals)
                {
                    Console.WriteLine($"{animal.Species} says {animal.Sound}");
                }
            }
        }
    }


    //----------------------------------------------------------------------------------------------------------
    // Question #1: Using class AnimalBase below, create 2 derived classes from it
    //              1) class Dog (Species = Dog, Sound = Woof)
    //              2) class Cat (Species = Cat, Sound = Meow)
    public class AnimalBase
    {
        private string species;
        public AnimalBase(string species)
        {
            this.species = species;
        }
        public virtual string Sound { get; }
        public string Species => species;
    }

    public class Dog : AnimalBase
    {
        public Dog () : base("Dog")
        {

        }

        public override string Sound => "Woof";
    }

    public class Cat : AnimalBase
    {
        public Cat() : base("Cat")
        {

        }

        public override string Sound => "Meow";
    }

    public class CatDog : AnimalBase
    {
        public CatDog() : base("CatDog")
        {

        }

        public override string Sound => "Wooeow";
    }






    //----------------------------------------------------------------------------------------------------------
    // Question #2: Using the 2 new derived classes implemented in question 1, modify
    //              GetAnimals() below to return a list including 1 instance of Dog and 
    //              1 instance of Cat.  Use a list initializer to create the list.
    public static class AnimalFactory
    {
        public static List<AnimalBase> GetAnimals()
        {
            var newCat = new Cat();
            var newDog = new Dog();
            var newSpecies = new CatDog();

            var animalList = new List<AnimalBase> { newCat, newDog, newSpecies };

            return animalList;
        }
    }
}
