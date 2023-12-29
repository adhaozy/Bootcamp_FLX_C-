using System;

namespace DoFactory.GangOfFour.Factory.Structural
{
    class MainApp
    {
        static void Main()
        {
            // Create products directly without using Factory Method

            ConcreteProductA productA = new ConcreteProductA();
            Console.WriteLine("Created {0}", productA.GetType().Name);

            ConcreteProductB productB = new ConcreteProductB();
            Console.WriteLine("Created {0}", productB.GetType().Name);

            // Wait for user
            Console.ReadKey();
        }
    }

    // The 'Product' abstract class
    abstract class Product
    {
    }

    // A 'ConcreteProduct' class
    class ConcreteProductA : Product
    {
    }

    // A 'ConcreteProduct' class
    class ConcreteProductB : Product
    {
    }

    // The 'Creator' abstract class
    abstract class Creator
    {
        public abstract Product FactoryMethod();
    }

    // A 'ConcreteCreator' class
    class ConcreteCreatorA : Creator
    {
        public override Product FactoryMethod()
        {
            return new ConcreteProductA();
        }
    }

    // A 'ConcreteCreator' class
    class ConcreteCreatorB : Creator
    {
        public override Product FactoryMethod()
        {
            return new ConcreteProductB();
        }
    }
}
