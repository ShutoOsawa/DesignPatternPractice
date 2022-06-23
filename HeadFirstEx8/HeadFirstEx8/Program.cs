using System;
using System.IO;

namespace HeadFirstEx8
{
    class Program
    {
        static void Main(string[] args)
        {
            CoffeeWithHook coffee = new CoffeeWithHook();
            coffee.prepareRecipe();
        }
    }

    public class CoffeeWithHook : CaffeineBeverageWithHook
    {

        public override void brew()
        {
            Console.WriteLine("Dripping Coffee through filter");
        }

        public override void addCondiments()
        {
            Console.WriteLine("Adding Sugar and Milk");
        }

        public override bool customerWantsCondiments()
        {
            string answer = getUserInput();

            if (answer.ToLower().StartsWith("y"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string getUserInput()
        {
            string answer = null;
            Console.WriteLine("Would you like milk and sugar with your coffee (y/n)?");
            try
            {
                answer = Console.ReadLine();
            }
            catch(IOException e)
            {
                Console.Error.WriteLine("IO error trying to read your answer");
            }
            if(answer == "")
            {
                return "no";
            }

            return answer;
        }
    }

    public abstract class CaffeineBeverageWithHook
    {
        public void prepareRecipe()
        {
            boilWater();
            brew();
            pourInCup();
            if (customerWantsCondiments())
            {
                addCondiments();
            }
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

        public virtual bool customerWantsCondiments()
        {
            return true;
        }
    }
}
