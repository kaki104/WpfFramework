using Microsoft.Toolkit.Mvvm.Messaging.Messages;

namespace WpfFramework.Models
{
    /// <summary>
    /// 레이어 팝업 메시지
    /// </summary>
    public class LayerPopupMessage : ValueChangedMessage<bool>
    {
        /// <summary>
        /// 컨트롤 이름
        /// </summary>
        public string ControlName { get; set; }
        /// <summary>
        /// 컨트롤에 전달할 파라메터
        /// </summary>
        public object Parameter { get; set; } = null;
        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="value">true : 레이어팝업 오픈, false : 레이어 팝업 닫기</param>
        public LayerPopupMessage(bool value) : base(value)
        {
        }
    }
}
