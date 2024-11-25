using ServicesLab1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLab1.Services
{
    public class BankServices 
    {
        private readonly ApplicationDbContext _context;
        private readonly TransactionService _transactionService;

        public BankServices(ApplicationDbContext context, TransactionService transactionService)
        {
            _context = context;
            _transactionService = transactionService;
        }

        public void Withdraw(string accountNumber, decimal amount, Transaction transaction)
        {
            var account = _context.BankAccounts.SingleOrDefault(a => a.AccountNumber == accountNumber);
            if (account == null || account.Balance < amount)
            {
                throw new Exception("Insufficient funds or account not found.");
            }

            account.Balance -= amount;
            _context.SaveChanges();

            var transaction1 = new Transaction
            {
                SourceAccNumber = "ATM",
                Operation = "withdraw",
                Amount = amount,
                BankAccount = account
            };
            _transactionService.AddTransaction(transaction);
        }

        public void Deposit(string accountNumber, decimal amount)
        {
            var account = _context.BankAccounts.SingleOrDefault(a => a.AccountNumber == accountNumber);
            if (account == null)
            {
                throw new Exception("Account not found.");
            }

            account.Balance += amount;
            _context.SaveChanges();
        }

        public void Transfer(int ac1, int ac2,decimal amount)
        { }


        // Implementing Transfer Function
        public void Transfer(string sourceAccountNumber, string destinationAccountNumber, decimal amount)
        {
            var sourceAccount = _context.BankAccounts.SingleOrDefault(a => a.AccountNumber == sourceAccountNumber);
            var destinationAccount = _context.BankAccounts.SingleOrDefault(a => a.AccountNumber == destinationAccountNumber);
            if (sourceAccount == null || destinationAccount == null || sourceAccount.Balance < amount)
            {
                throw new Exception("Insufficient funds or account not found.");
            }

            sourceAccount.Balance -= amount;
            destinationAccount.Balance += amount;
            _context.SaveChanges();

            var transaction2 = new Transaction
            {
                SourceAccNumber = sourceAccountNumber,
                Operation = "transfer",
                Amount = amount,
                BankAccount = sourceAccount
            };
            _transactionService.AddTransaction(transaction2);

            var transaction3 = new Transaction
            {
                SourceAccNumber = destinationAccountNumber,
                Operation = "transfer",
                Amount = amount,
                BankAccount = destinationAccount
            };
            _transactionService.AddTransaction(transaction3);
        }
    }
}
