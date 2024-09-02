using BusinessObject.DTO;
using BusinessObject.Model;
using DataAccess.DAO;
using Reponsitory.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reponsitory
{
    public interface AccountsIRepository
    {
        Task NewAccounts(AccountsDTO accounts);
        Task<bool> UpdateAccounts(int id, ChangePasswordDTO accounts);
        Task<List<Accounts>> GetAllAccounts();
        Task<int> GetAccountsToSession(string username);
        Task<bool> CheckAccountExist(string username);
        Task<bool> CheckLogin(string username, string password);
        Task<Accounts> GetAccountsToToken(string username);
        Task RemoveAccount(int id);
        Task ActiveAccount(int id);
        Task VerifyAccount(int id);
        Task<List<Accounts>> GetAllAccountsWithStatus(int status);
        Task RegistAdmin(RegistAdminDTO accounts);
        Task<string> ForgotPassword(string username);
        Task ChangePasswordR(RegistAdminDTO accounts);




    }
}
