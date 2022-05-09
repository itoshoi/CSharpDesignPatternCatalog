namespace ObjectAdapter
{
    public class Adaptee
    {
        public void HugaFunction()
        {
        }
    }

    public class Target
    {
        public virtual void HogeFunction()
        {
        }
    }

    public class Adapter : Target
    {
        private Adaptee adaptee = null;

        public Adapter(Adaptee adaptee)
        {
            this.adaptee = adaptee;
        }

        public override void HogeFunction()
        {
            adaptee.HugaFunction();
        }
    }
}
