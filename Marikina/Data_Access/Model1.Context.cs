﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Marikina.Data_Access
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class marikinaDBEntities : DbContext
    {
        public marikinaDBEntities()
            : base("name=marikinaDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<announcement> announcements { get; set; }
        public DbSet<banner> banners { get; set; }
        public DbSet<@event> events { get; set; }
        public DbSet<header> headers { get; set; }
        public DbSet<logo> logoes { get; set; }
        public DbSet<official> officials { get; set; }
        public DbSet<role> roles { get; set; }
    }
}
