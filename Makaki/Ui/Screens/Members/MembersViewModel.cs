using System;
using System.Collections.ObjectModel;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Makaki.Model;
using Makaki.Ui.Screens.Members.Bottom.AchievementInfo;
using Makaki.Ui.Screens.Members.Bottom.ActivitiesInfo;
using Makaki.Ui.Screens.Members.Bottom.BasicInfo;
using Makaki.Ui.Screens.Members.Dialog;
using Makaki.Ui.Screens.Members.ListMembers;
using Makaki.Ui.Screens.ReferentDialog;

namespace Makaki.Ui.Screens.Members
{
    public class MembersViewModel : ObservableObject
    {
        private int _selectedTabIndex;
        private ObservableObject _basicInfoArea;
        private ObservableObject _activitiesArea;
        private ObservableObject _achievementsArea;
        private Member _selectedMember;

        public RelayCommand<Type> Codebook { get; set; }
        public RelayCommand GoToAddCommand { get; set; }
        public RelayCommand GoToEditCommand { get; set; }


        public MembersViewModel()
        {
            MainContentArea = new ListMembersViewModel();
            SelectedTabIndex = 0;
            Messenger.Default.Register<Member>(this, SelectedMemberChanged);

            Codebook = new RelayCommand<Type>(CodebookExecute);   
            GoToAddCommand = new RelayCommand(ExecuteGoToAddCommand);      
            GoToEditCommand = new RelayCommand(ExecuteGoToEditCommand, CanExecuteGoToEditCommand);
        }

        private void ExecuteGoToEditCommand()
        {
            MemberEditDialogViewModel vm = new MemberEditDialogViewModel(_selectedMember);

            MemberEditDialog d = new MemberEditDialog(vm);
            d.Owner = Application.Current.MainWindow;
            d.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            d.ShowDialog();
        }

        private bool CanExecuteGoToEditCommand()
        {
            return _selectedMember != null;
        }

        private void ExecuteGoToAddCommand()
        {
            
        }

        private void CodebookExecute(Type obj)
        {
            DialogView dw2 = null;
            if (typeof(MembershipType) == obj)            
                dw2 = new DialogView(new DialogReferentViewModel<MembershipType>("Šifrarnik: članstvo"));                
            else if (typeof(AffiliationFeeType) == obj)
                dw2 = new DialogView(new DialogReferentViewModel<AffiliationFeeType>("Šifrarnik: članarina - todo clanarina kosta"));
            else if (typeof(MemberFunction) == obj)
                dw2 = new DialogView(new DialogReferentViewModel<MemberFunction>("Šifrarnik: funkcija"));
            else if (typeof(Section) == obj)
                dw2 = new DialogView(new DialogReferentViewModel<Section>("Šifrarnik: sekcije"));
            else if (typeof(AchievementType) == obj)
                dw2 = new DialogView(new DialogReferentViewModel<AchievementType>("Šifrarnik: medalje"));
            else if (typeof(MemberCategory) == obj)
                dw2 = new DialogView(new DialogReferentViewModel<MemberCategory>("Šifrarnik: kategorije"));
            else if (typeof(EmploymentStatus) == obj)
                dw2 = new DialogView(new DialogReferentViewModel<EmploymentStatus>("Šifrarnik: status"));

            if (dw2 != null)
            {
                dw2.Owner = Application.Current.MainWindow;
                dw2.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                dw2.ShowDialog();
            }
        }        

        public ObservableObject MainContentArea { get; set; }

        public int SelectedTabIndex
        {
            get { return _selectedTabIndex; }
            set
            {
                _selectedTabIndex = value;
                RaisePropertyChanged(nameof(SelectedTabIndex));
            }
        }

        public ObservableObject BasicInfoArea
        {
            get { return _basicInfoArea; }
            set
            {
                if (_basicInfoArea == value)
                    return;
                
                _basicInfoArea = value;
                RaisePropertyChanged(nameof(BasicInfoArea));
            }
        }

        public ObservableObject ActivitiesArea
        {
            get { return _activitiesArea; }
            set
            {
                if (_activitiesArea == value)
                    return;

                _activitiesArea = value;
                RaisePropertyChanged(nameof(ActivitiesArea));
            }
        }

        public ObservableObject AchievementsArea
        {
            get { return _achievementsArea; }
            set
            {
                if (_achievementsArea == value)
                    return;

                _achievementsArea = value;
                RaisePropertyChanged(nameof(AchievementsArea));
            }
        }

        private void SelectedMemberChanged(Member obj)
        {
            _selectedMember = obj;
            BasicInfoArea = new BasicInfoViewModel(obj);
            ActivitiesArea = new ActivitiesInfoViewModel(obj);
            AchievementsArea = new AchievementsInfoViewModel(obj);
        }        
    }
}
