using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;

namespace MyTools.Function01
{
  public class Function01ViewModel : NotificationObject
  {
    public Function01ViewModel()
    {
      TestText = "Start Function01";
    }

    private string _TestText;
    public string TestText
    {
      get { return _TestText; }
      set
      {
        _TestText = value;
        RaisePropertyChanged(() => TestText);
      }
    }
  }
}
