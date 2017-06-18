using System.Collections.Generic;
using System.Linq;
using Makaki.Model;


namespace Makaki.Data.Seeder
{
    public class GuardianSeeder : ISeeder
    {
        public void Seed(DatabaseContext context)
        {
            List<Address> addresses = context.Addresses.ToList();

            var list = new List<Guardian>()
            {
                new Guardian() { Address = addresses[0], Email = "guardina@gmail.com", FirstName = "Tom", LastName = "Tomic", MobilePhone = "987-555-333", Phone = "456-444-365", PID = "123456789" },
                new Guardian() { Address = addresses[1], Email = "gerald@gmail.com", FirstName = "Pero", LastName = "Peric", MobilePhone = "987-555-333", Phone = "456-444-365", PID = "123456789" },
                new Guardian() { Address = addresses[2], Email = "darko@gmail.com", FirstName = "Darko", LastName = "Teloman", MobilePhone = "987-555-333", Phone = "456-444-365", PID = "123456789" },
            };

            context.Guardians.AddRange(list);
        }
    }
}
