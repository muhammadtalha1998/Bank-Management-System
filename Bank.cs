using System;
using System.Collections.Generic;

public class Bank
{


    List<Account> _accounts = new List<Account>();


    public void AddAccount(Account account)
    {
        _accounts.Add(account);

    }
    public Account GetAccount(string name)
    {
        foreach (Account acc in _accounts)
        {

            if (acc.Name.Equals(name))
            {

                return acc;
            }
        }
        return null;
    }

    public void ExecuateTransaction(withdrawTransaction WD)
    {





        WD.Execute();
        if (WD.Success)
        {

            WD.Print();
        }

        else
        {

            WD.Rollback();

        }


    }
    public void ExecuateTransaction(DepsiteTransaction DT)
    {
        DT.Execute();
        if (DT.Success)
        {

            DT.Print();
        }
        else

        {

            DT.Rollback();

        }

    }
    public void ExecuateTransaction(transfertransaction TT)
    {
        TT.Execution();


    }



}