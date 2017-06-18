using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using GalaSoft.MvvmLight;
using Makaki.Data;
using Makaki.Model;

namespace Makaki.Ui.Screens.ReferentDialog.List
{
    public class ListViewModel<T> : ListViewModel where T : class
    {
        public ListViewModel()
        {
            using (UnitOfWork context = new UnitOfWork())
            {                               
                ReferentViewModels = CollectionViewSource.GetDefaultView(context.Repository<T>().Get().ToList());             
            }            
        }
    }

    public class ListViewModel : ObservableObject
    {
        private ICollectionView _referentViewModels;
        private IReferentModel _selectedReferentViewModel;

        public ListViewModel()
        {
            
        }

        public ICollectionView ReferentViewModels
        {
            get { return _referentViewModels; }
            set
            {
                _referentViewModels = value;
                RaisePropertyChanged(nameof(ReferentViewModels));
            }
        }

        public IReferentModel SelectedReferentViewModel
        {
            get { return _selectedReferentViewModel; }
            set
            {
                _selectedReferentViewModel = value;
                RaisePropertyChanged(nameof(SelectedReferentViewModel));
            }
        }
    }
}
