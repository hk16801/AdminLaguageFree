using BusinessObject.DTO;
using BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reponsitory.Service
{
    public interface SettingsIRepository
    {
        Task NewSettings(SettingsDTO settings);
        Task<Settings> GetSettings(int userId);
    }
}
