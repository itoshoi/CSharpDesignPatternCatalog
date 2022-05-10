namespace Bridge
{
    public abstract class Implementor
    {
        public abstract void SomeFunctionImp();
    }

    public class ConcreteImplementorA : Implementor
    {
        public override void SomeFunctionImp()
        {
        }
    }

    public class ConcreteImplementorB : Implementor
    {
        public override void SomeFunctionImp()
        {
        }
    }

    public abstract class Abstraction
    {
        private Implementor imp = null;

        public Abstraction(Implementor implementor)
        {
            this.imp = implementor;
        }

        public void SomeFunction()
        {
            this.imp.SomeFunctionImp();
        }
    }

    public class RefinedAbstraction : Abstraction
    {
        public RefinedAbstraction(Implementor implementor) : base(implementor)
        {
        }

        public void SomeRefinedFunction()
        {
            SomeFunction();
            SomeFunction();
        }
    }
}
