using System.Collections.Generic;
using Makaki.Model;

namespace Makaki.Data.Seeder
{
    public class MemberFunctionsSeeder : ISeeder
    {
        public void Seed(DatabaseContext context)
        {
            var memberCategories = new List<MemberFunction>
            {
                new MemberFunction {Name = "Predsjednik"},
                new MemberFunction {Name = "Potpredsjednik"},
                new MemberFunction {Name = "Sekretar"},
                new MemberFunction {Name = "Blagajnik"},
                new MemberFunction {Name = "Savjetnik"}
            };

            context.MemberFunctions.AddRange(memberCategories);
        }
    }
}
