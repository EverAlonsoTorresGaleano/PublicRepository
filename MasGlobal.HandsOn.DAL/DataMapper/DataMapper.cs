using MasGlobal.HandsOn.Model.Entities;
using System.Data.Entity;

namespace MasGlobal.HandsOn.DAL.DataMapper
{
    public partial class DataMapper : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        public DataMapper()
            : base("name=MasGlobalConnectionString")
        {
            Configuration.LazyLoadingEnabled = true;
            //Database.SetInitializer<DataMapper>(null); //new MySqlInitializer());
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<DocumentType> DocumentTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DocumentType>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.DocumentType)
                .HasForeignKey(e => e.DocumentTypeFk);
             
        }

    }

}
