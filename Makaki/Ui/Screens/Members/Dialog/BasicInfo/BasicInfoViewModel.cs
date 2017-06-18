using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using Makaki.Data;
using Makaki.Model;

namespace Makaki.Ui.Screens.Members.Dialog.BasicInfo
{
    public class BasicInfoViewModel : ObservableObject
    {
        private readonly Member _member;                

        public BasicInfoViewModel(Member member)
        {
            _member = member;
            using (UnitOfWork uof = new UnitOfWork())
            {
                MembershipTypes = new ObservableCollection<MembershipType>(uof.Repository<MembershipType>().Get().ToList());
                Cities = new ObservableCollection<City>(uof.Repository<City>().Get().ToList());
            }
        }
     
        public ObservableCollection<string> Genders { get; set; } = new ObservableCollection<string>() {"M", "F"};

        public string MemberCode
        {
            get { return _member.MemberCode; }

            set
            {
                if (_member.MemberCode == value)
                    return;

                _member.MemberCode = value;
                RaisePropertyChanged(nameof(MemberCode));
            }
        }

        #region Membership
        public ObservableCollection<MembershipType> MembershipTypes { get; set; }

        public MembershipType MembershipType
        {
            get { return _member.MembershipType; }

            set
            {
                if (_member.MembershipType == value)
                    return;

                _member.MembershipType = value;
                RaisePropertyChanged(nameof(MembershipType));
            }
        }

        public int? MembershipTypeId
        {
            get { return _member.MembershipTypeId; }

            set
            {
                if (_member.MembershipTypeId == value)
                    return;

                _member.MembershipTypeId = value;
                RaisePropertyChanged(nameof(MembershipTypeId));
            }
        }
        #endregion

        #region City
        public ObservableCollection<City> Cities { get; set; }

        public City City
        {
            get { return _member.Address?.City; }

            set
            {
                if (_member.Address?.City == value)
                    return;

                if (_member.Address == null)
                    _member.Address = new Address();

                _member.Address.City = value;
                RaisePropertyChanged(nameof(City));
            }
        }

        public int? CityId
        {
            get { return _member.Address?.CityId; }

            set
            {
                if (_member.Address?.CityId == value)
                    return;

                if (_member.Address == null)
                    _member.Address = new Address();

                _member.Address.CityId = value;
                RaisePropertyChanged(nameof(CityId));
            }
        } 
        #endregion


        public string FirstName
        {
            get { return _member.FirstName; }

            set
            {
                if (_member.FirstName == value)
                    return;

                _member.FirstName = value;
                RaisePropertyChanged(nameof(FirstName));
            }
        }

        public string LastName
        {
            get { return _member.LastName; }

            set
            {
                if (_member.LastName == value)
                    return;

                _member.LastName = value;
                RaisePropertyChanged(nameof(LastName));
            }
        }

        public string Gender
        {
            get { return _member.Gender; }

            set
            {
                if (_member.Gender == value)
                    return;

                _member.Gender = value;
                RaisePropertyChanged(nameof(Gender));
            }
        }

        public DateTime? Birthday
        {
            get { return _member.Birthday; }

            set
            {
                if (_member.Birthday == value)
                    return;

                _member.Birthday = value;
                RaisePropertyChanged(nameof(Birthday));
            }
        }

        public string PID
        {
            get { return _member.PID; }

            set
            {
                if (_member.PID == value)
                    return;

                _member.PID = value;
                RaisePropertyChanged(nameof(PID));
            }
        }

        public string AddressLine1
        {
            get { return _member.Address?.AddressLine1; }

            set
            {
                if (_member.Address?.AddressLine1 == value)
                    return;

                if (_member.Address == null)
                    _member.Address = new Address();

                _member.Address.AddressLine1 = value;
                RaisePropertyChanged(nameof(AddressLine1));
            }
        }

        public string AddressLine2
        {
            get { return _member.Address?.AddressLine2; }

            set
            {
                if (_member.Address?.AddressLine2 == value)
                    return;

                if (_member.Address == null)
                    _member.Address = new Address();

                _member.Address.AddressLine2 = value;
                RaisePropertyChanged(nameof(AddressLine2));
            }
        }

        public string ZipCode
        {
            get { return _member.Address?.ZipCode; }

            set
            {
                if (_member.Address?.ZipCode == value)
                    return;

                if (_member.Address == null)
                    _member.Address = new Address();

                _member.Address.ZipCode = value;
                RaisePropertyChanged(nameof(ZipCode));
            }
        }

        public string Phone
        {
            get { return _member.Phone; }

            set
            {
                if (_member.Phone == value)
                    return;

                _member.Phone = value;
                RaisePropertyChanged(nameof(Phone));
            }
        }

        public string MobilePhone
        {
            get { return _member.MobilePhone; }

            set
            {
                if (_member.MobilePhone == value)
                    return;

                _member.MobilePhone = value;
                RaisePropertyChanged(nameof(MobilePhone));
            }
        }

        public string BussinessPhone
        {
            get { return _member.BussinessPhone; }

            set
            {
                if (_member.BussinessPhone == value)
                    return;

                _member.BussinessPhone = value;
                RaisePropertyChanged(nameof(BussinessPhone));
            }
        }

        public string Email
        {
            get { return _member.Email; }

            set
            {
                if (_member.Email == value)
                    return;

                _member.Email = value;
                RaisePropertyChanged(nameof(Email));
            }
        }

        public bool HasGuardian => _member.Guardian != null;
    }
}
