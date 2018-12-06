using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork1
{
    public class NeuralNetwork
    {
        private class Node
        {
            public double charge;
            public double bias = 0;

            public int cnt;
            public double[] weights;
            public Node[] nextLayer;

            public Node(int c)
            {
                cnt = c;
                weights = new double[c];
                nextLayer = new Node[c];
            }


            public void Activate()
            {
                double fire = 1 / (1 + Math.Exp(-charge + bias));
                charge = 0;
                for (int i = 0; i < cnt; i++)
                {
                    nextLayer[i].charge += fire * weights[i];
                }
            }

        }

       


        public int SencorCount;
        public double HiddenLayerMagnifyer; 
        public int HiddenNeuronsCount;
        public int OutputCount;
        public int HiddenLayersCount;

        private int AllNeuronCount;

        private Node[] Sensors;
        private Node[][] Layers;
        private Node[] Outputs;


        private void setup() {
            Sensors = new Node[SencorCount];
            Outputs = new Node[OutputCount];
            Layers = new Node[2+HiddenLayersCount][];
            Layers[0] = Sensors;
            Layers[1 + HiddenLayersCount] = Outputs;
            for (int i = 1; i < HiddenLayersCount+1; i++)
            {
                Layers = new Node[HiddenNeuronsCount];

            }

            for (int i = 0; i < SencorCount; i++)
            {
                Sensors[i] = new Node((int)HiddenLayerMagnifyer * 3);


            }

            for (int i = 1; i < HiddenLayersCount; i++)
            {
                for (int j = 0; j < HiddenNeuronsCount; j++)
                {
                    Layers[i][j] = new Node(HiddenNeuronsCount);
                }
            }

            for (int j = 0; j < HiddenNeuronsCount; j++)
            {
                Layers[HiddenNeuronsCount][j] = new Node(OutputCount);
            }


            for (int j = 0; j < OutputCount; j++)
            {
                Output[j] = new Node(0);
            }




        }

        public NeuralNetwork(int sc,int op, int hlayers, double hmag)
        {
            SencorCount = sc;
            HiddenLayerMagnifyer = hmag;
            OutputCount = op;
            HiddenLayersCount = hlayers;
            HiddenNeuronsCount = (int)(HiddenLayerMagnifyer * sc);
            AllNeuronCount = sc + HiddenNeuronsCount * HiddenLayersCount + op;


        }


    }
}
