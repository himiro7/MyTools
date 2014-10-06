using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BaseControls;
using BaseControls.ViewModel;

namespace MyTools.Function01
{
  public class Function01Holder : DocViewModel
  {
    public Function01Holder(MainWindowViewModel mainWindowViewModel) : base(mainWindowViewModel)
    {
      Title = "Func01";
      MyContent = new Function01ViewModel();
    }

    private Function01ViewModel _MyContent;
    public Function01ViewModel MyContent
    {
      get { return _MyContent; }
      set
      {
        _MyContent = value;
        RaisePropertyChanged(() => MyContent);
      }
    }

  }
}
