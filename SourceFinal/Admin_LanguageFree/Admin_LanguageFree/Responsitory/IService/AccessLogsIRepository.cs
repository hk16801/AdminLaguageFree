using BusinessObject.DTO;
using BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reponsitory
{
    public interface AccessLogsIRepository
    {
        Task NewAccessLogs(AccessLogsDTO access);
        Task<List<AccessLogs>> GetAllAccessLogs();
    }
}
