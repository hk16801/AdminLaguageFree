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
    public class UsersRepository : UsersIRepository
    {
        private readonly UsersDAO _usersDAO;

        public UsersRepository(UsersDAO usersDAO)
        {
            _usersDAO = usersDAO;
        }
        public Task NewUsers(UsersDTO users)
        {
            return _usersDAO.AddUsers(users);
        }
        public Task<List<Users>> GetAllUsers()
        {
            return _usersDAO.GetAllUser();
        }

        public Task<UserVoiceDTO> GetByUserVoice(int id)
        {

            return _usersDAO.GetByUserVoice(id);
        }
        public Task<Users> GetByUserTemp(int id)
        {

            return _usersDAO.GetByUserTemp(id);
        }
        public Task<Users> GetByAccount(string userName)
        {

            return _usersDAO.GetByAccount(userName);

        }
        public Task<Users> GetByAccountByID(int id)
        {

            return _usersDAO.GetByAccountByID(id);

        }
        public Task<bool> CheckUserExist(string userName)
        {
            return _usersDAO.CheckUserExist(userName);
        }

        public Task UpdateUsers(UsersDTO users)
        {
            return _usersDAO.UpdateUser(users);
        }
        public Task<List<Users>> GetAllUserWithAccountStatus(string roleid, int status)
        {
            return _usersDAO.GetAllUserWithAccountStatus(roleid, status);
        }
        public Task<List<Users>> GetAllUserWithStatus(int status)
        {
            return _usersDAO.GetAllUserWithStatus(status);
        }
    }
}
