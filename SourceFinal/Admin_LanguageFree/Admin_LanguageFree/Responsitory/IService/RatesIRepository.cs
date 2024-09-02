using BusinessObject.DTO;
using BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reponsitory
{
    public interface RatesIRepository
    {
        Task NewRates(RatesDTO rates);
        Task<List<Rates>> GetAllRates();
        Task<bool> CanRate(int userId);

    }
}
