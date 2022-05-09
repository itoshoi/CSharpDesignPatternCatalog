namespace FactoryMethod
{
    public abstract class ProductUser
    {
		private Product product = null;

		// factory method
        protected abstract Product CreateProduct();

		public ProductUser()
		{
			// you should not call CreateProduct() here.
			// because you still cannot use concrete CreateProduct() in super class constructor.
		}

		public void LazyInit()
		{
			this.product = CreateProduct();
		}

		public void SomeFunction()
		{
		}
    }

    public class ConcreteProductUser1 : ProductUser
    {
        protected override Product CreateProduct()
        {
            return new ProductA();
        }
    }

    public class ConcreteProductUser2 : ProductUser
    {
        protected override Product CreateProduct()
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
        public void SomeFunction(bool someCondition)
        {
            if (someCondition)
            {
   				var user1 = new ConcreteProductUser1();
				user1.LazyInit();
				user1.SomeFunction();
            }
            else
            {
				var user2 = new ConcreteProductUser2();
				user2.LazyInit();
				user2.SomeFunction();
            }
        }
    }
}
