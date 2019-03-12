using System;
using System.Collections.Generic;

namespace design
{
  public class Account : IObservable<Account>
  {
    public readonly User User;

    private List<IObserver<Account>> _observers;

    public decimal Balance { get; private set; } = 0;

    public List<Transaction> History { get; private set; }

    public Account(User user)
    {
      if (user == null)
      {
        throw new System.ArgumentException("Account requires a valid user.");
      }

      _observers = new List<IObserver<Account>>();


      User = user;

      History = new List<Transaction>();

      Notify();
    }

    public void Transact(Transaction transaction)
    {
      History.Add(transaction);
      Balance += transaction.Value;

      Notify();
    }

    public override string ToString()
    {
      return $"Account for {User.ToString()} has a balance of ${System.Math.Round(Balance, 2)}.";
    }

    public IDisposable Subscribe(IObserver<Account> observer)
    {
      if (!_observers.Contains(observer))
        _observers.Add(observer);
      return new Unsubscriber(_observers, observer);
    }

    private class Unsubscriber : IDisposable
    {
      private List<IObserver<Account>> _observers;
      private IObserver<Account> _observer;

      public Unsubscriber(List<IObserver<Account>> observers, IObserver<Account> observer)
      {
        this._observers = observers;
        this._observer = observer;
      }

      public void Dispose()
      {
        if (_observer != null && _observers.Contains(_observer))
          _observers.Remove(_observer);
      }
    }

    private void Notify()
    {
      foreach (var observer in _observers)
      {
        observer.OnNext(this);
      }
    }

    private void Error(Exception e)
    {
      foreach (var observer in _observers)
      {
        observer.OnError(e);
      }
    }
  }
}