
using System.Windows.Controls;


namespace _2048
{
    /// <summary>
    /// Interaction logic for AppMain.xaml
    /// </summary>
    public partial class AppMainView : UserControl
    {
        public AppMainView(object ViewModel)
        {
            InitializeComponent();
            DataContext = ViewModel;
        }
    }
}

