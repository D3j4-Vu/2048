using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    public static class UndoManager
    {
        #region Private members

        private static bool undoInProgress = false;

        private static ObservableCollection<int> _movesCounts;
        private static ObservableCollection<IUndo> _undoList;

        #endregion
        #region Public properties

        public static bool isLeftUndos { get { return MovesCounts.Count > 0 ? true : false; } }
        public static int? UndoLimit { get; set; }
        public static ObservableCollection<int> MovesCounts 
        {
            get
            {
                if (_movesCounts == null)
                    _movesCounts = new ObservableCollection<int>();
                return _movesCounts;
            }
            private set
            {
                _movesCounts = value;    
            }
        }
        public static ObservableCollection<IUndo> UndoList
        {
            get
            {
                if (_undoList == null)
                    _undoList = new ObservableCollection<IUndo>();
                return _undoList;
            }
            private set
            {
                _undoList = value;
            }
        }
        public static bool CanUndo
        {
            get
            {
                return UndoList.Count > 0;
            }
        }
        #endregion
        #region Public methods

        public static void Add<T>(T instance) where T : IUndo
        {
            if (instance == null)
                throw new ArgumentNullException("instance");
            if (undoInProgress)
                return;
            UndoList.Add(instance);
            if (MovesCounts.Count == 0)
                MovesCounts.Add(0);
            MovesCounts[MovesCounts.Count - 1]++;
        }
        public static void ClearAll()
        {
            MovesCounts.Clear();
            UndoList.Clear();
        }
        public static void Undo()
        {
            undoInProgress = true;
            if (MovesCounts.Count != 0)
            {
                if (MovesCounts.Last().Equals(0))
                    MovesCounts.RemoveAt(MovesCounts.Count - 1);
                for (int i = 0; i < MovesCounts[MovesCounts.Count - 1]; i++)
                    if (UndoList.Count > 0)
                    {
                        IUndo item = UndoList.Last();
                        UndoList.RemoveAt(UndoList.Count - 1);
                        item.Undo();
                    }
                MovesCounts.RemoveAt(MovesCounts.Count - 1);
            }
            undoInProgress = false;
        }

        public static void splitUndo()
        {
            if (MovesCounts.Count > 0 && MovesCounts.Last().Equals(0))
                return;
            MovesCounts.Add(0);
            trimUndos();
        }
        #endregion
        #region Private regions

        private static void trimUndos()
        {
            if (UndoLimit == null)
                return;
            if (MovesCounts.Count <= UndoLimit.Value)
                return;
            for (int i = 0; i < MovesCounts[0]; i++)
                UndoList.RemoveAt(0);
            MovesCounts.RemoveAt(0);
        }

        #endregion
    }
}
