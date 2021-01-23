using System.Windows;

namespace _2048
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
