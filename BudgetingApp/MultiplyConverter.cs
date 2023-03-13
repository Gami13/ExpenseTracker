using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetingApp
{
    public class MultiplyConverter : IMultiValueConverter
    { 

        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values == null || values.Length < 2 || values[0] ==null || values[1]==null)
                return 0;
            Debug.WriteLine(values[0].ToString() +" "+ values[1].ToString());
            double a = (double)values[0];
            double b = (double)values[1];
            return (a * b);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
