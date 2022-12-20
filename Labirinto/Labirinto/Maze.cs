using System;

using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace Labirinto
{
    public class Maze
    {
        List<Celula> visitadas { get; set; } //lista de todos os lugares visitados
        Celula[,] ShapeMaze { get; set; } // o "shape" do labirinto
        public enum dir : int { N = 0, S, E, W } // Msm do codigo anterior
        private int Height;
        private int Width;
        private int BoxSize;
        private Graphics G;
        private Bitmap ma;

        public Maze(int height, int width, int boxsize)
        {
            this.Height = height;
            this.Width = width;
            this.BoxSize = boxsize;
        }
        public void ShapeLabyrinth(PictureBox ImageMaze)
        {
            ImageMaze.SizeMode = PictureBoxSizeMode.AutoSize;
            visitadas = new List<Celula>();
            ShapeMaze = new Celula[Height, Width];
            ma = new Bitmap((ShapeMaze.GetLength(0) + 1) * BoxSize, (ShapeMaze.GetLength(1) + 1) * BoxSize);
            G = Graphics.FromImage(ma);

            for (int x = 0; x < ShapeMaze.GetLength(0); x++)
            {
                for (int y = 0; y < ShapeMaze.GetLength(1); y++)
                {
                    ShapeMaze[x, y] = new Celula(BoxSize, x, y); //vem do usuario
                    ShapeMaze[x, y].Topleft = new Point(x * ShapeMaze[x, y].SquareSize,
                            y * ShapeMaze[x, y].SquareSize);


                }
            }
        }
        public void PrintMaze(PictureBox ImageMaze)
        {
            for (int i = 0; i < ShapeMaze.GetLength(0); i++)
            {
                for (int j = 0; j < ShapeMaze.GetLength(1); j++)
                {
                    ShapeMaze[i, j].desenha(G);
                    ImageMaze.Image = ma;
                }
            }
            ImageMaze.Image = ma;
        }
        public void createMaze(int x, int y)
        {

            // Y = Linha
            // X = Coluna
            Celula currentCell = ShapeMaze[x, y];
            visitadas.Add(currentCell);
            while (visitadas.Count > 0)
            {
                bool flag = false;
                currentCell.Visited = true;



                if (!flag)
                {
                    var values = new List<int>(new int[] { 0, 1, 2, 3 }).OrderBy(k => Guid.NewGuid());
                    foreach (var rw in values)
                    {

                        if (rw == 0 && !IsOutOfBounds(currentCell.X, currentCell.Y - 1) && IsNotVisted(currentCell.X, currentCell.Y - 1))
                        {
                            currentCell.derrubaWall((int)dir.N);
                            currentCell = ShapeMaze[currentCell.X, currentCell.Y - 1];
                            currentCell.derrubaWall((int)dir.S);
                            visitadas.Add(currentCell);
                            y--;
                            break;

                        }

                        // South - Baixo
                        else if (rw == 1 && !IsOutOfBounds(currentCell.X, currentCell.Y + 1) && IsNotVisted(currentCell.X, currentCell.Y + 1))
                        {
                            currentCell.derrubaWall((int)dir.S); //
                            currentCell = ShapeMaze[currentCell.X, currentCell.Y + 1];
                            currentCell.derrubaWall((int)dir.N);
                            visitadas.Add(currentCell);
                            y++;
                            break;
                        }

                        // East - Direita
                        else if (rw == 2 && !IsOutOfBounds(currentCell.X + 1, currentCell.Y) && IsNotVisted(currentCell.X + 1, currentCell.Y))
                        {
                            currentCell.derrubaWall((int)dir.E);
                            currentCell = ShapeMaze[currentCell.X + 1, currentCell.Y];
                            currentCell.derrubaWall((int)dir.W);
                            visitadas.Add(currentCell);
                            x++;
                            break;
                        }

                        // West - Esquerda
                        else if (rw == 3 && !IsOutOfBounds(currentCell.X - 1, currentCell.Y) && IsNotVisted(currentCell.X - 1, currentCell.Y))
                        {
                            currentCell.derrubaWall((int)dir.W);
                            currentCell = ShapeMaze[currentCell.X - 1, currentCell.Y];
                            currentCell.derrubaWall((int)dir.E);
                            visitadas.Add(currentCell);
                            x--;
                            break;
                        }
                        else
                        {
                            flag = true;
                        }


                    }
                }

                if (flag)
                {
                    currentCell = visitadas.Last();
                    visitadas.RemoveAt(visitadas.Count - 1);
                }
            }
        }

        private bool IsOutOfBounds(int x, int y)
        {
            if (x < 0 || x > ShapeMaze.GetLength(0) - 1)
                return true;

            if (y < 0 || y > ShapeMaze.GetLength(1) - 1)
                return true;

            return false;
        }

        private bool IsNotVisted(int x, int y)
        {

            return !ShapeMaze[x, y].Visited;

        }

        public List<LinkedList<Edge>> listAdjacency()
        {
            List<LinkedList< Edge >> listAdjacency = new List<LinkedList<Edge>>();

            for(int x = 0; x < Width; x++)
            {
                for(int y = 0; y < Height; y++)
                {
                    listAdjacency.Add(new LinkedList<Edge>());

                    if (!ShapeMaze[x, y].Walls[(int)dir.N])
                    {
                        listAdjacency.Last().AddLast(new Edge(x, y -1, 1));
                    }

                    if(!ShapeMaze[x, y].Walls[(int)dir.S]) {
                        listAdjacency.Last().AddLast(new Edge(x, y + 1, 1));
                    }
                    if(!ShapeMaze[x, y].Walls[(int)dir.E]) {
                        listAdjacency.Last().AddLast(new Edge(x + 1, y , 1));
                    }
                    if(!ShapeMaze[x, y].Walls[(int)dir.W]) {
                        listAdjacency.Last().AddLast(new Edge(x - 1, y, 1));
                    }

                }
            }

            return listAdjacency;
        }

    }

}