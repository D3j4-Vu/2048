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
        public TileModel[][] Tiles { get; set; }
        public bool IsLeftUndoMoves { get; set; }


        #endregion
        #region Constructors

        public GameBoardViewModel(GameViewModel game)
        {
            this.game = game;
            IsLeftUndoMoves = false;
            Tiles = setupTiles();
            View = new GameBoardView(this);
            generateTile(2);
        }

        #endregion
        #region Public methods

        public void generateTile(int timesToGenerate = 1)
        {
            for (int i = 0; i < timesToGenerate; i++)
                TileGenerator.generateTile(Tiles);
        }

        public void moveTiles(string direction)
        {
            TileModel[][] cloned = cloneTiles(Tiles);
            if (TileMover.moveTiles(Tiles, direction))
            {
                TileGenerator.generateTile(Tiles);
                AddUndo(this, "Tiles", cloned, Tiles);
            }
            //temporary
            checkIfUndoAvailable();
        }

        public void resetTiles()
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    Tiles[i][j].TileLevel = 0;
        }

        public void checkIfUndoAvailable()
        {
            if (UndoManager.IsLeftUndoMoves == true)
            {
                IsLeftUndoMoves = true;
            }
            else
            {
                IsLeftUndoMoves = false;
            }
        }

        #endregion
        #region Private methods

        private static TileModel[][] setupTiles()
        {
            TileModel[][] tiles = new TileModel[4][];
            for (int i = 0; i < 4; i++)
            {
                tiles[i] = new TileModel[4];
                for (int j = 0; j < 4; j++)
                    tiles[i][j] = new TileModel(0);
            }
            return tiles;
        }

        static private TileModel[][] cloneTiles(TileModel[][] from)
        {
            TileModel[][] tiles = new TileModel[4][];
            for (int i = 0; i < 4; i++)
            {
                tiles[i] = new TileModel[4];
                for (int j = 0; j < 4; j++)
                    tiles[i][j] = new TileModel(from[i][j].TileLevel);
                    
            }
            return tiles;
        }

        #endregion



    }
}
