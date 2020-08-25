using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace DTOs.RequestModels
{

    //[DataContract]
    
    public class ClientContract
    {
        public ClientContract()
        {
            ContactsInfo = new List<ContactInfoContract>();
            Documents = new List<DocumentContract>();
            Relations = new List<RelationContract>();
            ClientComment = new List<CommentContract>();
        }

        [DataMember(Name = "INN")]
        [Key]
        public int INN { get; set; }

        [DataMember(Name = "validfrom")]
        public DateTime ValidFrom { get; set; }

        [DataMember(Name = "validto")]
        public DateTime ValidTo { get; set; }

        [DataMember(Name = "clienttype")]
        public ClientType ClientType { get; set; }

        [DataMember(Name = "companyname")]
        public string CompanyName { get; set; }

        [DataMember(Name = "firstname")]
        public string FirstName { get; set; }

        [DataMember(Name = "lastname")]
        public string LastName { get; set; }

        [DataMember(Name = "fathername")]
        public string FatherName { get; set; }

        [DataMember(Name = "pinnumber")]
        public string PinNumber { get; set; }

        [DataMember(Name = "birthdate")]
        public DateTime? BirthDate { get; set; }

        [DataMember(Name = "positioncustom")]
        public string PositionCustom { get; set; }

        [DataMember(Name = "position")]
        public int Position { get; set; }

        [DataMember(Name = "monthlyincome")]
        public decimal MonthlyIncome { get; set; }

        [DataMember(Name = "clientcomments")]
        public List<CommentContract> ClientComment { get; set; }

        [DataMember(Name = "contactsinfo")]
        [ForeignKey("ContactInfoContract")]
        public List<ContactInfoContract> ContactsInfo { get; set; }

        [DataMember(Name = "documents")]
        [ForeignKey("Documents")]
        public List<DocumentContract> Documents { get; set; }

        [DataMember(Name = "relations")]
        public List<RelationContract> Relations { get; set; }

    }

    public enum ClientType
    {
        Pyhsical = 1,
        Company = 2
    }
}
