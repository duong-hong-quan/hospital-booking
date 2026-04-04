using BookingHospital.Repositories.Data;
using BookingHospital.Repositories.Models;
using BookingHospital.Repositories.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BookingHospital.Repositories.Repositories.Implementations;

public class AccountRepository : IAccountRepository
{
    private HospitalContext _context;

    public AccountRepository(HospitalContext context)
    {
        _context = context;
    }

    public async Task<List<Account>> GetAccountsAsync()
    {
        var list = await _context.Accounts.ToListAsync();
        return list;
    }

    public async Task<Account?> GetAccountAsync(string name)
    {
        return await _context.Accounts.FirstOrDefaultAsync(s => s.UserName == name);
    }

    public async Task<Account> AddAccountAsync(Account account)
    {
        await _context.Accounts.AddAsync(account);
        await _context.SaveChangesAsync();
        return account;
    }

    public async Task<Account> UpdateAccountAsync(Account account)
    {
        var accountInDb = await _context.Accounts.FirstOrDefaultAsync(s => s.UserName == account.UserName);
        if (accountInDb != null)
        {
            accountInDb.UserName = account.UserName;
            _context.Accounts.Update(accountInDb);
            await _context.SaveChangesAsync();
        }

        return accountInDb;
    }

    public async Task<Account> DeleteAccountAsync(int id)
    {
        var accountInDb = await _context.Accounts.FirstOrDefaultAsync(s => s.Id == id);
        if (accountInDb != null)
        {
            _context.Accounts.Remove(accountInDb);
            await _context.SaveChangesAsync();
        }
        return accountInDb;
    }
}