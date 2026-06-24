using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Input;
using WpfFramework.Bases;
using WpfFramework.Models;

namespace WpfFramework.ViewModels
{
    /// <summary>
    /// 로그인 뷰모델
    /// </summary>
    public class LoginPageViewModel : ViewModelBase
    {
        private IAppContext _appContext = new Models.AppContext();
        /// <summary>
        /// AppContext, Id와 Name을 컨트롤에서 직접 입력 받을 AppContext
        /// </summary>
        public IAppContext AppContext
        {
            get => _appContext;
            set => SetProperty(ref _appContext, value);
        }
        /// <summary>
        /// 로그인 커맨드
        /// </summary>
        public ICommand LoginCommand { get; set; }
        /// <summary>
        /// 기본 생성자
        /// </summary>
        public LoginPageViewModel()
        {
            Init();
        }

        private void Init()
        {
            ////싱글톤으로 생성되어있는 것을 AppContext에 주입
            //AppContext = App.Current.Services.GetService<IAppContext>();
            LoginCommand = new RelayCommand(OnLogin);
        }

        private void OnLogin()
        {
            if(string.IsNullOrEmpty(AppContext.Id) || string.IsNullOrEmpty(AppContext.Name))
            {
                ShowWarning("Id와 Name은 필수값 입니다.");
                return;
            }
            //로그인 성공으로 판단

            //아이디와 이름을 싱글톤appcontext에 입력
            var singletonAppContext = App.Current.Services.GetService<IAppContext>();
            singletonAppContext.Id = AppContext.Id;
            singletonAppContext.Name = AppContext.Name;
            //네비게이션
            WeakReferenceMessenger.Default.Send(new NavigationMessage("Views/HomePage.xaml"));
        }
    }
}
