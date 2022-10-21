namespace Interpreter
{
    using System;

    public abstract class AbstractExpression
    {
        public abstract void Interpret(Context context);
    }

    public class TerminalExpression : AbstractExpression
    {
        private string literal;

        public TerminalExpression(string literal)
        {
            this.literal = literal;
        }

        public override void Interpret(Context context)
        {
            // some interpret
            Console.Write(this.literal);
        }
    }

    public class NonterminalExpression : AbstractExpression
    {
        private TerminalExpression exp1;
        private TerminalExpression exp2;

        public NonterminalExpression(TerminalExpression exp1, TerminalExpression exp2)
        {
            this.exp1 = exp1;
            this.exp2 = exp2;
        }

        public override void Interpret(Context context)
        {
            // some interpret
            Console.Write(this.exp1 + "&" + this.exp2);
        }
    }

    public class Context
    {
        public string SomeInfo;
    }

    public class SomeApplication
    {
        public void SomeFunction()
        {
            var terminalExp1 = new TerminalExpression("literal1");
            var terminalExp2 = new TerminalExpression("literal2");
            var someExp = new NonterminalExpression(terminalExp1, terminalExp2);
            var context = new Context { SomeInfo = "someINfo" };
            someExp.Interpret(context);
        }
    }
}
