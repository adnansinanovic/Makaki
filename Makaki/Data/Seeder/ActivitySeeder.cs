using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Makaki.Model;

namespace Makaki.Data.Seeder
{
    public class ActivitySeeder : ISeeder
    {
        public void Seed(DatabaseContext context)
        {
            var list = context.ActivityTypes.ToList();

            List<Activity> activities = new List<Activity>()
            {
                new Activity() { Name = "Rujiste 2017", ActivityType = list[0], StartTime = new DateTime(2017,10,5), Description = "Izlet na Rujište sa svim tim ljudima"},
                new Activity() { Name = "LA 2017", ActivityType = list[2], StartTime = new DateTime(2017,7,20), Description = "Prvenstvo Solomonskih otoka u bacanju sira sa jezika"},
                new Activity() { Name = "BUda Buda buda", ActivityType = list[2], StartTime = new DateTime(2018,1,20), Description = "Brzo čitanje, ko može ko ne može"},
                new Activity() { Name = "Ozren-1", ActivityType = list[1], StartTime = new DateTime(2019,1,20), Description = "Pošumljavanje Ozrena sadnicama bora"},
                new Activity() { Name = "Ozren-2", ActivityType = list[1], StartTime = new DateTime(2019,1,23), Description = "Pošumljavanje Ozrena sadnicama bora"},
             };

            context.Activities.AddRange(activities);
        }
    }
}
