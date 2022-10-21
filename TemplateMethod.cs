namespace TemplateMethod
{
    public abstract class AbstractClass
    {
        public void TemplateMethod()
        {
            PrimitiveOperation1();
            PrimitiveOperation2();
        }

        protected abstract void PrimitiveOperation1();
        protected abstract void PrimitiveOperation2();
    }

    public class ConcreteClass : AbstractClass
    {
        protected override void PrimitiveOperation1()
        {
            // some first operation
        }

        protected override void PrimitiveOperation2()
        {
            // some second operation
        }
    }
}
