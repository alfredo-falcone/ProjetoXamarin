using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Locabem.Xamarin
{
    public class CorBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((bool)value) ? Color.Red : Color.Blue;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        { 
            throw new NotSupportedException("Não suportado");
        }
    }
}
