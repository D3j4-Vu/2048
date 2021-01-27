using System.Windows;
using System.Windows.Input;

namespace _2048
{
    public class GameBoardViewModel : UndoableViewModelBase<GameBoardViewModel>
    {
        #region Private members

        private GameViewModel game;

        #endregion
        #region Public properties

        public GameBoardView View { get; set; }
        public BoardModel GameBoard { get; set; }
        public TileModel[][] Tiles
        {
            get { return GameBoard.Tiles; }
        }

        #endregion
        #region Constructors

        public GameBoardViewModel(GameViewModel game)
        {
            this.game = game;
            GameBoard = new BoardModel();
            View = new GameBoardView(this);
        }

        #endregion
        #region Public methods

        public void swipeBoard(string direction)
        {
            GameBoard.moveTiles(direction);
        }

        public void undoSwipe()
        {
            GameBoard.undo();
        }

        public void resetBoard()
        {
            GameBoard.reset();
        }

        #endregion

    }
}
