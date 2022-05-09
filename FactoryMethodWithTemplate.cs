namespace FactoryMethodWithTemplate
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

	public class StandartProductUser<T> : ProductUser where T : Product, new()
    {
        protected override Product CreateProduct()
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
        public void SomeFunction(bool someCondition)
        {
            if (someCondition)
            {
   				var user1 = new StandartProductUser<ProductA>();
				user1.LazyInit();
				user1.SomeFunction();
            }
            else
            {
				var user2 = new StandartProductUser<ProductB>();
				user2.LazyInit();
				user2.SomeFunction();
            }
        }
    }
}
