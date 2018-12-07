using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuralNetwork1
{
    public partial class Form1 : Form
    {
        GenerateImage generator;

        public Form1()
        {
            InitializeComponent();
            generator = new GenerateImage();
           
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int x = (int)((double)200 / pictureBox1.Width * e.X);
            int y = (int)((double)200 / pictureBox1.Height * e.Y);

            generator.start_point = new Point(x, y);
            generator.get_random_figure();
            pictureBox1.Image = generator.genBitmap();
            pictureBox1.Invalidate();
        }
    }

  }
