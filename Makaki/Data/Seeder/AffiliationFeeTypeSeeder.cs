using System.Collections.Generic;
using System.Windows.Documents;
using Makaki.Model;

namespace Makaki.Data.Seeder
{
    class AffiliationFeeTypeSeeder : ISeeder
    {
        public void Seed(DatabaseContext context)
        {
            var list = new List<AffiliationFeeType>()
            {
                new AffiliationFeeType() { Name = "Djeca i omladina - zelena marka" },
                new AffiliationFeeType() { Name = "Penzioneri - crvena marka" },
                new AffiliationFeeType() { Name = "Senioru - Plava" },
            };

            context.AffiliationFeeTypes.AddRange(list);
        }
    }
}
