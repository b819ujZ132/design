namespace design
{
  public class EvenHandler : IntHandler
  {
    protected override void _Handle(ref int i)
    {
      if (System.Math.Abs(i) % 2 == 0)
      {
        i -= 64;
      }
    }
  }
}