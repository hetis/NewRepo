using System;
using System.Collections.Generic;

#nullable disable

namespace AutoMapperOdata.Models
{
    public partial class Naming
    {
        public int Id { get; set; }
        public string DefaultValue { get; set; }
        public int Type { get; set; }
        public string ValueEn { get; set; }
        public string ValueRu { get; set; }
    }
}
