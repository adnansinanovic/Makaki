using System.Collections.Generic;
using Makaki.Model;

namespace Makaki.Data.Seeder
{
    public class ActivityTypeSeeder : ISeeder
    {
        public void Seed(DatabaseContext context)
        {
            var list = new List<ActivityType>
            {                
                new ActivityType() { Name = "Izlet"},
                new ActivityType() { Name = "Radna akcija"},
                new ActivityType() { Name = "Takmičenje"},
            };

            context.ActivityTypes.AddRange(list);
        }
    }
}