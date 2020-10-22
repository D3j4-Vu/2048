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

        #endregion
        #region Constructors

        public GameViewModel(AppMainViewModel main_page)
        {
            this.main_page = main_page;
            GameBoard = new GameBoardViewModel(this);

            Score = "0";
            BestScore = "0";

            GoToMainPage = new RelayCommand(() => this.main_page.goToMainPage());

            View = new GameView(this);
        }

        #endregion
        #region Public methods

        public void swipe(Key kb_input)
        {
            TileMover.moveTiles(GameBoard.Tiles, kb_input.ToString());
        }


        #endregion
        #region Helpers

        #endregion
    }
}
