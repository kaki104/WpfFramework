using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfFramework.Bases;
using WpfFramework.Models;

namespace WpfFramework.ViewModels
{
    /// <summary>
    /// 홈뷰모델
    /// </summary>
    public class HomeViewModel : ViewModelBase
    {
        /// <summary>
        /// 네비게이션 카운트 출력용 - 삭제 가능
        /// </summary>
        public static int Count { get; set; }

        private decimal _price;
        /// <summary>
        /// 가격
        /// </summary>
        public decimal Price
        {
            get { return _price; }
            set { SetProperty(ref _price, value); }
        }

        /// <summary>
        /// Busy 테스트 커맨드
        /// </summary>
        public ICommand BusyTestCommand { get; set; }
        /// <summary>
        /// LayerPopup 테스트 커맨드
        /// </summary>
        public ICommand LayerPopupTestCommand { get; set; }

        /// <summary>
        /// 생성자
        /// </summary>
        public HomeViewModel()
        {
            Title = "Home";

            Init();
        }

        private void Init()
        {
            BusyTestCommand = new AsyncRelayCommand(OnBusyTestAsync);
            LayerPopupTestCommand = new RelayCommand(OnLayerPopupTest);

            Price = 12345678;
        }

        private void OnLayerPopupTest()
        {
            WeakReferenceMessenger.Default.Send(new LayerPopupMessage(true) { ControlName = "AboutControl" });
        }

        /// <summary>
        /// OnBusyTest
        /// </summary>
        /// <returns></returns>
        private async Task OnBusyTestAsync()
        {
            WeakReferenceMessenger.Default.Send(new BusyMessage(true) { BusyId = "OnBusyTestAsync" });
            await Task.Delay(5000);
            WeakReferenceMessenger.Default.Send(new BusyMessage(false) { BusyId = "OnBusyTestAsync" });
        }

        public override void OnNavigated(object sender, object navigatedEventArgs)
        {
            Count++;
            Message = $"{Count} Navigated";
        }
    }
}
