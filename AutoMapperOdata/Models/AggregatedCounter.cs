﻿using System;
using System.Collections.Generic;

#nullable disable

namespace AutoMapperOdata.Models
{
    public partial class AggregatedCounter
    {
        public string Key { get; set; }
        public long Value { get; set; }
        public DateTime? ExpireAt { get; set; }
    }
}
