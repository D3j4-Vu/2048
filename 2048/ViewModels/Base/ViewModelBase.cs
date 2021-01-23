using PropertyChanged;
using System.ComponentModel;


namespace _2048
{
    /// <summary>
    /// Class that casts "PropertyChanged" event when needed.
    /// </summary>
    [AddINotifyPropertyChangedInterface]
    public class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// The event that is casted when any child property changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };


        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
