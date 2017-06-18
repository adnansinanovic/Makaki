using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using Makaki.Data;
using Makaki.Model;

namespace Makaki.Ui.Screens.Members.Dialog.AdditionalInfo
{
    public class AdditionalInfoViewModel : ObservableObject
    {
        private readonly Member _member;
        private string _statusPlaceLabel;
        private bool _isEmploymentPlaceEnabled;
        private string _statusDetailsLabel;
        private bool _isEmploymentDetailsEnabled;

        public AdditionalInfoViewModel(Member member)
        {
            _member = member;

            using (UnitOfWork uof = new UnitOfWork())
            {
                EmploymentStatuses = new ObservableCollection<EmploymentStatus>(uof.Repository<EmploymentStatus>().Get().OrderBy(x => x.Name).ToList());
            }

            SetEmploymentPlaceLabel(EmploymentStatus);
            SetEmploymentDetailsLabel(EmploymentStatus);
        }

        #region Employment Status
        public ObservableCollection<EmploymentStatus> EmploymentStatuses { get; set; }

        public EmploymentStatus EmploymentStatus
        {
            get { return _member.EmploymentStatus; }

            set
            {
                if (_member.EmploymentStatus == value)
                    return;

                SetEmploymentPlaceLabel(value);
                SetEmploymentDetailsLabel(value);


                _member.EmploymentStatus = value;
                RaisePropertyChanged(nameof(EmploymentStatus));
            }
        }

        public int? EmploymentStatusId
        {
            get { return _member.EmploymentStatusId; }

            set
            {
                if (_member.EmploymentStatusId == value)
                    return;

                _member.EmploymentStatusId = value;
                RaisePropertyChanged(nameof(EmploymentStatusId));
            }
        }
        #endregion

        #region Employment Place
        public string EmploymentPlaceLabel
        {
            get { return _statusPlaceLabel; }

            set
            {
                if (_statusPlaceLabel == value)
                    return;

                _statusPlaceLabel = value;
                RaisePropertyChanged(nameof(EmploymentPlaceLabel));
            }
        }

        public string EmploymentPlace
        {
            get { return _member.EmploymentPlace; }

            set
            {
                if (_member.EmploymentPlace == value)
                    return;

                _member.EmploymentPlace = value;
                RaisePropertyChanged(nameof(EmploymentPlace));
            }
        }

        public bool IsEmploymentPlaceEnabled
        {
            get { return _isEmploymentPlaceEnabled; }
            set
            {
                if (_isEmploymentPlaceEnabled == value)
                    return;

                _isEmploymentPlaceEnabled = value;
                RaisePropertyChanged(nameof(IsEmploymentPlaceEnabled));
            }
        }

        private void SetEmploymentPlaceLabel(EmploymentStatus value)
        {
            switch (value?.Name.ToLower())
            {
                case "zaposlen":
                    EmploymentPlaceLabel = "Firma";
                    break;
                case "student":
                case "učenik":
                    EmploymentPlaceLabel = "Škola";
                    break;
                case "predškolarac":
                    EmploymentPlaceLabel = "Vrtić";
                    break;
                default:
                    EmploymentPlaceLabel = string.Empty;
                    break;
            }

            IsEmploymentPlaceEnabled = !string.IsNullOrWhiteSpace(EmploymentPlaceLabel);

        }
        #endregion

        #region Employment Details
        public string EmploymentDetailsLabel
        {
            get { return _statusDetailsLabel; }

            set
            {
                if (_statusDetailsLabel == value)
                    return;

                _statusDetailsLabel = value;
                RaisePropertyChanged(nameof(EmploymentDetailsLabel));
            }
        }

        public string EmploymentDetails
        {
            get { return _member.EmploymentDetails; }

            set
            {
                if (_member.EmploymentDetails == value)
                    return;

                _member.EmploymentDetails = value;
                RaisePropertyChanged(nameof(EmploymentDetails));
            }
        }

        public bool IsEmploymentDetailsEnabled
        {
            get { return _isEmploymentDetailsEnabled; }
            set
            {
                if (_isEmploymentDetailsEnabled == value)
                    return;

                _isEmploymentDetailsEnabled = value;
                RaisePropertyChanged(nameof(IsEmploymentDetailsEnabled));
            }
        }

        private void SetEmploymentDetailsLabel(EmploymentStatus value)
        {
            switch (value?.Name.ToLower())
            {
                case "zaposlen":
                    EmploymentDetailsLabel = "Zanimanje";
                    break;
                case "student":
                    EmploymentDetailsLabel = "Obrazovanje";
                    break;
                default:
                    EmploymentDetailsLabel = string.Empty;
                    break;
            }

            IsEmploymentDetailsEnabled = !string.IsNullOrWhiteSpace(EmploymentDetailsLabel);

        }
        #endregion

        #region Physcial
        public bool RequiredPhysical
        {
            get { return _member.RequiredPhysical; }
            set
            {
                if (_member.RequiredPhysical == value)
                    return;

                _member.RequiredPhysical = value;
                RaisePropertyChanged(nameof(RequiredPhysical));
            }
        }

        public DateTime? LastPhysical
        {
            get { return _member.LastPhysical; }
            set
            {
                if (_member.LastPhysical == value)
                    return;

                _member.LastPhysical = value;
                RaisePropertyChanged(nameof(LastPhysical));
            }
        } 
        #endregion
    }
}
