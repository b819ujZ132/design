namespace design
{
  public class Transaction
  {
    public decimal Value { get; private set; }
    
    public string Memo { get; private set; }

    private TransactionType _type;

    public Transaction(decimal value, string memo = null)
    {
      if (value == 0)
      {
        throw new System.ArgumentException("A zero-dollar transaction is invalid.");
      }

      Value = value;
      Memo = memo;

      if (Value > 0)
      {
        _type = TransactionType.DEPOSIT;
      }
      else
      {
        _type = TransactionType.WITHDRAWAL;
      }
    }

    public override string ToString()
    {
      return $"{(_type == TransactionType.WITHDRAWAL ? "Withdrawal" : "Deposit")} of ${System.Math.Round(Value, 2)}{(Memo != null ? $" for '{Memo}'" : ".")}";
    }

    internal enum TransactionType
    {
      WITHDRAWAL,
      DEPOSIT
    }
  }
}