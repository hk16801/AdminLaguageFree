using BusinessObject.DTO;
using BusinessObject.Model;
using DataAccess.DAO;
using Reponsitory.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reponsitory.Service
{
    public class RolesRepository : RolesIRepository
    {
        private readonly RolesDAO _rolesDAO;

        public RolesRepository(RolesDAO rolesDAO)
        {
            _rolesDAO = rolesDAO;
        }
        public Task NewRoles(RolesDTO roles)
        {
            return _rolesDAO.AddRoles(roles);
        }
        public Task<List<Roles>> GetAllRoles()
        {
            return _rolesDAO.GetAllRoles();
        }

        public Task<bool> UpdateRole(int id, RolesDTO roles)
        {
            return _rolesDAO.UpdateRole(id, roles);
        }
    }
}
