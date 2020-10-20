using _2048.View;
using _2048.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _2048.ViewModels
{
    public class MainWindowViewModel: ObservableObject
    {
        #region Public Members

        public AppMainViewModel AppMainVM { get; set; }

        #endregion
        #region Constructors

        public MainWindowViewModel(Window window)
        {
            this.AppMainVM = new AppMainViewModel(window);
        }

        #endregion
    }
}
