using System;
using System.Collections.Generic;

#nullable disable

namespace AutoMapperOdata.Models
{
    public partial class Tag
    {
        public int Id { get; set; }
        public int? TagId { get; set; }
        public Guid? ObjectIdentifier { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public int? QualityPoint { get; set; }
        public string ObjectIdentifierSourceType { get; set; }
    }
}
