﻿using PropertyChanged;
using System.ComponentModel;


namespace _2048.ViewModels.Base
{
    /// <summary>
    /// Class that casts "PropertyChanged" event when needed.
    /// </summary>
    [AddINotifyPropertyChangedInterface]
    public class ObservableObject : INotifyPropertyChanged
    {
        /// <summary>
        /// The event that is casted when any child property changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (IChannelSender, e) => { };
    }
}
