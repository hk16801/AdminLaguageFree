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
    public class UsersDAO
    {
        private readonly DBContext _dBContext;
        public Users ur { get; set; } = new Users();
        public List<Users> users { get; set; } = new List<Users>();
        public UserVoiceDTO uv { get; set; } = new UserVoiceDTO();
        public UsersDAO(DBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task AddUsers(UsersDTO user)
        {
            try
            {
                if (user == null)
                {
                    throw new ArgumentNullException(nameof(user), "UsersDTO cannot be null.");
                }

                ur.UserId = user.UserId;
                ur.FullName = user.FullName;
                ur.ImageUser = user.ImageUser;
                ur.Email = user.Email;
                ur.DateOfBirth = user.DateOfBirth;
                ur.Gender = user.Gender;
                ur.Phone = user.Phone;
                ur.National = user.National;
                ur.Timestamp = DateTime.Now;
                _dBContext.User.Add(ur);
                await _dBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while adding user: {ex.Message}", ex);
            }
        }

        public async Task<List<Users>> GetAllUser()
        {
            try
            {
                var user = await _dBContext.User.ToListAsync();
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while getting all users: {ex.Message}", ex);
            }
        }
        public async Task<List<Users>> GetAllUserWithAccountStatus(string roleid , int status)
        {
            try
            {
                var account = await _dBContext.Account.Where(a => a.RoleId == roleid && a.Status == status).ToListAsync();
                foreach(var item in account)
                {
                    var user = await _dBContext.User.Where(u => u.UserId == item.UserId).FirstOrDefaultAsync();
                    if(user != null)
                    {
                        users.Add(user);
                    }
                }
                return users;
            }
            catch(Exception ex)
            {
                throw new Exception($"Error occurred while getting all users: {ex.Message}", ex);
            }
        }
        public async Task<List<Users>> GetAllUserWithStatus(int status)
        {
            try
            {
                var account = await _dBContext.Account.Where(a => a.Status == status).ToListAsync();
                foreach (var item in account)
                {
                    var user = await _dBContext.User.Where(u => u.UserId == item.UserId).FirstOrDefaultAsync();
                    if (user != null)
                    {
                        users.Add(user);
                    }
                }
                return users;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while getting all users: {ex.Message}", ex);
            }
        }
        public async Task<Users> GetByAccount(string username)
        {
            try
            {
                var accounts = await _dBContext.Account.Where(u => u.Username == username).FirstOrDefaultAsync();
                var user = await _dBContext.User.Where(u => u.UserId == accounts.UserId).FirstOrDefaultAsync();
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while getting user by account: {ex.Message}", ex);
            }
        }

        public async Task<Users> GetByAccountByID(int id)
        {
            try
            {
                var accounts = await _dBContext.Account.Where(u => u.UserId == id).FirstOrDefaultAsync();
                var user = await _dBContext.User.Where(u => u.UserId == accounts.UserId).FirstOrDefaultAsync();
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while getting user by account ID: {ex.Message}", ex);
            }
        }

        public async Task<UserVoiceDTO> GetByUserVoice(int id)
        {
            try
            {
                var user = await _dBContext.User.Where(u => u.UserId == id).FirstOrDefaultAsync();
                uv.DateOfBirth = user.DateOfBirth;
                uv.Gender = user.Gender;
                return uv;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while getting user voice: {ex.Message}", ex);
            }
        }

        public async Task<Users> GetByUserTemp(int id)
        {
            try
            {
                var user = await _dBContext.User.Where(u => u.UserId == id).FirstOrDefaultAsync();
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while getting user by ID: {ex.Message}", ex);
            }
        }

        public async Task<bool> CheckUserExist(string username)
        {
            try
            {
                var accounts = await _dBContext.Account.Where(u => u.Username == username).FirstOrDefaultAsync();
                var existingAccount = await _dBContext.User.Where(u => u.UserId == accounts.UserId).FirstOrDefaultAsync();
                return existingAccount != null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while checking if user exists: {ex.Message}", ex);
            }
        }

        public async Task UpdateUser(UsersDTO updatedUser)
        {
            try
            {
                var existingUser = await _dBContext.User.Where(u => u.UserId == updatedUser.UserId).FirstOrDefaultAsync();
                if (existingUser == null)
                {
                    throw new Exception("User not found");
                }
                existingUser.FullName = updatedUser.FullName;
                existingUser.ImageUser = updatedUser.ImageUser;
                existingUser.Email = updatedUser.Email;
                existingUser.DateOfBirth = updatedUser.DateOfBirth;
                existingUser.Gender = updatedUser.Gender;
                existingUser.Phone = updatedUser.Phone;
                existingUser.National = updatedUser.National;
                _dBContext.User.Update(existingUser);
                await _dBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while updating user: {ex.Message}", ex);
            }
        }
    }
}
