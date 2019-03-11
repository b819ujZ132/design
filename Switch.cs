namespace design
{
  public class Switch
  {
    public bool isOn { get; private set; } = false;

    public void Toggle()
    {
      isOn = !isOn;
    }

    public override string ToString()
    {
      return $"Switch is {(isOn ? "on" : "off")}.";
    }
  }
}