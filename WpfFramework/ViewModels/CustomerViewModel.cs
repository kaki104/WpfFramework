using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Windows;
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

        [ObservableProperty]
        private Customer _selectedCustomer;

        [ObservableProperty] 
        private string _errorMessage;

        public IRelayCommand SaveCommand { get; set; }

        public CustomerViewModel(IDatabaseService databaseService)
        {
            _dbService = databaseService;
            Init();
        }

        private void Init()
        {
            Title = "Customer";

            SaveCommand = new RelayCommand(Save, 
                            () => Customers != null 
                            && Customers.Any(c => string.IsNullOrWhiteSpace(c?.CustomerID)));

            PropertyChanging += CustomerViewModel_PropertyChanging;
            PropertyChanged += CustomerViewModel_PropertyChanged;
        }

        private void CustomerViewModel_PropertyChanging(object sender, System.ComponentModel.PropertyChangingEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(SelectedCustomer):
                    if(SelectedCustomer != null)
                    {
                        SelectedCustomer.ErrorsChanged -= SelectedCustomer_ErrorsChanged;
                        ErrorMessage = string.Empty;
                    }
                    break;
            }
        }

        private void CustomerViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch(e.PropertyName)
            {
                case nameof(SelectedCustomer):
                    if (SelectedCustomer != null)
                    {
                        SelectedCustomer.ErrorsChanged += SelectedCustomer_ErrorsChanged;
                        SetErrorMessage(SelectedCustomer);
                    }
                    break;
            }
        }

        private void SelectedCustomer_ErrorsChanged(object sender, System.ComponentModel.DataErrorsChangedEventArgs e)
        {
            SetErrorMessage(sender as Customer);
        }

        private void SetErrorMessage(Customer customer)
        {
            if(customer == null)
            {
                return;
            }
            var errors = customer.GetErrors();
            ErrorMessage = string.Join("\n", errors.Select(e => e.ErrorMessage));
        }

        /// <summary>
        /// AddCommand
        /// </summary>
        [ICommand]
        private void Add()
        {
            var newCustomer = new Customer();
            Customers.Insert(0, newCustomer);
            SelectedCustomer = newCustomer;
            SaveCommand.NotifyCanExecuteChanged();
        }
        private void Save()
        {
            MessageBox.Show("Save");
            SaveCommand.NotifyCanExecuteChanged();
        }
        /// <summary>
        /// BackCommand
        /// </summary>
        [ICommand]
        private void Back()
        {
            WeakReferenceMessenger.Default.Send(new NavigationMessage("GoBack"));
        }

        public override async void OnNavigated(object sender, object navigatedEventArgs)
        {
            Message = "Navigated";

            var datas = await _dbService.GetDatasAsync<Customer>("Select * from [Customers]");
            Customers = new ObservableCollection<Customer>(datas);
        }
    }
}
