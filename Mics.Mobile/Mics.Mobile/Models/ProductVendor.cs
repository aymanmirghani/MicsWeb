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
    public partial class ProductVendor
    {
        [Key]
        public int ID { get; set; }
        public int ProductID { get; set; }
        public int VendorID { get; set; }
        public int AverageLeadTime { get; set; }
        public decimal StandardPrice { get; set; }
        public Nullable<decimal> LastReceiptCost { get; set; }
        public Nullable<System.DateTime> LastReceiptDate { get; set; }
        public int MinOrderQty { get; set; }
        public int MaxOrderQty { get; set; }
        public Nullable<int> OnOrderQty { get; set; }
        public string UnitMeasureCode { get; set; }
        public System.DateTime ModifiedDate { get; set; }
    }
}
