﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FLLB.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FLBAdminDevEntities : DbContext
    {
        public FLBAdminDevEntities()
            : base("name=FLBAdminDevEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ShortenURL> ShortenURLs { get; set; }
        public virtual DbSet<UnsubscribeReason> UnsubscribeReasons { get; set; }
        public virtual DbSet<Unsubscription> Unsubscriptions { get; set; }
    }
}