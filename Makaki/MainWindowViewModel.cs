using System;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Makaki.Model;
using Makaki.Ui.Screens.Activities;
using Makaki.Ui.Screens.Home;
using Makaki.Ui.Screens.MainMenu;
using Makaki.Ui.Screens.Members;
using Makaki.Ui.Screens.ReferentDialog;

namespace Makaki
{
    public class MainWindowViewModel : ObservableObject
    {
        private string _testMessage = nameof(MainWindowViewModel);
        private ObservableObject _contentArea = new MembersViewModel();
        private ObservableObject _mainMenuArea = new MainMenuViewModel();

        public MainWindowViewModel()
        {
            Messenger.Default.Register<MainMenuButton>(this, MainMenuButtonPressed);
        }

        private void MainMenuButtonPressed(MainMenuButton obj)
        {
            switch (obj)
            {
                case MainMenuButton.Unknown:
                    break;
                case MainMenuButton.Members:
                    ContentArea = new MembersViewModel();
                    break;
                case MainMenuButton.Activities:
                    ContentArea = new ActivitiesViewModel();
                    break;
                case MainMenuButton.Finances:
                    DialogView dw = new DialogView(new DialogReferentViewModel<MemberCategory>("Šifrarnik: članstvo"));
                    dw.Owner = Application.Current.MainWindow;
                    dw.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                    dw.ShowDialog();
                    break;
                case MainMenuButton.Documents:
                    DialogView dw2 = new DialogView(new DialogReferentViewModel<MemberFunction>("Šifrarnik: funkcija"));
                    dw2.Owner = Application.Current.MainWindow;
                    dw2.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                    dw2.ShowDialog();
                    break;
                case MainMenuButton.Economat:
                    break;
                case MainMenuButton.Home:
                    ContentArea = new HomeViewModel();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(obj), obj, null);
            }
        }

        public string TestMessage
        {
            get { return _testMessage; }
            set
            {
                _testMessage = value;
                RaisePropertyChanged(nameof(TestMessage));
            }
        }

        public ObservableObject ContentArea
        {
            get { return _contentArea; }
            set
            {
                _contentArea = value;
                RaisePropertyChanged(nameof(ContentArea));
            }
        }

        public ObservableObject MainMenuArea
        {
            get { return _mainMenuArea; }
            set
            {
                _mainMenuArea = value;
                RaisePropertyChanged(nameof(MainMenuArea));
            }
        }
    }
}
