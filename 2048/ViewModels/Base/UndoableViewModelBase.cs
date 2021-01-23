using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    public abstract class UndoableViewModelBase<T> : ViewModelBase
    {
        private List<UndoableProperty<T>> _undoables;

        /// <summary>
        /// Get the list of undoable/redoable entries for this VM.
        /// </summary>
        protected List<UndoableProperty<T>> Undoable
        {
            get
            {
                if (_undoables == null)
                    _undoables = new List<UndoableProperty<T>>();
                return _undoables;
            }
        }

        /// <summary>
        /// Initializes a new instance of <see cref="UndoableViewModelBase"/>
        /// </summary>
        public UndoableViewModelBase() : base() { }

        /// <summary>
        /// Add an item to the undoable list.
        /// </summary>
        /// <param name="instance">The instance to add the undoable item against.</param>
        /// <param name="property">The property change.</param>
        /// <param name="oldValue">The original value.</param>
        /// <param name="newValue">The updated value.</param>
        protected void AddUndo(T instance, string property, object oldValue, object newValue)
        {
            AddUndo(instance, property, oldValue, newValue, property);
        }

        /// <summary>
        /// Add an item to the undoable list.
        /// </summary>
        /// <param name="instance">The instance to add the undoable item against.</param>
        /// <param name="property">The property change.</param>
        /// <param name="oldValue">The original value.</param>
        /// <param name="newValue">The updated value.</param>
        /// <param name="name">The name of the undo operation.</param>
        protected void AddUndo(T instance, string property, object oldValue, object newValue, string name)
        {
            Undoable.Add(new UndoableProperty<T>(property, instance, oldValue, newValue, name));
        }


    }
}
