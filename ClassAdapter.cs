namespace ClassAdapter
{
    public class Adaptee
    {
        public void HugaFunction()
        {
        }
    }

    public interface Target
    {
        public void HogeFunction();
    }

    public class Adapter : Adaptee, Target
    {
        public void HogeFunction()
        {
            this.HogeFunction();
        }
    }
}

