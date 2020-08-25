using System;
using System.Collections.Generic;

#nullable disable

namespace AutoMapperOdata.Models
{
    public partial class CommentComp
    {
        public int Id { get; set; }
        public int Inn { get; set; }
        public int? CommentId { get; set; }
        public int? ContactId { get; set; }

        public virtual Comment Comment { get; set; }
        public virtual ContactInfo Contact { get; set; }
        public virtual ClientRef InnNavigation { get; set; }
    }
}
