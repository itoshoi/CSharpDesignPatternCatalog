namespace Iterator
{
    public abstract class Aggregate
    {
        public abstract Iterator CreateIterator();
    }

    public class ConcreteAggregate : Aggregate
    {
        public override Iterator CreateIterator()
        {
            return new ConcreteIterator(this);
        }
    }

    public class SomeItem
    {
    }

    public abstract class Iterator
    {
        protected Aggregate aggregate;
        public Iterator(Aggregate aggregate)
        {
            this.aggregate = aggregate;
        }

        public abstract void First();
        public abstract void Next();
        public abstract bool IsDone();
        public abstract SomeItem CurrentItem();
    }

    public class ConcreteIterator : Iterator
    {
        private int currentIndex = 0;

        public ConcreteIterator(Aggregate aggregate) : base(aggregate)
        {
        }

        public override void First()
        {
            // some algorithm
            this.currentIndex = 0;
        }

        public override void Next()
        {
            // some algorithm
            this.currentIndex++;
        }

        public override bool IsDone()
        {
            // some algorithm
            return this.currentIndex < aggregate.Count;
        }

        public override SomeItem CurrentItem()
        {
            // some algorithm
            return this.currentIndex[currentIndex];
        }
    }

    public class SomeApplication
    {
        private Aggregate someAggregate = null;

        public void SomeFunction()
        {
            var iterator = this.someAggregate.CreateIterator();
            iterator.First();
            while (!iterator.IsDone())
            {
                iterator.Next();
                var item = iterator.CurrentItem();
            }
        }
    }
}
