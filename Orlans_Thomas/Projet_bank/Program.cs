public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
}

public class CurrentAccount
{
    public string Number { get; set; }
    public double Balance { get; private set; }
    public double CreditLine { get; set; }
    public Person Owner { get; set; }

    public void Withdraw(double amount)
    {
        if (amount > 0 && Balance - amount >= -CreditLine)
        {
            Balance -= amount;
        }
    }

    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            Balance += amount;
        }
    }
}

public class Bank
{
    public Dictionary<string, CurrentAccount> Accounts { get; }
        = new Dictionary<string, CurrentAccount>();
    public string Name { get; set;}

    public void AddAccount(CurrentAccount account)
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

        foreach (CurrentAccount account in Accounts.Values)
        {
            if (account.Owner == owner)
            {
                total += account.Balance;
            }
        }

        return total;
    }
}

public class SavingsAccount
{
    public string Number { get; set; }
    public double Balance { get; private set; }
    public DateTime DateLastWithdraw { get; set; }
    public Person Owner { get; set; }

    public void Withdraw(double amount)
    {
        if (amount > 0 && amount <= Balance)
        {
            Balance -= amount;
            DateLastWithdraw = DateTime.Now;
        }
    }

    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            Balance += amount;
        }
    }
}

public class Account
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
}