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
    
    public partial class SelectPurchaseInvoiceHeadersAll_Result
    {
        public int InvoiceID { get; set; }
        public string InvoiceNumber { get; set; }
        public byte Status { get; set; }
        public int EmployeeID { get; set; }
        public Nullable<int> PurchaseOrderID { get; set; }
        public int VendorID { get; set; }
        public Nullable<System.DateTime> InvoiceDate { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxAmt { get; set; }
        public Nullable<decimal> Freight { get; set; }
        public decimal TotalDue { get; set; }
        public System.DateTime ModifiedDate { get; set; }
    }
}
