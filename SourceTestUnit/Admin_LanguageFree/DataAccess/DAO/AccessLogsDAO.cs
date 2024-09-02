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
    public class AccessLogsDAO
    {
        private readonly DBContext _dBContext;
        public AccessLogs al { get; set; } = new AccessLogs();

        public AccessLogsDAO(DBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task AddAccessLogs(AccessLogsDTO access)
        {
            try
            {
                if (access == null)
                {
                    throw new ArgumentNullException(nameof(access), "AccessLogsDTO cannot be null.");
                }

                al.PageId = access.PageId;
                al.UserId = access.UserId;
                al.Location = access.Location;
                al.Timestamp = DateTime.Now;

                if (al.PageId == null || al.UserId == null || al.Location == null)
                {
                    throw new InvalidOperationException("AccessLogsDTO properties cannot be null.");
                }

                _dBContext.AccessLog.Add(al);
                await _dBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                throw new InvalidOperationException("AccessLogsDTO exception.");
            }
        }

        public async Task<List<AccessLogs>> GetAllAccessLogs()
        {
            try
            {
                var accessLogs = await _dBContext.AccessLog.ToListAsync();
                return accessLogs;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                throw new InvalidOperationException("AccessLogsDTO exception.");
            }
        }
    }
}
