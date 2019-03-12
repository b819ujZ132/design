using System;

namespace design
{
  class Program
  {
    static void Main(string[] args)
    {
      // Handlers
      var pHandler = new PositiveHandler();
      var nHandler = new NegativeHandler();
      var eHandler = new EvenHandler();

      // Set successors in chain of responsibility
      pHandler.Successor = nHandler;
      nHandler.Successor = eHandler;

      // Use chain
      var chain = pHandler;
      var result = 2;
      chain.Handle(ref result); // 2 + (2 * (2)) - 64 = -58
      Console.WriteLine(result);
      chain.Handle(ref result); // -58 * (-1) + 1 = 59
      Console.WriteLine(result);
      chain.Handle(ref result);
      Console.WriteLine(result); // 59 + (2 * 59) = 177
    }
  }
}
