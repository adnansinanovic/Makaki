using System.Text;
using GalaSoft.MvvmLight;
using Makaki.Model;

namespace Makaki.Ui.Screens.Members.Bottom.BasicInfo
{
    public class BasicInfoViewModel : ObservableObject
    {
        private Member _member;

        public BasicInfoViewModel(Member member)
        {
            Member = member;
        }

        public Member Member
        {
            get { return _member; }
            set
            {
                _member = value;
                RaisePropertyChanged(nameof(Member));                
            }
        }

        public string Name => $"{_member?.FirstName} {_member?.LastName}";  

        public string City => _member?.Address?.City?.Name;

        public string EmploymentStatus => _member?.EmploymentStatus?.Name;

        public string Address
        {
            get
            {
                StringBuilder sb =new StringBuilder();

                if (!string.IsNullOrWhiteSpace(_member?.Address?.AddressLine1))
                {
                    sb.AppendFormat(_member?.Address?.AddressLine1);

                    if (!string.IsNullOrWhiteSpace(_member?.Address?.AddressLine2))
                    {
                        sb.AppendFormat(", ");
                        sb.AppendFormat(_member?.Address?.AddressLine2);
                    }
                }                

                return sb.ToString();
            }
        }

        public bool ShowGuardian => Member.Guardian != null;

        public string GuardianName => $"{_member?.Guardian?.FirstName} {_member?.Guardian?.LastName}";

        public string GuardianAddress
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                if (!string.IsNullOrWhiteSpace(_member?.Guardian?.Address?.AddressLine1))
                {
                    sb.AppendFormat(_member?.Guardian?.Address?.AddressLine1);
                    if (!string.IsNullOrWhiteSpace(_member?.Guardian?.Address?.AddressLine2))
                    {
                        sb.AppendFormat(", ");
                        sb.AppendFormat(_member?.Guardian?.Address?.AddressLine2);
                    }
                }                

                return sb.ToString();
            }
        }

        public string GuardianCity => _member?.Address?.City?.Name;
    }
}
