using System;
using System.Collections.Generic;

#nullable disable

namespace AutoMapperOdata.Models
{
    public partial class Address
    {
        public int Id { get; set; }
        public int Inn { get; set; }
        public int? CountryId { get; set; }
        public int? RegOrCityId { get; set; }
        public string DistrictOrStreet { get; set; }
        public string AdditionalInfo { get; set; }
        public int? CountryQl { get; set; }
        public int? RegOrCityQl { get; set; }
        public int? DistrictOrStreetQl { get; set; }

        public virtual ClientRef InnNavigation { get; set; }
    }
}
