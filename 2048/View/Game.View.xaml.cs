﻿
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace _2048
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

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Focusable = true;
            this.Focus();
        }

    }

}
