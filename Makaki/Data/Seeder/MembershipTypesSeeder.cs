using System.Collections.Generic;
using Makaki.Model;

namespace Makaki.Data.Seeder
{
    public class MembershipTypesSeeder : ISeeder
    {
        public void Seed(DatabaseContext context)
        {
            var list = new List<MembershipType>
            {
                new MembershipType {Name = "Redovni član"},
                new MembershipType {Name = "Nominalni član"},
                new MembershipType {Name = "Počasni član"},
                new MembershipType {Name = "Podupirući član"}
            };

            context.MembershipTypes.AddRange(list);
        }
    }
}
