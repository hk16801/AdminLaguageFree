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
    public class LanguageLogsDAO
    {
        private readonly DBContext _dBContext;
        public LanguageLogs lg { get; set; } = new LanguageLogs();

        public LanguageLogsDAO(DBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task AddLanguageLogs(LanguageLogsDTO languagelogs)
        {
            try
            {
                if (languagelogs == null)
                {
                    throw new ArgumentNullException(nameof(languagelogs), "LanguageLogsDTO cannot be null.");
                }

                lg.UserId = languagelogs.UserId;
                lg.PageId = languagelogs.PageId;
                lg.Location = languagelogs.Location;
                lg.LanguageTarget = languagelogs.LanguageTarget;
                lg.FromOrTo = languagelogs.FromOrTo;
                lg.Timestamp = DateTime.Now;

                _dBContext.LanguageLog.Add(lg);
                await _dBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while adding language logs: {ex.Message}", ex);
            }
        }

        //public async Task<bool> UpdateLanguageLogs(int id, LanguageLogsDTO languagelogs)
        //{
        //    try
        //    {
        //        var existingLog = await _dBContext.LanguageLog.FindAsync(id);

        //        if (existingLog == null)
        //            return false;

        //        existingLog.UserId = languagelogs.UserId;
        //        existingLog.PageId = languagelogs.PageId;
        //        existingLog.Location = languagelogs.Location;
        //        existingLog.LanguageTarget = languagelogs.LanguageTarget;
        //        existingLog.FromOrTo = languagelogs.FromOrTo;
        //        existingLog.Timestamp = DateTime.Now;
        //        await _dBContext.SaveChangesAsync();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception($"Error occurred while updating language logs: {ex.Message}", ex);
        //    }
        //}

        public async Task<List<LanguageLogs>> GetAllLanguageLogs()
        {
            try
            {
                var logs = await _dBContext.LanguageLog.ToListAsync();
                return logs;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while getting all language logs: {ex.Message}", ex);
            }
        }
    }
}
