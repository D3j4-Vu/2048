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
            this.AppMainVM = new AppMainViewModel(window);
        }

        #endregion
    }
}
