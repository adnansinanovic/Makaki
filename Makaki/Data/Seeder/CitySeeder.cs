using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Makaki.Model;

namespace Makaki.Data.Seeder
{
    public class CitySeeder : ISeeder
    {
        public void Seed(DatabaseContext context)
        {
            Country bosnia = context.Countries.First(x => x.Abbreviation == "BiH");
            Country croatia = context.Countries.First(x => x.Abbreviation == "Cro");
            Country serbia = context.Countries.First(x => x.Abbreviation == "Srb");

            var cities = new List<City>
            {
                new City {Country = bosnia, Name = "Sarajevo"},
                new City {Country = bosnia, Name = "Banjaluka"},
                new City {Country = bosnia, Name = "Tuzla"},
                new City {Country = bosnia, Name = "Zenica"},
                new City {Country = bosnia, Name = "Mostar"},
                new City {Country = bosnia, Name = "Doboj"},
                new City {Country = bosnia, Name = "Trebinje"},
                new City {Country = bosnia, Name = "Bugojno"},
                new City {Country = bosnia, Name = "Prijedor"},
                new City {Country = bosnia, Name = "Bijeljina"},
                new City {Country = bosnia, Name = "Travnik"},
                new City {Country = bosnia, Name = "Bihać"},
                new City {Country = croatia, Name = "Zagreb"},
                new City {Country = croatia, Name = "Split"},
                new City {Country = croatia, Name = "Dubrovnik"},
                new City {Country = croatia, Name = "Rijeka"},
                new City {Country = croatia, Name = "Osijek"},
                new City {Country = croatia, Name = "Zadar"},
                new City {Country = croatia, Name = "Šibenik"},
                new City {Country = serbia, Name = "Beograd"},
                new City {Country = serbia, Name = "Novi Sad"},
                new City {Country = serbia, Name = "Niš"},
                new City {Country = serbia, Name = "Kragujevac"}
            };


            DbSet<City> set = context.Set<City>();
            set.AddRange(cities);
        }
    }
}
