using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Makaki.Containers;
using Makaki.Data;
using Makaki.Model;

namespace Makaki.Ui.Screens.ReferentDialog.Edit
{
    public class EditViewModel<T> : EditViewModel where T : class, IReferentModel
    {
        public EditViewModel(IReferentModel referentModel) : base(referentModel)
        {            
        }

        public override void Save(IReferentModel model)
        {
            T item = model as T;

            if (item == null)
                throw new Exception($"'{model.GetType()}' cannot be cast to '{typeof(T)}'.");

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                unitOfWork.Repository<T>().Update(item);
                unitOfWork.Save();
            }         
        }
    }

    public abstract class EditViewModel : ObservableObject
    {
        private readonly IReferentModel _referentModel;
        public RelayCommand ButtonOk { get; set; }

        public RelayCommand ButtonCancel { get; set; }

        protected EditViewModel(IReferentModel referentModel)
        {
            _referentModel = referentModel;
            ButtonOk = new RelayCommand(ButtonOkExecute);
            ButtonCancel = new RelayCommand(ButtonCancelExecute);
        }

        public abstract void Save(IReferentModel model);

        private void ButtonOkExecute()
        {
            Save(_referentModel);

            Messenger.Default.Send(new MessengerArgDialog() { GotoScreen = DialogViewScreen.ListScreen });
        }

        private void ButtonCancelExecute()
        {
            Messenger.Default.Send(new MessengerArgDialog() { GotoScreen = DialogViewScreen.ListScreen });
        }

        public string Name
        {
            get { return _referentModel.Name; }
            set
            {
                _referentModel.Name = value;
                RaisePropertyChanged(nameof(Name));
            }
        }

        public string Description
        {
            get { return _referentModel.Description; }
            set
            {
                _referentModel.Description = value;
                RaisePropertyChanged(nameof(Description));
            }
        }
    }
}
