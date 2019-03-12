namespace design
{
  public class NegativeHandler : IntHandler
  {
    protected override void _Handle(ref int i)
    {
      if (i < 0)
      {
        i = i * -1 + 1;
      }
    }
  }
}