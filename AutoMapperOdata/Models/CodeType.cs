using System;
using System.Collections.Generic;

#nullable disable

namespace AutoMapperOdata.Models
{
    public partial class CodeType
    {
        public CodeType()
        {
            Codes = new HashSet<Code>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Code> Codes { get; set; }
    }
}
