using design.extensions;
using design.interfaces;
using System.Collections.Generic;
using System.Linq;

namespace design
{
  public class CommandInvoker
  {
    private List<ICommand> _history;

    public CommandInvoker()
    {
      _history = new List<ICommand>();
    }

    public void Invoke(ICommand command)
    {
      _history.Push(command);
      command.Execute();
    }

    public void Rollback()
    {
      _history.Pop().Unexecute();
    }
  }
}