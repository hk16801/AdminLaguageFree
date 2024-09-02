using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO
{
    public class UpdateUserDTO
    {
        public ImageUploadModel UploadModel { get; set; }
        public UserTempIdDTO UserTempIdDTO { get; set; }
    }
}
