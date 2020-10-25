using _2048.Logic;
using _2048.View;
using _2048.ViewModels.Base;
using System.Windows;
using System.Windows.Input;

namespace _2048.ViewModels
{
    public class GameBoardViewModel : ObservableObject
    {
        #region Private members

        private GameViewModel game;

        #endregion
        #region Public properties

        public GameBoardView View { get; set; }
        public TileModel[][] Tiles { get; set; }
        

        #endregion
        #region Commands
        
        #endregion
        #region Constructors

        public GameBoardViewModel(GameViewModel game)
        {
            this.game = game;
            setupTiles();
            GameEngine.start(Tiles);
            View = new GameBoardView(this);
        }

        #endregion
        #region Private methods

        private void setupTiles()
        {
            Tiles = new TileModel[4][];
            for (int i = 0; i < 4; i++)
            {
                Tiles[i] = new TileModel[4];
                for (int j = 0; j < 4; j++)
                {
                    Tiles[i][j] = new TileModel(0);
                }
            }
            Tiles[0][0].TileLevel = 1;
            Tiles[1][0].TileLevel = 1;
            Tiles[2][0].TileLevel = 2;
            Tiles[3][0].TileLevel = 3;
            Tiles[0][1].TileLevel = 0;
            Tiles[1][1].TileLevel = 0;
            Tiles[2][1].TileLevel = 1;
            Tiles[3][1].TileLevel = 2;
            Tiles[0][2].TileLevel = 3;
            Tiles[1][2].TileLevel = 1;
            Tiles[2][2].TileLevel = 1;
            Tiles[3][2].TileLevel = 1;
            Tiles[0][3].TileLevel = 1;
            Tiles[1][3].TileLevel = 1;
            Tiles[2][3].TileLevel = 1;
            Tiles[3][3].TileLevel = 2;

        }

        #endregion
    }
}
