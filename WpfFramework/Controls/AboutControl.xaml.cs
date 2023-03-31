using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Windows;
using System.Windows.Controls;
using WpfFramework.Models;

namespace WpfFramework.Controls
{
    /// <summary>
    /// Interaction logic for AboutControl.xaml
    /// </summary>
    public partial class AboutControl : UserControl, ISupportParameter
    {
        public AboutControl()
        {
            InitializeComponent();
        }
        public object Parameter
        {
            get { return (object)GetValue(ParameterProperty); }
            set { SetValue(ParameterProperty, value); }
        }
        /// <summary>
        /// 파라메터 - DependencyProperty이기 때문에 직접 바인딩을 하거나, Changed 이벤트를 이용해서 작업을 진행할 수 있습니다.
        /// </summary>
        public static readonly DependencyProperty ParameterProperty =
            DependencyProperty.Register(nameof(Parameter), typeof(object), typeof(AboutControl), new PropertyMetadata(null, ParameterChanged));

        private static void ParameterChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (AboutControl)d;
            control.OnParameterChanged();
        }

        private void OnParameterChanged()
        {
            //작업 내용 처리
        }

        /// <summary>
        /// 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WeakReferenceMessenger.Default.Send(new LayerPopupMessage(false));
        }
    }
}
