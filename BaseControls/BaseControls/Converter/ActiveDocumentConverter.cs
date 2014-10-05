﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using BaseControls.ViewModel;

namespace BaseControls.Converter
{

  class ActiveDocumentConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      if (value is DocViewModel)
        return value;

      return Binding.DoNothing;
    }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      if (value is DocViewModel)
        return value;

      return Binding.DoNothing;
    }
  }
}
