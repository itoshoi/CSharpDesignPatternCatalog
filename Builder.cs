namespace Builder
{
    public abstract class Builder
    {
        public abstract void BuildPartA();
        public abstract void BuildPartB();
        public abstract void BuildPartC();
        public abstract Result GetResult();
    }

    public class ConcreteBuilder : Builder
    {
        private Result result = null;

        public ConcreteBuilder()
        {
            this.result = new Result();
        }

        public override void BuildPartA()
        {
            this.result.AddFoo();
        }

        public override void BuildPartB()
        {
            this.result.AddFoo();
            this.result.SetBar(0);
        }

        public override void BuildPartC()
        {
            this.result.RemoveFoo();
            this.result.SetBar(1);
        }

        public override Result GetResult()
        {
            return result;
        }
    }

    public class Director
    {
        public void Construct(Builder builder)
        {
            builder.BuildPartA();
            builder.BuildPartB();
        }

        public void ConstructHoge(Builder builder)
        {
            builder.BuildPartB();
            builder.BuildPartC();
        }

        public void ConstructHuga(Builder builder)
        {
            builder.BuildPartA();
            builder.BuildPartB();
            builder.BuildPartC();
        }
    }

    public class Result
    {
        public void AddFoo()
        {
        }

        public void RemoveFoo()
        {
        }

        public void SetBar(int someParam)
        {
        }
    }

    public class SomeApplication
    {
        public void SomeFunction(int someCondition)
        {
            var builder = new ConcreteBuilder();
            var director = new Director();

            switch (someCondition)
            {
                case 1:
                    director.Construct(builder);
                    break;
                case 2:
                    director.ConstructHoge(builder);
                    break;
                case 3:
                    director.ConstructHuga(builder);
                    break;
            }

			var result = builder.GetResult();
        }
    }
}
