using System;

namespace HeadFirstEx1
{
    class Program
    {
        static void Main(string[] args)
        {
            MallardDuck mallard = new MallardDuck();
            Console.WriteLine("MallardDuck");
            mallard.performFly();
            mallard.performQuack();
            Console.WriteLine("RubberDuck");
            RubberDuck rubber = new RubberDuck();
            rubber.performFly();
            rubber.performQuack();
            Console.WriteLine("------------------------");
            rubber.setFlyBehavior(new FlyWithWings());
            rubber.performFly();
        }
    }

    public abstract class Duck
    {
        public FlyBehavior flyBehavior;
        public QuackBehavior quackBehavior;

        public Duck()
        {

        }
        public abstract void display();

        public void setFlyBehavior(FlyBehavior fb)
        {
            flyBehavior = fb;
        }
        public void performFly()
        {
            flyBehavior.fly();
        }

        public void setQuackBehavior(QuackBehavior qb)
        {
            quackBehavior = qb;
        }

        public void performQuack()
        {
            quackBehavior.quack();
        }
        public void swim()
        {
            Console.WriteLine("Swim");
        }
    }

    public interface FlyBehavior
    {
        void fly();
    }

    public class FlyWithWings : FlyBehavior
    {
        public void fly()
        {
            Console.WriteLine("I am flying.");
        }
    }
    public class FlyNoWay : FlyBehavior
    {
        public void fly()
        {
            Console.WriteLine("I cannot fly.");
        }
    }

    public interface QuackBehavior
    {
        void quack();
    }

    public class Quack:QuackBehavior
    {
        public void quack()
        {
            Console.WriteLine("Quack");
        }
    }

    public class Squeak : QuackBehavior
    {
        public void quack()
        {
            Console.WriteLine("Squeak");
        }
    }

    public class MuteQuack : QuackBehavior
    {
        public void quack()
        {
            Console.WriteLine("<< Silence >>");        
        }
    }
    public class MallardDuck: Duck
    {
        public MallardDuck()
        {            
            setFlyBehavior(new FlyWithWings());
            setQuackBehavior(new Quack());
        }

        public override void display()
        {
            Console.WriteLine("I am a MallardDuck");
        }
    }

    public class RubberDuck : Duck
    {
        public RubberDuck()
        {       
            setFlyBehavior(new FlyNoWay());
            setQuackBehavior(new Squeak());
        }

        public override void display()
        {
            Console.WriteLine("I am a rubber duck");
        }
    }



}
