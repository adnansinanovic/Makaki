using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Makaki.Model
{
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ActivityType ActivityType { get; set; }

        public DateTime StartTime { get; set; }
        
        public string Description { get; set; }

        public Boolean? IsCompleted { get; set; }

        public virtual ICollection<ActivityParticipant> MemberActivities { get; set; }
    }
}
