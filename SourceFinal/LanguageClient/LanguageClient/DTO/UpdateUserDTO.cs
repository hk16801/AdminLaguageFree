using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageClient.DTO
{
    public class UpdateUserDTO
    {
        public ImageUploadModel UploadModel { get; set; }
        public UserTempIdDTO UserTempIdDTO { get; set; }
    }
}
