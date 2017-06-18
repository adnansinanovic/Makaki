using Makaki.Model;
using System.Collections.Generic;

namespace Makaki.Data.Seeder
{
    public class TransactionMeanSeeder : ISeeder
    {
        public void Seed(DatabaseContext context)
        {
            var list = new List<TransactionMean>()
            {
                new TransactionMean() {Name = "Gotovinsko plaćanje"},
                new TransactionMean() {Name = "Uplata na račun"},
            };

            context.TransactionMeans.AddRange(list);
        }
    }
}
