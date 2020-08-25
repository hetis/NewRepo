using System;
using System.Collections.Generic;

#nullable disable

namespace AutoMapperOdata.Models
{
    public partial class ClientRelationComp
    {
        public int Id { get; set; }
        public int? Client1 { get; set; }
        public int? Client2 { get; set; }
        public int? RelationId { get; set; }

        public virtual ClientRef Client1Navigation { get; set; }
        public virtual ClientRef Client2Navigation { get; set; }
    }
}
