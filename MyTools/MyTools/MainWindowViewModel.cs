using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Practices.Prism.ViewModel;
using Microsoft.Practices.Prism.Commands;
using BaseControls.ViewModel;
using MyTools.Function01;
using MyTools.Function0A;

namespace MyTools
{
  public class MainWindowViewModel : MainViewModel
  {
    public MainWindowViewModel()
    {
      TestText = "AAA";
      Function0A = new Function0AViewModel();
    }

    protected override void OnNew()
    {
      //base.OnNew();

      _Files.Add(new Function01Holder(this));
      ActiveDocument = _Files.Last();
    }

    private Function0AViewModel _Function0A;
    public Function0AViewModel Function0A
    {
      get { return _Function0A; }
      set
      {
        _Function0A = value;
        RaisePropertyChanged(() => Function0A);
      }
    }
  }
}
