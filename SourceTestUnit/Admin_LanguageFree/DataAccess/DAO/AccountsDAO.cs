using BusinessObject.DTO;
using BusinessObject.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class AccountsDAO
    {
        private readonly DBContext _dBContext;

        public AccountsDAO(DBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task AddAccounts(AccountsDTO accounts)
        {
            try
            {
                if (accounts == null)
                {
                    throw new ArgumentNullException(nameof(accounts), "AccountsDTO cannot be null.");
                }

                Accounts act = new Accounts();
                act.Username = accounts.Username;
                act.Password = accounts.Password;
                act.Status = 1;
                act.RoleId = "1";
                act.Timestamp = DateTime.Now;
                _dBContext.Account.Add(act);
                await _dBContext.SaveChangesAsync();
                act.UserId = act.AccountId;
                await _dBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                throw new InvalidOperationException("AccountsDTO Exception.");
            }
        }

        public async Task<bool> UpdateAccounts(int id, AccountsDTO accounts)
        {
            try
            {
                var existingAccount = await _dBContext.Account.FindAsync(id);

                if (existingAccount == null)
                    return false;

                existingAccount.UserId = accounts.UserId;
                existingAccount.Username = accounts.Username;
                existingAccount.Password = accounts.Password;
                existingAccount.Status = accounts.Status;
                existingAccount.RoleId = accounts.RoleId;

                await _dBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                throw new InvalidOperationException("AccountsDTO Exception.");
            }
        }

        public async Task<List<Accounts>> GetAllAccounts()
        {
            try
            {
                var accounts = await _dBContext.Account.ToListAsync();
                return accounts;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                throw new InvalidOperationException("AccountsDTO Exception.");
            }
        }
        public async Task<List<Accounts>> GetAllAccountsWithStatus(int status)
        {
            return await _dBContext.Account.Where(a => a.Status == status).ToListAsync();
        }
        public async Task<int> GetAccountsToSession(string username)
        {
            try
            {
                var accounts = await _dBContext.Account.Where(u => u.Username == username).Select(u => u.UserId).FirstOrDefaultAsync();
                return accounts;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                throw new InvalidOperationException("AccountsDTO Exception.");
            }
        }

        public async Task<bool> CheckAccountExist(string username)
        {
            try
            {
                var existingAccount = await _dBContext.Account.AnyAsync(u => u.Username == username);
                return existingAccount;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                throw new InvalidOperationException("AccountsDTO Exception.");
            }
        }

        public async Task<bool> CheckLog(string username, string pass)
        {
            try
            {
                var check = await _dBContext.Account.AnyAsync(s => s.Username == username && s.Password == pass);
                return check;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                throw new InvalidOperationException("AccountsDTO Exception.");
            }
        }

        public async Task<Accounts> GetAccountsToToken(string username)
        {
            try
            {
                var accounts = await _dBContext.Account.FirstOrDefaultAsync(u => u.Username == username);
                return accounts;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                throw new InvalidOperationException("AccountsDTO Exception.");
            }
        }
        public async Task<bool> RemoveAccount(int accountId)
        {
            try
            {
                var accounts = await _dBContext.Account.FindAsync(accountId);
                if (accounts != null)
                {
                    accounts.Status = 2;
                    await _dBContext.SaveChangesAsync();

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                throw new Exception("Failed to Remove Account", ex);
            }
        }
        public async Task<bool> ActiveAccount(int accountId)
        {
            try
            {
                var accounts = await _dBContext.Account.FindAsync(accountId);
                if (accounts != null)
                {
                    accounts.Status = 1;
                    await _dBContext.SaveChangesAsync();

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                throw new Exception("Failed to Unban Account", ex);
            }
        }
        public async Task RegistAdmin(RegistAdminDTO accounts)
        {
            try
            {
                if (accounts == null)
                {
                    throw new ArgumentNullException(nameof(accounts), "RegistAdminDTO cannot be null.");
                }

                Accounts act = new Accounts();
                act.Username = accounts.Username;
                act.Password = accounts.Password;
                act.Status = 1;
                act.RoleId = "2";
                act.Timestamp = DateTime.Now;
                _dBContext.Account.Add(act);
                await _dBContext.SaveChangesAsync();
                act.UserId = act.AccountId;
                await _dBContext.SaveChangesAsync();
                Users ur = new Users();
                ur.UserId = act.UserId;
                ur.FullName = accounts.FullName;
                ur.ImageUser = accounts.ImageUser;
                ur.Email = accounts.Username;
                ur.DateOfBirth = accounts.DateOfBirth;
                ur.Gender = accounts.Gender;
                ur.Phone = accounts.Phone;
                ur.National = accounts.National;
                ur.Timestamp = act.Timestamp;
                _dBContext.User.Add(ur);
                await _dBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                throw new InvalidOperationException("AccountsDTO Exception.");
            }
        }
    }
}
