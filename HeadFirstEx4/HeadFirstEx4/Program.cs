using System;
using System.Collections;
using System.Collections.Generic;

namespace HeadFirstEx4
{
    class Program
    {
        static void Main(string[] args)
        {
            //SimplePizzaStore simplePizzaStore = new SimplePizzaStore();
            //SimplePizza simplePizza = simplePizzaStore.orderPizza();
            //Console.WriteLine("Ethan ordered a " + simplePizza.getName() + ".\n");


            PizzaStore nyStore = new NYPizzaStore();
            Pizza cheesepizza = nyStore.orderPizza("cheese");
            Console.WriteLine("Ethan ordered a " + cheesepizza.getName() + "\n");

            Pizza veggiepizza = nyStore.orderPizza("veggie");
            Console.WriteLine("Ethan ordered a " + veggiepizza.getName() + "\n");

            PizzaStore chicagoStore = new ChicagoPizzaStore();
            Pizza chicagoCheesePizza = chicagoStore.orderPizza("cheese");
            Console.WriteLine("Ethan ordered a " + chicagoCheesePizza.getName() + "\n");

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
            else if (type == "veggie")
            {
                return new NYStyleVeggiePizza();
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

    public class NYStyleVeggiePizza : Pizza
    {
        public NYStyleVeggiePizza()
        {
            Name = "NY Style Sause and Veggie Pizza";
            Dough = "Thin Crust Dough";
            Sauce = "Marinara Sauce";
            Toppings.Add("Veggie");
        }
    }

    public class NYStylePepperoniPizza : Pizza
    {
        public NYStylePepperoniPizza()
        {
            Name = "NY Style Sause and Pepperoni Pizza";
            Dough = "Thin Crust Dough";
            Sauce = "Marinara Sauce";
            Toppings.Add("Pepperoni");
        }
    }

   

    public class ChicagoPizzaStore : PizzaStore
    {
        protected override Pizza createPizza(string type)
        {
            if (type == "cheese")
            {
                return new ChicagoStyleCheesePizza();
            }
            else if (type == "veggie")
            {
                return new ChicagoStyleVeggiePizza();
            }
            else if (type == "pepperoni")
            {
                return new ChicagoStylePepperoniPizza();
            }
            else return null;

        }
    }
    public class ChicagoStyleCheesePizza : Pizza
    {
        public ChicagoStyleCheesePizza()
        {
            Name = "Chicago Style Deep Dish Cheese Pizza";
            Dough = "Extra Thick Crust Dough";
            Sauce = "Plum Tomato Sauce";
            Toppings.Add("Shredded Mozzarella Cheese");
        }

        public override void cut()
        {
            Console.WriteLine("Cutting the pizza into square slices");
        }

    }

    public class ChicagoStyleVeggiePizza : Pizza
    {
        public ChicagoStyleVeggiePizza()
        {
            Name = "Chicago Style Deep Dish Cheese Pizza";
            Dough = "Extra Thick Crust Dough";
            Sauce = "Plum Tomato Sauce";
            Toppings.Add("Shredded Mozzarella Cheese");
        }

        public override void cut()
        {
            Console.WriteLine("Cutting the pizza into square slices");
        }

    }

    public class ChicagoStylePepperoniPizza : Pizza
    {
        public ChicagoStylePepperoniPizza()
        {
            Name = "Chicago Style Deep Dish Cheese Pizza";
            Dough = "Extra Thick Crust Dough";
            Sauce = "Plum Tomato Sauce";
            Toppings.Add("Shredded Mozzarella Cheese");
        }

        public override void cut()
        {
            Console.WriteLine("Cutting the pizza into square slices");
        }

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

        public virtual void cut()
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

    //public class SimplePizza
    //{

    //    //public string Name { get; set; }
    //    //public string Dough { get; set; }
    //    //public string Sauce { get; set; }
    //    //public List<string> Toppings { get; set; } = new List<string>();

    //    private string name;
    //    private string dough;
    //    private string sauce;
    //    private List<string> toppings = new List<string>();

    //    public SimplePizza()
    //    {
    //        name = "Simple Pizza";
    //        this.dough = "Simple Dough";
    //        this.sauce = "Simple Tomato Sauce";
    //        toppings.Add("Cheese");
    //    }

        
        
    //    public void prepare()
    //    {
    //        Console.WriteLine("Preparing " + name);
    //        Console.WriteLine("Tossing dough...");
    //        Console.WriteLine("Adding sauce... ");
    //        Console.WriteLine("Adding toppings: ");
    //        for (int i = 0; i < toppings.Count; i++)
    //        {
    //            Console.WriteLine("    " + toppings[i]);
    //        }
    //    }
    //    public void bake()
    //    {
    //        Console.WriteLine("Bake for 25 minutes at 350");
    //    }

    //    public virtual void cut()
    //    {
    //        Console.WriteLine("Cutting the pizza into diagonal slices");
    //    }

    //    public void box()
    //    {
    //        Console.WriteLine("Place pizza in official PizzaStore box");
    //    }

    //    public string getName()
    //    {
    //        return name;
    //    }
    //}
}
