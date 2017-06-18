using System.Collections.Generic;
using System.Data.Entity;
using Makaki.Data.Seeder;

namespace Makaki.Data
{
    class DatabaseInitializer : DropCreateDatabaseAlways<DatabaseContext>
    {
        private List<ISeeder> _seeders;

        public override void InitializeDatabase(DatabaseContext context)
        {
            _seeders = new List<ISeeder>
            {
                 new MembershipTypesSeeder(),
                 new MemberFunctionsSeeder(),
                 new EmploymentStatusSeeder(),
                 new MemberCategorySeeder(),
                 new BranchSeeder(),
                 new TransactionMeanSeeder(),
                 new ActivityTypeSeeder(),
                 new AchievementTypeSeeder(),
                 new SectionSeeder(),
                 new AffiliationFeeTypeSeeder(),
                 new CoachSeeder(),

                 new CountrySeeder(),
                 new CitySeeder(),
                 new AddressSeeder(),
                 new GuardianSeeder(),

                 new MemberSeeder(),
                 new ActivitySeeder(),

                 new ActivityParticipantSeeder(),
                 new AchievementSeeder()
             };

            base.InitializeDatabase(context);
        }

        protected override void Seed(DatabaseContext context)
        {
            foreach (ISeeder seeder in _seeders)
            {
                try
                {
                    seeder.Seed(context);
                    context.SaveChanges();
                }
                catch (System.Exception ex)
                {
                    
                }
            }

            base.Seed(context);
        }
    }
}
