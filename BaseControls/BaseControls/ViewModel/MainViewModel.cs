using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;
using System.Windows.Input;
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
using BaseControls.Message;
using System.Collections.ObjectModel;

namespace BaseControls.ViewModel
{
  public class MainViewModel : NotificationObject
  {
    /// <summary>
    /// コンストラクタ
    /// </summary>
    public MainViewModel()
    {
      TestText = "Start";
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

    //--------------------------------
    protected ObservableCollection<DocViewModel> _Files = new ObservableCollection<DocViewModel>();
    ReadOnlyObservableCollection<DocViewModel> _ReadOnlyFiles = null;
    public ReadOnlyObservableCollection<DocViewModel> Files
    {
      get
      {
        return this._ReadOnlyFiles = this._ReadOnlyFiles ??
          new ReadOnlyObservableCollection<DocViewModel>(_Files);
      }
    }

    #region NewCommand
    DelegateCommand _NewCommand = null;
    public DelegateCommand NewCommand
    {
      get
      {
        return this._NewCommand = this._NewCommand ??
          new DelegateCommand(OnNew);
      }
    }

    protected virtual void OnNew()
    {
      _Files.Add(new DocViewModel(this));
      ActiveDocument = _Files.Last();

    }
    #endregion

    #region ActiveDocument
    private DocViewModel _ActiveDocument = null;
    public DocViewModel ActiveDocument
    {
      get { return _ActiveDocument; }
      set
      {
        if (_ActiveDocument != value)
        {
          _ActiveDocument = value;
          RaisePropertyChanged(() => ActiveDocument);
          if (ActiveDoumentChanged != null)
          {
            ActiveDoumentChanged(this, EventArgs.Empty);
          }

        }
      }
    }

    public event EventHandler ActiveDoumentChanged;
    #endregion

    internal void Close(DocViewModel fileToClose)
    {
      if (fileToClose.IsDirty)
      {
        //var res = MessageBox.Show(string.Format("Save changes for file '{0}'?", fileToClose.FileName), "AvalonDock Test App", MessageBoxButton.YesNoCancel);
        //if (res == MessageBoxResult.Cancel)
        //  return;
        //if (res == MessageBoxResult.Yes)
        //{
        //  Save(fileToClose);
        //}
      }

      _Files.Remove(fileToClose);
    }

    //internal void Save(DocViewModel fileToSave, bool saveAsFlag = false)
    //{
    //  if (fileToSave.FilePath == null || saveAsFlag)
    //  {
    //    var dlg = new SaveFileDialog();
    //    if (dlg.ShowDialog().GetValueOrDefault())
    //      fileToSave.FilePath = dlg.SafeFileName;
    //  }

    //  File.WriteAllText(fileToSave.FilePath, fileToSave.TextContent);
    //  ActiveDocument.IsDirty = false;
    //}

    //#region OpenCommand
    //DelegateCommand<object> _openCommand = null;
    //public DelegateCommand<object> OpenCommand
    //{
    //  get
    //  {
    //    if (_openCommand == null)
    //    {
    //      _openCommand = new DelegateCommand<object>((p) => OnOpen(p), (p) => CanOpen(p));
    //    }

    //    return _openCommand;
    //  }
    //}

    //private bool CanOpen(object parameter)
    //{
    //  return true;
    //}

    //private void OnOpen(object parameter)
    //{
    //  var dlg = new OpenFileDialog();
    //  if (dlg.ShowDialog().GetValueOrDefault())
    //  {
    //    var fileViewModel = Open(dlg.FileName);
    //    ActiveDocument = fileViewModel;
    //  }
    //}

    //public FileViewModel Open(string filepath)
    //{
    //  // Verify whether file is already open in editor, and if so, show it
    //  var fileViewModel = _Files.FirstOrDefault(fm => fm.FilePath == filepath);

    //  if (fileViewModel != null)
    //  {
    //    this.ActiveDocument = fileViewModel; // File is already open so shiw it

    //    return fileViewModel;
    //  }

    //  fileViewModel = _Files.FirstOrDefault(fm => fm.FilePath == filepath);
    //  if (fileViewModel != null)
    //    return fileViewModel;

    //  fileViewModel = new FileViewModel(filepath, this);
    //  _Files.Add(fileViewModel);
    //  //this.RecentFiles.AddNewEntryIntoMRU(filepath);

    //  return fileViewModel;
    //}

    //#endregion




    //----------------------------------------------------------
    private DelegateCommand _OpenFile;
    public DelegateCommand OpenFile
    {
      get
      {
        return this._OpenFile = this._OpenFile ??
          new DelegateCommand(openFile);
      }
    }

    private void openFile()
    {
      TestText = "open file!!";

      OpenFileRequest.Raise(new Confirmation { Title = "", Content = new FileMessage() },
        (confirmation) =>
        {
          if (confirmation.Confirmed)
          {
            var fileMessage = confirmation.Content as FileMessage;
            TestText = fileMessage.FileName;
          }
        }
        );
    }

    private DelegateCommand _saveFile;
    public DelegateCommand SaveFile
    {
      get
      {
        return this._saveFile = this._saveFile ??
          new DelegateCommand(saveFile);
      }
    }

    private void saveFile()
    {
      TestText = "save File!!";

      SaveFileRequest.Raise(new Confirmation { Title = "", Content = new FileMessage() },
        (confirmation) =>
        {
          if (confirmation.Confirmed)
          {
            var fileMessage = confirmation.Content as FileMessage;
            TestText = fileMessage.FileName;
          }
        }
        );
    }

    private DelegateCommand _SelectFolder;
    public DelegateCommand SelectFolder
    {
      get
      {
        return this._SelectFolder = this._SelectFolder ??
          new DelegateCommand(selectFolder);
      }
    }

    private void selectFolder()
    {
      TestText = "select Folder!!";

      SelectFolderRequest.Raise(new Confirmation { Title = "", Content = new FileMessage() },
        (confirmation) =>
        {
          if (confirmation.Confirmed)
          {
            var fileMessage = confirmation.Content as FileMessage;
            TestText = fileMessage.FileName;
          }
        }
        );
    }

    private InteractionRequest<Confirmation> _OpenFileRequest;
    public InteractionRequest<Confirmation> OpenFileRequest
    {
      get
      {
        return this._OpenFileRequest = this._OpenFileRequest ??
          new InteractionRequest<Confirmation>();
      }
    }

    private InteractionRequest<Confirmation> _SaveFileRequest;
    public InteractionRequest<Confirmation> SaveFileRequest
    {
      get
      {
        return this._SaveFileRequest = this._SaveFileRequest ??
          new InteractionRequest<Confirmation>();
      }
    }

    private InteractionRequest<Confirmation> _SelectFolderRequest;
    public InteractionRequest<Confirmation> SelectFolderRequest
    {
      get
      {
        return this._SelectFolderRequest = this._SelectFolderRequest ??
          new InteractionRequest<Confirmation>();
      }
    }
  }
}
