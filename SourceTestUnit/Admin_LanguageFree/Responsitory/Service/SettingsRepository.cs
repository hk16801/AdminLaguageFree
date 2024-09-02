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
    public class SettingsRepository : SettingsIRepository
    {
        private readonly SettingsDAO _settingsDAO;

        public SettingsRepository(SettingsDAO settingsDAO)
        {
            _settingsDAO = settingsDAO;
        }
        public Task NewSettings(SettingsDTO settings)
        {
            return _settingsDAO.AddSettings(settings);
        }
        public Task<Settings> GetSettings(int userId)
        {
            return _settingsDAO.GetSettings(userId);
        }
    }
}
