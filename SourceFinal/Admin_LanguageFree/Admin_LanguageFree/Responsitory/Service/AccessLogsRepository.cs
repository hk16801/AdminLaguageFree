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
    public class AccessLogsRepository : AccessLogsIRepository
    {
        private readonly AccessLogsDAO _accesslogsDAO;

        public AccessLogsRepository(AccessLogsDAO accessLogsDAO)
        {
            _accesslogsDAO = accessLogsDAO;
        }

        public Task NewAccessLogs(AccessLogsDTO access)
        {
            return _accesslogsDAO.AddAccessLogs(access);
        }
        public Task<List<AccessLogs>> GetAllAccessLogs()
        {
            return _accesslogsDAO.GetAllAccessLogs();
        }
    }
}
