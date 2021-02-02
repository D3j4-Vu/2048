using System;
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
        public int BestScore { get { return Score.BestValue; } }
        #endregion
        #region Commands

        public ICommand GoToMainPage { get; set; }
        public ICommand Swipe { get; set; }
        public ICommand ResetGame { get; set; }
        public ICommand UndoMove { get; set; }

        #endregion
        #region Constructors

        public GameViewModel(AppMainViewModel main_page, bool loadSave)
        {
            this.main_page = main_page;

            GameBoardVM = new GameBoardViewModel();
            if(loadSave) GameBoardVM.loadSavedBoard();

            Score.BestValue = Serializator.deserialize<int>(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\game2048\bestScore.txt");

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
            Serializator.serialize(Score.BestValue, Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\game2048\", "bestScore.txt");
            GameBoardVM.saveBoard();

            GameBoardVM.resetBoard();
            UndoManager.ClearAll();
            main_page.goToMainPage();
        }

        #endregion
    }
}
