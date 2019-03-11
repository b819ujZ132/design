using design.interfaces;
using System;

namespace design
{
  public class PrintCommand : ICommand
  {
    public String Message { get; private set; }

    public PrintCommand(String message)
    {
      if (String.IsNullOrEmpty(message) || String.IsNullOrWhiteSpace(message))
      {
        throw new System.ArgumentException("Message parameter is invalid.");
      }

      Message = message;
    }

    public void Execute()
    {
      Console.WriteLine(Message);
    }

    public void Unexecute()
    {
      // Empty
    }
  }
}