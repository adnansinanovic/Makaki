using System.Collections.Generic;
using System.Linq;
using Makaki.Model;

namespace Makaki.Data.Seeder
{
    public class AchievementSeeder : ISeeder
    {
        public void Seed(DatabaseContext context)
        {
            List<Member> members = context.Members.ToList();
            List<AchievementType> achievementTypes = context.AchievementTypes.ToList();
            List<string> assignedBy = new List<string> { "John Brown", "Asim Dule", "Milan Pavica", "Redžo Kar", "Anica Dobra", "Dunja Zaklan", "Bego Begajić" };
            List<string> note = new List<string> { "Napomena 123",  "Sedam dana i sedam noći", "Zelena je trava", "Babo ručo", "Nije niko lud da spava", "Bila mama Kukunka"  };
            List<string> name = new List<string> { "Nagrada 1. Maj", "Pohvala Ilije Lije", "Izvanredan uspjeh iz rezbaranja", "Priznanje Drug Tito", "Zeleni mrav" };

            List<Achievement> achievements = new List<Achievement>();
            foreach (Member member in members)
            {
                int count = RandomHelper.Next(0, 3);
                for (int i = 0; i < count; i++)
                {
                    achievements.Add(new Achievement
                    {
                        Member = member,
                        AchievementType = RandomHelper.List(achievementTypes),
                        AssignedBy = RandomHelper.List(assignedBy),
                        AssignedDate = RandomHelper.Date(),
                        Note = RandomHelper.List(note),
                        Name = RandomHelper.List(name)
                    });
                }
            }

            context.Achievements.AddRange(achievements);
        }
    }
}
