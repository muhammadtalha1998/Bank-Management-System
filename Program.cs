using System;
using System.IO;
using System.Collections.Generic;
namespace Test_net
{

    class Program
    {
        private static void DoWithdraw(Bank toBank)
        {
            Account toAccount = FindAccount(toBank);
            if (toAccount == null) return;
            decimal withdrawAmount = 0;

            do
            {
                try
                {

                    Console.WriteLine("Enter amount to withdraw ");
                    withdrawAmount = Convert.ToDecimal(Console.ReadLine());

                }
                catch
                {
                    Console.WriteLine("That's not a valid option");

                }
                if (withdrawAmount <= 0)
                {
                    Console.WriteLine("The amount you have entered is invalid");
                }
            } while (withdrawAmount <= 0);
            toBank.ExecuateTransaction(new withdrawTransaction(toAccount, withdrawAmount));
        }

        private static void DoDeposit(Bank toBank)
        {
            Account toAccount = FindAccount(toBank);

            decimal depositAmount = 0;
            if (toAccount == null) return;
            do
            {
                try
                {

                    Console.WriteLine("Enter amount to deposit ");
                    depositAmount = Convert.ToDecimal(Console.ReadLine());

                }
                catch
                {
                    Console.WriteLine("That's not a valid option");

                }
            } while (depositAmount <= 0);
            toBank.ExecuateTransaction(new withdrawTransaction(toAccount, depositAmount));
        }

        private static Account FindAccount(Bank fromBank)
        {
            Console.Write("Enter account name: ");
            String name = Console.ReadLine();
            Account result = fromBank.GetAccount(name);
            if (result == null)
            {
                Console.WriteLine($"No account found with name {name}");
            }
            return result;
        }
        private static void DoPrint(Bank toBank)

        {
            Account toAccount = FindAccount(toBank);
            toAccount.Print(toAccount.Name, toAccount.Balance);


        }
        private static MenuOption ReadUsersOption()

        {
            int option = 0;

            do
            {
                try
                {
                    Console.WriteLine(" Select one of the following options: \n 1. New Account \n 2. Withdraw \n 3. Deposit \n 4. Transfer \n 5. Print \n 6. Quit ");
                    option = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine(" That's not right choose an option between 1-6: ");
                    option = -1;

                }

            } while (option < 1 || option > 6);

            return (MenuOption)(option - 1);
        }
        public static void Main()
        {
            MenuOption userSelection;
            Bank Ba = new Bank();



            do
            {
                userSelection = ReadUsersOption();
                switch (userSelection)
                {
                    case MenuOption.NewAccount:
                        Console.Write("Enter account name: ");
                        String name = Console.ReadLine();


                        Ba.AddAccount(new Account(name, 500000));
                        break;

                    case MenuOption.Withdraw:
                        DoWithdraw(Ba); // Withdraw method expects a parameter - passing in an account object called zenabsaccount.
                        break;

                    case MenuOption.Deposit:
                        DoDeposit(Ba);
                        break;
                    case MenuOption.transfer:
                        Account fromAccount = FindAccount(Ba);
                        if (fromAccount == null) break;

                        Console.Write("Enter amount to transfer ");
                        decimal amountToTransfer = decimal.Parse(Console.ReadLine());
                        Ba.ExecuateTransaction(new transfertransaction(fromAccount, new Account("zaneb", 500000), amountToTransfer));
                        break;
                    case MenuOption.Print:
                        DoPrint(Ba);
                        break;
                }
            } while (userSelection != MenuOption.Quit);


        }


    }
    public enum MenuOption

    {
        NewAccount,
        Withdraw,
        Deposit,
        transfer,
        Print,
        Quit,


    }




}
