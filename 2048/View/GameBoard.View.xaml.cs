
using System.Windows.Controls;
using System.Windows.Input;

namespace _2048
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
