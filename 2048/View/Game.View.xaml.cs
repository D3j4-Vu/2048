
using System.Windows.Controls;

namespace _2048.View
{
    /// <summary>
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class GameView : UserControl
    {
        public GameView(object ViewModel)
        {
            InitializeComponent();
            DataContext = ViewModel;
            
        }
    }
}
