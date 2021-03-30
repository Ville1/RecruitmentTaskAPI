﻿using System;
using System.Collections.Generic;

namespace RecruitmentTaskAPI.Data
{
    [Serializable]
    public class EmailData
    {
        public string Key { get; set; }
        public string Email { get; set; }
        public List<string> Attributes  { get; set; }
    }
}
