using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WpfFramework.Converters
{
    /// <summary>
    /// Bool을 Visibility로 변환해주는 컨버터
    /// </summary>
    /// <remarks>
    /// 컨버터 생성시 꼭 public을 붙여 준다. 디자인 타임에 생성이 않되서, 디자인 타임자체가 출력되지 않을 수 있음
    /// </remarks>
    public class BoolToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// True일때 반환할 값 - 반대로 반환해야하는 경우 여기 속성만 변경한 인스턴스를 추가해서 사용한다.
        /// </summary>
        public Visibility TrueValue { get; set; } = Visibility.Visible;
        /// <summary>
        /// False일때 반환할 값 - 반대로 반환해야하는 경우 여기 속성만 변경한 인스턴스를 추가해서 사용한다.
        /// </summary>
        public Visibility FalseValue { get; set; } = Visibility.Collapsed;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //value를 boolValue로 형변환
            if (value is bool boolValue)
            {
                //true면 trueValue반환, false이면 falseValue반환
                if (boolValue)
                {
                    return TrueValue;
                }
                else
                {
                    return FalseValue;
                }
            }
            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
