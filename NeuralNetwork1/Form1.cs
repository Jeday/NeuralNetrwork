﻿using System;
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
           

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int x = (int)((double)200 / pictureBox1.Width * e.X);
            int y = (int)((double)200 / pictureBox1.Height * e.Y);

            generator.ClearImage();
            generator.start_point = new Point(x, y);
            
            generator.create_triangle();
            generator.GenInputOutput(out double[] input, out int type);
            
            label1.Text = net.predict(input).ToString();
            pictureBox1.Image = generator.genBitmap();
            pictureBox1.Invalidate();
        }

        private void train_network(int hidden_layers, double hmag, int training_size, int epoches,double acceptable_error )
        {
            StatusLabel.Text = "Training in progres...";
            StatusLabel.ForeColor = Color.Black;
            net = new NeuralNetwork(400, generator.figure_count, hidden_layers, hmag);
            List<double[]> data = new List<double[]>(training_size);
            List<int> res = new List<int>(training_size);
            var trainingSetGen = new GenerateImage();
            for (int i = 0; i < 2; i++)
            {
                trainingSetGen.generate_figure(i % trainingSetGen.figure_count);
                trainingSetGen.GenInputOutput(out double[] inp, out int type);
                data.Add(inp);
                res.Add(type);

            }
            bool f = net.TrainOnDataSet(data, res,epoches, acceptable_error);
            if (f)
            {
                StatusLabel.Text = "Network is trained succesfully";
                StatusLabel.ForeColor = Color.Green;

            }
            else
            {
                StatusLabel.Text = "Training failed";
                StatusLabel.ForeColor = Color.Red;

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            train_network((int)HidLayerCounter.Value, (double)HiddenMagCounter.Value, (int)TrainingSizeCounter.Value, (int)EpochesCounter.Value, (100 - AccuracyCounter.Value) / 100.0);
            this.Enabled = true;
        }
    }

  }
