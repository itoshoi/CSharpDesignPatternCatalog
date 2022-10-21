namespace Strategy
{
    public class Context
    {
        private Strategy strategy;

        public Context(Strategy strategy)
        {
            this.strategy = strategy;
        }

        public void ContextInterface()
        {
            this.strategy.AlgorithmInterface();
        }
    }

    public abstract class Strategy
    {
        public abstract void AlgorithmInterface();
    }

    public class ConcreteStrategyA : Strategy
    {
        public override void AlgorithmInterface()
        {
            // strategy A algorithm
        }
    }

    public class ConcreteStrategyB : Strategy
    {
        public override void AlgorithmInterface()
        {
            // strategy B algorithm
        }
    }

    public class ConcreteStrategyC : Strategy
    {
        public override void AlgorithmInterface()
        {
            // strategy C algorithm
        }
    }

    public class SomeApplication
    {
        public void SomeFunction()
        {
            // when use strategy A
            {
                var strategyA = new ConcreteStrategyA();
                var context = new Context(strategyA);
                context.ContextInterface();
            }

            // when use strategy B 
            {
                var strategyB = new ConcreteStrategyA();
                var context = new Context(strategyB);
                context.ContextInterface();
            }

            // when use strategy C
            {
                var strategyC = new ConcreteStrategyA();
                var context = new Context(strategyC);
                context.ContextInterface();
            }
        }
    }
}
