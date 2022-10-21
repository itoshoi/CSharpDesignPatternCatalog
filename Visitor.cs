namespace Visitor
{
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Visitor
    {
        public abstract void VisitConcreteElementA(ConcreteElementA elementA);
        public abstract void VisitConcreteElementB(ConcreteElementB elementB);
    }

    public class ConcreteVisitor1 : Visitor
    {
        public override void VisitConcreteElementA(ConcreteElementA elementA)
        {
            // some action
        }

        public override void VisitConcreteElementB(ConcreteElementB elementB)
        {
            // some action
        }
    }

    public class ConcreteVisitor2 : Visitor
    {
        public override void VisitConcreteElementA(ConcreteElementA elementA)
        {
            // some action
        }

        public override void VisitConcreteElementB(ConcreteElementB elementB)
        {
            // some action
        }
    }

    public abstract class Element
    {
        public abstract void Accept(Visitor visitor);
    }

    public class ConcreteElementA : Element
    {
        public override void Accept(Visitor visitor)
        {
            visitor.VisitConcreteElementA(this);
        }
    }

    public class ConcreteElementB : Element
    {
        public override void Accept(Visitor visitor)
        {
            visitor.VisitConcreteElementB(this);
        }
    }

    public class ObjectStructure
    {
        public IEnumerable<Element> SomeStructure;
    }

    public class SomeApplication
    {
        public void SomeFunction()
        {
            var structureA = new ObjectStructure
            {
                SomeStructure = new List<ConcreteElementA>().Cast<Element>()
            };

            var structureB = new ObjectStructure
            {
                SomeStructure = new List<ConcreteElementB>().Cast<Element>()
            };

            var visitor1 = new ConcreteVisitor1();
            var visitor2 = new ConcreteVisitor2();

            // when use structureA and visitor1
            foreach (var element in structureA.SomeStructure)
            {
                element.Accept(visitor1);
            }

            // when use structureA and visitor2
            foreach (var element in structureA.SomeStructure)
            {
                element.Accept(visitor2);
            }

            // when use structureB and visitor1
            foreach (var element in structureB.SomeStructure)
            {
                element.Accept(visitor1);
            }

            // when use structureB and visitor2
            foreach (var element in structureB.SomeStructure)
            {
                element.Accept(visitor2);
            }
        }
    }
}
