﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TDP.Database
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Defect> Defect { get; set; }
        public virtual DbSet<DefectPlace> DefectPlace { get; set; }
        public virtual DbSet<DefectType> DefectType { get; set; }
        public virtual DbSet<Detail> Detail { get; set; }
        public virtual DbSet<DetailSize> DetailSize { get; set; }
        public virtual DbSet<DetailType> DetailType { get; set; }
        public virtual DbSet<ExportLat> ExportLat { get; set; }
        public virtual DbSet<ExportNik> ExportNik { get; set; }
        public virtual DbSet<Forging> Forging { get; set; }
        public virtual DbSet<Sharping> Sharping { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}
