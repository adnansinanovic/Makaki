using System.Collections.Generic;
using System.Linq;
using Makaki.Model;

namespace Makaki.Data.Seeder
{
    public class AddressSeeder : ISeeder
    {
        public void Seed(DatabaseContext context)
        {

            City sarajevo = context.Cities.First(x => x.Name == "Sarajevo");
            City mostar = context.Cities.First(x => x.Name == "Mostar");         

            var addresses = new List<Address>()
            {
                new Address { AddressLine1 = "Hamida Vuka 35", AddressLine2 = string.Empty, ZipCode = "71000", City = sarajevo},
                new Address { AddressLine1 = "Ferde Hauptmana 23", AddressLine2 = string.Empty, ZipCode = "71000", City = sarajevo},
                new Address { AddressLine1 = "Kolodvorska 11/45", AddressLine2 = string.Empty, ZipCode = "71000", City = sarajevo},
                new Address { AddressLine1 = "Zmaja od Bosne 88", AddressLine2 = string.Empty, ZipCode = "71000", City = sarajevo},
                new Address { AddressLine1 = "Grbavička 1", AddressLine2 = string.Empty, ZipCode = "71000", City = sarajevo},

                new Address { AddressLine1 = "Ulica braće Fejića 1", AddressLine2 = string.Empty, ZipCode = "88000", City = mostar},
                new Address { AddressLine1 = "Maršala Tita 96", AddressLine2 = string.Empty, ZipCode = "88000", City = mostar},
                new Address { AddressLine1 = "Adema Buća 71", AddressLine2 = string.Empty, ZipCode = "88000", City = mostar},                
            };


            context.Addresses.AddRange(addresses);

        }
    }
}
