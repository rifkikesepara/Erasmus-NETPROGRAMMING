using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Erasmus24
{
    enum ATMState
    {
        StandBy = 0, LoggedIn, CashWithdrawal, CheckBalance, PayCash, ChangePin
    }
    class Customer
    {
        public Customer(string name,double balance,int pin)
        {
            this.name = name;
            this.balance = balance;
            this.pin = pin;
        }

        public string name { get; set; }
        public double balance { get; set; }

        public int pin { get; set; }
    }
    class ATM
    {
        public static List<Customer> Customers { get; set; } = new List<Customer>();
        private int selectedCustomer = -1;
        private ATMState state;

        public ATM()
        {
            state = ATMState.StandBy;
           
            
        }

        public void Run()
        {
            while(true)
            {
                switch(state)
                {
                    case ATMState.StandBy: StandBy(); break;
                    case ATMState.LoggedIn:LoggedIn();break;
                    case ATMState.CheckBalance:CheckBalance();break;
                    case ATMState.PayCash:PayCash(); break;
                    case ATMState.CashWithdrawal:CashWithdrawal(); break;
                    case ATMState.ChangePin:ChangePin(); break;
                }
            }
        }

        private void StandBy()
        {
            if (selectedCustomer == -1)
            {
                Console.WriteLine("***\tWelcome to the ATM\t***");
                for (int i=0;i<Customers.LongCount();i++)
                {
                    Console.WriteLine(i + ") " + Customers.ElementAt(i).name);
                }
                Console.Write("Select a Customer: ");
                selectedCustomer = int.Parse(Console.ReadLine());
            }
            else
            {
                Console.Write("Enter the pin: ");
                if (int.Parse(Console.ReadLine()) == Customers.ElementAt(selectedCustomer).pin)
                {
                    Console.Clear();
                    Console.WriteLine("Logged in successfully!");
                    state = ATMState.LoggedIn;
                }
                else
                {
                    Console.WriteLine("Try Again!");
                }
            }
        }

        private void LoggedIn()
        {
            Console.WriteLine("User: " + Customers.ElementAt(selectedCustomer).name + "\n");
            Console.Write("Options: \n1) Check the balance\n2) Pay Cash\n3) Cash withdrawal\n4) Change the pin\n5) Exit\n");
            Console.Write("Select an option to proceed: ");
            switch (int.Parse(Console.ReadLine()))
            {
                case 1: state = ATMState.CheckBalance; break;
                case 2: state = ATMState.PayCash; break;
                case 3: state = ATMState.CashWithdrawal; break;
                case 4: state = ATMState.ChangePin; break;
                case 5: state =  ATMState.StandBy; selectedCustomer = -1;Console.Clear();break;
            }
        }

        private void CheckBalance()
        {
            Console.Clear();
            Console.WriteLine("Balance: " + Customers.ElementAt(selectedCustomer).balance.ToString("0.##"));
            Console.WriteLine("Press enter to continue...");
            if(Console.ReadKey().Key==ConsoleKey.Enter)
            {
                Console.Clear();
                state = ATMState.LoggedIn;
            }
        }

        private void PayCash()
        {
            int cash = 0;
            Console.Clear();
            do
            {
                Console.WriteLine("Balance: " + Customers.ElementAt(selectedCustomer).balance.ToString("0.##"));
                Console.Write("Write the amount of cash that you want to pay: ");
                cash = int.Parse(Console.ReadLine());
            }
            while (cash <= 0);

            Customers.ElementAt(selectedCustomer).balance += cash;
            Console.WriteLine("New Balance: " + Customers.ElementAt(selectedCustomer).balance.ToString("0.##"));
            Console.WriteLine("Press enter to continue...");
            if(Console.ReadKey().Key==ConsoleKey.Enter)
            {
                Console.Clear();
                state = ATMState.LoggedIn;
            }
        }

        private void CashWithdrawal()
        {
            int cash = 0;
            Console.Clear();
            do
            {
                Console.WriteLine("Balance: " + Customers.ElementAt(selectedCustomer).balance.ToString("0.##"));
                Console.Write("Write the amount of cash that you want to withdrawal: ");
                cash = int.Parse(Console.ReadLine());
            }
            while (cash > Customers.ElementAt(selectedCustomer).balance);

            Customers.ElementAt(selectedCustomer).balance -= cash;
            Console.WriteLine("New Balance: " + Customers.ElementAt(selectedCustomer).balance.ToString("0.##"));
            Console.WriteLine("Press enter to continue...");
            if(Console.ReadKey().Key==ConsoleKey.Enter)
            {
                Console.Clear();
                state = ATMState.LoggedIn;
            }
        }

        private void ChangePin()
        {
            int? newPin;
            Console.Clear();
            do
            {
                Console.Write("Enter the current pin: ");
                newPin = int.Parse(Console.ReadLine());
            } while (newPin != Customers.ElementAt(selectedCustomer).pin);
            Console.Write("Enter the new pin: ");
            Customers.ElementAt(selectedCustomer).pin = int.Parse(Console.ReadLine());
            Console.WriteLine("The pin has been changed successfully!");
            Console.WriteLine("Press enter to continue...");
            if(Console.ReadKey().Key==ConsoleKey.Enter)
            {
                Console.Clear();
                state = ATMState.LoggedIn;
            }
        }
    }



    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd= new Random();
            ATM.Customers.Add(new Customer("Rıfkı Kesepara", rnd.NextDouble() * 10000, 3971));
            ATM.Customers.Add(new Customer("Zafer Bacaksız", rnd.NextDouble() * 10000, 2000));
            ATM.Customers.Add(new Customer("Efe Dortluoğlu", rnd.NextDouble() * 10000, 1234));

            ATM atm= new ATM();
            atm.Run();
            Console.ReadLine();
        }
    }
}
