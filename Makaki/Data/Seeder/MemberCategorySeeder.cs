using System.Collections.Generic;
using Makaki.Model;

namespace Makaki.Data.Seeder
{
    public class MemberCategorySeeder : ISeeder
    {
        public void Seed(DatabaseContext context)
        {
            var list = new List<MemberCategory>()
            {
                new MemberCategory() { Name = "Seniori" },
                new MemberCategory() { Name = "Kadeti" },
                new MemberCategory() { Name = "Juniori" }
            };

            context.MemberCategories.AddRange(list);
        }
    }
}
