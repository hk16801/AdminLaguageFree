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
    public class RatesRepository : RatesIRepository
    {
        private readonly RatesDAO _ratesDAO;

        public RatesRepository(RatesDAO ratesDAO)
        {
            _ratesDAO = ratesDAO;
        }
        public Task NewRates(RatesDTO rates)
        {
            return _ratesDAO.AddRates(rates);
        }
        public Task<List<Rates>> GetAllRates()
        {
            return _ratesDAO.GetAllRates();
        }
        public async Task<bool> CanRate(int userId)
        {
            return await _ratesDAO.CanUserRate(userId);
        }
    }
}
