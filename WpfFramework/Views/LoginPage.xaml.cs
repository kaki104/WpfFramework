using System.Windows.Controls;
using WpfFramework.ViewModels;

namespace WpfFramework.Views
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
            DataContext = App.Current.Services.GetService(typeof(LoginPageViewModel));
        }
    }
}
