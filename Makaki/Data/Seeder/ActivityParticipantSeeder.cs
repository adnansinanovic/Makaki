using System;
using System.Collections.Generic;
using System.Linq;
using Makaki.Model;

namespace Makaki.Data.Seeder
{
    public class ActivityParticipantSeeder : ISeeder
    {
        private readonly Random _random = new Random();

        public void Seed(DatabaseContext context)
        {
            List<Member> members = context.Members.ToList();
            List<Activity> activities = context.Activities.ToList();
            List<ActivityParticipant> participants = new List<ActivityParticipant>();

            foreach (var activity in activities)
            {
                List<Member> porticipantCandidates = new List<Member>(members);
                int participantCount = _random.Next(5, 20);                

                for (int i = 0; i < participantCount; i++)
                {
                    Member member = GetRandom(porticipantCandidates);
                    participants.Add(new ActivityParticipant()
                    {
                        Activity = activity,
                        Member = member,
                        ActivityId = activity.Id,
                        MemberId = member.Id,
                        RegistrationDate = DateTime.Today
                    });

                    porticipantCandidates.Remove(member);
                }
            }

            context.ActivityParticipants.AddRange(participants);
        }

        private Member GetRandom(List<Member> members)
        {
            int rnd = _random.Next(0, members.Count);
            return members[rnd];
        }
    }
}
