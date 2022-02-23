using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
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
