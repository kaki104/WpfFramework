using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace WpfFramework.Bases
{
    /// <summary>
    /// 뷰모델 베이스
    /// </summary>
    public abstract class ViewModelBase : ObservableObject
    {
        private string _title;
        /// <summary>
        /// 타이틀
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

    }
}
