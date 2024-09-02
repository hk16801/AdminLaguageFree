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
    public class RolesDAO
    {
        private readonly DBContext _dBContext;
        public Roles rl { get; set; } = new Roles();

        public RolesDAO(DBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task AddRoles(RolesDTO roles)
        {
            try
            {
                if (roles == null)
                {
                    throw new ArgumentNullException(nameof(roles), "RolesDTO cannot be null.");
                }

                rl.RoleName = roles.RoleName;

                _dBContext.Role.Add(rl);
                await _dBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while adding role: {ex.Message}", ex);
            }
        }

        public async Task<List<Roles>> GetAllRoles()
        {
            try
            {
                var roles = await _dBContext.Role.ToListAsync();
                return roles;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while getting all roles: {ex.Message}", ex);
            }
        }

        //public async Task<bool> UpdateRole(int id, RolesDTO roles)
        //{
        //    try
        //    {
        //        var existingRole = await _dBContext.Role.FindAsync(id);

        //        if (existingRole == null)
        //            return false;

        //        existingRole.RoleName = roles.RoleName;

        //        await _dBContext.SaveChangesAsync();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception($"Error occurred while updating role: {ex.Message}", ex);
        //    }
        //}
    }
}
