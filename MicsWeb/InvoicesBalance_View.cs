//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MicsWeb
{
    using System;
    using System.Collections.Generic;
    
    public partial class InvoicesBalance_View
    {
        public Nullable<int> InvoiceID { get; set; }
        public int CustomerID { get; set; }
        public string InvoiceNumber { get; set; }
        public Nullable<System.DateTime> InvoiceDate { get; set; }
        public Nullable<decimal> InvoiceTotal { get; set; }
        public Nullable<decimal> TotalPayments { get; set; }
        public Nullable<decimal> Balance { get; set; }
    }
}
