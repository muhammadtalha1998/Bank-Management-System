using System;
using System.Collections.Generic;
public class transfertransaction
{
    private Account _toaccount;
    private Account _fromaccount;
    private decimal _amount;
    private withdrawTransaction withdraw;
    private DepsiteTransaction deposit;
    private bool _executed = false;
    private bool _success = false;
    private bool _reversed = false;

    public bool Success
    {
        get
        {
            return _success;
        }
    }
    public bool Executed
    {
        get
        {

            return _executed;
        }
    }
    public bool Reversed
    {
        get
        {
            return _reversed;
        }
    }

    public transfertransaction(Account fromaccount, Account toaccount, decimal amount)
    {
        _toaccount = toaccount;
        _fromaccount = fromaccount;
        withdraw = new withdrawTransaction(_fromaccount, amount);
        deposit = new DepsiteTransaction(_toaccount, amount);
        _amount = amount;


    }

    public void Execution()
    {
        if (_executed)
        {
            throw new Exception("Already Done!!!!!!!!!!!!!!!");
        }
        withdraw.Execute();
        if (withdraw.Success)
        {

            deposit.Execute();
            if (deposit.Success)
            {
                print();
            }
        }
        _executed = true;


    }
    public void Rollback()
    {
        if (withdraw.Success)
        {
            withdraw.Rollback();
        }
        if (deposit.Success) { withdraw.Rollback(); }
    }
    public void print()
    {

        Console.WriteLine("Transferred  $ " + _amount + "from " + _fromaccount.Name + "to" + _toaccount.Name + " " + _toaccount.Balance + " " + _fromaccount.Balance);
    }

}
