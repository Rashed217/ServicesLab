using ServicesLab1.Models;
using ServicesLab1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLab1.Services
{
    public class TransactionService
    {
        private readonly TransactionRepository _repository;

        public TransactionService(TransactionRepository repository)
        {
            _repository = repository;
        }

        public void AddTransaction(Transaction transaction)
        {
            _repository.Add(transaction);
        }

        public void UpdateTransaction(Transaction transaction)
        {
            _repository.Update(transaction);
        }

        public void DeleteTransaction(Transaction transaction)
        {
            _repository.Delete(transaction);
        }

        public Transaction GetTransactionById(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<Transaction> GetAllTransactions()
        {
            return _repository.GetAll();
        }
    }
}
