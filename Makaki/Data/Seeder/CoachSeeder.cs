using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Makaki.Model;

namespace Makaki.Data.Seeder
{
    class CoachSeeder : ISeeder
    {
        public void Seed(DatabaseContext context)
        {
            var list = new List<Coach>
            {
                new Coach {Id = 1, Name = "Meha Dule"},
                new Coach {Id= 2, Name = "Garo Suke" },
                new Coach {Id= 3, Name = "Ana Milana"},
                new Coach {Id= 4, Name = "Suke Mujke"},
                new Coach {Id= 4, Name = "Daria Kuzmanov"},
            };


            context.Coaches.AddRange(list);
        }
    }
}
