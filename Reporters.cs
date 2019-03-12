using System;

namespace design
{
  public class AccountBalanceReporter : IObserver<Account>
  {
    private IDisposable _unsubscriber;

    public AccountBalanceReporter()
    {
      // Empty
    }

    public virtual void Subscribe(IObservable<Account> provider)
    {
      if (provider != null)
        _unsubscriber = provider.Subscribe(this);
    }

    public virtual void OnCompleted()
    {
      this.Unsubscribe();
    }

    public virtual void OnError(Exception e)
    {
      Console.WriteLine(e.Message);
    }

    public virtual void OnNext(Account account)
    {
      Console.WriteLine(account.ToString());
    }

    public virtual void Unsubscribe()
    {
      _unsubscriber.Dispose();
    }
  }

  public class AccountHistoryReporter : IObserver<Account>
  {
    private IDisposable _unsubscriber;

    public AccountHistoryReporter()
    {
      // Empty
    }

    public virtual void Subscribe(IObservable<Account> provider)
    {
      if (provider != null)
        _unsubscriber = provider.Subscribe(this);
    }

    public virtual void OnCompleted()
    {
      this.Unsubscribe();
    }

    public virtual void OnError(Exception e)
    {
      Console.WriteLine(e.Message);
    }

    public virtual void OnNext(Account account)
    {
      Console.WriteLine($"Transaction submitted for {account.User.ToString()}'s account.");
      Console.WriteLine("History:");
      for (var i = account.History.Count - 1; i > -1; --i)
      {
        Console.WriteLine(((Transaction)account.History[i]).ToString());
      }
      Console.WriteLine();
    }

    public virtual void Unsubscribe()
    {
      _unsubscriber.Dispose();
    }
  }
}