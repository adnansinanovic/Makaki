using System;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Makaki.Containers;
using Makaki.Data;
using Makaki.Model;
using Makaki.Ui.Screens.ReferentDialog.Add;
using Makaki.Ui.Screens.ReferentDialog.Edit;
using Makaki.Ui.Screens.ReferentDialog.List;
using RelayCommand = GalaSoft.MvvmLight.Command.RelayCommand;

namespace Makaki.Ui.Screens.ReferentDialog
{  
    public class DialogReferentViewModel<T> : DialogReferentViewModel where T : class, IReferentModel
    {
        public DialogReferentViewModel(string title) : base(title)
        {                      
        }

        protected sealed override ObservableObject CreateListViewModel()
        {
            return new ListViewModel<T>();
        }

        protected sealed override ObservableObject CreateEditViewModel(IReferentModel model)
        {
            return new EditViewModel<T>(model);
        }

        protected override void DeleteSelectedItem(IReferentModel model)
        {
            T item = model as T;

            if (item == null)
                throw new Exception($"'{model.GetType()}' cannot be cast to '{typeof(T)}'.");

            using (UnitOfWork unit = new UnitOfWork())
            {
                unit.Repository<T>().Delete(item);
                unit.Save();
            }
        }

        protected sealed override ObservableObject CreateAddViewModel()
        {
            return new AddViewModel<T>();
        }
    }

    public abstract class DialogReferentViewModel : ObservableObject
    {
             
        private string _dialogTitle;
        private ObservableObject _contentArea;
        private bool _showCloseButton;
        public RelayCommand GoToAdd { get; set; }
        public RelayCommand GoToEdit { get; set; }
        public RelayCommand DeleteItem { get; set; }
        
        protected abstract ObservableObject CreateAddViewModel();

        protected abstract ObservableObject CreateListViewModel();
        protected abstract ObservableObject CreateEditViewModel(IReferentModel model);

        protected abstract void DeleteSelectedItem(IReferentModel model);

        public DialogReferentViewModel(string title)
        {            
            DialogTitle = title;        
            GoToAdd = new RelayCommand(GoToAddExecute, CanGoToAddExecute);
            GoToEdit = new RelayCommand(GoToEditExecute, CanGoToEditExecute);
            DeleteItem = new RelayCommand(DeleteItemExecute, CanDeleteItemExecute);            

            Messenger.Default.Register<MessengerArgDialog>(this, OnMessengerEvent);

            GoToListExecute();
        }        

        public bool ShowCloseButton
        {
            get { return _showCloseButton; }
            set
            {
                if (_showCloseButton == value)
                    return;

                _showCloseButton = value;
                RaisePropertyChanged(nameof(ShowCloseButton));
            }
        }

        public string DialogTitle
        {
            get { return _dialogTitle; }
            set
            {
                if (_dialogTitle == value)
                    return;

                _dialogTitle = value;
                RaisePropertyChanged(nameof(DialogTitle));
            }
        }

        public ObservableObject ContentArea
        {
            get { return _contentArea; }
            set
            {
                if (_contentArea == value)
                    return;

                _contentArea = value;
                RaisePropertyChanged(nameof(ContentArea));
            }
        }

        private void OnMessengerEvent(MessengerArgDialog obj)
        {            
            switch (obj.GotoScreen)
            {
                case DialogViewScreen.ListScreen:
                    GoToListExecute();                    
                    break;
                case DialogViewScreen.AddScreen:
                    GoToAddExecute();
                    break;
                case DialogViewScreen.UpdateScreen:
                    GoToEditExecute();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private bool CanDeleteItemExecute()
        {
            var list = ContentArea as ListViewModel;

            return list?.SelectedReferentViewModel != null;
        }

        private void DeleteItemExecute()
        {
            var list = ContentArea as ListViewModel;

            if (list?.SelectedReferentViewModel == null)
            {
                //neither of these two should be null, it's already checked in CanGoToEditExecute().
                string s = list == null ? "List" : "SelectedReferentViewModel";
                throw new Exception($"Impossible! {s} is null.");
            }

            MessageBoxResult result = MessageBox.Show("Da li želite obrisati izabranu stavku?", "Potvrda", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {                
                DeleteSelectedItem(list.SelectedReferentViewModel);
                GoToListExecute();
            }
        }        
        private bool CanGoToEditExecute()
        {
            var list = ContentArea as ListViewModel;

            return list?.SelectedReferentViewModel != null;
        }

        private void GoToEditExecute()
        {
            var list = ContentArea as ListViewModel;

            if (list?.SelectedReferentViewModel == null)
            {
                //neither of these two should be null, it's already checked in CanGoToEditExecute().
                string s = list == null ? "List" : "SelectedReferentViewModel";
                throw new Exception($"Impossible! {s} is null.");
            }
            
            ContentArea = CreateEditViewModel(list.SelectedReferentViewModel);
            ShowCloseButton = false;
        }

        private bool CanGoToAddExecute()
        {
            var list = ContentArea as ListViewModel;

            return list != null;
        }

        private void GoToAddExecute()
        {
            ContentArea = CreateAddViewModel();
            ShowCloseButton = false;
        }

        private void GoToListExecute()
        {
            ContentArea = CreateListViewModel();
            ShowCloseButton = true;
        }
     
    }   
}
