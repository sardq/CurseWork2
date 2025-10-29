using DatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseImplement
{
    public class Database : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseNpgsql(@"Host=localhost;Database=ScientificWorks;Username=postgres;Password=postgres");
            }
            base.OnConfiguring(optionsBuilder);

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDataTimeInfinityConversions", true);
        }
        public virtual DbSet<Client> Clients { set; get; }
        public virtual DbSet<Department> Departments { set; get; }
        public virtual DbSet<DepartmentTeacher> DepartmentTeachers { set; get; }
		public virtual DbSet<Grant> Grants { set; get; }
		public virtual DbSet<Order> Orders { set; get; }
        public virtual DbSet<Participant> Participants { set; get; }
        public virtual DbSet<Teacher> Teachers { set; get; }
        public virtual DbSet<ScientificWork> ScientificWorks { set; get; }
	}
}