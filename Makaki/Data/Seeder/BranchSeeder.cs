using System.Collections.Generic;
using Makaki.Model;

namespace Makaki.Data.Seeder
{
    public class BranchSeeder : ISeeder
    {
        public void Seed(DatabaseContext context)
        {
            var list = new List<Branch>()
            {
                new Branch() { Name = "Sarajevo-1", Description = "Sve je isto ko i lani"},
                new Branch() { Name = "Sarajevo-2"},
                new Branch() { Name = "Sarajevo-3"},
                new Branch() { Name = "Mostar"},
            };

            context.Branches.AddRange(list);
        }
    }
}
