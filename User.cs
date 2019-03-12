namespace design
{
  public class User
  {
    public string _firstName { get; private set; }
    public string _lastName { get; private set; }

    public User(string firstName, string lastName)
    {
      if (
        string.IsNullOrEmpty(firstName)
        || string.IsNullOrWhiteSpace(firstName)
        || string.IsNullOrEmpty(lastName)
        || string.IsNullOrWhiteSpace(lastName)
      )
      {
        throw new System.ArgumentException("User can only be created with valid names.");
      }

      _firstName = firstName;
      _lastName = lastName;
    }

    public override string ToString()
    {
      return $"{_firstName} {_lastName}";
    }
  }
}