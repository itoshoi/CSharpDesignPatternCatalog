namespace Flyweight
{
    using System.Collections.Generic;

    public abstract class Flyweight
    {
        public abstract void Operation(ExtrinsicState extrinsicState);
    }

    public class ConcreteFlyweight : Flyweight
    {
        private int someIntrinsicState;

        public override void Operation(ExtrinsicState extrinsicState)
        {
        }
    }

    public class UnsharedConcreteFlyweight : Flyweight
    {
        private int allState;

        public override void Operation(ExtrinsicState extrinsicState)
        {
        }
    }

    public class ExtrinsicState
    {
        public int someParam;
    }

    public class FlyweightFactory
    {
        private Dictionary<string, ConcreteFlyweight> flyweights;

        public FlyweightFactory()
        {
            flyweights = new Dictionary<string, ConcreteFlyweight>();
        }

        public ConcreteFlyweight CreateConcreteFlyweight(string key)
        {
            if (!flyweights.ContainsKey(key))
            {
                flyweights.Add(key, new ConcreteFlyweight());
            }

            return flyweights[key];
        }

        public UnsharedConcreteFlyweight CreateUnsharedConcreteFlyweight()
        {
            return new UnsharedConcreteFlyweight();
        }
    }

    public class SomeApplication
    {
        public void SomeFuncition()
        {
            var factory = new FlyweightFactory();
            var exState = new ExtrinsicState();

            for (int i = 0; i < 100; i++)
            {
                // create 100 foo
                var concreteFlyweight = factory.CreateConcreteFlyweight("foo");
                exState.someParam = i;
                concreteFlyweight.Operation(exState);
            }

            for (int i = 0; i < 30; i++)
            {
                // create 30 bar
                var concreteFlyweight = factory.CreateConcreteFlyweight("bar");
                exState.someParam = i;
                concreteFlyweight.Operation(exState);
            }

            var unsharedFlyweight = factory.CreateUnsharedConcreteFlyweight();
            unsharedFlyweight.Operation(exState);
        }
    }
}
