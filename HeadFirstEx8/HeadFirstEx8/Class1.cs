using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadFirstEx8x
{
    public class Coffee
    {
        public void prepareRecipe()
        {
            boilWater();
            brewCoffeeGrinds();
            pourInCup();
            addSugarAndMilk();
        }

        public void boilWater()
        {
            Console.WriteLine("Boiling water");
        }

        public void brewCoffeeGrinds()
        {
            Console.WriteLine("Dripping Coffee through filter");
        }

        public void pourInCup()
        {
            Console.WriteLine("Pourint into cup");
        }

        public void addSugarAndMilk()
        {
            Console.WriteLine("Adding Sugar and Milk");

        }
    }

    public class Tea
    {
        public void prepareRecipe()
        {
            boilWater();
            steepTeaBag();
            pourInCup();
            addLemon();
        }

        public void boilWater()
        {
            Console.WriteLine("Boiling water");
        }

        public void steepTeaBag()
        {
            Console.WriteLine("Steeping the tea");
        }

        public void addLemon()
        {
            Console.WriteLine("Adding Lemon");

        }

        public void pourInCup()
        {
            Console.WriteLine("Pourint into cup");
        }


    }
}
