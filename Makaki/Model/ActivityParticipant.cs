using System;

namespace Makaki.Model
{
    public class ActivityParticipant
    {
        public virtual int MemberId { get; set; }
        public virtual int ActivityId { get; set; }
        public virtual Member Member { get; set; }
        public virtual Activity Activity { get; set; }

        public virtual DateTime RegistrationDate { get; set; }
        public virtual string Note { get; set; }

    }
}
