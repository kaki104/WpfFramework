using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WpfFramework.Models
{
    /// <summary>
    /// Customer
    /// </summary>
    public partial class Customer : ObservableValidator
    {
        private string _customerID;
        [Required]
        [MaxLength(5)]
        public string CustomerID
        {
            get { return _customerID; }
            set { SetProperty(ref _customerID, value, true); }
        }
        private string _companyName;
        [Required]
        [MaxLength(40)]
        public string CompanyName
        {
            get { return _companyName; }
            set { SetProperty(ref _companyName, value, true); }
        }
        [ObservableProperty]
        [MaxLength(30)]
        private string _contactName;
        [ObservableProperty]
        [MaxLength(30)]
        private string _contactTitle;
        [ObservableProperty]
        [MaxLength(60)]
        private string _address;
        [ObservableProperty]
        [MaxLength(15)]
        private string _city;
        [ObservableProperty]
        [MaxLength(15)]
        private string _region;
        [ObservableProperty]
        [MaxLength(10)]
        private string _postalCode;
        [ObservableProperty]
        [MaxLength(15)]
        private string _country;
        [ObservableProperty]
        [MaxLength(24)]
        [Phone]
        private string _phone;
        [ObservableProperty]
        [MaxLength(24)]
        [Phone]
        private string _fax;
    }
}
