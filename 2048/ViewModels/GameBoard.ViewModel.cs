using _2048.Logic;
using _2048.View;
using _2048.ViewModels.Base;
using System.Windows;
using System.Windows.Input;

namespace _2048.ViewModels
{
    public class GameBoardViewModel : UndoableViewModelBase<GameBoardViewModel>
    {
        #region Private members

        private GameViewModel game;
        private TileModel[][] _tiles;

        #endregion
        #region Public properties

        public GameBoardView View { get; set; }
        public TileModel[][] Tiles {
            get { return _tiles; }
            set
            {
                if (_tiles != value)
                {
                    AddUndo(this, "Tiles", _tiles, value);
                    _tiles = value;
                }
            }
        }
        

        #endregion
        #region Constructors

        public GameBoardViewModel(GameViewModel game)
        {
            this.game = game;
            _tiles = setupTiles();
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
            cloneTiles(Tiles, temp_tiles);
            if (TileMover.moveTiles(Tiles, direction))
            {
                cloneTiles(temp_tiles, OldTiles);
                TileGenerator.generateTile(Tiles);
            }
        }

        public void resetTiles()
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    Tiles[i][j].TileLevel = 0;
        }

        public void undoMove()
        {
            cloneTiles(OldTiles, Tiles);
        }

        #endregion
        #region Private methods

        private static TileModel[][] setupTiles()
        {
            TileModel[][] tiles;
            tiles = new TileModel[4][];
            for (int i = 0; i < 4; i++)
            {
                tiles[i] = new TileModel[4];
                for (int j = 0; j < 4; j++)
                    tiles[i][j] = new TileModel(0);
            }
            return tiles;
        }

        #endregion






















        //  temporary code !!!!!!!

        private TileModel[][] temp_tiles = setupTiles();
        private TileModel[][] OldTiles = setupTiles();

        static private void cloneTiles(TileModel[][] from, TileModel[][] to)
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    to[i][j].TileLevel = from[i][j].TileLevel;
        }


        //






    }
}
