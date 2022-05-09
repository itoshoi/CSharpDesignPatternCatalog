namespace Prototype
{
    public class Product
    {
        public void Init(int someParam)
        {
        }

        public virtual Product Clone()
        {
            return (Product)MemberwiseClone();
        }
    }

    public class ProductB : Product
    {
        public override Product Clone()
        {
            return (Product)MemberwiseClone();
        }
    }

    public class PrototypeFactory
    {
        private Product prototypeProduct = null;

        public PrototypeFactory(Product prototype)
        {
            this.prototypeProduct = prototype;
        }

        public Product MakeProduct1()
        {
            var product = this.prototypeProduct.Clone();
            product.Init(1);
            return product;
        }

        public Product MakeProduct2()
        {
            var product = this.prototypeProduct.Clone();
            product.Init(2);
            return product;
        }
    }

    public class SomeApplication
    {
        public void SomeFunction(bool someCondition)
        {
            Product prototype;
            if (someCondition)
            {
                prototype = new Product();
            }
            else
            {
                prototype = new ProductB();
            }

            var factory = new PrototypeFactory(prototype);

            var product1 = factory.MakeProduct1();
            var product2 = factory.MakeProduct2();
        }
    }
}
