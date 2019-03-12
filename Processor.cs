using System;

namespace design
{
  public class Processor : AbstractProcessor
  {
    public Processor(Action delegat)
      : base(delegat)
    {
      // Empty
    }

    protected override void PreExecute()
    {
      Console.WriteLine("PreExecute from concrete.");
    }

    protected override void Execute()
    {
      base.Execute();

      Console.WriteLine("Execute from concrete.");
    }
  }
}