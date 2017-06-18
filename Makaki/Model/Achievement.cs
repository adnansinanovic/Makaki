using System;

namespace Makaki.Model
{
    public class Achievement
    {
        public int Id { get; set; }
        public int? MemberId { get; set; }
        public virtual Member Member { get; set; }
        public int? AchievementTypeId { get; set; }
        public virtual AchievementType AchievementType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public DateTime? AssignedDate { get; set; }
        public string AssignedBy { get; set; }
    }
}
