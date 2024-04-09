using MongoDBWebAPI.Models;

namespace MongoDBWebAPI.Interfaces
{
    public interface IAccountService
    {
        Account CreateAccount(Account account);
        List<Account> GetAllAccounts();
        Account GetAccountById(string id);

        void DeleteAccount(string id);

        void UpdateAccount(string id, Account account);

    }
}
