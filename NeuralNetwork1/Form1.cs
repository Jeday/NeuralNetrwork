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
        int curr_figure = 0;
        int mode = 0;
        public Form1()
        {
            InitializeComponent();
            generator = new GenerateImage();
            net = new NeuralNetwork(400, generator.figure_count, 5,3);
           

        }

        private void set_result(int r)
        {
            switch (r)
            {
                default:
                case -1:
                    label1.Text ="UNKNOWNN";
                    break;
                case 0:
                    label1.Text = "Trinagle";
                    break;

                case 1:
                    label1.Text = "Rectangle";
                    break;

                case 2:
                    label1.Text = "Circle";
                    break;

                case 3:
                    label1.Text = "Sin";
                    break;
            }

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int x = (int)((double)200 / pictureBox1.Width * e.X);
            int y = (int)((double)200 / pictureBox1.Height * e.Y);

           
            generator.start_point = new Point(x, y);

            generator.generate_figure(curr_figure);
            generator.GenInputOutput(out double[] input, out int type);
            Enabled = false;
            int pred_res= -1;
            if (mode == 0)
                pred_res = net.Train(input, 40, type,0.5);
            else if (mode == 1)
                pred_res = net.predict(input);
            Enabled = true;
            
            set_result(pred_res);

            label8.Text = String.Join("\n", net.getOutput().Select(d => d.ToString()));
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
            for (int i = 0; i < training_size; i++)
            {
                trainingSetGen.generate_figure(i % trainingSetGen.figure_count, true);
                trainingSetGen.GenInputOutput(out double[] inp, out int type);
                data.Add(inp);
                res.Add(type);

            }
            double f = net.TrainOnDataSet(data, res,epoches,acceptable_error);
            StatusLabel.Text = "Accuracy: "+f.ToString();
            StatusLabel.ForeColor = Color.Green;

          
        }

        private void train_networkSIMPLE(int hidden_layers, double hmag, int training_size, int epoches, double acceptable_error)
        {
            StatusLabel.Text = "Training in progres...";
            StatusLabel.ForeColor = Color.Black;
            net = new NeuralNetwork(400, generator.figure_count, hidden_layers, hmag);
            List<double[]> data = new List<double[]>(training_size);
            List<int> res = new List<int>(training_size);
            var trainingSetGen = new GenerateImage();
            for (int i = 0; i < training_size; i++)
            {
                trainingSetGen.generate_figure(i % trainingSetGen.figure_count, true);
                trainingSetGen.GenInputOutput(out double[] inp, out int type);
                data.Add(inp);
                res.Add(type);

            }
            double f = net.TrainOnDataSetSimple(data, res);
            StatusLabel.Text = "Accuracy: " + f.ToString();
            StatusLabel.ForeColor = Color.Green;


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

        private void AccuracyCounter_Scroll(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                curr_figure = 0;
            else if (radioButton2.Checked)
                curr_figure = 1;
            else if (radioButton3.Checked)
                curr_figure = 2;
            else if (radioButton4.Checked)
                curr_figure = 3;
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked)
                mode = 0;
            else if (radioButton5.Checked)
                mode = 1; 
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            train_networkSIMPLE((int)HidLayerCounter.Value, (double)HiddenMagCounter.Value, (int)TrainingSizeCounter.Value, (int)EpochesCounter.Value, (100 - AccuracyCounter.Value) / 100.0);
            this.Enabled = true;
        }
    }

  }
