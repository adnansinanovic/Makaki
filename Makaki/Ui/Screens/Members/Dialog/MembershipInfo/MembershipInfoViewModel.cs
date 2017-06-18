using System;
using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using Makaki.Data;
using Makaki.Model;

namespace Makaki.Ui.Screens.Members.Dialog.MembershipInfo
{
    public class MembershipInfoViewModel : ObservableObject
    {
        private readonly Member _member;

        public MembershipInfoViewModel(Member member)
        {
            _member = member;
            using (UnitOfWork uof = new UnitOfWork())
            {
                Branches = new ObservableCollection<Branch>(uof.Repository<Branch>().Get().ToList());
                MemberFunctions = new ObservableCollection<MemberFunction>(uof.Repository<MemberFunction>().Get().OrderBy(x => x.Name).ToList());
                AffiliationFeeTypes = new ObservableCollection<AffiliationFeeType>(uof.Repository<AffiliationFeeType>().Get().OrderBy(x => x.Name).ToList());
                Sections = new ObservableCollection<Section>(uof.Repository<Section>().Get().OrderBy(x => x.Name).ToList());
                MemberCategories = new ObservableCollection<MemberCategory>(uof.Repository<MemberCategory>().Get().OrderBy(x => x.Name).ToList());
                Coaches = new ObservableCollection<Coach>(uof.Repository<Coach>().Get().ToList());
            }
        }     

        #region Member Categories
        public ObservableCollection<MemberCategory> MemberCategories { get; set; }

        public MemberCategory MemberCategory
        {
            get { return _member.MemberCategory; }

            set
            {
                if (_member.MemberCategory == value)
                    return;

                _member.MemberCategory = value;
                RaisePropertyChanged(nameof(MemberCategory));
            }
        }

        public int? MemberCategoryId
        {
            get { return _member.MemberCategoryId; }

            set
            {
                if (_member.MemberCategoryId == value)
                    return;

                _member.MemberCategoryId = value;
                RaisePropertyChanged(nameof(MemberCategoryId));
            }
        }
        #endregion

        #region Sections
        public ObservableCollection<Section> Sections { get; set; }
  
        public Section Section
        {
            get { return _member.Section; }

            set
            {
                if (_member.Section == value)
                    return;

                _member.Section = value;
                RaisePropertyChanged(nameof(Section));
            }
        }

        public int? SectionId
        {
            get { return _member.SectionId; }

            set
            {
                if (_member.SectionId == value)
                    return;

                _member.SectionId = value;
                RaisePropertyChanged(nameof(SectionId));
            }
        }
        #endregion

        #region Affilation Type
        public ObservableCollection<AffiliationFeeType> AffiliationFeeTypes { get; set; }

        public AffiliationFeeType AffiliationFeeType
        {
            get { return _member.AffiliationFeeType; }

            set
            {
                if (_member.AffiliationFeeType == value)
                    return;

                _member.AffiliationFeeType = value;
                RaisePropertyChanged(nameof(AffiliationFeeType));
            }
        }

        public int? AffiliationFeeTypeId
        {
            get { return _member.AffiliationFeeTypeId; }

            set
            {
                if (_member.AffiliationFeeTypeId == value)
                    return;

                _member.AffiliationFeeTypeId = value;
                RaisePropertyChanged(nameof(AffiliationFeeTypeId));
            }
        }

        #endregion
        
        #region Member Function
        public ObservableCollection<MemberFunction> MemberFunctions { get; set; }

        public MemberFunction MemberFunction
        {
            get { return _member.MemberFunction; }

            set
            {
                if (_member.MemberFunction == value)
                    return;

                _member.MemberFunction = value;
                RaisePropertyChanged(nameof(MemberFunction));
            }
        }

        public int? MemberFunctionId
        {
            get { return _member.MemberFunctionId; }

            set
            {
                if (_member.MemberFunctionId == value)
                    return;

                _member.MemberFunctionId = value;
                RaisePropertyChanged(nameof(MemberFunctionId));
            }
        } 
        #endregion

        #region Branches
        public ObservableCollection<Branch> Branches { get; set; }

        public Branch Branch
        {
            get { return _member.Branch; }

            set
            {
                if (_member.Branch == value)
                    return;

                _member.Branch = value;
                RaisePropertyChanged(nameof(Branch));
            }
        }

        public int? BranchId
        {
            get { return _member.BranchId; }

            set
            {
                if (_member.BranchId == value)
                    return;

                _member.BranchId = value;
                RaisePropertyChanged(nameof(BranchId));
            }
        }
        #endregion

        #region Coaches
        public ObservableCollection<Coach> Coaches { get; set; }

        public Coach Coach
        {
            get { return _member.Coach; }

            set
            {
                if (_member.Coach == value)
                    return;

                _member.Coach = value;
                RaisePropertyChanged(nameof(Coach));
            }
        }

        public int? CoachId
        {
            get { return _member.CoachId; }

            set
            {
                if (_member.CoachId == value)
                    return;

                _member.CoachId = value;
                RaisePropertyChanged(nameof(CoachId));
            }
        } 
        #endregion

        public DateTime? JoinDate
        {
            get { return _member.JoinDate; }
            set
            {
                if (_member.JoinDate == value)
                    return;

                _member.JoinDate = value;
                RaisePropertyChanged(nameof(JoinDate));
            }
        }

        public DateTime? UnjoinDate
        {
            get { return _member.UnjoinDate; }
            set
            {
                if (_member.UnjoinDate == value)
                    return;

                _member.UnjoinDate = value;
                RaisePropertyChanged(nameof(UnjoinDate));
            }
        }
        
        public string UnjoinReason
        {
            get { return _member.UnjoinReason; }
            set
            {
                if (_member.UnjoinReason == value)
                    return;

                _member.UnjoinReason = value;
                RaisePropertyChanged(nameof(UnjoinReason));
            }
        }

        public string CardNumber
        {
            get { return _member.CardNumber; }
            set
            {
                if (_member.CardNumber == value)
                    return;

                _member.CardNumber = value;
                RaisePropertyChanged(nameof(CardNumber));
            }
        }

        public string AssociationRegistrationNumber
        {
            get { return _member.AssociationRegistrationNumber; }
            set
            {
                if (_member.AssociationRegistrationNumber == value)
                    return;

                _member.AssociationRegistrationNumber = value;
                RaisePropertyChanged(nameof(AssociationRegistrationNumber));
            }
        }
    }
}
