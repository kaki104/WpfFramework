using Microsoft.Toolkit.Mvvm.Messaging.Messages;

namespace WpfFramework.Models
{
    /// <summary>
    /// 네비게이션 메시지
    /// </summary>
    public class NavigationMessage : ValueChangedMessage<string>
    {
        public NavigationMessage(string value) : base(value)
        {
        }
    }
}
