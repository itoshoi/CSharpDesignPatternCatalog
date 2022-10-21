namespace State
{
    public class Context
    {
        private State currentState;
        public ConcreteStateA stateA { get; private set; }
        public ConcreteStateB stateB { get; private set; }

        public Context()
        {
            this.stateA = new ConcreteStateA();
            this.stateB = new ConcreteStateB();
            this.currentState = stateA;
        }

        public void Request()
        {
            this.currentState.Handle(this);
        }

        public void ChangeState(State state)
        {
            this.currentState = state;
        }
    }

    public abstract class State
    {
        public abstract void Handle(Context context);
        public virtual void ChangeState(Context context, State state)
        {
            context.ChangeState(state);
        }
    }

    public class ConcreteStateA : State
    {
        public override void Handle(Context context)
        {
            ChangeState(context, context.stateB);
        }
    }

    public class ConcreteStateB : State
    {
        public override void Handle(Context context)
        {
            ChangeState(context, context.stateA);
        }
    }

    public class SomeApplication
    {
        public void SomeFunction()
        {
            var context = new Context();
            context.Request();
        }
    }
}
