namespace Decorator
{
    public abstract class Component
    {
        public abstract void Operation();
    }

    public class ConcreteComponent : Component
    {
        public override void Operation()
        {
        }
    }

    public abstract class Decorator : Component
    {
        private Component component;

        public override void Operation()
        {
            component.Operation();
        }
    }

    public class ConcreteDecoratorA : Decorator
    {
        private int someParam;

        public override void Operation()
        {
            base.Operation();
        }
    }

    public class ConcreteDecoratorB : Decorator
    {
        public override void Operation()
        {
            base.Operation();
            SomeFunction();
        }

        public void SomeFunction()
        {
        }
    }
}
