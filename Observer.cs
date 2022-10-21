namespace Observer
{
    using System.Collections.Generic;

    public abstract class Subject
    {
        protected List<Observer> observers = null;

        public virtual void Attach(Observer observer)
        {
            this.observers.Add(observer);
        }

        public virtual void Detach(Observer observer)
        {
            this.observers.Remove(observer);
        }

        public virtual void Notify()
        {
            foreach (var observer in this.observers)
            {
                observer.Update(this);
            }
        }
    }

    public class ConcreteSubject : Subject
    {
        public void Foo()
        {
            // do something

            Notify();
        }
    }

    public abstract class Observer
    {
        public abstract void Update(Subject changedSubject);
    }

    public class ConcreteObserver : Observer
    {
        public override void Update(Subject changedSubject)
        {
            // do something update
        }
    }

    public class SomeApplication
    {
        public void SomeFunction()
        {
            var subject = new ConcreteSubject();
            subject.Foo();
        }
    }
}
