using System;
using System.Collections.Generic;

#nullable disable

namespace AutoMapperOdata.Models
{
    public partial class Code
    {
        public int Id { get; set; }
        public int TypeOid { get; set; }
        public int CodeOid { get; set; }
        public string Value { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }

        public virtual CodeType TypeO { get; set; }
    }
}
