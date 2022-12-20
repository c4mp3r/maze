using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labirinto
{
    public class Celula
    {

        private Point topleft, centro;
        private int squareSize; 
        private Pen p; 
        private Color col;
        private bool[] walls = { true, true, true, true }; 

        private bool v = false;
        public int X { get; set; }
        public int Y { get; set; }
        public enum dir : int { N = 0, S, E, W }
        public Celula(int sqz, int x, int y)
        {
            squareSize = sqz;
            col = Color.Blue;
            p = new Pen(col);
            X = x;
            Y = y;
        }

        public Point Topleft
        {
            get
            {
                return topleft;
            }
            set
            {
                topleft = value;
                centro = new Point((topleft.X + (topleft.X + squareSize)) / 2 - squareSize / 4,
                                    ((topleft.Y + (topleft.Y + squareSize)) / 2) - squareSize / 4);
            }
        }

        public Point Center { get => centro; }

        public int SquareSize { get => squareSize; set => squareSize = value; }
        public Pen P { get => p; set => p = value; }
        public Color C { get => col; set => col = value; }
        public bool[] Walls { get => walls; set => walls = value; }
        public bool Visited { get => v; set => v = value; }

        public void derrubaWall(int w)
        {
            if (w == 3) this.walls[3] = false;
            else if (w == 2) this.walls[2] = false;
            else if (w == 1) this.walls[1] = false;
            else if (w == 0) this.walls[0] = false;

        }

        // desenha - Método responsável pelo desenho
        public void desenha(Graphics g)
        {
            //North
            if (walls[(int)dir.N])
            {
                g.DrawLine(p, topleft.X, topleft.Y, topleft.X + squareSize, topleft.Y);
                Console.WriteLine("{0} {1}, {2}, {3}, {4}", "North: ",
                    topleft.X, topleft.Y, topleft.X + squareSize, topleft.Y);

            }
                      

            //East
            if (walls[(int)dir.E])
            {
                g.DrawLine(p, topleft.X + squareSize, topleft.Y, topleft.X + squareSize, topleft.Y + squareSize);
                Console.WriteLine("{0} {1}, {2}, {3}, {4}", "East: ",
                    topleft.X + squareSize, topleft.Y, topleft.X + squareSize, topleft.Y + squareSize);

            }

            //West
            if (walls[(int)dir.W])
            {
                g.DrawLine(p, topleft.X, topleft.Y, topleft.X, topleft.Y + squareSize);
                Console.WriteLine("{0} {1}, {2}, {3}, {4}", "West: ",
                    topleft.X, topleft.Y, topleft.X, topleft.X + squareSize);
            }

            //South
            if (walls[(int)dir.S])
            {
                g.DrawLine(p, topleft.X, topleft.Y + squareSize, topleft.X + squareSize, topleft.Y + squareSize);
                Console.WriteLine("{0} {1}, {2}, {3}, {4}", "South: ",
                    topleft.X, topleft.Y + squareSize, topleft.X + squareSize, topleft.Y + squareSize);
            }

            //g.DrawEllipse(p, center.X, center.Y, squareSize / 2,squareSize/2);
            // g.FillEllipse(new SolidBrush(Color.Green), center.X, center.Y, squareSize / 2, squareSize / 2);
        }

      

    }

}