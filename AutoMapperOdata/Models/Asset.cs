using System;
using System.Collections.Generic;

#nullable disable

namespace AutoMapperOdata.Models
{
    public partial class Asset
    {
        public int Id { get; set; }
        public Guid? ObjectIdentifier { get; set; }
        public int? ObjectIdentifierSourceType { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public int Inn { get; set; }

        public virtual ClientRef InnNavigation { get; set; }
    }
}
