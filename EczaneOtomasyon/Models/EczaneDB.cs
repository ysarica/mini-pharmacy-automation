namespace EczaneOtomasyon.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EczaneDB : DbContext
    {
        public EczaneDB()
            : base("name=EczaneDB")
        {
        }

        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TBLBolum> TBLBolum { get; set; }
        public virtual DbSet<TBLIlaclar> TBLIlaclar { get; set; }
        public virtual DbSet<TBLKullanici> TBLKullanici { get; set; }
        public virtual DbSet<TBLRecete> TBLRecete { get; set; }
        public virtual DbSet<TBLReceteIlac> TBLReceteIlac { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
