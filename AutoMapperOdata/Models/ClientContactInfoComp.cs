using System;
using System.Collections.Generic;

#nullable disable

namespace AutoMapperOdata.Models
{
    public partial class ClientContactInfoComp
    {
        public int Id { get; set; }
        public int Inn { get; set; }
        public int ContactInfoId { get; set; }
        public int? Point { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        public virtual ContactInfo ContactInfo { get; set; }
        public virtual ClientRef InnNavigation { get; set; }
    }
}
