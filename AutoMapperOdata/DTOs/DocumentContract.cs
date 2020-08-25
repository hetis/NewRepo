using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace DTOs.RequestModels
{
    
    public class DocumentContract
    {
        [Key]
        public int Id { get; set; }

        [DataMember(Name = "documentNumber")]
        public string documentNumber { get; set; }

        [DataMember(Name = "documentType")]
        public int documentType { get; set; }

        [DataMember(Name = "documentexpiredate")]
        public DateTime? documentExpireDate { get; set; }
    }
}
