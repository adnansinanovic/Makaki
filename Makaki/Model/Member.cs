using System;
using System.Collections.Generic;

namespace Makaki.Model
{
    public class Member
    {
        public int Id { get; set; }
        /// <summary>
        /// Sifra clana
        /// </summary>
        public string MemberCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        /// <summary>
        /// Personal Identificatin Number
        /// USA = Security Social Number
        /// Bosnia = JMBG
        /// Croatia = OIB
        /// </summary>
        public string PID { get; set; }

        public DateTime? Birthday { get; set; }

        ///// <summary>
        ///// Status clana
        ///// </summary>
        //public string MemberStatus { get; set; }

        /// <summary>
        /// Kategorija clana
        /// </summary>
        public MemberCategory MemberCategory { get; set; }

        public int? MemberCategoryId { get; set; }

        /// <summary>
        /// Datum uclanjenja
        /// </summary>
        public DateTime? JoinDate { get; set; }

        /// <summary>
        /// Datum ispisa
        /// </summary>
        public DateTime? UnjoinDate { get; set; }

        /// <summary>
        /// Razlog ispisa
        /// </summary>
        public string UnjoinReason { get; set; }

        /// <summary>
        /// Vrsta clanarine
        /// </summary>
        public MembershipType MembershipType { get; set; }

        public int? MembershipTypeId { get; set; }

        public Address Address { get; set; }
        public int? AddressId { get; set; }

        public string Phone { get; set; }

        public string MobilePhone { get; set; }

        public string BussinessPhone { get; set; }

        public string Email { get; set; }

        //public string ChekoutReason { get; set; }
        //public string Note1 { get; set; }
        //public string Note2 { get; set; }

        /// <summary>
        /// Broj clanske iskaznice
        /// </summary>
        public string CardNumber { get; set; }

        /// <summary>
        /// Registarski broj udruge
        /// </summary>
        public string AssociationRegistrationNumber { get; set; }

        ///// <summary>
        ///// Registarski broj saveza        
        ///// </summary>
        //public string AllianceRegistrationNumber { get; set; }

        /// <summary>
        /// Status osobe
        /// </summary>
        public EmploymentStatus EmploymentStatus { get; set; }
        public int? EmploymentStatusId { get; set; }

        /// <summary>
        /// Firma ako radi, skola ako studira, vrtic ako je predskolsko
        /// </summary>
        public string EmploymentPlace { get; set; }

        /// <summary>
        /// Zanimanje ako radi, obrazovanje ako je student itd.
        /// </summary>
        public string EmploymentDetails { get; set; }

        /// <summary>
        /// Obavezan ljekarski
        /// </summary>
        public bool RequiredPhysical { get; set; }


        /// <summary>
        /// Zadnji ljekarski pregled
        /// </summary>
        public DateTime? LastPhysical{ get; set; }

        ///// <summary>
        ///// Razred
        ///// </summary>
        //public string Grade { get; set; }

        ///// <summary>
        ///// Strucna sprema
        ///// </summary>
        //public string Education { get; set; }

        ///// <summary>
        ///// Zanimanje
        ///// </summary>
        //public string Title { get; set; }

        /// <summary>
        /// Skrbnik 
        /// </summary>
        public Guardian Guardian { get; set; }
        public int? GuardianId { get; set; }

        ///// <summary>
        ///// Sticenik
        ///// </summary>
        //public bool IsProtege { get; set; }

        //public MemberFunction MemberFunction { get; set; }

        public string Gender { get; set; }
        public Branch Branch { get; set; }
        public int? BranchId { get; set; }

        public Section Section { get; set; }
        public int? SectionId { get; set; }

        public AffiliationFeeType AffiliationFeeType { get; set; }
        public int? AffiliationFeeTypeId { get; set; }

        public MemberFunction MemberFunction { get; set; }
        public int? MemberFunctionId { get; set; }

        public Coach Coach { get; set; }
        public int? CoachId { get; set; }


        public virtual ICollection<ActivityParticipant> MemberActivities { get; set; }

        public virtual ICollection<Achievement> Achievements{ get; set; } = new HashSet<Achievement>();        
    }
}
