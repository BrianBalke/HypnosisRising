using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace HypnosisRising.MVVMExtensions.Converters
{
    /// <summary>
    /// One-way converter used to prevent access to a control before a text
    /// value is defined.
    /// </summary>
    public class IsStringDefinedConverter : IValueConverter
    {
        /// <summary>
        /// True
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string sval = value as string;
            return !(sval is null) &&
                !sval.Equals(string.Empty);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
