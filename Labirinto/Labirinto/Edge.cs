using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labirinto
{

    public class Edge
    {

        public int X { get; set; }
        public int Y
        {
            get; set;
        }
        public int Value { get; set; }

        public Edge(int x, int y, int value)
        {
            this.X = x;
            this.Y = y;
            this.Value = value;
        }
    }
}
