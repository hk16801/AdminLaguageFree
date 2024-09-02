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
    public class TranslationHistorysDAO
    {
        private readonly DBContext _dBContext;
        public TranslationHistorys th { get; set; } = new TranslationHistorys();
        public string tempSrcText { get; set; }
        public string tempTranText { get; set; }

        public TranslationHistorysDAO(DBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task AddTranslationHistorys(TranslationHistorysDTO translation)
        {
            try
            {
                if (translation == null)
                {
                    throw new ArgumentNullException(nameof(translation), "TranslationHistorysDTO cannot be null.");
                }
                    
                th.UserId = translation.UserId;
                th.PageId = translation.PageId;
                th.SourceLanguage = translation.SourceLanguage;
                th.TargetLanguage = translation.TargetLanguage;
                tempSrcText = EncodeString(translation.SourceText);
                th.SourceText = tempSrcText;
                tempTranText = EncodeString(translation.TranslatedText);
                th.TranslatedText = tempTranText;
                th.Location = translation.Location;
                th.Status = "1";
                th.TranslationDate = DateTime.Now;

                _dBContext.TranslationHistory.Add(th);
                await _dBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while adding translation history: {ex.Message}", ex);
            }
        }

        public async Task<List<TranslationHistorys>> GetAllTranslationHistorys(int userId)
        {
            try
            {
                var translationHistorys = await _dBContext.TranslationHistory
                    .Where(th => th.UserId == userId)
                    .ToListAsync();

                foreach (var translationHistory in translationHistorys)
                {
                    tempSrcText = DecodeString(translationHistory.SourceText);
                    translationHistory.SourceText = tempSrcText;
                    tempTranText = DecodeString(translationHistory.TranslatedText);
                    translationHistory.TranslatedText = tempTranText;
                }

                return translationHistorys;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while getting all translation historys: {ex.Message}", ex);
            }
        }
        public async Task<bool> RemoveTranslationHistory(int translationId)
        {
            try
            {
                var translationHistory = await _dBContext.TranslationHistory.FindAsync(translationId);
                if (translationHistory != null)
                {
                    translationHistory.Status = "2";
                    await _dBContext.SaveChangesAsync();

                    return true; 
                }
                else
                {
                    throw new Exception("Favourite not found");     
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Failed to Remove translation history status", ex);
            }
        }


        public static string EncodeString(string input)
        {
            string encodedString = Convert.ToBase64String(Encoding.UTF8.GetBytes(input));

            return encodedString;
        }

        public static string DecodeString(string encodedString)
        {
            try
            {
                byte[] decodedBytes = Convert.FromBase64String(encodedString);
                string decodedString = Encoding.UTF8.GetString(decodedBytes);

                return decodedString;
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}
