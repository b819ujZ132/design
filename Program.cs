using System;

namespace design
{
  class Program
  {
    static void Main(string[] args)
    {
      // Account instances
      var account1 = new Account(new User("Bender", "Rodriguez"));
      var account2 = new Account(new User("Philip", "Fry"));
      var account3 = new Account(new User("Turanga", "Leela"));

      // Accounts container instance
      var accounts = new Accounts();

      // Reporter instances
      var creationReporter = new AccountBalanceReporter();
      var historyReporter = new AccountHistoryReporter();

      // Reporter subscriptions
      creationReporter.Subscribe(accounts);
      historyReporter.Subscribe(accounts);

      // Add accounts
      accounts.AddAccount(account1);
      accounts.AddAccount(account2);
      accounts.AddAccount(account3);

      // Account transactions
      account1.Transact(new Transaction(100.25M, "Let's get looting!"));
      account2.Transact(new Transaction(-3.25M, "I'll take a coffee."));
      account2.Transact(new Transaction(-5M, "Can I charge it to my eyePhone?"));
      account2.Transact(new Transaction(-0.75M, "Gotta spend money to earn money."));
      account1.Transact(new Transaction(1200M, "My government stipend of 1200 wing wangs."));
    }
  }
}
