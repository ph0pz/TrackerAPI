using TrackerData;

namespace TrackerAPI.Services.Interfaces
{
    public interface TransactionInterface
    {
        Task<Transaction> GetTransaction(int transactionId);

        Task<List<object>> GetAllTransactionByMonth(int userId, int month, int year);

        Task<List<object>> GetDayTransactionByMonth(int userId, int month, int year);

        Task<Transaction> AddTransaction(Transaction transaction);
        Task DeleteTransaction(int transactionId);

        Task<Transaction> EditTransaction(Transaction transaction);

        Task<int> GetIncome(int userId, int month, int year);

    }
}
