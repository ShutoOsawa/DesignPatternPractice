using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace HeadFirstEx5
{
    class Program
    {

        private static object lockObj = new object();
        private bool flag = true;
        static void Main(string[] args)
        {
            //ChocolateBoiler boiler = ChocolateBoiler.getInstance();
            //boiler.fill();
            //boiler.boil();
            //boiler.drain();

            //ChocolateBoiler boiler2 = ChocolateBoiler.getInstance();
            var lst = new List<ChocolateBoiler>();
            //ChocolateBoiler boiler = new ChocolateBoiler();
            //ChocolateBoiler boiler2 = new ChocolateBoiler();
            //lst.Add(boiler);
            //lst.Add(boiler2);

            ChocolateBoiler boiler = ChocolateBoiler.getInstance();
            ChocolateBoiler boiler2 = ChocolateBoiler.getInstance();

            if (boiler == boiler2)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }

            //lst.Add(boiler);
            //lst.Add(boiler2);

            //compareBoiler(lst);


            //ParallelLoopResult result = Parallel.For(0, 2, i =>
            //{
            //lock (lockObj)
            //{
            //    int id = System.Threading.Thread.CurrentThread.ManagedThreadId;
            //    Console.WriteLine("ThreadID : " + id);
            //    addBoiler(lst);
            //    Thread.Sleep(1000);
            //    }
            //});


            //for (int i = 0; i < 2; i++)
            //{
            //    int id = System.Threading.Thread.CurrentThread.ManagedThreadId;
            //    Console.WriteLine("ThreadID : " + id);

            //    ChocolateBoiler boiler = ChocolateBoiler.getInstance();
            //    lst.Add(boiler);
            //}

            //compareBoiler(lst);

            //Task task1 = Task.Factory.StartNew(() => addBoiler(lst));
            //Task task2 = Task.Factory.StartNew(() => addBoiler(lst));

            //Task.WhenAll(task1, task2);


            //Console.WriteLine("All threads complete");
            //for (int i = 0;i < lst.Count; i++)
            //{
            //    Console.WriteLine(lst[i].ID);
            //   // Console.WriteLine(lst.Count);
            //}



            //compareBoiler(lst);


        }

        public static void addBoiler(List<ChocolateBoiler> lst)
        {
            ChocolateBoiler boiler = ChocolateBoiler.getInstance();
            boiler.fill();
            boiler.boil();
            boiler.drain();
            lst.Add(boiler);
            Thread.Sleep(1000);
            int id = System.Threading.Thread.CurrentThread.ManagedThreadId;
                Console.WriteLine("ThreadID : " + id);
        }

        public static void compareBoiler(List<ChocolateBoiler> lst)
        {

            if (lst[0] == lst[1])
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
            
        }



    }

    //public class Execute
    //{
    //    private bool flag = true;
    //    public void executeTasks()
    //    {

    //        var lst = new List<ChocolateBoiler>();
    //        Task task1 = Task.Factory.StartNew(() => addBoiler(lst));
    //        Task task2 = Task.Factory.StartNew(() => addBoiler(lst));
    //        Task.WaitAll(task1, task2);
            

    //        while (true)
    //        {
    //            if(lst.Count > 1)
    //            {
    //                flag = false;
    //            }
                
    //        }

            
    //    }

    //    public void addBoiler(List<ChocolateBoiler> lst)
    //    {
    //        ChocolateBoiler boiler = ChocolateBoiler.getInstance();
    //        boiler.fill();
    //        boiler.boil();
    //        boiler.drain();
    //        lst.Add(boiler);
    //        Thread.Sleep(1000);
    //        int id = System.Threading.Thread.CurrentThread.ManagedThreadId;
    //        Console.WriteLine("ThreadID : " + id);
    //    }

    //    public void compareBoiler(List<ChocolateBoiler> lst)
    //    {
    //        int id = System.Threading.Thread.CurrentThread.ManagedThreadId;
    //        // Console.WriteLine("ThreadID : " + id);
    //        if (lst.Count > 1)
    //        {
    //            if (lst[0] == lst[1])
    //            {
    //                Console.WriteLine("True");
    //            }
    //            else
    //            {
    //                Console.WriteLine("False");
    //            }
    //            Console.WriteLine("ThreadID : " + id);
    //        }

    //    }

    //}

    //    public class Singleton
    //{
    //    private static Singleton uniqueInstance;

    //    private Singleton()
    //    {

    //    }

    //    public static Singleton getInstance()
    //    {
    //        if(uniqueInstance == null)
    //        {
    //            uniqueInstance = new Singleton();
    //        }

    //        return uniqueInstance;
    //    }
    //}

    public class ChocolateBoiler
    {
        private bool empty;
        private bool boiled;
        public ChocolateBoiler()
        {
            empty = true;
            boiled = false;
        }
        private static object lockObj = new object();
        private static ChocolateBoiler uniqueInstance;
        public static ChocolateBoiler getInstance()
        {
            //lock (lockObj)
            //{
                if (uniqueInstance == null)
                {
                    uniqueInstance = new ChocolateBoiler();
                }
            
                return uniqueInstance;
            //}
        }

        public void fill()
        {
            if (isEmpty())
            {
                empty = false;
                boiled = false;
            }
        }

        public void drain()
        {
            if(!isEmpty() && isBoiled())
            {
                empty = true;
            }
        }

        public void boil()
        {
            if(!isEmpty() && !isBoiled())
            {
                boiled = true;
            }
        }

        public bool isEmpty()
        {
            return empty;
        }

        public bool isBoiled()
        {
            return boiled;
        }
    }
}
