using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using WpfFramework.Bases;
using WpfFramework.Models;

namespace WpfFramework.ViewModels
{
    /// <summary>
    /// 메인 뷰모델 클래스
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Busy 목록
        /// </summary>
        private IList<BusyMessage> _busys = new List<BusyMessage>();

        private string _navigationSource;
        /// <summary>
        /// 네비게이션 소스
        /// </summary>
        public string NavigationSource
        {
            get { return _navigationSource; }
            set { SetProperty(ref _navigationSource, value); }
        }
        /// <summary>
        /// 네비게이트 커맨드
        /// </summary>
        public ICommand NavigateCommand { get; set; }

        private bool _isBusy;
        /// <summary>
        /// IsBusy
        /// </summary>
        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }

        private bool _showLayerPopup;
        /// <summary>
        /// 레이어 팝업 출력여부
        /// </summary>
        public bool ShowLayerPopup
        {
            get { return _showLayerPopup; }
            set { SetProperty(ref _showLayerPopup, value); }
        }

        private string _controlName;
        /// <summary>
        /// 레이어 팝업 내부 컨트롤 이름
        /// </summary>
        public string ControlName
        {
            get { return _controlName; }
            set { SetProperty(ref _controlName, value); }
        }

        /// <summary>
        /// 생성자
        /// </summary>
        public MainViewModel()
        {
            Title = "Main View";
            Init();
        }

        private void Init()
        {
            //시작 페이지 설정
            NavigationSource = "Views/HomePage.xaml";
            NavigateCommand = new RelayCommand<string>(OnNavigate);

            //네비게이션 메시지 수신 등록
            WeakReferenceMessenger.Default.Register<NavigationMessage>(this, OnNavigationMessage);
            //BusyMessage 수신 등록
            WeakReferenceMessenger.Default.Register<BusyMessage>(this, OnBusyMessage);
            //LayerPopupMessage 수신 등록
            WeakReferenceMessenger.Default.Register<LayerPopupMessage>(this, OnLayerPopupMessage);
        }

        private void OnLayerPopupMessage(object recipient, LayerPopupMessage message)
        {
            ShowLayerPopup = message.Value;
            ControlName = message.ControlName;
        }

        /// <summary>
        /// 비지 메시지 수신 처리
        /// </summary>
        /// <param name="recipient"></param>
        /// <param name="message"></param>
        private void OnBusyMessage(object recipient, BusyMessage message)
        {
            if (message.Value)
            {
                var existBusy = _busys.FirstOrDefault(b => b.BusyId == message.BusyId);
                if (existBusy != null)
                {
                    //이미 추가된 녀석이기 때문에 추가하지 않음
                    return;
                }
                _busys.Add(message);
            }
            else
            {
                var existBusy = _busys.FirstOrDefault(b => b.BusyId == message.BusyId);
                if (existBusy == null)
                {
                    //없기 때문에 나감
                    return;
                }
                _busys.Remove(existBusy);
            }
            //_busys에 아이템이 있으면 true, 없으면 false
            IsBusy = _busys.Any();
        }

        /// <summary>
        /// 네비게이션 메시지 수신 처리
        /// </summary>
        /// <param name="recipient"></param>
        /// <param name="message"></param>
        private void OnNavigationMessage(object recipient, NavigationMessage message)
        {
            NavigationSource = message.Value;
        }

        private void OnNavigate(string pageUri)
        {
            NavigationSource = pageUri;
        }
    }
}
