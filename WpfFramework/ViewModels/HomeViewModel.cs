using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;
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

        private IAppContext _appContext;
        /// <summary>
        /// AppContext
        /// </summary>
        public IAppContext AppContext
        {
            get => _appContext;
            set => SetProperty(ref _appContext, value);
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

            AppContext = App.Current.Services.GetService<IAppContext>();
        }

        private void OnLayerPopupTest()
        {
            WeakReferenceMessenger.Default.Send(new LayerPopupMessage(true) 
            { 
                ControlName = "AboutControl",
                Parameter = "kaki104 parameter"
            });
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
