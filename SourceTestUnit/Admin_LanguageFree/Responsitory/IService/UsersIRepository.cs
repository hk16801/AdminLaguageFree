using BusinessObject.DTO;
using BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reponsitory
{
    public interface UsersIRepository
    {
        Task NewUsers(UsersDTO users);
        Task<List<Users>> GetAllUsers();
        Task<UserVoiceDTO> GetByUserVoice(int id);
        Task<Users> GetByAccount(string userName);
        Task<Users> GetByAccountByID(int id);

        Task<Users> GetByUserTemp(int id);
        Task<bool> CheckUserExist (string userName);
        Task UpdateUsers(UsersDTO users);
        Task<List<Users>> GetAllUserWithAccountStatus(string roleid, int status);
        Task<List<Users>> GetAllUserWithStatus(int status);

    }
}
