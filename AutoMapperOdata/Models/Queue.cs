using System;
using System.Collections.Generic;

#nullable disable

namespace AutoMapperOdata.Models
{
    public partial class Queue
    {
        public int Id { get; set; }
        public byte TypeOid { get; set; }
        public short SubtypeOid { get; set; }
        public byte Priority { get; set; }
        public short RetryCount { get; set; }
        public byte StatusOid { get; set; }
        public byte SystemOid { get; set; }
        public string Recipient { get; set; }
        public Guid? RelatedObjectId { get; set; }
        public DateTime? ProcessAfter { get; set; }
        public DateTime? LastProcessedOn { get; set; }
        public string LastErrorText { get; set; }
        public string Payload { get; set; }
        public short? Version { get; set; }
        public DateTime CreatedTimestamp { get; set; }
    }
}
