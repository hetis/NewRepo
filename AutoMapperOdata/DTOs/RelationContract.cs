using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace DTOs.RequestModels
{
    public class RelationContract
    {
        [DataMember(Name = "clientinn")]
        [Key]
        public int ClientINN { get; set; }

        [DataMember(Name = "relationType")]
        public int RelationType { get; set; }
    }
}
