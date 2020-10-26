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
        #region Public methods

        public void startGame()
        {
            resetTiles();
            GameEngine.start(Tiles);
        }

        public void stopGame()
        {
            GameEngine.stop();
        }

        public void undoMove()
        {
            GameEngine.undoMove();
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
        }

        private void resetTiles()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Tiles[i][j].TileLevel = 0;
                }
            }
        }
        #endregion
    }
}
