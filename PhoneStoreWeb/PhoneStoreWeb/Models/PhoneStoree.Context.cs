﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PhoneStoreWeb.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PhoneStoreEntities1 : DbContext
    {
        public PhoneStoreEntities1()
            : base("name=PhoneStoreEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tb_Advertisement> tb_Advertisement { get; set; }
        public virtual DbSet<tb_Contact> tb_Contact { get; set; }
        public virtual DbSet<tb_Menu> tb_Menu { get; set; }
        public virtual DbSet<tb_News> tb_News { get; set; }
        public virtual DbSet<tb_Order> tb_Order { get; set; }
        public virtual DbSet<tb_OrderDetail> tb_OrderDetail { get; set; }
        public virtual DbSet<tb_ProductCategory> tb_ProductCategory { get; set; }
        public virtual DbSet<tb_Subcribe> tb_Subcribe { get; set; }
        public virtual DbSet<tb_SystemSetting> tb_SystemSetting { get; set; }
        public virtual DbSet<tb_Header> tb_Header { get; set; }
        public virtual DbSet<tb_Product> tb_Product { get; set; }
    }
}
