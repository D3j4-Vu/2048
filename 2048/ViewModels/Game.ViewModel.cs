using System.Windows;
using System.Windows.Input;

namespace _2048
{
    public class GameViewModel : ViewModelBase
    {
        #region Private members

        private AppMainViewModel main_page;
        private const int undoLimit = 5;

        #endregion
        #region Public properties

        public GameView View { get; set; }
        public GameBoardViewModel GameBoardVM { get; set; }
        public bool IsLeftUndoMoves { get { return UndoManager.isLeftUndos; } }
        public int BestScore { 
            get { return Score.BestValue; } 
            set
            {
                Score.BestValue = value;
            }
        }
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

            BestScore = 0;
            GameBoardVM = new GameBoardViewModel();

            UndoManager.UndoLimit = undoLimit;
            UndoManager.ClearAll();
            
            setupCommands();

            View = new GameView(this);
        }

        #endregion
        #region Private methods

        private void setupCommands()
        {
            Swipe = new RelayCommand((object arg) => this.doSwipe(arg.ToString()));
            ResetGame = new RelayCommand((object arg) => this.doResetGame());
            UndoMove = new RelayCommand((object arg) => { 
                UndoManager.Undo();
                OnPropertyChanged("IsLeftUndoMoves");
                OnPropertyChanged("BestScore");
            });
            GoToMainPage = new RelayCommand((object arg) => goToMainPage());
        }

        private void doSwipe(string direction)
        {
            UndoManager.splitUndo();
            GameBoardVM.swipeBoard(direction);
            OnPropertyChanged("IsLeftUndoMoves");
            OnPropertyChanged("BestScore");
        }

        private void doResetGame()
        {
            GameBoardVM.resetBoard();
            UndoManager.ClearAll();
            OnPropertyChanged("IsLeftUndoMoves");
            OnPropertyChanged("BestScore");
        }

        private void goToMainPage()
        {
            GameBoardVM.resetBoard();
            UndoManager.ClearAll();
            main_page.goToMainPage();
        }

        #endregion
    }
}
