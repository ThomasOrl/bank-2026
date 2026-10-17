/*
    Test du Program
*/
CurrentAccount courant = new CurrentAccount();
courant.Number = "Compte001";
courant.Deposit(1000);

SavingsAccount epargne = new SavingsAccount();
epargne.Number = "Compte002";
epargne.Deposit(1000);

courant.ApplyInterest();
epargne.ApplyInterest();

Console.WriteLine(courant.Balance); // Normalement 1030 en result
Console.WriteLine(epargne.Balance); 



/* 
    Program
*/
public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
}

public class CurrentAccount : Account
{
    public double CreditLine { get; set; }

    public override void Withdraw(double amount)
    {
        base.Withdraw(amount, CreditLine);
    }

    protected override double CalculInterets()
    {
        if (Balance > 0)
        {
            return Balance * 0.03;
        }
        else
        {
            return Balance * 0.0975;
        }
    }
}

public class Bank
{
    public Dictionary<string, Account> Accounts { get; }
        = new Dictionary<string, Account>();

    public string Name { get; set; }

    public void AddAccount(Account account)
    {
        Accounts.Add(account.Number, account);
    }

    public void DeleteAccount(string number)
    {
        Accounts.Remove(number);
    }

    public double AccountBalance(string number)
    {
        return Accounts[number].Balance;
    }

    public double AccountTotalBalance(Person owner)
    {
        double total = 0;

        foreach (Account account in Accounts.Values)
        {
            if (account.Owner == owner)
            {
                total += account.Balance;
            }
        }

        return total;
    }
}

public class SavingsAccount : Account
{
    public DateTime DateLastWithdraw { get; set; }

    public override void Withdraw(double amount)
    {
        if (amount > 0 && amount <= Balance)
        {
            base.Withdraw(amount);
            DateLastWithdraw = DateTime.Now;
        }
    }

    protected override double CalculInterets()
    {
        return Balance * 0.045;
    }
}

public abstract class Account
{
    public string Number { get; set; }
    public double Balance { get; private set; }
    public Person Owner { get; set; }

    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            Balance += amount;
        }
    }

    public virtual void Withdraw(double amount)
    {
        Withdraw(amount, 0);
    }

    protected void Withdraw(double amount, double creditLine)
    {
        if (amount > 0 && Balance - amount >= -creditLine)
        {
            Balance -= amount;
        }
    }
    protected abstract double CalculInterets();
    public void ApplyInterest()
    {
        Balance += CalculInterets();
    }
}
