
using _2048.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace _2048.View
{
    /// <summary>
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class GameView : UserControl
    {
        GameViewModel ViewModel;

        public GameView(object ViewModel)
        {
            InitializeComponent();
            this.ViewModel = ViewModel as GameViewModel;
            DataContext = ViewModel;
            
        }

    }

}
