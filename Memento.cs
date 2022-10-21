namespace Memento
{
    public interface IMementoNarrow
    {
    }

    public interface IMementoWide
    {
        public void SetState(State state);
        public State GetState();
    }

    public class Memento : IMementoNarrow, IMementoWide
    {
        private State state;

        public Memento()
        {

        }

        public void SetState(State state)
        {
            this.state = state;
        }

        public State GetState()
        {
            return this.state;
        }
    }

    public class State
    {
        // some state params
        public string someState;
    }

    public class Originator
    {
        public IMementoNarrow CreateMemento()
        {
            return new Memento();
        }

        public void SetMemento(IMementoNarrow memento)
        {
            var mementoWide = memento as IMementoWide;
        }

        public void Foo()
        {

        }
    }

    public class Caretaker
    {
        private Originator originator;
        private IMementoNarrow prevMemento;

        public void SomeExecuteFunction()
        {
            // execute something
            this.originator.Foo();

            this.prevMemento = this.originator.CreateMemento();
        }

        public void SomeUndoFunction()
        {
            this.originator.SetMemento(this.prevMemento);
        }
    }
}
