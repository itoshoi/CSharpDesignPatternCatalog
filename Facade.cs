namespace Facade
{
    using SomeSubSystems;

    public class Facade
    {
        public void SomeFunction()
        {
            var subSystemA = new SubSystemA();
            var subSystemB = new SubSystemB();
            var subSystemC = new SubSystemC();

            subSystemA.FunctionA();
            subSystemB.FunctionB();
            subSystemC.FunctionC();
        }
    }
}

namespace SomeSubSystems
{
    public class SubSystemA
    {
        public void FunctionA()
        {
        }
    }

    public class SubSystemB
    {
        public void FunctionB()
        {
        }
    }

    public class SubSystemC
    {
        public void FunctionC()
        {
        }
    }
}
