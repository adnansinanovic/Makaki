using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Makaki.Containers;
using Makaki.Data;
using Makaki.Model;

namespace Makaki.Ui.Screens.ReferentDialog.Add
{
    public class AddViewModel<T> : AddViewModel where T : class, IReferentModel
    {        
        public AddViewModel()
        {            
        }

        public override void Save(string name, string description)
        {
            IReferentModel item = Activator.CreateInstance<T>();
            item.Name = name;
            item.Description = description;

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                unitOfWork.Repository<T>().Insert((T)item);
                unitOfWork.Save();
            }            

            Messenger.Default.Send(new MessengerArgDialog() { GotoScreen = DialogViewScreen.ListScreen });
        }
    }

    public abstract class AddViewModel : ObservableObject
    {
        private string _name;
        private string _description;
        public RelayCommand ButtonOk { get; set; }
        public RelayCommand ButtonCancel { get; set; }

        protected AddViewModel()
        {
            ButtonOk = new RelayCommand(ButtonOkExecute);
            ButtonCancel = new RelayCommand(ButtonCancelExecute);
        }

        private void ButtonCancelExecute()
        {
            Messenger.Default.Send(new MessengerArgDialog() { GotoScreen = DialogViewScreen.ListScreen });
        }

        public abstract void Save(string name, string description);

        private void ButtonOkExecute()
        {
            Save(Name, Description);
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged(nameof(Name));
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                RaisePropertyChanged(nameof(Description));
            }
        }
    }
}
