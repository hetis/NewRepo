using Microsoft.AspNet.OData.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace DTOs.RequestModels
{
    //[DataContract]
    public class ContactInfoContract
    {
        public ContactInfoContract()
        {
            ContactComments = new List<CommentContract>();
        }
        [Key]
        [IgnoreDataMember]
        public int? Id { get; set; }

        //[DataMember(Name = "type")]
        public int Type { get; set; }

        //[DataMember(Name = "value")]
        public string Value { get; set; }

        //[DataMember(Name = "contactComments")]
        public List<CommentContract> ContactComments { get; set; }
    }
}
