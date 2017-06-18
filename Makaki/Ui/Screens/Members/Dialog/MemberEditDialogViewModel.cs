using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Makaki.Model;
using Makaki.Ui.Screens.Members.Dialog.AdditionalInfo;
using Makaki.Ui.Screens.Members.Dialog.BasicInfo;
using Makaki.Ui.Screens.Members.Dialog.MembershipInfo;

namespace Makaki.Ui.Screens.Members.Dialog
{
    public class MemberEditDialogViewModel : ObservableObject
    {
        private readonly Member _member;
        private ObservableObject _basicInfoArea;
        private ObservableObject _additionalInfoArea;
        private ObservableObject _membershipInfoArea;

        public RelayCommand ButtonOkCommand { get; set; }

        public MemberEditDialogViewModel(Member member)
        {
            _member = member;
            Title = $"Podaci o članu: {member.FirstName} {member.LastName}";

            BasicInfoArea = new BasicInfoViewModel(member);
            AdditionalInfoArea = new AdditionalInfoViewModel(member);
            MembershipInfoArea = new MembershipInfoViewModel(member);
        }

        public string Title { get; set; }


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

        public ObservableObject AdditionalInfoArea
        {
            get { return _additionalInfoArea; }
            set
            {
                if (_additionalInfoArea == value)
                    return;

                _additionalInfoArea = value;
                RaisePropertyChanged(nameof(AdditionalInfoArea));
            }
        }

        public ObservableObject MembershipInfoArea
        {
            get { return _membershipInfoArea; }
            set
            {
                if (_membershipInfoArea == value)
                    return;

                _membershipInfoArea = value;
                RaisePropertyChanged(nameof(MembershipInfoArea));
            }
        }

    }
}
