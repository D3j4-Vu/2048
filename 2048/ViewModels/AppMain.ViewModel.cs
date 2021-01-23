using System.Windows;
using System.Windows.Input;

namespace _2048
{
    public class AppMainViewModel: ViewModelBase
    {
        #region Private members

        private Window window;

        #endregion
        #region Public properties

        public AppMainView View { get; set; }

        public GameViewModel GameVM { get; set; }

        public Visibility contentVisibility {
            get
            {
                if (GameVM == null) return Visibility.Collapsed;
                else return Visibility.Visible;
            }
        }
        #endregion
        #region Commands

        public ICommand StartGame { get; set; }
        public ICommand CloseCommand { get; set; }

        #endregion
        #region Constructors

        public AppMainViewModel(Window window)
        {
            this.window = window;

            GameVM = null;
            
            CloseCommand = new RelayCommand(() => this.window.Close());
            StartGame = new RelayCommand(() => startGame());

            View = new AppMainView(this);
        }

        #endregion
        #region Private methods

        private void startGame()
        {
            GameVM = new GameViewModel(this);
        }


        private void stopGame()
        {
            GameVM = null;
        }

        #endregion
        #region Public methods
            
        public void goToMainPage()
        {
            //To do: Save game
            stopGame();
        }

        #endregion
    }
}
