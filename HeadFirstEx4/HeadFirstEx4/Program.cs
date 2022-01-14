using System;
using System.Collections;
using System.Collections.Generic;

namespace HeadFirstEx4
{
    class Program
    {
        static void Main(string[] args)
        {
            PizzaStore nyStore = new NYPizzaStore();
            Pizza pizza = nyStore.orderPizza("cheese");
            Console.WriteLine("Ethan ordered a " + pizza.getName() + "\n");
        }
    }

    public abstract class PizzaStore
    {

        public Pizza orderPizza(string type)
        {
            Pizza pizza;
            pizza = createPizza(type);
            pizza.prepare();
            pizza.bake();
            pizza.cut();
            pizza.box();
            return pizza;
        }

        protected abstract Pizza createPizza(string type);
    }

    public class NYPizzaStore: PizzaStore  
    {
        protected override Pizza createPizza(string type)
        {
            if (type == "cheese")
            {
                return new NYStyleCheesePizza();
            }
            else if (type == "greek")
            {
                return new NYStyleGreekPizza();
            }
            else if (type == "pepperoni")
            {
                return new NYStylePepperoniPizza();
            }
            else return null;
            
        }
    }

    public class NYStyleCheesePizza : Pizza
    {
        public NYStyleCheesePizza()
        {
            Name = "NY Style Sause and Cheese Pizza";
            Dough = "Thin Crust Dough";
            Sauce = "Marinara Sauce";
            Toppings.Add("Grated Reggiano Cheese");
        }
    }

    public class NYStyleGreekPizza : Pizza
    {

    }

    public class NYStylePepperoniPizza : Pizza
    {

    }
    public class Pizza
    {

        public string Name { get; set; }
        public string Dough { get; set; }
        public string Sauce { get; set; }
        public List<string> Toppings { get; set; } = new List<string>();

        public void prepare()
        {
            Console.WriteLine("Preparing " + Name);
            Console.WriteLine("Tossing dough...");
            Console.WriteLine("Adding sauce... ");
            Console.WriteLine("Adding toppings: ");
            for(int i = 0;i < Toppings.Count; i++)
            {
                Console.WriteLine("    " + Toppings[i]);
            }
        }
        public void bake()
        {
            Console.WriteLine("Bake for 25 minutes at 350");
        }

        public void cut()
        {
            Console.WriteLine("Cutting the pizza into diagonal slices");
        }

        public void box()
        {
            Console.WriteLine("Place pizza in official PizzaStore box");
        }

        public string getName()
        {
            return Name;
        }
    }
}
