using System;
using System.Linq.Expressions;

namespace design
{
  public abstract class AbstractProcessor
  {
    private readonly Action _delegat; // e

    public AbstractProcessor(Action delegat)
    {
      if (delegat == null)
      {
        throw new System.ArgumentException("Invalid delegate.");
      }

      _delegat = delegat;
    }

    public void Run()
    {
      // Algorithm composed of template methods
      Console.WriteLine("Starting algorithm.");
      PreExecute();
      Execute();
      PostExecute();
      Console.WriteLine("Completed algorithm.");
      // Delegate method that enables runtime-specific logic
      _delegat();
    }

    protected virtual void PreExecute()
    {
      Console.WriteLine("PreExecute from abstract.");
    }

    protected virtual void Execute()
    {
      Console.WriteLine("Execute from abstract.");
    }

    protected virtual void PostExecute()
    {
      Console.WriteLine("PostExecute from abstract.");
    }
  }
}