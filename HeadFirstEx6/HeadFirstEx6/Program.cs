using System;

namespace HeadFirstEx6
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleRemoteControl remote = new SimpleRemoteControl();
            Light light = new Light();
            LightOnCommand lightOn = new LightOnCommand(light);

            remote.setCommand(lightOn);
            remote.buttonWasPressed();
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
            Console.WriteLine("Light is On");
        }

        public void off()
        {
            Console.WriteLine("Light is Off");
        }
    }

    public class SimpleRemoteControl
    {
        Command slot;
        public SimpleRemoteControl() { }

        public void setCommand(Command command)
        {
            slot = command;
        }

        public void buttonWasPressed()
        {
            slot.execute();
        }
    }
}
