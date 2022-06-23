using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadFirstEx8x2
{

    class Program
    {
        //static void Main(string[] args)
        //{
        //    Tea tea = new Tea();
        //    tea.prepareRecipe();

        //    Coffee coffee = new Coffee();
        //    coffee.prepareRecipe();
        //}
    }
    public class Tea : CaffeineBeverage
    {
        public override void brew()
        {
            Console.WriteLine("Steeping the tea");
        }

        public override void addCondiments()
        {
            Console.WriteLine("Adding Lemon");
        }
    }

    public class Coffee : CaffeineBeverage
    {
        public override void brew()
        {
            Console.WriteLine("Dripping Coffee through filter");
        }

        public override void addCondiments()
        {
            Console.WriteLine("Adding Sugar and Milk");
        }
    }


    public abstract class CaffeineBeverage
    {
        public void prepareRecipe()
        {
            boilWater();
            brew();
            pourInCup();
            addCondiments();
        }

        public abstract void brew();
        public abstract void addCondiments();

        public void boilWater()
        {
            Console.WriteLine("Boiling water");
        }

        public void pourInCup()
        {
            Console.WriteLine("Pourint into cup");
        }
    }
}
