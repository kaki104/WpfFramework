﻿using Microsoft.Toolkit.Mvvm.Input;
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
        public static int Count { get; set; }

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
