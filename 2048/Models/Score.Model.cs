using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    public class Score: Undoable<Score>
    {
        #region Private members

        private int _myValue;

        #endregion
        #region Public properties

        public static int BestValue { get; set; } = 0;
        public int MyValue
        {
            get { return _myValue; }
            set
            {
                AddUndo(this, "MyValue", _myValue);
                _myValue = value;
                if (value > BestValue)
                {
                    AddUndo(this, "BestValue", BestValue);
                    BestValue = value;
                }
            }
        }

        #endregion
        #region

        public Score()
        {
            _myValue = 0;
        }

        #endregion
        #region Public methods

        public void add(int val)
        {
            MyValue += val;
        }

        #endregion
    }
}
