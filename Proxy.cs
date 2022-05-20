namespace Proxy
{
    public abstract class Subject
    {
        public abstract void SomeFunction();
    }

    public class RealSubject : Subject
    {
        public override void SomeFunction()
        {
        }
    }

    public class Proxy : Subject
    {
        RealSubject realSubject = null;

        public override void SomeFunction()
        {
            // you can manage how to access here
            realSubject.SomeFunction();
        }
    }
}
