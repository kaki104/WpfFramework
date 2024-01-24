using System.Collections.Generic;
using System.Collections.ObjectModel;
using WpfFramework.Bases;

namespace WpfFramework.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        /// <summary>
        /// 카운트 - 뷰모델을 싱글톤으로 사용하기 때문에 static 제거 
        /// </summary>
        public int Count { get; set; }

        private IList<string> _sampleTexts;
        /// <summary>
        /// 셈플 텍스트
        /// </summary>
        public IList<string> SampleTexts
        {
            get => _sampleTexts;
            set => SetProperty(ref _sampleTexts, value);
        }

        public HomeViewModel()
        {
            Title = "Home";
        }
        /// <summary>
        /// 네비게이트 완료 - 네이게이트가 완료될 때 호출(백으로 돌아올 때도 호출됨)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="navigatedEventArgs"></param>
        public override void OnNavigated(object sender, object navigatedEventArgs)
        {
            Count++;
            Message = $"{Count} Navigated";

            if (SampleTexts == null)
            {
                //처음에 생성
                SampleTexts = new ObservableCollection<string>
                {
                    "kaki104",
                };
            }
            else
            {
                //그 다음부터는 메시지 추가
                SampleTexts.Add(Message);
            }
        }
    }
}
