using System;

public class Account
{
    private decimal _balance;
    private string _name;






    public Account(string name, decimal startingBalance)
    {
        _name = name;
        _balance = startingBalance;

    }

    public bool Deposit(decimal amountToDeposit)
    {
        if (amountToDeposit > 0)

        {
            _balance += amountToDeposit;

            return true;
        }
        return false;


    }

    public bool Withdraw(decimal amountToWithdraw)
    {
        if (amountToWithdraw > 0)
        {
            if (_balance - amountToWithdraw >= 0)   // checking the amount left in the balance is either 0 or greater.
            {
                _balance -= amountToWithdraw;
                return true;
            }

        }

        Console.WriteLine("You don't have enough money");
        return false;


    }

    public string Name
    {
        get { return _name; }
    }

    public decimal Balance
    {
        get { return _balance; }
    }
    public void Print(string name, decimal balance)
    {
        Console.WriteLine("Hi: " + name + " Your account balance is: $" + balance);

    }
}