using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    public class UndoableProperty<T> : IUndo
    {
        #region Member
        private object _oldValue;
        private string _property;
        private T _instance;
        #endregion

        public UndoableProperty(string property, T instance, object oldValue)
            : this(property, instance, oldValue, property)
        {
        }

        public UndoableProperty(string property, T instance, object oldValue, string name)
            : base()
        {
            _instance = instance;
            _property = property;
            _oldValue = oldValue;

            Name = name;

            // Notify the calling application that this should be added to the undo list.
            UndoManager.Add(this);
        }

        public string Name { get; private set; }

        public void Undo()
        {
            _instance.GetType().GetProperty(_property).SetValue(_instance, _oldValue, null);
        }
    }
}
