namespace WpfFramework.Interfaces
{
    /// <summary>
    /// 네비게이션 시작, 종료되는 시점을 뷰모델에 알려주는 인터페이스
    /// </summary>
    public interface INavigationAware
    {
        void OnNavigating(object sender, object navigationEventArgs);
        void OnNavigated(object sender, object navigatedEventArgs);
    }
}
