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
        
    }

    public void Deposit(double amount)
    {
        
    }
}