
using System.Windows.Controls;


namespace _2048.View
{
    public partial class GameBoardView : UserControl
    {
        public GameBoardView(object view_model)
        {
            InitializeComponent();
            DataContext = view_model;
        }
    }
}
