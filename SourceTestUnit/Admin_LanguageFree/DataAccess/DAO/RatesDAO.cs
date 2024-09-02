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
    public class RatesDAO
    {
        private readonly DBContext _dBContext;
        public Rates r { get; set; } = new Rates();

        public RatesDAO(DBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task AddRates(RatesDTO rates)
        {
            try
            {
                if (rates == null)
                {
                    throw new ArgumentNullException(nameof(rates), "RatesDTO cannot be null.");
                }

                r.UserId = rates.UserId;
                r.RateNum = rates.RateNum;
                r.Location = rates.Location;
                r.Timestamp = DateTime.Now;

                _dBContext.Rate.Add(r);
                await _dBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while adding rates: {ex.Message}", ex);
            }
        }

        public async Task<List<Rates>> GetAllRates()
        {
            try
            {
                var rates = await _dBContext.Rate.ToListAsync();
                return rates;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while getting all rates: {ex.Message}", ex);
            }
        }

        public async Task<bool> CanUserRate(int userId)
        {
            try
            {
                bool userHasRated = await _dBContext.Rate.AnyAsync(r => r.UserId == userId);
                if (!userHasRated)
                {
                    return true;
                }

                DateTime? latestTimestamp = await _dBContext.Rate
                    .Where(r => r.UserId == userId)
                    .MaxAsync(r => (DateTime?)r.Timestamp);

                if (latestTimestamp.HasValue)
                {
                    TimeSpan difference = DateTime.Now - latestTimestamp.Value;
                    return difference.Days >= 10;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while checking if user can rate: {ex.Message}", ex);
            }
        }
    }
}
