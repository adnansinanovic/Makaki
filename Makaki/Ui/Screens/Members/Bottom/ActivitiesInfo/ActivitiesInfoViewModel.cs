using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using GalaSoft.MvvmLight;
using Makaki.Data;
using Makaki.Model;

namespace Makaki.Ui.Screens.Members.Bottom.ActivitiesInfo
{
    public class ActivitiesInfoViewModel : ObservableObject
    {
        private ICollectionView _activities;

        public ActivitiesInfoViewModel(Member member)
        {
            using (UnitOfWork uio = new UnitOfWork())
            {
                List<ActivityParticipant> list = uio.Repository<ActivityParticipant>().Get(
                    x => x.Member.Id == member.Id,
                    includeProperties: nameof(ActivityParticipant.Activity))
                    .ToList();

                Activities = CollectionViewSource.GetDefaultView(list);
            }
        }

        public ICollectionView Activities
        {
            get { return _activities; }
            set
            {
                if (_activities == value)
                    return;

                _activities = value;
                RaisePropertyChanged(nameof(Activities));
            }
        }
    }
}
