using Microsoft.Toolkit.Mvvm.Messaging;
using System.Windows;
using System.Windows.Controls;
using WpfFramework.Models;

namespace WpfFramework.Controls
{
    /// <summary>
    /// Interaction logic for AboutControl.xaml
    /// </summary>
    public partial class AboutControl : UserControl
    {
        public AboutControl()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WeakReferenceMessenger.Default.Send(new LayerPopupMessage(false));
        }
    }
}
