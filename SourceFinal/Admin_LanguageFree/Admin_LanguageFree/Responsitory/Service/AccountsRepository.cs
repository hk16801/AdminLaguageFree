using BusinessObject.DTO;
using BusinessObject.Model;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reponsitory.Service
{
    public class AccountsRepository : AccountsIRepository
    {
        private readonly AccountsDAO _accountsDAO;

        public AccountsRepository(AccountsDAO accountsDAO)
        {
            _accountsDAO = accountsDAO;
        }
        public Task NewAccounts(AccountsDTO accounts)
        {
            return _accountsDAO.AddAccounts(accounts);
        }
        public Task<bool> UpdateAccounts(int id, ChangePasswordDTO accounts)
        {
            return _accountsDAO.UpdateAccounts(id, accounts);
        }

        public Task<List<Accounts>> GetAllAccounts()
        {
            return _accountsDAO.GetAllAccounts();
        }
        public Task<List<Accounts>> GetAllAccountsWithStatus(int status)
        {
            return _accountsDAO.GetAllAccountsWithStatus(status);
        }
        public Task<int> GetAccountsToSession(string username)
        {
            return _accountsDAO.GetAccountsToSession(username);
        }

        public Task<bool> CheckAccountExist(string username)
        {
            return _accountsDAO.CheckAccountExist(username);
        }
        public Task<bool> CheckLogin(string username, string password)
        {
            return _accountsDAO.CheckLog(username, password);
        }
        public Task<Accounts> GetAccountsToToken(string username)
        {
            return _accountsDAO.GetAccountsToToken(username);
        }
        public Task RemoveAccount(int id)
        {
            return _accountsDAO.RemoveAccount(id);
        }
        public Task ActiveAccount(int id)
        {
            return _accountsDAO.ActiveAccount(id);
        }
        public Task VerifyAccount(int id)
        {
            return _accountsDAO.VerifyAccount(id);
        }
        public Task RegistAdmin(RegistAdminDTO accounts)
        {
            return _accountsDAO.RegistAdmin(accounts);
        }
        public Task<string> ForgotPassword(string username)
        {
            return _accountsDAO.ForgotPassword(username);
        }
        public Task ChangePasswordR(RegistAdminDTO accounts)
        {
            return _accountsDAO.RegistAdmin(accounts);
        }
    }
}
