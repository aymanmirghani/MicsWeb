//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mics.Web.Api
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class SalesPerson_view
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        [Key]
        public int SalesPersonID { get; set; }
        public decimal Bonus { get; set; }
        public Nullable<decimal> SalesQuota { get; set; }
        public decimal CommissionPct { get; set; }
    }
}
