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
            
            CloseCommand = new RelayCommand((object arg) => window.Close());
            StartSavedGame = new RelayCommand((object arg) => startSavedGame());
            StartGame = new RelayCommand((object arg) => startGame());

            //Bad code!
            IsGameOnProgres = File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\game2048\gameData.txt");
            
            View = new AppMainView(this);
        }

        #endregion
        #region Private methods

        private void startSavedGame()
        {
            //Bad code! (need to use relayCMD if can execuce)
            if (IsGameOnProgres)
                GameVM = new GameViewModel(this, true);
        }

        private void startGame()
        {
            GameVM = new GameViewModel(this,false);
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
            //Bad code!
            IsGameOnProgres = File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\game2048\gameData.txt");
        }

        #endregion
    }
}
