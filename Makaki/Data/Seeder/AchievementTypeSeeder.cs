using System.Collections.Generic;
using Makaki.Model;

namespace Makaki.Data.Seeder
{
    public class AchievementTypeSeeder : ISeeder
    {
        public void Seed(DatabaseContext context)
        {
            var list = new List<AchievementType>()
            {
                new AchievementType() {  Name = "Nagrada"},
                new AchievementType() {  Name = "Medalja"},
                new AchievementType() {  Name = "Plaketa"},
                new AchievementType() {  Name = "Pohvalnica"},
                new AchievementType() {  Name = "Priznanje"},
                new AchievementType() {  Name = "Zahvalnica"}
            };

            context.AchievementTypes.AddRange(list);

        }
    }
}
