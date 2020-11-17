using Syncfusion.DataSource.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace ListViewXamarin
{
    #region GroupHeaderConverter
    public class GroupHeaderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;

            var groupResult = value as GroupResult;
            if (groupResult.Key.ToString() == "WORK")
                return groupResult.Count > 1 ? "WORK" : "EMPTY WORK";
            else
                return groupResult.Count > 1 ? "PERSONAL" : "EMPTY PERSONAL";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    #endregion
}
