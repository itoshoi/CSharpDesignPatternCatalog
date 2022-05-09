namespace AbstractFactory
{
    public abstract class AbstractFactory
    {
        public abstract Product CreateProduct();
    }

    public class ConcreteFactory1 : AbstractFactory
    {
        public override Product CreateProduct()
        {
            return new ProductA();
        }
    }

    public class ConcreteFactory2 : AbstractFactory
    {
        public override Product CreateProduct()
        {
            return new ProductB();
        }
    }

    public abstract class Product
    {
    }

    public class ProductA : Product
    {
    }

    public class ProductB : Product
    {
    }

    public class SomeApplication
    {
        private Product product;

        public void Init(AbstractFactory factory)
        {
            this.product = factory.CreateProduct();
        }
    }

    public class SomeApplicationUser
    {
        public void SomeFunction(bool someCondition)
        {
            var someApp = new SomeApplication();

            if (someCondition)
            {
                var factory1 = new ConcreteFactory1();
                someApp.Init(factory1);
            }
            else
            {

                var factory2 = new ConcreteFactory2();
                someApp.Init(factory2);
            }
        }
    }
}
