using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using Xceed.Wpf.AvalonDock.Layout;
using BaseControls.ViewModel;

namespace BaseControls.View.Pane
{


  class PanesTemplateSelector : DataTemplateSelector
    {
        public PanesTemplateSelector()
        {
        
        }


        public DataTemplate FileViewTemplate
        {
            get;
            set;
        }

        public DataTemplate RecentFilesViewTemplate
        {
          get;
          set;
        }

        public DataTemplate FileStatsViewTemplate
        {
            get;
            set;
        }

        public DataTemplate DocViewTemplate { get; set; }

        public override System.Windows.DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
        {
            var itemAsLayoutContent = item as LayoutContent;

            if (item is DocViewModel)
                return DocViewTemplate;

            //if (item is FileStatsViewModel)
            //    return FileStatsViewTemplate;

            //if (item is RecentFilesViewModel)
            //  return RecentFilesViewTemplate;

            return base.SelectTemplate(item, container);
        }
    }
}
