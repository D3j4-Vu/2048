using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    public interface IUndo
    {
        string Name { get; }
        void Undo();
    }
}
