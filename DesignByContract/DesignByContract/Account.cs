using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;
namespace DesignByContract
{
    class Account
    {
        private double balance;

        public double Balance { get { return balance; } }

        public void Deposit(double amount)
        {
            Contract.Requires(amount > 0);
            Contract.Ensures(Balance >= 0);
            balance += amount;
        }

        public void Withdraw(double amount)
        {
           
            //Contract.Requires(amount > 0);
            //Contract.Requires(Balance >= amount);
            //Contract.Ensures(Balance >= 0);
            if (amount <= 0 || Balance < amount)
                throw new ArgumentException("Incorrect amount!");
            Contract.EndContractBlock();
            balance -= amount;

        }


        static void Main(string[] args)
        {
            Account dep = new Account();
            
            dep.Deposit(-1); //codecontracts vil her sige at amount skal være større end 0
            dep.Deposit(101);
            
            Console.WriteLine("Din balance er nu: " + dep.Balance.ToString());
            
            int eben = Convert.ToInt32(Console.ReadLine());
            dep.Withdraw(eben);
            
            //dep.Withdraw(101); // vil give incorrect amount som argumentexception fordi beløbet man trækker er større end balance
            Console.WriteLine("Din balance er nu: " + dep.Balance.ToString());
            
            //Console.WriteLine("23/7 = " + Deposit(2));
            //Console.WriteLine("56/0 = " + Divide(56, 0));
            //Console.WriteLine(add([1],[1]));
            Console.ReadKey();
        }
        
    }

}

