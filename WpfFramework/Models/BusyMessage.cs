using Microsoft.Toolkit.Mvvm.Messaging.Messages;

namespace WpfFramework.Models
{
    /// <summary>
    /// 비지 메시지
    /// </summary>
    public class BusyMessage : ValueChangedMessage<bool>
    {
        /// <summary>
        /// BusyId
        /// </summary>
        public string BusyId { get; set; }
        /// <summary>
        /// BusyText
        /// </summary>
        public string BusyText { get; set; }
        /// <summary>
        /// todtjdwk
        /// </summary>
        /// <param name="value"></param>
        public BusyMessage(bool value) : base(value)
        {
        }
    }
}
