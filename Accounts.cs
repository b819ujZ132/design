using System;
using System.Collections.Generic;

namespace design
{
  // To reduce complexity, I have not broken out into a more generic container
  public class Accounts : IObservable<Account>, IObserver<Account>
  {
    private List<IObserver<Account>> _observers;

    private IDisposable _unsubscriber;

    public List<Account> A { get; private set; }

    public Accounts()
    {
      A = new List<Account>();
      _observers = new List<IObserver<Account>>();
    }

    public void AddAccount(Account account)
    {
      A.Add(account);
      this.Subscribe(account);
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
      Error(e);
    }

    public virtual void OnNext(Account account)
    {
      Notify(account);
    }

    public virtual void Unsubscribe()
    {
      _unsubscriber.Dispose();
    }

    public void Notify(Account account)
    {
      foreach (var observer in _observers)
      {
        observer.OnNext(account);
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