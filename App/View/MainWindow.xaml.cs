using App.ViewModels.Facade;
using System.Windows;


namespace App.View
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // By having a Facade design pattern in place we can just call this one constructor
            // and worry less about any kind of logic that is covered behind it.
            // Otherwise it would be needed to initialize all the Wallet, Chart, User, etc objects here
            // and bind directly to the MainWindow class by using 'this' - which would be really "hardcoded" way
            DataContext = new ViewModelFacade();
        }
    }
}
