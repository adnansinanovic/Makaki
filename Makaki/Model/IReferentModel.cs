using System.Collections.Generic;

namespace Makaki.Model
{
    public interface IReferentModel
    {        
      int Id { get; set; }
      string Name { get; set; }
      string Description { get; set; }
    }

    /// <summary>
    /// Tip clana
    /// E.g. senior, junior, kadet
    /// </summary>
    public class MemberCategory : IReferentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Member> Members { get; set; } = new List<Member>();
    }
 
    /// <summary>
    /// Predsjednik, tajnik, blagajnik
    /// </summary>
    public class MemberFunction : IReferentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    /// <summary>
    /// Type of membership
    /// Redovni, nominalni, pocasni
    /// </summary>
    public class MembershipType : IReferentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Member> Members { get; set; } = new List<Member>();
    }

    /// <summary>
    /// Status
    /// Zaposlen, Umirovljenik, Nezaposlen, Student
    /// </summary>
    public class EmploymentStatus : IReferentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Member> Members { get; set; } = new List<Member>();
    }

    /// <summary>
    /// Informaticla, likovna, muzicka
    /// </summary>
    public class Section : IReferentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Member> Members { get; set; } = new List<Member>();
    }

    /// <summary>
    /// Priznanja, medalja, pohvala, trofej
    /// </summary>
    public class AchievementType : IReferentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Achievement> Achievements { get; set; } = new List<Achievement>();
    }

    /// <summary>
    /// Tip clanarine
    /// </summary>
    public class AffiliationFeeType : IReferentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Member> Members { get; set; } = new List<Member>();
    }


    /// <summary>
    /// Podruznica
    /// </summary>
    public class Branch : IReferentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Member> Members { get; set; } = new List<Member>();
    }

    /// <summary>
    /// Nacin uplate:
    /// Gotovinsko placanje
    ///  Uplata na racun
    /// </summary>
    public class TransactionMean : IReferentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }


    /// <summary>
    /// Vrsta aktivnosti
    /// Izlet
    /// Radna akcija
    /// </summary>
    public class ActivityType : IReferentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class Coach : IReferentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

}
