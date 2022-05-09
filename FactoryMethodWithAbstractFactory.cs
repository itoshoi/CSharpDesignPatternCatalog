namespace FactoryMethodWithAbstractFactory
{
    public abstract class AbstractFactory
    {
        public abstract Product CreateProduct();
    }

	public class StandardFactory<T> : AbstractFactory where T : Product, new()
	{
		public override Product CreateProduct()
		{
			return new T();
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
                var factory1 = new StandardFactory<ProductA>();
                someApp.Init(factory1);
            }
            else
            {
                var factory2 = new StandardFactory<ProductB>();
                someApp.Init(factory2);
            }
        }
    }
}
