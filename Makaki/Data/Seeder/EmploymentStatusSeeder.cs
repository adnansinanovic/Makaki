using System.Collections.Generic;
using Makaki.Model;

namespace Makaki.Data.Seeder
{
    public class EmploymentStatusSeeder : ISeeder
    {
        public void Seed(DatabaseContext context)
        {
            var statuses = new List<EmploymentStatus>
            {
                new EmploymentStatus { Name = "Zaposlen" },
                new EmploymentStatus { Name = "Penzioner"},
                new EmploymentStatus { Name = "Student"},                
                new EmploymentStatus { Name = "Učenik" },
                new EmploymentStatus { Name = "Nezaposlen" },                
            };

            context.EmploymentStatuses.AddRange(statuses);
        }
    }
}
