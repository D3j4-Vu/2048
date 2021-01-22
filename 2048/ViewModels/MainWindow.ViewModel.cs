using _2048.ViewModels.Base;
using System.Windows;

namespace _2048.ViewModels
{
    public class MainWindowViewModel: ViewModelBase
    {
        #region Public Members

        public AppMainViewModel AppMainVM { get; set; }

        #endregion
        #region Constructors

        public MainWindowViewModel(Window window)
        {
            UndoManager.MaximumUndoLimit = 5;

            this.AppMainVM = new AppMainViewModel(window);
        }

        #endregion
    }
}
