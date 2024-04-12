using System;
using System.Collections.Generic;
using System.Linq;

namespace Erasmus24
{
    struct Banknode
    {
        public Banknode(int v,int a) { Value = v;Amount = a; }
        public int Value { get; set; }
        public int Amount { get; set; }

    }
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
        public List<Banknode> Banknodes { get; set; } = new List<Banknode>();
        private int selectedCustomer = -1;
        private ATMState state;

        double Balance { get; set; }

        public ATM()
        {
            int[] banknodesinf = { 5, 10, 20, 50, 100, 200 };

            Random rnd=new Random();
            for(int i = 0;i<6;i++)
            {
                Banknodes.Add(new Banknode(banknodesinf[i], rnd.Next(10)));
            }

            state = ATMState.StandBy;
            Balance = rnd.NextDouble() * 10000;
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


            Console.Write("\nBanknodes\n");
            Console.WriteLine("Banknode 5 -> " + Banknodes[0].Amount);
            Console.WriteLine("Banknode 10 -> " + Banknodes[1].Amount);
            Console.WriteLine("Banknode 20 -> " + Banknodes[2].Amount);
            Console.WriteLine("Banknode 50 -> " + Banknodes[3].Amount);
            Console.WriteLine("Banknode 100 -> " + Banknodes[4].Amount);
            Console.WriteLine("Banknode 200 -> " + Banknodes[5].Amount);

            Console.WriteLine("Press enter to continue...");
            if(Console.ReadKey().Key==ConsoleKey.Enter)
            {
                Console.Clear();
                state = ATMState.LoggedIn;
            }
        }

        private void PayCash()
        {
            int cash = 0, selected = -1;
            Console.Clear();
            do
            {
                Console.WriteLine("ATM Balance: " + Balance.ToString("0.##"));
                Console.WriteLine("Balance: " + Customers.ElementAt(selectedCustomer).balance.ToString("0.##"));
                Console.Write("1) 5\n2) 10\n3) 20\n4) 50\n5) 100\n6) 200\n7) Other Amount\n");
                Console.Write("Select the amount of cash that you want to deposit: ");

                selected = int.Parse(Console.ReadLine());
                if (selected > 7 || selected < 1)
                {
                    selected = -1;
                    continue;
                }
                switch (selected)
                {
                    case 1: cash = 5; break;
                    case 2: cash = 10; break;
                    case 3: cash = 20; break;
                    case 4: cash = 50; break;
                    case 5: cash = 100; break;
                    case 6: cash = 200; break;
                    case 7:
                        while (true)
                        {
                            Console.Write("Type the amount that you want to withdraw: ");
                            cash = int.Parse(Console.ReadLine());
                            if (cash % 5 == 0)
                                break;
                        }
                        break;
                }
                //cash = int.Parse(Console.ReadLine());
            }
            while (cash <= 0 || selected == -1);

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
            int cash = 0, selected = -1;
            do
            {
                Console.Clear();
                Console.WriteLine("ATM Balance: " + Balance.ToString("0.##"));
                Console.WriteLine("User Balance: " + Customers.ElementAt(selectedCustomer).balance.ToString("0.##") + "\n");
                Console.Write("1) 5\n2) 10\n3) 20\n4) 50\n5) 100\n6) 200\n7) Other Amount\n");
                Console.Write("Select the amount of cash that you want to withdrawal: ");

                selected = int.Parse(Console.ReadLine());
                if (selected > 7 || selected < 1 || Banknodes[selected - 1].Amount <= 0)
                {
                    selected = -1;
                    continue;
                }
                switch (selected)
                {
                    case 1: cash = 5; Banknodes[selected-1] = new Banknode(5, Banknodes[selected-1].Amount - 1); break;
                    case 2: cash = 10; Banknodes[selected-1] = new Banknode(10, Banknodes[selected - 1].Amount - 1); break;
                    case 3: cash = 20; Banknodes[selected - 1] = new Banknode(20, Banknodes[selected - 1].Amount - 1); break;
                    case 4: cash = 50; Banknodes[selected - 1] = new Banknode(50, Banknodes[selected - 1].Amount - 1); break;
                    case 5: cash = 100; Banknodes[selected - 1] = new Banknode(100, Banknodes[selected - 1].Amount - 1); break;
                    case 6: cash = 200; Banknodes[selected - 1] = new Banknode(200, Banknodes[selected - 1].Amount - 1); break;
                    case 7:
                        while (true)
                        {
                            Console.Write("Type the amount that you want to withdraw: ");
                            cash = int.Parse(Console.ReadLine());
                            if (cash % 5 == 0)
                                break;
                        }
                        break;
                }
            }
            while (cash > Customers.ElementAt(selectedCustomer).balance || selected == -1 || cash > Balance );

            Customers.ElementAt(selectedCustomer).balance -= cash;
            Balance -= cash;
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

            ATM atm = new ATM();
            atm.Run();
            Console.ReadLine();
        }
    }
}
