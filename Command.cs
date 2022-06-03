namespace CommandSimple
{
    using System.Collections.Generic;

    public abstract class Command
    {
        public abstract void Execute();
    }

    public class ConcreteCommand : Command
    {
        private int someState;
        Receiver receiver = null;

        public ConcreteCommand(Receiver receiver)
        {
            this.receiver = receiver;
        }

        public override void Execute()
        {
            receiver.SomeAction();
        }
    }

    public class Receiver
    {
        public void SomeAction()
        {
        }
    }

    public class SomeApplication
    {
        private List<Command> commandList = null;
        private int currentIndex = 0;

        public void SomeFunction()
        {
            this.commandList = new List<Command>();

            var receiver1 = new Receiver();
            var command1 = new ConcreteCommand(receiver1);
            commandList.Add(command1);

            var receiver2 = new Receiver();
            var command2 = new ConcreteCommand(receiver2);
            commandList.Add(command2);
        }

        public void ExecuteNext()
        {
            commandList[currentIndex].Execute();
            currentIndex++;
        }
    }
}

namespace CommandPractice
{
    using System.Collections.Generic;

    public abstract class Command
    {
        public abstract void Execute();
        public abstract void Unexecute();
    }

    public class ConcreteCommand1 : Command
    {
        private int someState;

        public ConcreteCommand1()
        {
        }

        public override void Execute()
        {
        }

        public override void Unexecute()
        {
        }
    }

    public class ConcreteCommand2 : Command
    {
        private int someState;
        Receiver receiver = null;

        public ConcreteCommand2(Receiver receiver)
        {
            this.receiver = receiver;
        }

        public override void Execute()
        {
            receiver.SomeAction();
        }

        public override void Unexecute()
        {
            receiver.SomeUndoAction();
        }
    }

    public class MacroCommand : Command
    {
        private List<Command> commandList = null;
        private int someState;
        Receiver receiver = null;

        public MacroCommand()
        {
            commandList = new List<Command>();

            commandList.Add(new ConcreteCommand1());

            var receiver = new Receiver();
            commandList.Add(new ConcreteCommand2(receiver));
        }

        public override void Execute()
        {
            for (int i = 0; i < commandList.Count; i++)
            {
                commandList[i].Execute();
            }
        }

        public override void Unexecute()
        {
            for (int i = commandList.Count - 1; 0 <= i; i--)
            {
                commandList[i].Unexecute();
            }
        }
    }

    public class Receiver
    {
        public void SomeAction()
        {
        }

        public void SomeUndoAction()
        {
        }
    }

    public class SomeApplication
    {
        private List<Command> commandList = null;
        private int currentIndex = 0;

        public void SomeFunction()
        {
            this.commandList = new List<Command>();

            var command1 = new ConcreteCommand1();
            commandList.Add(command1);

            var receiver = new Receiver();
            var command2 = new ConcreteCommand2(receiver);
            commandList.Add(command2);
        }

        public void ExecuteNext()
        {
            commandList[currentIndex].Execute();
            currentIndex++;
        }

        public void Undo()
        {
            commandList[currentIndex].Unexecute();
            currentIndex--;
        }
    }
}
