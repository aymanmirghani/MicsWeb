﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MicsEntities : DbContext
    {
        public MicsEntities()
            : base("name=MicsEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<OrderNumber> OrderNumbers { get; set; }
        public virtual DbSet<OrderStatu> OrderStatus { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductAdjustmentHistory> ProductAdjustmentHistories { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<ProductCostHistory> ProductCostHistories { get; set; }
        public virtual DbSet<ProductInventory> ProductInventories { get; set; }
        public virtual DbSet<ProductListPriceHistory> ProductListPriceHistories { get; set; }
        public virtual DbSet<ProductSubcategory> ProductSubcategories { get; set; }
        public virtual DbSet<ProductVendor> ProductVendors { get; set; }
        public virtual DbSet<PurchaseInvoiceDetail> PurchaseInvoiceDetails { get; set; }
        public virtual DbSet<PurchaseInvoiceHeader> PurchaseInvoiceHeaders { get; set; }
        public virtual DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        public virtual DbSet<PurchaseOrderHeader> PurchaseOrderHeaders { get; set; }
        public virtual DbSet<SalesInvoiceDetail> SalesInvoiceDetails { get; set; }
        public virtual DbSet<SalesInvoiceHeader> SalesInvoiceHeaders { get; set; }
        public virtual DbSet<SalesOrderDetail> SalesOrderDetails { get; set; }
        public virtual DbSet<SalesOrderHeader> SalesOrderHeaders { get; set; }
        public virtual DbSet<SalesPerson> SalesPersons { get; set; }
        public virtual DbSet<SalesTaxRate> SalesTaxRates { get; set; }
        public virtual DbSet<SalesTerritory> SalesTerritories { get; set; }
        public virtual DbSet<SalesTerritoryHistory> SalesTerritoryHistories { get; set; }
        public virtual DbSet<ShipMethod> ShipMethods { get; set; }
        public virtual DbSet<SpecialOffer> SpecialOffers { get; set; }
        public virtual DbSet<SpecialOfferProduct> SpecialOfferProducts { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
        public virtual DbSet<SalesPersonQuotaHistory> SalesPersonQuotaHistories { get; set; }
        public virtual DbSet<Employee_Address_View> Employee_Address_View { get; set; }
        public virtual DbSet<InvoicesBalance_View> InvoicesBalance_View { get; set; }
        public virtual DbSet<SaleOrder_View> SaleOrder_View { get; set; }
        public virtual DbSet<SalesPerson_view> SalesPerson_view { get; set; }
        public virtual DbSet<SalesTerritoryList_View> SalesTerritoryList_View { get; set; }
        public virtual DbSet<CustomerBalanceView> CustomerBalanceViews { get; set; }
        public virtual DbSet<CustomerView> CustomerViews { get; set; }
    }
}
