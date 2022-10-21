namespace Proxy
{
    public abstract class Subject
    {
        public abstract void Request();
    }

    public class RealSubject : Subject
    {
        public override void Request()
        {
        }
    }

    public class Proxy : Subject
    {
        RealSubject realSubject = null;

        public override void Request()
        {
            // you can manage how to access here
            realSubject.Request();
        }
    }
}
