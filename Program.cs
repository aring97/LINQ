using System;
using System.Collections.Generic;
using System.Linq;
namespace linq
{
    class Program
    {
        static void Main(string[] args)
        {
            // Find the words in the collection that start with the letter 'L'
            List<string> fruits = new List<string>() {"Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry"};
            IEnumerable<string> LFruits = from fruit in fruits
                                where fruit.StartsWith("L")
                                select fruit;
            foreach(string Fruit in LFruits){
                System.Console.WriteLine(Fruit);
            }
            // Which of the following numbers are multiples of 4 or 6
            List<int> numbers = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };
            IEnumerable<int> fourSixMultiples = numbers.Where(num=>num%4==0 ||num%6==0);
            foreach(int number in fourSixMultiples){
                System.Console.WriteLine(number);
            }
            // Order these student names alphabetically, in descending order (Z to A)
            List<string> names = new List<string>()
            {
                "Heather", "James", "Xavier", "Michelle", "Brian", "Nina",
                "Kathleen", "Sophia", "Amir", "Douglas", "Zarley", "Beatrice",
                "Theodora", "William", "Svetlana", "Charisse", "Yolanda",
                "Gregorio", "Jean-Paul", "Evangelina", "Viktor", "Jacqueline",
                "Francisco", "Tre"
            };

            List<string> descend = names.OrderByDescending(name=>name).ToList();
            foreach(string name in descend){
                System.Console.WriteLine(name);
            }

            // Build a collection of these numbers sorted in ascending order
            List<int> sortedAscending= numbers.OrderBy(num=>num).ToList();
            foreach(int number in sortedAscending){
                System.Console.WriteLine(number);
            }
            System.Console.WriteLine(numbers.Count());

            List<double> purchases = new List<double>()
            {
                2340.29, 745.31, 21.76, 34.03, 4786.45, 879.45, 9442.85, 2454.63, 45.65
            };
            List<double> oredered=purchases.OrderByDescending(num=>num).ToList();
            System.Console.WriteLine(oredered[0]);
            // What is our most expensive product?
            List<double> prices = new List<double>()
            {
                879.45, 9442.85, 2454.63, 45.65, 2340.29, 34.03, 4786.45, 745.31, 21.76
            };
            List<double> orderedPrices=prices.OrderByDescending(num=>num).ToList();
            System.Console.WriteLine(orderedPrices[0]);

            List<int> wheresSquaredo = new List<int>()
            {
                66, 12, 8, 27, 82, 34, 7, 50, 19, 46, 81, 23, 30, 4, 68, 14
            };
            List<double> listOfDouble=new List<double>();
            foreach(int number in wheresSquaredo){
                listOfDouble.Add(Convert.ToDouble(number));
            }
            
            List<double> beforeSquare=listOfDouble.TakeWhile(number=>(Math.Sqrt(number))%1>0).ToList();
            foreach(int number in beforeSquare){
                System.Console.WriteLine(number);
            }
            
            /*
                Store each number in the following List until a perfect square
                is detected.

                Expected output is { 66, 12, 8, 27, 82, 34, 7, 50, 19, 46 } 

                Ref: https://msdn.microsoft.com/en-us/library/system.math.sqrt(v=vs.110).aspx
            */

            List<Customer> customers = new List<Customer>() {
                new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
                new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
                new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
                new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
                new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
                new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
                new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
                new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
                new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
                new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
            };
            List<BankTotal> millionarPerBank= (from customer in customers
                                            where(customer.Balance/1000000>=1)
                                            group customer by customer.Bank into customersBank
                                            select new BankTotal{
                                                BankName=customersBank.Key,
                                                NumberOfMillions=customersBank.Count()
                                            }).ToList();
            foreach(BankTotal bank in millionarPerBank){
                System.Console.WriteLine($"{bank.BankName} {bank.NumberOfMillions}");
            }
            // Create some banks and store in a List
        List<Bank> banks = new List<Bank>() {
            new Bank(){ Name="First Tennessee", Symbol="FTB"},
            new Bank(){ Name="Wells Fargo", Symbol="WF"},
            new Bank(){ Name="Bank of America", Symbol="BOA"},
            new Bank(){ Name="Citibank", Symbol="CITI"},
        };

        /*
            You will need to use the `Where()`
            and `Select()` methods to generate
            instances of the following class.
        */

        List<ReportItem> millionaireReport =customers.Where(customer=>customer.Balance/1000000>=1)
                                                    .OrderBy(customer=>customer.Name.Split(" ")[1])
                                                    .Join(banks, customers=>customers.Bank, 
                                                            bank=>bank.Symbol,
                                                            (customer, bank)=>
                                                            new ReportItem{BankName=bank.Name, CustomerName=customer.Name}
                                                            ).ToList();

        foreach (var item in millionaireReport)
        {
            Console.WriteLine($"{item.CustomerName} at {item.BankName}");
        }

    }
        public class Customer
        {
            public string Name { get; set; }
            public double Balance { get; set; }
            public string Bank { get; set; }
        }
        public class BankTotal{
            public string BankName{get; set;}
            public int NumberOfMillions{get;set;}
        }

        public class Bank
        {
            public string Symbol { get; set; }
            public string Name { get; set; }
        }

        public class ReportItem
            {
                public string CustomerName { get; set; }
                public string BankName { get; set; }
            }
    }
}
