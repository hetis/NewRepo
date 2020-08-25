using System;
using System.Collections.Generic;

#nullable disable

namespace AutoMapperOdata.Models
{
    public partial class Comment
    {
        public Comment()
        {
            CommentComps = new HashSet<CommentComp>();
        }

        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime? CreateTimestamp { get; set; }
        public string Creator { get; set; }

        public virtual ICollection<CommentComp> CommentComps { get; set; }
    }
}
