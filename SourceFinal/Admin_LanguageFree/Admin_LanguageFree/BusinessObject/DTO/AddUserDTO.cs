﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO
{
    public class AddUserDTO
    {
        public ImageUploadModel UploadModel { get; set; }
        public UserTempDTO UserTempDTO { get; set; }
    }
}
