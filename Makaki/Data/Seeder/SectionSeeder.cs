using System.Collections.Generic;
using Makaki.Model;

namespace Makaki.Data.Seeder
{
    public class SectionSeeder : ISeeder
    {
        public void Seed(DatabaseContext context)
        {
            var list = new List<Section>
            {
                new Section { Name = "Informatička"},
                new Section { Name = "Muzička"},
                new Section { Name = "Likovna"}
            };

            context.Sections.AddRange(list);
        }
    }
}
