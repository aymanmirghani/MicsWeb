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
    public partial class Payment
    {
        [Key]
        public int PaymentID { get; set; }
        public Nullable<int> InvoiceID { get; set; }
        public string PaymentType { get; set; }
        public System.DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public string Comments { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public string CheckNumber { get; set; }
    }
}
