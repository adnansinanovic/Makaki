    using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace Makaki.Ui.Screens.MainMenu
{
    public class MainMenuViewModel : ObservableObject
    {
        public RelayCommand<MainMenuButton> ButtonPressedParam { get; set; }

        public MainMenuViewModel()
        {            
            ButtonPressedParam = new RelayCommand<MainMenuButton>(ButtonPressedParamExecute);
        }

        private void ButtonPressedParamExecute(MainMenuButton obj)
        {          
            Messenger.Default.Send<MainMenuButton>(obj);            
        }             
    }
}
