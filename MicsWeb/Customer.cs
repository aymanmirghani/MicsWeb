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
    
    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            this.SalesOrderHeaders = new HashSet<SalesOrderHeader>();
        }
    
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public Nullable<int> AddressID { get; set; }
        public string AccountNumber { get; set; }
        public string Phone { get; set; }
        public string SecondPhone { get; set; }
        public string Fax { get; set; }
        public Nullable<decimal> CreditLimit { get; set; }
        public Nullable<short> DeliveryDay { get; set; }
        public string CustomerType { get; set; }
        public string ContactName { get; set; }
        public string Email { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public Nullable<int> BillingAddressID { get; set; }
        public Nullable<bool> ActiveFlag { get; set; }
    
        public virtual SalesTerritory SalesTerritory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesOrderHeader> SalesOrderHeaders { get; set; }
    }
}
