using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SushiBot
{
    struct СursorPosition
    {
        internal int Left { get; set; }
        internal int Top { get; set; }
        internal СursorPosition(int left, int top)
        {
            Left = left;
            Top = top;
        }
    }
}
