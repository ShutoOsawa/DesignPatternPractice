using System;

namespace Chapter7AdapterPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            MallardDuck duck = new MallardDuck();
            WildTurkey turkey = new WildTurkey();
            Duck turkeyAdapter = new TurkeyAdapter(turkey);

            Console.WriteLine("The turkey says...");
            turkey.gobble();
            turkey.fly();

            Console.WriteLine("\nThe Duck says...");
            testDuck(duck);

            Console.WriteLine("\nThe TurkeyAdpater says...");
            testDuck(turkeyAdapter);
        }
        
        static void testDuck(Duck duck)
        {
            duck.quack();
            duck.fly();
        }
    }

    public interface Duck
    {
        public void quack();
        public void fly();
    }

    public class MallardDuck : Duck
    {
        public void quack()
        {
            Console.WriteLine("Quack");
        }

        public void fly()
        {
            Console.WriteLine("I'm flying");
        }
    }

    public interface Turkey
    {
        public void gobble();
        public void fly();

    }

    public class WildTurkey: Turkey
    {
        public void gobble()
        {
            Console.WriteLine("Gobble gobble");
        }

        public void fly()
        {
            Console.WriteLine("I'm flying a short distance");
        }
    }

    public class TurkeyAdapter : Duck
    {
        Turkey turkey;
        public TurkeyAdapter(Turkey turkey)
        {
            this.turkey = turkey;
        }

        public void quack()
        {
            turkey.gobble();
        }

        public void fly()
        {
            turkey.fly();
        }
    }

}
