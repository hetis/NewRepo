using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace DTOs.RequestModels
{
    [DataContract]
    
    public class ClientInfoContract
    {
        public ClientInfoContract()
        {
            Clients = new List<ClientContract>();
        }

        [DataMember(Name = "source")]
        public SourceType Source { get; set; }

        [DataMember(Name = "responsiblePerson")]
        public string ResponsiblePerson { get; set; }

        [DataMember(Name = "clients")]
        public List<ClientContract> Clients { get; set; }
    }

    public enum SourceType
    {
        CRM = 0,
        IMS = 1,
        UNIVERSALE = 2
    }
}
