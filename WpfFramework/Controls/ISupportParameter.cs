namespace WpfFramework.Controls
{
    /// <summary>
    /// 컨트롤에 Parameter를 전달하기 위한 인터페이스
    /// </summary>
    public interface ISupportParameter
    {
        /// <summary>
        /// 파라메터
        /// </summary>
        object Parameter { get; set; }
    }
}