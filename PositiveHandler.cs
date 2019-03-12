namespace design
{
  public class PositiveHandler : IntHandler
  {
    protected override void _Handle(ref int i)
    {
      if (i > 0)
      {
        i += 2 * i;
      }
    }
  }
}