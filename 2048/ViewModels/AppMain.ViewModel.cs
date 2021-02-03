using System;
using System.IO;
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

        public bool IsGameOnProgres { get; set; }
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
        public ICommand StartSavedGame { get; set; }
        public ICommand CloseCommand { get; set; }

        #endregion
        #region Constructors

        public AppMainViewModel(Window window)
        {
            this.window = window;

            GameVM = null;
            //Bad code!
            IsGameOnProgres = File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\game2048\gameData.txt");

            setupCommands();
            
            View = new AppMainView(this);
        }

        #endregion
        #region Private methods

        private void setupCommands() 
        {
            CloseCommand = new RelayCommand((object arg) => window.Close());
            StartSavedGame = new RelayCommand((object arg) => { GameVM = new GameViewModel(this, true); }, IsGameOnProgres);
            StartGame = new RelayCommand((object arg) => { GameVM = new GameViewModel(this, false); });
        }

        private void updateMainPage()
        {
            //Bad code!
            IsGameOnProgres = File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\game2048\gameData.txt");
            StartSavedGame = new RelayCommand((object arg) => { GameVM = new GameViewModel(this, false); }, IsGameOnProgres);
        }

        private void stopGame()
        {
            //Bad code!
            GameVM = null;
        }

        #endregion
        #region Public methods
            
        public void goToMainPage()
        {
            stopGame();
            updateMainPage();
        }

        #endregion
    }
}
