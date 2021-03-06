using System;
using System.Text;

namespace HeadFirstEx6
{
    class Program
    {
        static void Main(string[] args)
        {
            //RemoteControl remote = new RemoteControl();
            //invoker
            RemoteControlWithUndo remote = new RemoteControlWithUndo();

            //command objects
            Light livingRoomLight = new Light("Living Room");
            Light kitchenLight = new Light("Kitchen");
            LightOnCommand livingRoomLightOn = new LightOnCommand(livingRoomLight);            
            LightOffCommand livingRoomLightOff = new LightOffCommand(livingRoomLight);

            LightOnCommand kitchenLightOn = new LightOnCommand(kitchenLight);
            LightOffCommand kitchenLightOff = new LightOffCommand(kitchenLight);

            //store command objects in the invoker
            remote.setCommand(0,livingRoomLightOn,livingRoomLightOff);
            remote.setCommand(1,kitchenLightOn, kitchenLightOff);

            //execute commands
            remote.onButtonWasPushed(0);
            remote.undoButtonWasPushed();
            remote.offButtonWasPushed(0);
            remote.undoButtonWasPushed();
            
            Console.WriteLine(remote.toString());
            remote.onButtonWasPushed(1);
            remote.offButtonWasPushed(1);

            
        }
    }

    public interface Command
    {
        public void execute();
        public void undo();
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

        public void undo()
        {
            light.off();
        }
    }

    public class LightOffCommand : Command
    {
        Light light;
        public LightOffCommand(Light light)
        {
            this.light = light;
        }

        public void execute()
        {
            light.off();
        }

        public void undo()
        {
            light.on();
        }
    }

   

    public class Light
    {
        private string name;

        public Light(string name = "")
        {
            this.name = name;
        }

        public void on()
        {
            Console.WriteLine($"{name} Light is On");
        }

        public void off()
        {
            Console.WriteLine($"{name} Light is Off");
        }
    }

    public class Stereo
    {
        public void on()
        {
            Console.WriteLine("Stereo is On");
        }

        public void off()
        {
            Console.WriteLine("Stereo is Off");
        }

        public void setCD()
        {

        }

        public void setVolume(int volume)
        {

        }
    }
    public class StereoOnWithCDCommand : Command
    {
        Stereo stereo;

        public StereoOnWithCDCommand(Stereo stereo)
        {
            this.stereo = stereo;
        }

        public void execute()
        {
            stereo.on();
            stereo.setCD();
            stereo.setVolume(11);
        }

        public void undo()
        {

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

        public void undo()
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

    public class RemoteControlWithUndo
    {
        Command[] onCommands;
        Command[] offCommands;
        Command undoCommand;

        public RemoteControlWithUndo()
        {
            onCommands = new Command[7];
            offCommands = new Command[7];

            Command noCommand = new NoCommand();
            for (int i = 0; i < 7; i++)
            {
                onCommands[i] = noCommand;
                offCommands[i] = noCommand;
            }
            undoCommand = noCommand;
        }

        public void setCommand(int slot, Command onCommand, Command offCommand)
        {
            onCommands[slot] = onCommand;
            offCommands[slot] = offCommand;

        }

        public void onButtonWasPushed(int slot)
        {
            onCommands[slot].execute();
            undoCommand = onCommands[slot];
        }

        public void offButtonWasPushed(int slot)
        {
            offCommands[slot].execute();
            undoCommand = offCommands[slot];
        }

        public void undoButtonWasPushed()
        {
            undoCommand.undo();
        }

        public string toString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\n------ Remote Control------ -\n");
            for (int i = 0; i < onCommands.Length; i++)
            {
                sb.Append("[slot " + i + "] " + onCommands[i].GetType().Name + " " + offCommands[i].GetType().Name + "\n");
            }

            return sb.ToString();
        }
    }
}
