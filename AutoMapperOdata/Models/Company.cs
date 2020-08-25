﻿using System;
using System.Collections.Generic;

#nullable disable

namespace AutoMapperOdata.Models
{
    public partial class Company
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public int Inn { get; set; }
        public int? CompanyNameQl { get; set; }

        public virtual ClientRef InnNavigation { get; set; }
    }
}
