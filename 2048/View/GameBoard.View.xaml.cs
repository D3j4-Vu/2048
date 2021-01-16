
using _2048.ViewModels;
using System.Windows.Controls;
using System.Windows.Input;

namespace _2048.View
{
    public partial class GameBoardView : UserControl
    {


        public GameBoardView(object view_model)
        {
            InitializeComponent();
            DataContext = view_model;
            vm = (GameBoardViewModel)view_model;
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Focusable = true;
            this.Focus();
        }

        //temporary code, just for testing until I do it in wright way.

        GameBoardViewModel vm;
        private void UserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up || e.Key == Key.Down || e.Key == Key.Left || e.Key == Key.Right)
            {
                vm.moveTiles(e.Key.ToString());
                e.Handled = true;
            }
        }
    }
}
