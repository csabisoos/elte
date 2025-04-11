using System.Data.SqlTypes;
using NinthLabor.Behavioral.Strategy;
using NinthLabor.Behavioral.Template;
using NinthLabor.Creational.Factory;
using NinthLabor.Creational.Singleton;
using NinthLabor.Structural.Bridge;
using NinthLabor.Structural.Composite;
using Class = NinthLabor.Behavioral.Template.Class;

namespace NinthLabor
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Singleton
            {
                Singleton.Instance().Method();
                Console.WriteLine();
            }
            #endregion Singleton
            
            #region Factory Method
            {
                Creator creator;

                creator = new CreatorFirst();
                creator.Method();

                creator = new CreatorSecond();
                creator.Method();

                Console.WriteLine();
            }
            #endregion Factory Method
            
            #region Bridge

            {
                IImplementation implementation;
                Abstraction abstraction;

                implementation = new ImplementationFirst();
                abstraction = new(implementation);
                abstraction.Method();
                
                implementation = new ImplementationSecond();
                abstraction = new(implementation);
                abstraction.Method();
            }
            #endregion Bridge
            
            #region Composite

            {
                Composite composite1 = new();
                Composite composite2 = new();
                Composite composite3 = new();

                Leaf leaf1 = new();
                Leaf leaf2 = new();
                Leaf leaf3 = new();
                
                composite2.Add(leaf1);
                
                composite3.Add(leaf2);
                composite3.Add(leaf3);
                
                composite1.Add(composite2);
                composite1.Add(composite3);
                
                composite1.Method();
                Console.WriteLine();
            }
            #endregion Composite

            #region Template Method

            {
                Behavioral.Template.Class @class;
                
                @class = new ClassFirst();
                @class.Template();

                @class = new ClassSecond();
                @class.Template();

                Console.WriteLine();
            }

            #endregion

            #region Strategy

            {
                IStrategy strategy;
                Behavioral.Strategy.Class @class;

                strategy = new StrategyFirst();
                @class = new(strategy);
                @class.Method();

                strategy = new StrategySecond();
                @class.Strategy = strategy;
                @class.Method();

                Console.WriteLine();
            }

            #endregion
        }
    }
}

