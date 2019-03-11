namespace design.interfaces
{
  public interface ICommand
  {
    void Execute();
    void Unexecute();
  }
}