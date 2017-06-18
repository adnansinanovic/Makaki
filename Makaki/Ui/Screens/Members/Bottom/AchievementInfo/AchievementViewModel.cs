using System;
using GalaSoft.MvvmLight;
using Makaki.Model;

namespace Makaki.Ui.Screens.Members.Bottom.AchievementInfo
{
    public class AchievementViewModel : ObservableObject
    {
        private readonly Achievement _model;

        public AchievementViewModel(Achievement achievement)
        {
            _model = achievement;
        }
        public int Id
        {
            get { return _model.Id; }
            set
            {
                if (_model.Id == value)
                    return;

                _model.Id = value;
                RaisePropertyChanged(nameof(Id));
            }
        }

        public int? MemberId
        {
            get { return _model.MemberId; }
            set
            {
                if (_model.MemberId == value)
                    return;

                _model.MemberId = value;
                RaisePropertyChanged(nameof(MemberId));
            }
        }

        public virtual Member Member
        {
            get { return _model.Member; }
            set
            {
                if (_model.Member == value)
                    return;

                _model.Member = value;
                RaisePropertyChanged(nameof(Member));
            }
        }

        public int? AchievementTypeId
        {
            get { return _model.AchievementTypeId; }
            set
            {
                if (_model.AchievementTypeId == value)
                    return;

                _model.AchievementTypeId = value;
                RaisePropertyChanged(nameof(AchievementTypeId));
            }
        }

        public virtual AchievementType AchievementType
        {
            get { return _model.AchievementType; }
            set
            {
                if (_model.AchievementType == value)
                    return;

                _model.AchievementType = value;
                RaisePropertyChanged(nameof(AchievementType));
            }
        }

        public string Name
        {
            get { return _model.Name; }
            set
            {
                if (_model.Name == value)
                    return;

                _model.Name = value;
                RaisePropertyChanged(nameof(Name));
            }
        }

        public string Description
        {
            get { return _model.Description; }
            set
            {
                if (_model.Description == value)
                    return;

                _model.Description = value;
                RaisePropertyChanged(nameof(Description));
            }
        }

        public string Note
        {
            get { return _model.Note; }
            set
            {
                if (_model.Note == value)
                    return;

                _model.Note = value;
                RaisePropertyChanged(nameof(Note));
            }
        }

        public DateTime? AssignedDate
        {
            get { return _model.AssignedDate; }
            set
            {
                if (_model.AssignedDate == value)
                    return;

                _model.AssignedDate = value;
                RaisePropertyChanged(nameof(AssignedDate));
            }
        }

        public string AssignedBy
        {
            get { return _model.AssignedBy; }
            set
            {
                if (_model.AssignedBy == value)
                    return;

                _model.AssignedBy = value;
                RaisePropertyChanged(nameof(AssignedBy));
            }
        }

        public Achievement Achievement { get { return _model; } }
    }
}
