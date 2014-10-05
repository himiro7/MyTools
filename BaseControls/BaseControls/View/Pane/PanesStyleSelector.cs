using System.Windows;
using System.Windows.Controls;
using BaseControls.ViewModel;


namespace BaseControls.View.Pane
{

  class PanesStyleSelector : StyleSelector
  {
    public Style ToolStyle
    {
      get;
      set;
    }

    public Style FileStyle
    {
      get;
      set;
    }

    public Style RecentFilesStyle
    {
      get;
      set;
    }

    public Style DocStyle { get; set; }

    public override System.Windows.Style SelectStyle(object item, System.Windows.DependencyObject container)
    {
    //  if (item is RecentFilesViewModel)
    //    return RecentFilesStyle;

    //if (item is ToolViewModel)
    //    return ToolStyle;

      if (item is DocViewModel)
        return DocStyle;

      return base.SelectStyle(item, container);
    }
  }
}
