using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Practices.Prism.ViewModel;
using Microsoft.Practices.Prism.Commands;
using BaseControls.ViewModel;
using MyTools.Function0A;

namespace MyTools
{
  class MainWindowViewModel : MainViewModel
  {
    public MainWindowViewModel()
    {
      Function01 = new Function0AViewModel();

      TestText = "AAA";
    }

    private Function0AViewModel _Function01;
    public Function0AViewModel Function01
    {
      get { return _Function01; }
      set
      {
        _Function01 = value;
        RaisePropertyChanged(() => Function01);
      }
    }
  }
}
