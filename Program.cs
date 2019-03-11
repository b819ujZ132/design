namespace design
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var invoker = new CommandInvoker();

      invoker.Invoke(new PrintCommand("Hello, world!"));

      var c = new PrintCommand("May your friends fare better than your enemies...");
      invoker.Invoke(c);

      var s = new Switch();
      s.Toggle();

      invoker.Invoke(new PrintCommand(s.ToString()));

      invoker.Invoke(new SwitchCommand(s));
      invoker.Invoke(new PrintCommand(s.ToString()));

      invoker.Rollback();
      invoker.Rollback();

      invoker.Invoke(new PrintCommand(s.ToString()));

    }
  }
}
