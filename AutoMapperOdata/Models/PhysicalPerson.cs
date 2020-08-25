﻿using System;
using System.Collections.Generic;

#nullable disable

namespace AutoMapperOdata.Models
{
    public partial class PhysicalPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string FullName { get; set; }
        public string Pin { get; set; }
        public int Inn { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? Position { get; set; }
        public string PositionCustom { get; set; }
        public decimal? MonthlyIncome { get; set; }
        public int? FirstNameQl { get; set; }
        public int? LastNameQl { get; set; }
        public int? FatherNameQl { get; set; }
        public int? FullNameQl { get; set; }
        public int? PinQl { get; set; }
        public int? BirthDateQl { get; set; }
        public int? PositionQl { get; set; }
        public int? MonthlyIncomeQl { get; set; }

        public virtual ClientRef InnNavigation { get; set; }
    }
}
