using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfFramework.Models
{
    public partial class Customer : ObservableValidator
    {
        [ObservableProperty]
        private string _customerID;
        [ObservableProperty]
        private string _companyName;
        [ObservableProperty]
        private string _contactName;
        [ObservableProperty]
        private string _contactTitle;
        [ObservableProperty]
        private string _address;
        [ObservableProperty]
        private string _city;
        [ObservableProperty]
        private string _region;
        [ObservableProperty]
        private string _postalCode;
        [ObservableProperty]
        private string _country;
        [ObservableProperty]
        private string _phone;
        [ObservableProperty]
        private string _fax;
    }
}
