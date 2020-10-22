﻿
using _2048.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace _2048
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel(this.window);
            
        }

    }
}
