using System;

namespace design
{
  class Program
  {
    static void Main(string[] args)
    {
      var processor = new Processor(() => { Console.WriteLine("Hello from the delegate!"); });
      processor.Run();
    }
  }
}
