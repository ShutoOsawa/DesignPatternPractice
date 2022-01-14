using System;

namespace HeadFirstEx3
{
    class Program
    {
        static void Main(string[] args)
        {
           
           
            Beverage matchaFrap = new MatchaCreamFrap();
            matchaFrap = new Grande(matchaFrap);
            matchaFrap = new ChocolateChip(matchaFrap);
            matchaFrap = new Ristretto(matchaFrap);
            matchaFrap = new VanillaSyrup(matchaFrap);
            matchaFrap = new VanillaSyrup(matchaFrap);
            matchaFrap = new VanillaSyrup(matchaFrap);
            matchaFrap = new VanillaSyrup(matchaFrap);
            matchaFrap = new VanillaSyrup(matchaFrap);
            matchaFrap = new MatchaPowder(matchaFrap);
            matchaFrap = new WhippedCream(matchaFrap);
            Console.WriteLine("{0}, Total: {1} Yen", matchaFrap.getDescription(), matchaFrap.cost());

            //Beverage dripCoffee = new DripCoffee();
            //dripCoffee = new VanillaSyrup(dripCoffee);
            //Console.WriteLine("{0}, Total: {1} Yen", dripCoffee.getDescription(), dripCoffee.cost());
        }
    }

    public abstract class Beverage
    {
        string description = "Unknown Beverage";

        public virtual string getDescription()
        {
            return description;
        }       

        public abstract double cost();
    }

    public abstract class CondimentDecorator : Beverage
    {
        protected Beverage beverage;
    }

    public abstract class SizeDecorator : Beverage
    {
        protected Beverage beverage;
    }

    public abstract class EspressoShots : Beverage
    {
        protected Beverage beverage;
    }

    public class Espresso : EspressoShots
    {
        Beverage beverage;

        public Espresso(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override string getDescription()
        {
            return beverage.getDescription() + ", Espresso Shot";
        }

        public override double cost()
        {
            return 55 + beverage.cost();
        }
    }

    public class Ristretto: EspressoShots
    {
        Beverage beverage;

        public Ristretto(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override string getDescription()
        {
            return beverage.getDescription() + ", Ristretto Shot";
        }

        public override double cost()
        {
            return 55 + beverage.cost();
        }
    }

    public class MatchaCreamFrap:Beverage
    {
        public override string getDescription()
        {
            return "Matcha Cream Frap";
        }

        public override double cost()
        {
            return 539;
        }
    }



    public class DripCoffee : Beverage
    {
        public override string getDescription()
        {
            return "Drip Coffee";
        }

        public override double cost()
        {
            return 319;
        }
    }


    public class ChocolateChip : CondimentDecorator
    {
        Beverage beverage;

        public ChocolateChip(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override string getDescription()
        {
            return beverage.getDescription() + ", Chocolate Chip";
        }

        public override double cost()
        {
            return 55 + beverage.cost();
        }
    }

    public class VanillaSyrup : CondimentDecorator
    {
        Beverage beverage;

        public VanillaSyrup(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override string getDescription()
        {
            return beverage.getDescription() + ", Vanilla Syrup";
        }

        public override double cost()
        {
            return 55 + beverage.cost();
        }
    }

    public class MatchaPowder : CondimentDecorator
    {
        Beverage beverage;

        public MatchaPowder(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override string getDescription()
        {
            return beverage.getDescription() + ", Matcha Powder";
        }

        public override double cost()
        {
            return 0 + beverage.cost();
        }
    }

    public class WhippedCream : CondimentDecorator
    {
        Beverage beverage;

        public WhippedCream(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override string getDescription()
        {
            return beverage.getDescription() + ", Whipped Cream";
        }

        public override double cost()
        {
            return 0 + beverage.cost();
        }
    }

    public class Short : SizeDecorator
    {
        Beverage beverage;

        public Short(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override string getDescription()
        {
            return beverage.getDescription() + ", Short";
        }

        public override double cost()
        {
            return 0 + beverage.cost();
        }
    }

    public class Tall : SizeDecorator
    {
        Beverage beverage;

        public Tall(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override string getDescription()
        {
            return beverage.getDescription() + ", Tall";
        }

        public override double cost()
        {
            return 44 + beverage.cost();
        }
    }

    public class Grande : SizeDecorator
    {
        Beverage beverage;

        public Grande(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override string getDescription()
        {
            return beverage.getDescription() + ", Grande";
        }

        public override double cost()
        {
            return 88 + beverage.cost();
        }
    }

    public class Venti : SizeDecorator
    {
        Beverage beverage;

        public Venti(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override string getDescription()
        {
            return beverage.getDescription() + ", Venti";
        }

        public override double cost()
        {
            return 132 + beverage.cost();
        }
    }
}
