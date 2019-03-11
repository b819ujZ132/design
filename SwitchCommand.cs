using design.interfaces;

namespace design
{
  public class SwitchCommand : ICommand
  {
    private readonly Switch _switch;

    public SwitchCommand(Switch s)
    {
      _switch = s;
    }

    public void Execute()
    {
      _switch.Toggle();
    }

    public void Unexecute()
    {
      // Reversing state is simplified here due to the two possible states
      _switch.Toggle();
    }
  }
}