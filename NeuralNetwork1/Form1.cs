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
        NeuralNetwork net;

        public Form1()
        {
            InitializeComponent();
            generator = new GenerateImage();
            net = new NeuralNetwork(400, generator.figure_count, 3,3);
            train_triangle();

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int x = (int)((double)200 / pictureBox1.Width * e.X);
            int y = (int)((double)200 / pictureBox1.Height * e.Y);

            generator.start_point = new Point(x, y);
            generator.get_random_figure();
            generator.GenInputOutput(out double[] input, out int type);
            
            label1.Text = net.predict(input).ToString();
            pictureBox1.Image = generator.genBitmap();
            pictureBox1.Invalidate();
        }

        private void train_triangle()
        {

            

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    generator.generate_figure(j);
                    generator.GenInputOutput(out double[] inp, out int type);
                    net.Train(inp, type);
                }
                
                
                

            }

            



        }

    }

  }
