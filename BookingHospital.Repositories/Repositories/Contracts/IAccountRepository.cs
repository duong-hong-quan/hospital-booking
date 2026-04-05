using BookingHospital.Repositories.Models;

namespace BookingHospital.Repositories.Repositories.Contracts;

public interface IAccountRepository
{
    Task<List<Account>> GetAccountsAsync();

    Task<Account?> GetAccountAsync(string name);

    Task<Account> AddAccountAsync(Account account);

    Task<Account> UpdateAccountAsync(Account account);

    Task<Account> DeleteAccountAsync(int id);
}