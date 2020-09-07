using System.Collections.Generic;
using System.Threading.Tasks;
using sportlife.Models;

namespace sportlife.Services
{
    public interface ITransactionService
    {
        Task<Transaction> Create(Transaction model);

        Task<List<Transaction>> SelectAll(int id);
    }
}