using System;
using sistema_bancario_csharp.Entities;
using System.Globalization;
using System.Collections;


namespace sistema_bancario_csharp
{
    public class Program
    {
        static void Main (string[] args)
        {
            
           Console.WriteLine(@"

░██╗░░░░░░░██╗███████╗██╗░░░░░░█████╗░░█████╗░███╗░░░███╗███████╗  ████████╗░█████╗░  ████████╗██╗░░██╗███████╗
░██║░░██╗░░██║██╔════╝██║░░░░░██╔══██╗██╔══██╗████╗░████║██╔════╝  ╚══██╔══╝██╔══██╗  ╚══██╔══╝██║░░██║██╔════╝
░╚██╗████╗██╔╝█████╗░░██║░░░░░██║░░╚═╝██║░░██║██╔████╔██║█████╗░░  ░░░██║░░░██║░░██║  ░░░██║░░░███████║█████╗░░
░░████╔═████║░██╔══╝░░██║░░░░░██║░░██╗██║░░██║██║╚██╔╝██║██╔══╝░░  ░░░██║░░░██║░░██║  ░░░██║░░░██╔══██║██╔══╝░░
░░╚██╔╝░╚██╔╝░███████╗███████╗╚█████╔╝╚█████╔╝██║░╚═╝░██║███████╗  ░░░██║░░░╚█████╔╝  ░░░██║░░░██║░░██║███████╗
░░░╚═╝░░░╚═╝░░╚══════╝╚══════╝░╚════╝░░╚════╝░╚═╝░░░░░╚═╝╚══════╝  ░░░╚═╝░░░░╚════╝░  ░░░╚═╝░░░╚═╝░░╚═╝╚══════╝

██████╗░░█████╗░███╗░░██╗██╗░░██╗██╗███╗░░██╗░██████╗░  ░██████╗██╗░░░██╗░██████╗████████╗███████╗███╗░░░███╗
██╔══██╗██╔══██╗████╗░██║██║░██╔╝██║████╗░██║██╔════╝░  ██╔════╝╚██╗░██╔╝██╔════╝╚══██╔══╝██╔════╝████╗░████║
██████╦╝███████║██╔██╗██║█████═╝░██║██╔██╗██║██║░░██╗░  ╚█████╗░░╚████╔╝░╚█████╗░░░░██║░░░█████╗░░██╔████╔██║
██╔══██╗██╔══██║██║╚████║██╔═██╗░██║██║╚████║██║░░╚██╗  ░╚═══██╗░░╚██╔╝░░░╚═══██╗░░░██║░░░██╔══╝░░██║╚██╔╝██║
██████╦╝██║░░██║██║░╚███║██║░╚██╗██║██║░╚███║╚██████╔╝  ██████╔╝░░░██║░░░██████╔╝░░░██║░░░███████╗██║░╚═╝░██║
╚═════╝░╚═╝░░╚═╝╚═╝░░╚══╝╚═╝░░╚═╝╚═╝╚═╝░░╚══╝░╚═════╝░  ╚═════╝░░░░╚═╝░░░╚═════╝░░░░╚═╝░░░╚══════╝╚═╝░░░░░╚═╝
 ");
           Console.WriteLine("\nTo begin, please enter your data! ");
           Account acc = null;
           try
           {
                                
                Console.Write("Enter the account number: ");
                int number = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter the account holder's name: ");
                string holder = Console.ReadLine();
                Console.Write("Enter the email: ");
                string email = Console.ReadLine();
                Console.Write("Whats is the initial balance? ");
                decimal balance = Convert.ToDecimal(Console.ReadLine());
                Console.Write("Is the account current or savings? (c/s) ");
                char option  = Convert.ToChar(Console.ReadLine());
                if (option == 'c')
                {
                    Console.Write("What is the loan limit? ");
                    decimal loanLimit = Convert.ToDecimal(Console.ReadLine());

                    acc = new CurrentAccount(number, holder, email, balance, loanLimit);
                }
                else if (option == 's')
                {
                    acc = new SavingsAccount (number, holder, email, balance);
                }
                else
                {
                    Console.WriteLine("Invalid option!");
                    Console.ReadKey();
                }

                Console.WriteLine(acc.ToString());
           }
           catch (ArgumentException e)
           {
            Console.WriteLine("Argument Null" + e.Message);
           }
           catch (Exception e)
           {
            Console.WriteLine(e.Message);
           }
           
           Console.WriteLine();
           bool menu = true;
           
           while (menu)
           {
            Console.Clear();
            Console.WriteLine("Please enter your option.");
            Console.WriteLine("1 - Deposit");
            Console.WriteLine("2 - Withdraw");
            Console.WriteLine("3 - Loan");        
            Console.WriteLine("4 - Summary");
            Console.WriteLine("5 - Exit");


            switch(Console.ReadLine())
            {
                case "1":
                Console.WriteLine("Enter the deposit amount");
                decimal amount = Convert.ToDecimal(Console.ReadLine());
                acc.Deposit(amount);
                break;

                case "2":
                Console.WriteLine("Enter the withdraw amount");
                amount = Convert.ToDecimal(Console.ReadLine());
                acc.Withdraw(amount);
                break;

                case "3":
                if(acc is CurrentAccount)
                {
                    Console.WriteLine("Enter the loan amount");
                    amount = Convert.ToDecimal(Console.ReadLine());
                    ((CurrentAccount)acc).Loan(amount);
                }
                else
                {
                    Console.WriteLine("sorry, only current accounts are eligible for loans");
                }
                
                break;

                case "4":
                Console.WriteLine("Account summary:");
                Console.WriteLine(acc.ToString());
                break;

                 case "5":
                menu = false;
                break;

                default:
                Console.WriteLine("Opção inválida");
                break;   
                 }

                 Console.WriteLine("Please, Press any key to continue.");
//ver o porque não esta imprimindo quando coloca o 4 e continuar o programa 
//colocando o 5 para sair do programa, apos isso verificar se o programa está rodando corretamente
            }

           }
      
        }
    }
    

