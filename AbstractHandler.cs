namespace design
{
  public abstract class AbstractHandler<T>
  {
    private AbstractHandler<T> _successor;
    public AbstractHandler<T> Successor {
      private get
      {
        return _successor;
      }

      set
      {
        if (value == null)
        {
          throw new System.ArgumentException("Handler successor is invalid.");
        }

        _successor = value;
      }
    }

    public void Handle(ref T t)
    {
      _Handle(ref t);

      if (Successor == null)
      {
        return;        
      }

      Successor.Handle(ref t);
    }

    protected virtual void _Handle(ref T t) { }
  }
}