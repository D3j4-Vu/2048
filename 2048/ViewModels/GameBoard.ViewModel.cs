using System.Windows;
using System.Windows.Input;

namespace _2048
{
    public class GameBoardViewModel: ViewModelBase
    {
        #region Public properties

        public bool IsLeftUndoMoves { get { return UndoManager.isLeftUndos; } }
        public GameBoardView View { get; set; }
        public BoardModel GameBoard { get; set; }
        public int Score { get { return GameBoard.Score; } }
        public TileModel[][] Tiles
        {
            get { return GameBoard.Tiles; }
        }

        #endregion
        #region Constructors

        public GameBoardViewModel()
        {
            GameBoard = new BoardModel();
            View = new GameBoardView(this);
        }

        #endregion
        #region Public methods

        public void swipeBoard(string direction)
        {
            GameBoard.moveTiles(direction);
            OnPropertyChanged("IsLeftUndoMoves");
            OnPropertyChanged("Score");
        }

        public void undoSwipe()
        {
            GameBoard.undo();
            OnPropertyChanged("IsLeftUndoMoves");
            OnPropertyChanged("Score");
        }

        public void resetBoard()
        {
            GameBoard.reset();
            OnPropertyChanged("IsLeftUndoMoves");
            OnPropertyChanged("Score");
        }

        #endregion

    }
}
