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

        public Decorator(Component component)
        {
            this.component = component;
        }

        public override void Operation()
        {
            component.Operation();
        }
    }

    public class ConcreteDecoratorA : Decorator
    {
        private int someParam;

        public ConcreteDecoratorA(Component component) : base(component)
        {
        }

        public override void Operation()
        {
            base.Operation();
        }
    }

    public class ConcreteDecoratorB : Decorator
    {
        public ConcreteDecoratorB(Component component) : base(component)
        {
        }

        public override void Operation()
        {
            base.Operation();
            SomeFunction();
        }

        public void SomeFunction()
        {
        }
    }

    public class SomeApplication
    {
        public void SomeFunction()
        {
            Component comp = new ConcreteComponent();
            Component deco1 = new ConcreteDecoratorA(comp);
            Component deco2 = new ConcreteDecoratorB(comp);
            Component deco3 = new ConcreteDecoratorA(new ConcreteDecoratorB(comp));
            Component deco4 = new ConcreteDecoratorA(new ConcreteDecoratorB(new ConcreteDecoratorB(comp)));
        }
    }
}
