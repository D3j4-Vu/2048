using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    /// <summary>
    /// The interface describing the Undo operation.
    /// </summary>
    public interface IUndo
    {
        /// <summary>
        /// The optional name for the Undo/Redo property.
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Code to perform the Undo operation.
        /// </summary>
        void Undo();
    }
}
