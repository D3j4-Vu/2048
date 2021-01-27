using System.Windows;
using System.Windows.Input;

namespace _2048
{
    public class GameViewModel : ViewModelBase
    {
        #region Private members

        private AppMainViewModel main_page;

        #endregion
        #region Public properties

        public GameView View { get; set; }
        public GameBoardViewModel GameBoardVM { get; set; }
        public string Score { get; set; }
        public string BestScore { get; set; }
        #endregion
        #region Commands

        public ICommand GoToMainPage { get; set; }
        public ICommand Swipe { get; set; }
        public ICommand ResetGame { get; set; }
        public ICommand UndoMove { get; set; }


        #endregion
        #region Constructors

        public GameViewModel(AppMainViewModel main_page)
        {
            this.main_page = main_page;
            Score = "0";
            BestScore = "0";

            GameBoardVM = new GameBoardViewModel();

            setupCommands();

            View = new GameView(this);
        }

        #endregion

        #region Private methods

        private void setupCommands()
        {
            Swipe = new RelayCommand((object arg) => GameBoardVM.swipeBoard(arg.ToString()));
            ResetGame = new RelayCommand((object arg) => GameBoardVM.resetBoard());
            UndoMove = new RelayCommand((object arg) => GameBoardVM.undoSwipe());
            GoToMainPage = new RelayCommand((object arg) => goToMainPage());
        }


        private void goToMainPage()
        {
            GameBoardVM.resetBoard();
            main_page.goToMainPage();
        }

        #endregion
    }
}
