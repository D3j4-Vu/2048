using _2048.View;
using _2048.ViewModels.Base;
using System.Windows;
using System.Windows.Input;

namespace _2048.ViewModels
{
    public class GameBoardViewModel : ObservableObject
    {
        #region Private members

        GameViewModel game;

        #endregion
        #region Public properties

        public GameBoardView View { get; set; }
        public TileModel[] Tiles { get; set; }

        #endregion
        #region Commands
        
        #endregion
        #region Constructors

        public GameBoardViewModel(GameViewModel game)
        {
            this.game = game;

            setupTiles();

            View = new GameBoardView(this);
        }

        #endregion
        #region Private methods

        private void setupTiles()
        {
            Tiles = new TileModel[16];
            for(int i=0; i < 16; i++)
            {
                Tiles[i] = new TileModel((i+1).ToString());
            }
        }

        #endregion
    }
}
