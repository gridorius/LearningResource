﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace patternsLearning.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class siteDbEntities1 : DbContext
    {
        public siteDbEntities1()
            : base("name=siteDbEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<category> category { get; set; }
        public virtual DbSet<section> section { get; set; }
        public virtual DbSet<article> article { get; set; }
        public virtual DbSet<base_part> base_part { get; set; }
        public virtual DbSet<sample_part> sample_part { get; set; }
        public virtual DbSet<list_source> list_source { get; set; }
    }
}
