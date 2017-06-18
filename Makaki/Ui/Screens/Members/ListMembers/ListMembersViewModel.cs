using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Makaki.Data;
using Makaki.Model;

namespace Makaki.Ui.Screens.Members.ListMembers
{
    public class ListMembersViewModel : ObservableObject
    {
        public RelayCommand BindCommand { get; set; }

        private ObservableCollection<Member> _members;
        private Member _selectedMember;
        
        public ListMembersViewModel()
        {

            BindCommand = new RelayCommand(BindCommandExecute);
            
            BindCommandExecute();
        }

        private void BindCommandExecute()
        {            
            using (UnitOfWork context = new UnitOfWork())
            {

                Members = new ObservableCollection<Member>(context.Repository<Member>()
                    .Get(includeProperties: $"{nameof(Member.Address)}, " +
                                              $"{nameof(Member.Address)}.{nameof(Address.City)}, " +
                                              $"{nameof(Member.EmploymentStatus)}, " +
                                              $"{nameof(Member.MembershipType)}, " +
                                              $"{nameof(Member.MemberCategory)}, " +
                                              $"{nameof(Member.Guardian)}, " +
                                              $"{nameof(Member.MemberFunction)}, " +
                                              $"{nameof(Member.Section)}, " +
                                              $"{nameof(Member.AffiliationFeeType)}, " +
                                              $"{nameof(Member.Coach)}, " +
                                              $"{nameof(Member.Branch)}")
                    .ToList());                                
            }                     
            
            
        }

        public ObservableCollection<Member> Members
        {
            get { return _members; }
            set
            {
                if (_members == value)
                    return;

                _members = value;
                RaisePropertyChanged(nameof(Members));
            }
        }

        public Member SelectedMember
        {
            get { return _selectedMember; }
            set
            {
                if (_selectedMember == value)
                    return;

                _selectedMember = value;                
                RaisePropertyChanged(nameof(SelectedMember));

                Messenger.Default.Send(SelectedMember);
            }
        }
    }
}
