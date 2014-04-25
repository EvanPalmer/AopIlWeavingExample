using System;
using PostSharp.Aspects;

namespace IlWeavingExample
{
    [Serializable]
    public class LoggingAspect : OnMethodBoundaryAspect
    {
        public override void OnException(MethodExecutionArgs args)
        {
            const string anErrorOccured = "An error occured";
            Console.WriteLine(anErrorOccured);
            args.ReturnValue = anErrorOccured;
            args.FlowBehavior = FlowBehavior.Return;
        }
        public override void OnEntry(MethodExecutionArgs args)
        {
            Console.WriteLine("Beginning OnEntry");
        }
        public override void OnSuccess(MethodExecutionArgs args)
        {
            b5();
            Console.WriteLine("No errors.");
        }
        public override void OnExit(MethodExecutionArgs args)
        {
            Console.WriteLine("Finished OnEntry");
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            DoSomething();
            DoSomethingElse();
            Console.ReadKey();
        }

        [LoggingAspect]
        private static void DoSomethingElse()
        {
            Console.WriteLine("Something else.");
        }

        [LoggingAspect]
        private static void DoSomething()
        {
            Console.WriteLine("Something else.");
        }
    }
}
