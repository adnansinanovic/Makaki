using System.Data.Entity;
using Makaki.Model;

namespace Makaki.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("DefaultConnection")
        {
            // Configuration.LazyLoadingEnabled = false;
             Database.SetInitializer(new DatabaseInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActivityParticipant>()
                .HasKey(x => new { x.MemberId, x.ActivityId });

            modelBuilder.Entity<Member>()
                .HasMany(p => p.MemberActivities)
                .WithRequired()
                .HasForeignKey(x => x.MemberId);

            modelBuilder.Entity<Activity>()
                .HasMany(p => p.MemberActivities)
                .WithRequired()
                .HasForeignKey(x => x.ActivityId);

            base.OnModelCreating(modelBuilder);
        }

       public virtual DbSet<MemberCategory> MemberCategories { get; set; }
       public virtual DbSet<MemberFunction> MemberFunctions { get; set; }
       public virtual DbSet<MembershipType> MembershipTypes { get; set; }
       public virtual DbSet<EmploymentStatus> EmploymentStatuses { get; set; }
       public virtual DbSet<TransactionMean> TransactionMeans { get; set; }
       public virtual DbSet<ActivityType> ActivityTypes { get; set; }
       public virtual DbSet<Branch> Branches { get; set; }
       public virtual DbSet<Section> Sections { get; set; }
       public virtual DbSet<Coach> Coaches { get; set; }
       public virtual DbSet<AchievementType> AchievementTypes { get; set; }
       public virtual DbSet<AffiliationFeeType> AffiliationFeeTypes { get; set; }
       public virtual DbSet<City> Cities { get; set; }
       public virtual DbSet<Country> Countries { get; set; }
       public virtual DbSet<Address> Addresses { get; set; }
       public virtual DbSet<Guardian> Guardians { get; set; }
       public virtual DbSet<Member> Members { get; set; }
       public virtual DbSet<Activity> Activities { get; set; }
       public virtual DbSet<ActivityParticipant> ActivityParticipants { get; set; }

       public virtual DbSet<Achievement> Achievements { get; set; }
    }
}
