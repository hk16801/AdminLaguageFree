using BusinessObject.DTO;
using BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reponsitory.IService
{
    public interface RolesIRepository
    {
        Task NewRoles(RolesDTO roles);
        Task<List<Roles>> GetAllRoles();
        Task<bool> UpdateRole(int id, RolesDTO roles);
    }
}
