using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace Labirinto
{
    public partial class Labirinto : Form
    {
        public Labirinto()
        {
            InitializeComponent();
            textBox1.Text = "30";
            textBox2.Text = "30";

        }

        private void btnGenerateMaze_Click(object sender, EventArgs e)
        {
            int x = int.Parse(textBox1.Text);
            int y = int.Parse(textBox2.Text);
            Maze maze = new Maze(x, y, 15);
            maze.ShapeLabyrinth(pictureBoxMaze);
            maze.createMaze(0, 0);
            maze.PrintMaze(pictureBoxMaze);
            maze.listAdjacency();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBoxMaze.Image = null;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
