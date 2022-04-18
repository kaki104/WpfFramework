using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WpfFramework.Models
{
    /// <summary>
    /// Customer
    /// </summary>
    public partial class Customer : ObservableValidator
    {
        [ObservableProperty]
        [Required]
        [MaxLength(5)]
        private string _customerID;
        [ObservableProperty]
        [Required]
        [MaxLength(40)]
        private string _companyName;
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
        private string _phone;
        [ObservableProperty]
        [MaxLength(24)]
        private string _fax;

    }
}
