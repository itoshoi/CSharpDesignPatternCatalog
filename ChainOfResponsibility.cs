namespace ChainOfResponsibility
{
    public abstract class Handler
    {
        protected Handler successor;

        public virtual void HandleRequest()
        {
            if (successor != null)
            {
                successor.HandleRequest();
            }
        }
    }

    public class ConcreteHandler1 : Handler
    {
        public override void HandleRequest()
        {
            base.HandleRequest();
        }
    }

    public class ConcreteHandler2 : Handler
    {
        public override void HandleRequest()
        {
            System.Console.WriteLine("some customized handle");
        }
    }

    public class SomeApplication
    {
        public void SomeFunction()
        {
            var handler1 = new ConcreteHandler1();
            var handler2 = new ConcreteHandler2();
            handler1.HandleRequest();
        }
    }
}
