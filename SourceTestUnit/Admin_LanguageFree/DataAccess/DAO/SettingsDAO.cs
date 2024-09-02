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
    public class SettingsDAO
    {
        private readonly DBContext _dBContext;
        public Settings st { get; set; } = new Settings();
        public SettingsDAO(DBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task AddSettings(SettingsDTO settings)
        {
            try
            {
                if (settings == null)
                {
                    throw new ArgumentNullException(nameof(settings), "SettingsDTO cannot be null.");
                }

                st.UserId = settings.UserId;
                st.TranslationLanguageFrom = settings.TranslationLanguageFrom;
                st.TranslationLanguageTo = settings.TranslationLanguageTo;
                st.UiLanguagePreference = settings.UiLanguagePreference;
                st.ConversationLanguageTo = settings.ConversationLanguageTo;
                st.ConversationLanguageFrom = settings.ConversationLanguageFrom;
                st.PictureLangTo = settings.PictureLangTo;

                _dBContext.Setting.Add(st);
                await _dBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while adding settings: {ex.Message}", ex);
            }
        }

        public async Task<Settings> GetSettings(int userId)
        {
            try
            {
                var settings = await _dBContext.Setting
                .Where(s => s.UserId == userId)
                .OrderByDescending(s => s.SettingId) // Sắp xếp theo thời gian giảm dần
                .FirstOrDefaultAsync(); 
                if (settings == null)
                {
                    throw new Exception($"Error occurred while getting all settings");

                }
                return settings;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while getting all settings: {ex.Message}", ex);
            }
        }

        
    }
}
