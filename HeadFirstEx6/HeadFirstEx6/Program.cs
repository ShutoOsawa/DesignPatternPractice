using System;
using System.Text;

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

    public class NoCommand: Command
    {
        public void execute()
        {
            
        }
    }


    public class RemoteControl
    {
        Command[] onCommands;
        Command[] offCommands;

        public RemoteControl()
        {
            onCommands = new Command[7];
            offCommands = new Command[7];

            Command noCommand = new NoCommand();
            for(int i = 0; i < 7; i++)
            {
                onCommands[i] = noCommand;
                offCommands[i] = noCommand;
            }
        }

        public void setCommand(int slot,Command onCommand,Command offCommand)
        {
            onCommands[slot] = onCommand;
            offCommands[slot] = offCommand;

        }

        public void onButtonWasPushed(int slot)
        {
            onCommands[slot].execute();

        }

        public void offButtonWasPushed(int slot)
        {
            offCommands[slot].execute();
        }

        public string toString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\n------ Remote Control------ -\n");
            for(int i=0;i < onCommands.Length; i++)
            {
                sb.Append("[slot " + i + "] " + onCommands[i].GetType().Name + " " + offCommands[i].GetType().Name + "\n");
            }

            return sb.ToString();
        }
    }
}
