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
        protected List<UndoableProperty<T>> Undoables
        {
            get
            {
                if (_undoables == null)
                    _undoables = new List<UndoableProperty<T>>();
                return _undoables;
            }
        }
        public Undoable() : base() { }
        protected void AddUndo(T instance, string property, object oldValue)
        {
            AddUndo(instance, property, oldValue, property);
        }
        protected void AddUndo(T instance, string property, object oldValue, string name)
        {
            Undoables.Add(new UndoableProperty<T>(property, instance, oldValue, name));
        }
    }
}
