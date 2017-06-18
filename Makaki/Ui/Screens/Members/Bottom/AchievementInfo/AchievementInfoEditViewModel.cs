using System;
using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Makaki.Data;
using Makaki.Model;
using Makaki.Ui.Helper;

namespace Makaki.Ui.Screens.Members.Bottom.AchievementInfo
{
    public class AchievementInfoEditViewModel : ObservableObject
    {
        private readonly Achievement _achievement;
        private readonly bool _editing;
        public RelayCommand<object> ButtonOkCommand { get; set; }

        //private readonly UnitOfWork _uof = new UnitOfWork();

        public AchievementInfoEditViewModel(Achievement achievement, bool editing)
        {
            _achievement = achievement;
            _editing = editing;

            ButtonOkCommand = new RelayCommand<object>(ExecuteButtonOkCommand, CanExecuteButtonOkCommand);

            using (UnitOfWork _uof = new UnitOfWork())
            {
                AchievementTypes = new ObservableCollection<AchievementType>(_uof.Repository<AchievementType>().Get().ToList());
            }

        }

        public ObservableCollection<AchievementType> AchievementTypes { get; set; }

        private bool CanExecuteButtonOkCommand(object obj)
        {
            if (_achievement.Member == null)
                return false;

            if (string.IsNullOrWhiteSpace(Name))
                return false;

            if (string.IsNullOrWhiteSpace(AssignedBy))
                return false;

            if (AchievementType == null)
                return false;

            return true;
        }

        private void ExecuteButtonOkCommand(object obj)
        {
            if (AssignedDate == null)
                AssignedDate = DateTime.Today;

            using (UnitOfWork uof = new UnitOfWork())
            {
                if (_editing)
                {
                    uof.Repository<Achievement>().Update(_achievement);
                    uof.Save();
                }
                else
                {
                    uof.Repository<AchievementType>().Update(_achievement.AchievementType);
                    uof.Repository<Member>().Update(_achievement.Member);
                    uof.Repository<Achievement>().Insert(_achievement);
                }

                uof.Save();
            }

            CloseDialogHelper.Close(obj);
        }

        #region Properties
        public AchievementType AchievementType
        {
            get { return _achievement.AchievementType; }
            set
            {
                if (_achievement.AchievementType == value)
                    return;

                _achievement.AchievementType = value;
                RaisePropertyChanged(nameof(AchievementType));
            }
        }

        public int? AchievementTypeId
        {
            get { return _achievement.AchievementTypeId; }
            set
            {
                if (_achievement.AchievementTypeId == value)
                    return;

                _achievement.AchievementTypeId = value;
                RaisePropertyChanged(nameof(AchievementTypeId));
            }
        }

        public DateTime? AssignedDate
        {
            get { return _achievement.AssignedDate; }
            set
            {
                if (_achievement.AssignedDate == value)
                    return;

                _achievement.AssignedDate = value;
                RaisePropertyChanged(nameof(AssignedDate));
            }
        }


        public string AssignedBy
        {
            get { return _achievement.AssignedBy; }
            set
            {
                if (_achievement.AssignedBy == value)
                    return;

                _achievement.AssignedBy = value;
                RaisePropertyChanged(nameof(AssignedBy));
            }
        }

        public string Description
        {
            get { return _achievement.Description; }
            set
            {
                if (_achievement.Description == value)
                    return;

                _achievement.Description = value;
                RaisePropertyChanged(nameof(Description));
            }
        }

        public string Member => $"{_achievement.Member?.FirstName} {_achievement.Member?.LastName}";

        public string Name
        {
            get { return _achievement.Name; }
            set
            {
                if (_achievement.Name == value)
                    return;

                _achievement.Name = value;
                RaisePropertyChanged(nameof(Name));
            }
        }

        public string Note
        {
            get { return _achievement.Note; }
            set
            {
                if (_achievement.Note == value)
                    return;

                _achievement.Note = value;
                RaisePropertyChanged(nameof(Note));
            }
        }
        #endregion
    }
}
