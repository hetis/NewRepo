using System;
using System.Collections.Generic;

#nullable disable

namespace AutoMapperOdata.Models
{
    public partial class ClientRef
    {
        public ClientRef()
        {
            Addresses = new HashSet<Address>();
            Assets = new HashSet<Asset>();
            ClientContactInfoComps = new HashSet<ClientContactInfoComp>();
            ClientRelationCompClient1Navigations = new HashSet<ClientRelationComp>();
            ClientRelationCompClient2Navigations = new HashSet<ClientRelationComp>();
            Clients = new HashSet<Client>();
            CommentComps = new HashSet<CommentComp>();
            Companies = new HashSet<Company>();
            Documents = new HashSet<Document>();
            PhysicalPeople = new HashSet<PhysicalPerson>();
        }

        public int Inn { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Asset> Assets { get; set; }
        public virtual ICollection<ClientContactInfoComp> ClientContactInfoComps { get; set; }
        public virtual ICollection<ClientRelationComp> ClientRelationCompClient1Navigations { get; set; }
        public virtual ICollection<ClientRelationComp> ClientRelationCompClient2Navigations { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<CommentComp> CommentComps { get; set; }
        public virtual ICollection<Company> Companies { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
        public virtual ICollection<PhysicalPerson> PhysicalPeople { get; set; }
    }
}
