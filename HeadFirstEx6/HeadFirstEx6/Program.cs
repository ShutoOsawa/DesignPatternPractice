using System;

namespace HeadFirstEx6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public interface Command
    {
        public void execute();
    }

    public class LightOnCommand: Command
    {
        Light light;
        public LightOnCommand(Light light)
        {
            this.light = light;
        }

        public void execute()
        {
            light.on();
        }
    }

    public class Light
    {
        public void on()
        {

        }

        public void off()
        {

        }
    }
}
