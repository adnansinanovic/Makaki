using System.Collections.Generic;
using Makaki.Model;

namespace Makaki.Data.Seeder
{
    public class CountrySeeder : ISeeder
    {
        public void Seed(DatabaseContext context)
        {
            var list = new List<Country>
            {
                new Country {CountryId = 1, Name = "Bosna i Hercegovina", Abbreviation = "BiH"},
                new Country {CountryId = 2, Name = "Hrvatska", Abbreviation = "Cro"},
                new Country {CountryId = 3, Name = "Srbija", Abbreviation = "Srb"}
            };


            context.Countries.AddRange(list);          
        }
    }
}
