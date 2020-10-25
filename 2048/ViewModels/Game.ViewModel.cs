using _2048.Logic;
using _2048.View;
using _2048.ViewModels.Base;
using System.Windows;
using System.Windows.Input;

namespace _2048.ViewModels
{
    public class GameViewModel: ObservableObject
    {
        #region Private members

        private AppMainViewModel main_page;

        #endregion
        #region Public properties

        public GameView View { get; set; }
        public GameBoardViewModel GameBoard { get; set; }
        public string Score { get; set; }
        public string BestScore { get; set; }

        #endregion
        #region Commands

        public ICommand GoToMainPage { get; set; }
        public ICommand ResetGame { get; set; }
        public ICommand UndoMove { get; set; }

        #endregion
        #region Constructors

        public GameViewModel(AppMainViewModel main_page)
        {
            this.main_page = main_page;
            GameBoard = new GameBoardViewModel(this);

            Score = "0";
            BestScore = "0";

            ResetGame = new RelayCommand(() => this.resetGame());
            GoToMainPage = new RelayCommand(() => this.goToMainPage());

            View = new GameView(this);
        }

        #endregion
        #region Public methods

        private void goToMainPage()
        {
            GameBoard.stopGame();
            main_page.goToMainPage();
        }

        private void resetGame()
        {
            GameBoard.stopGame();
            GameBoard.startGame();
        }

        #endregion
        #region Helpers

        #endregion
    }
}
