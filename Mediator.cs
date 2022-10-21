namespace Mediator
{
    public abstract class Mediator
    {
        public abstract void CreateColleagues();
        public abstract void ColleagueChanged(Colleague colleague);
    }

    public class ConcreteMediator : Mediator
    {
        private ConcreteColleague1 colleague1;
        private ConcreteColleague2 colleague2;

        public override void CreateColleagues()
        {
            this.colleague1 = new ConcreteColleague1(this);
            this.colleague2 = new ConcreteColleague2(this);
        }

        public override void ColleagueChanged(Colleague colleague)
        {
            if (colleague == this.colleague1)
            {
                this.colleague1.SetFoo();
            }
            else if (colleague == this.colleague2)
            {
                this.colleague2.SetBar();
            }
        }
    }

    public abstract class Colleague
    {
        protected Mediator mediator;

        public Colleague(Mediator mediator)
        {
            this.mediator = mediator;
        }

        protected void Changed()
        {
            this.mediator.ColleagueChanged(this);
        }
    }

    public class ConcreteColleague1 : Colleague
    {
        public ConcreteColleague1(Mediator mediator) : base(mediator)
        {
        }

        public void HogeEvent()
        {
            // some event such as mouse click
            Changed();
        }

        public void SetFoo()
        {
            // some action
        }
    }

    public class ConcreteColleague2 : Colleague
    {
        public ConcreteColleague2(Mediator mediator) : base(mediator)
        {
        }

        public void HugaEvent()
        {
            // some event such as mouse click
            Changed();
        }

        public void SetBar()
        {
            // some action
        }
    }

    public class SomeApplication
    {
        public void SomeFunction()
        {
            var mediator = new ConcreteMediator();
            mediator.CreateColleagues();
        }
    }
}
