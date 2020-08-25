using System;
using System.Collections.Generic;

#nullable disable

namespace AutoMapperOdata.Models
{
    public partial class Relation
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Reverse { get; set; }
        public int? TagId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}
