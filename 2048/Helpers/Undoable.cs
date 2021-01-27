using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    public abstract class Undoable<T>: ObservableObject
    {
        private List<UndoableProperty<T>> _undoables;

        /// <summary>
        /// Get the list of undoable/redoable entries for this VM.
        /// </summary>
        protected List<UndoableProperty<T>> Undoables
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
        public Undoable() : base() { }

        /// <summary>
        /// Add an item to the undoable list.
        /// </summary>
        /// <param name="instance">The instance to add the undoable item against.</param>
        /// <param name="property">The property change.</param>
        /// <param name="oldValue">The original value.</param>
        /// <param name="newValue">The updated value.</param>
        protected void AddUndo(T instance, string property, object oldValue)
        {
            AddUndo(instance, property, oldValue, property);
        }

        /// <summary>
        /// Add an item to the undoable list.
        /// </summary>
        /// <param name="instance">The instance to add the undoable item against.</param>
        /// <param name="property">The property change.</param>
        /// <param name="oldValue">The original value.</param>
        /// <param name="newValue">The updated value.</param>
        /// <param name="name">The name of the undo operation.</param>
        protected void AddUndo(T instance, string property, object oldValue, string name)
        {
            Undoables.Add(new UndoableProperty<T>(property, instance, oldValue, name));
        }


    }
}
