using _2048.View;
using _2048.ViewModels.Base;
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

        #endregion
        #region Commands

        
        #endregion
        #region Constructors

        public GameBoardViewModel(GameViewModel game)
        {
            this.game = game;
            

            View = new GameBoardView(this);
        }

        #endregion
        #region Private methods

        #endregion
    }
}
