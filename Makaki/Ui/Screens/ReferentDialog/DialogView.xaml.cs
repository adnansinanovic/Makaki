using System.Windows;

namespace Makaki.Ui.Screens.ReferentDialog
{
    /// <summary>
    /// Interaction logic for DialogView.xaml
    /// </summary>
    public partial class DialogView : Window
    {
        public DialogView()
        {            
        }

        public DialogView(DialogReferentViewModel dialogViewModel)
        {
            InitializeComponent();
            this.DataContext = dialogViewModel;
        }
    }
}
