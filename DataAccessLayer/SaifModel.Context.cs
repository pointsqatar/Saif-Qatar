﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SaifDatabaseEntities : DbContext
    {
        public SaifDatabaseEntities()
            : base("name=SaifDatabaseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AboutU> AboutUs { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<AdminLogin> AdminLogins { get; set; }
        public virtual DbSet<Certificate> Certificates { get; set; }
        public virtual DbSet<CompanyProfile> CompanyProfiles { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Gallery> Galleries { get; set; }
        public virtual DbSet<HomeCarousel> HomeCarousels { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<ProductCatalogue> ProductCatalogues { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Testimonial> Testimonials { get; set; }
    }
}