using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Input;
using WpfFramework.Bases;
using WpfFramework.Models;
using WpfFramework.Services;

namespace WpfFramework.ViewModels
{
    public partial class CustomerViewModel : ViewModelBase
    {
        private readonly IDatabaseService _dbService;

        [ObservableProperty]
        private IList<Customer> _customers;

        public ICommand BackCommand { get; set; }

        public CustomerViewModel(IDatabaseService databaseService)
        {
            _dbService = databaseService;
            Init();
        }

        private void Init()
        {
            Title = "Customer";
            BackCommand = new RelayCommand(OnBack);
        }

        private void OnBack()
        {
            WeakReferenceMessenger.Default.Send(new NavigationMessage("GoBack"));
        }

        public override async void OnNavigated(object sender, object navigatedEventArgs)
        {
            Message = "Navigated";

            var datas = await _dbService.GetDatasAsync<Customer>("Select * from [Customers]");
            Customers = datas;
        }
    }
}
