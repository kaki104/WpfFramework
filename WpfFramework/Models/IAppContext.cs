using System;

namespace WpfFramework.Models
{
    /// <summary>
    /// 앱 컨텍스트 인터페이스
    /// </summary>
    public interface IAppContext
    {
        DateTime Connection { get; set; }
        Guid ConnectionId { get; set; }
        string Id { get; set; }
        string Name { get; set; }
    }
}
