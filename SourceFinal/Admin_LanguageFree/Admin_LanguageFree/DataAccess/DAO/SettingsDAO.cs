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
            var existingSetting = await _dBContext.Setting.Where(s => s.UserId == settings.UserId).FirstOrDefaultAsync();
            if (existingSetting != null)
            {
                existingSetting.UiLanguagePreference = settings.UiLanguagePreference;
                existingSetting.TranslationLanguageFrom = settings.TranslationLanguageFrom;
                existingSetting.TranslationLanguageTo = settings.TranslationLanguageTo;
                existingSetting.ConversationLanguageFrom = settings.ConversationLanguageFrom;
                existingSetting.ConversationLanguageTo = settings.ConversationLanguageTo;
                existingSetting.PictureLangTo = settings.PictureLangTo;
                _dBContext.Setting.Update(existingSetting);
            }
            else
            {
                st.UserId = settings.UserId;
                st.UiLanguagePreference = settings.UiLanguagePreference;
                st.TranslationLanguageFrom = settings.TranslationLanguageFrom;
                st.TranslationLanguageTo = settings.TranslationLanguageTo;
                st.ConversationLanguageFrom = settings.ConversationLanguageFrom;
                st.ConversationLanguageTo = settings.ConversationLanguageTo;
                st.PictureLangTo = settings.PictureLangTo;
                _dBContext.Setting.Add(st);
            }
            await _dBContext.SaveChangesAsync();
        }

        public async Task<Settings> GetSettings(int userId)
        {
            try
            {
                var settings = await _dBContext.Setting
                .Where(s => s.UserId == userId)
                .OrderByDescending(s => s.SettingId)
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
