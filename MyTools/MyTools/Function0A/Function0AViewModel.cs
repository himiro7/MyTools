using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;

namespace MyTools.Function0A
{
  public class Function0AViewModel : NotificationObject
  {
    public Function0AViewModel()
    {
      TestText = "MyViewModel Deth";
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
