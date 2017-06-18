using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Makaki.Data;
using Makaki.Model;

namespace Makaki.Ui.Screens.Members.Bottom.AchievementInfo
{
    public class AchievementsInfoViewModel : ObservableObject
    {
        private readonly Member _member;
        public RelayCommand AddAchievement { get; set; }
        public RelayCommand EditAchievement { get; set; }

        private ObservableCollection<Achievement> _achievements;
        private Achievement _selectedAchievement;

        public AchievementsInfoViewModel(Member member)
        {
            _member = member;
            Load();

            AddAchievement = new RelayCommand(ExecuteAddAchievementCommand);
            EditAchievement = new RelayCommand(ExecuteEditAchievementCommand, CanExecuteEditAchievementCommand);           
        }

        private void Load()
        {
            using (UnitOfWork uof = new UnitOfWork())
            {
                List<Achievement> winners = uof
                    .Repository<Achievement>()
                    .Get(x => x.Member.Id == _member.Id,
                        includeProperties: $"{nameof(Achievement.AchievementType)}, {nameof(Achievement.Member)}")
                    .ToList();

                Achievements = new ObservableCollection<Achievement>(winners);
            }
        }

        public ObservableCollection<Achievement> Achievements
        {
            get { return _achievements; }
            set
            {
                if (_achievements == value)
                    return;

                _achievements = value;
                RaisePropertyChanged(nameof(Achievements));
            }
        }

        public Achievement SelectedAchievement
        {
            get { return _selectedAchievement; }
            set
            {
                if (_selectedAchievement == value)
                    return;

                _selectedAchievement = value;
                RaisePropertyChanged(nameof(SelectedAchievement));
            }
        }



        private bool CanExecuteEditAchievementCommand()
        {
            return SelectedAchievement != null;
        }

        private void ExecuteEditAchievementCommand()
        {
            ShowDialog(SelectedAchievement, true);            
        }

        private void ExecuteAddAchievementCommand()
        {
            Achievement achievement = new Achievement() { Member = _member, MemberId = _member.Id };
            ShowDialog(achievement, false);            
        }

        private void ShowDialog(Achievement achievement, bool editing)
        {
            AchievementInfoEditView dialog = new AchievementInfoEditView(new AchievementInfoEditViewModel(achievement, editing))
            {
                Owner = Application.Current.MainWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };

            if (dialog.ShowDialog() == true)
                Load();
        }
    }
}
