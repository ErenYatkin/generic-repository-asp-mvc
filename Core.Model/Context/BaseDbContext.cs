using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Core.Model.Context
{
    public class BaseDbContext : DbContext
    {
        //string _connectionString = @"
        //                               Server=(localdb)/mssqllocaldb;
        //                               Database=MyDatabase;
        //                               Integrated Security=true;";

        
        public BaseDbContext(string ConName) 
            : base(ConName)
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public BaseDbContext() :base("nameOrConnectionString")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
