﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BaseControls.ViewModel;
using BaseControls.ViewModel.Base;
using Microsoft.Practices.Prism.Commands;

namespace BaseControls.ViewModel
{
  public class DocViewModel : PaneViewModel
  {
    public DocViewModel(string filePath, MainViewModel mainViewModel)
    {
      //FilePath = filePath;
      //Title = FileName;
      Title = filePath;

      this.Workspace = mainViewModel;
      //this.MyTestViewModel = new TestViewModel();
    }

    public DocViewModel(MainViewModel mainWindowViewModel)
    {
      IsDirty = true;
      Title = "new";

      this.Workspace = mainWindowViewModel;
    }

    //private TestViewModel _MyTestViewModel;
    //public TestViewModel MyTestViewModel
    //{
    //  get { return _MyTestViewModel; }
    //  set
    //  {
    //    _MyTestViewModel = value;
    //    RaisePropertyChanged(() => MyTestViewModel);
    //  }
    //}

    //#region FilePath
    //private string _filePath = null;
    //public string FilePath
    //{
    //  get { return _filePath; }
    //  set
    //  {
    //    if (_filePath != value)
    //    {
    //      _filePath = value;
    //      RaisePropertyChanged("FilePath");
    //      RaisePropertyChanged("FileName");
    //      RaisePropertyChanged("Title");

    //      if (File.Exists(_filePath))
    //      {
    //        _textContent = File.ReadAllText(_filePath);
    //        //TextContent = File.ReadAllText(_filePath);
    //        ContentId = _filePath;
    //      }
    //    }
    //  }
    //}
    //#endregion


    //public string FileName
    //{
    //  get
    //  {
    //    if (FilePath == null)
    //      return "Noname" + (IsDirty ? "*" : "");

    //    return System.IO.Path.GetFileName(FilePath) + (IsDirty ? "*" : "");
    //  }
    //}



    #region TextContent

    private string _textContent = string.Empty;
    public string TextContent
    {
      get { return _textContent; }
      set
      {
        if (_textContent != value)
        {
          _textContent = value;
          RaisePropertyChanged(()=>TextContent);
          IsDirty = true;
        }
      }
    }

    #endregion

    #region IsDirty

    private bool _isDirty = false;
    public bool IsDirty
    {
      get { return _isDirty; }
      set
      {
        if (_isDirty != value)
        {
          _isDirty = value;
          RaisePropertyChanged("IsDirty");
          RaisePropertyChanged("FileName");
        }
      }
    }

    #endregion

    //#region SaveCommand
    //DelegateCommand<object> _saveCommand = null;
    //public ICommand SaveCommand
    //{
    //  get
    //  {
    //    if (_saveCommand == null)
    //    {
    //      _saveCommand = new DelegateCommand<object>((p) => OnSave(p), (p) => CanSave(p));
    //    }

    //    return _saveCommand;
    //  }
    //}

    //private bool CanSave(object parameter)
    //{
    //  return IsDirty;
    //}

    //private void OnSave(object parameter)
    //{
    //  Workspace.Save(this, false);
    //}

    //#endregion

    //#region SaveAsCommand
    //DelegateCommand<object> _saveAsCommand = null;
    //public ICommand SaveAsCommand
    //{
    //  get
    //  {
    //    if (_saveAsCommand == null)
    //    {
    //      _saveAsCommand = new DelegateCommand<object>(OnSaveAs, CanSaveAs);
    //    }

    //    return _saveAsCommand;
    //  }
    //}

    //private bool CanSaveAs(object parameter)
    //{
    //  return IsDirty;
    //}

    //private void OnSaveAs(object parameter)
    //{
    //  Workspace.Save(this, true);
    //}

    //#endregion

    #region CloseCommand
    DelegateCommand _closeCommand = null;
    public DelegateCommand CloseCommand
    {
      get
      {
        if (_closeCommand == null)
        {
          _closeCommand = new DelegateCommand(OnClose);
        }

        return _closeCommand;
      }
    }

    private bool CanClose()
    {
      return true;
    }

    private void OnClose()
    {
      Workspace.Close(this);
    }
    #endregion

    public override Uri IconSource
    {
      get
      {
        // This icon is visible in AvalonDock's Document Navigator window
        return new Uri("pack://application:,,,/Edi;component/Images/document.png", UriKind.RelativeOrAbsolute);
      }
    }

  }

}
