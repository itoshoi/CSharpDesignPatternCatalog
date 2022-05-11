using System.Collections.Generic;

namespace Composite
{
    public abstract class Component
    {
        public virtual void Add(Component component)
        {
        }

        public virtual void Remove(Component component)
        {
        }

        public virtual Component GetChild(int index)
        {
            return null;
        }

        public abstract void Operation();
    }

    public class Composite : Component
    {
        private List<Component> children = null;

        public Composite()
        {
            this.children = new List<Component>();
        }

        public override void Add(Component component)
        {
            children.Add(component);
        }

        public override void Remove(Component component)
        {
            children.Remove(component);
        }

        public override Component GetChild(int index)
        {
            if (index < children.Count)
            {
                return children[index];
            }

            return null;
        }

        public override void Operation()
        {
            foreach (var child in children)
            {
                child.Operation();
            }
        }
    }

    public class Leaf : Component
    {
        public override void Operation()
        {
        }
    }
}
