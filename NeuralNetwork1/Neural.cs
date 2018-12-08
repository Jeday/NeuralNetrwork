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
            public double output;
            public double bias = 0;
            public double error= 0;
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
                output = ActivationFunction(charge, bias);                      
                for (int i = 0; i < cnt; i++)
                {
                    nextLayer[i].charge += output * weights[i];
                }
                charge = 0;
            }
            
            public void Fire(double inp)
            {
                output = inp;
                for (int i = 0; i < cnt; i++)
                {
                    nextLayer[i].charge += output * weights[i];
                }
                

            }

            public static  double ActivationFunction(double inp,double bias)
            {
                return 1 / (1 + Math.Exp(-inp + bias));

            }

            public static  double ActivationFunctionDerivative(double inp, double bias)
            {
                double t = ActivationFunction(inp, bias);
                return t * (1 - t);

            }



        }



        private static double INIT_MAX_WEIGHT = 0.3;
        private static double INIT_MIN_WEIGHT = -0.3;
        private int LAST_HIDDEN_IND;
        private int COUNT_LAYERS;
        public int SencorCount;
        public double HiddenLayerMagnifyer; 
        public int HiddenNeuronsCount;
        public int OutputCount;
        public int HiddenLayersCount;
        public double LearningSpeed = 0.5;
        private int AllNeuronCount;

        private Node[] Sensors;
        private Node[][] Layers;
        private Node[] Outputs;


        public NeuralNetwork(int sc, int op, int hlayers, double hmag)
        {
            SencorCount = sc;
            HiddenLayerMagnifyer = hmag;
            OutputCount = op;
            HiddenLayersCount = hlayers;
            HiddenNeuronsCount = (int)(HiddenLayerMagnifyer * sc);
            AllNeuronCount = sc + HiddenNeuronsCount * HiddenLayersCount + op;
            LAST_HIDDEN_IND = HiddenLayersCount;
            COUNT_LAYERS = HiddenLayersCount + 2;
            setup();
        }



        private void setup() {
            // init layers arrays
            Sensors = new Node[SencorCount];
            Outputs = new Node[OutputCount];
            Layers = new Node[2+HiddenLayersCount][];
            Layers[0] = Sensors;
            Layers[1 + HiddenLayersCount] = Outputs;
            for (int i = 1; i < HiddenLayersCount+1; i++)
            {
                Layers[i] = new Node[HiddenNeuronsCount];

            }

            // init sensor nodes
            for (int i = 0; i < SencorCount; i++)
            {
                Sensors[i] = new Node((int)HiddenLayerMagnifyer * 3);


            }

            // init all but last hidden layers nodes
            for (int i = 1; i < HiddenLayersCount; i++)
            {
                for (int j = 0; j < HiddenNeuronsCount; j++)
                {
                    Layers[i][j] = new Node(HiddenNeuronsCount);
                }
            }

            // last layer 
            for (int j = 0; j < HiddenNeuronsCount; j++)
            {
                Layers[HiddenLayersCount][j] = new Node(OutputCount);
            }

            // init output layer
            for (int j = 0; j < OutputCount; j++)
            {
                Outputs[j] = new Node(0);
            }

            // link sensors to first hidden layer
            Random rand = new Random();
            for (int i = 0; i < SencorCount; i++)
            {

                Node s = Sensors[i];
              
                HashSet<int> nerv = new HashSet<int>();
                while (nerv.Count < s.cnt)
                {
                    int n =rand.Next(0, HiddenNeuronsCount - 1);
                    if (!nerv.Contains(n))
                        nerv.Add(n);
                }

                int ind = 0;
                foreach (var item in nerv)
                {
                    s.nextLayer[ind] = Layers[1][item];
                    s.weights[ind] = 1;
                    ind++;
                }
             
            }

            // link hidden layers inbetween
            for (int i = 1; i < HiddenLayersCount; i++)
            {
                for (int j = 0; j < HiddenNeuronsCount; j++)
                {
                    Node n = Layers[i][j];
                    for (int k = 0; k < n.cnt; k++)
                    {
                        n.nextLayer[k] = Layers[i + 1][k];
                        n.weights[k] = INIT_MIN_WEIGHT +  rand.NextDouble() * (INIT_MAX_WEIGHT-INIT_MIN_WEIGHT); 
                    }
                }
            }

            // link last hidden layer to output
            for (int j = 0; j < HiddenNeuronsCount; j++)
            {
                Node n = Layers[LAST_HIDDEN_IND][j];
                for (int k = 0; k < n.cnt; k++)
                {
                    n.nextLayer[k] = Outputs[k];
                    n.weights[k] = INIT_MIN_WEIGHT + rand.NextDouble() * (INIT_MAX_WEIGHT - INIT_MIN_WEIGHT);
                }
            }


        }



        private void Run(double[] input)
        {
            for (int i = 0; i < SencorCount; i++)
            {
                Sensors[i].Fire(input[i]);
            }

            for (int i = 1; i < COUNT_LAYERS; i++)
            {
                for (int j = 0; j < Layers[i].Length; j++)
                {
                    Layers[i][j].Activate();
                }
            }



        }


        public int predict(double[] input)
        {
            Run(input);
            int ind = 0;
            double m = Outputs[0].output;
            for (int i = 0; i < Outputs.Length; i++)
            {
                if(Outputs[i].output > m)
                {
                    m = Outputs[i].output;
                    ind = i;

                }
            }

            return ind;
        }

        public void Train(double[] input, int type)
        {

             Run(input);
             double ValueOfDesired = Outputs[type].output;
             double MaxGotten = Outputs.Max(n => n.output);
             if (ValueOfDesired >= MaxGotten)
                return;
            double diff = (MaxGotten - ValueOfDesired);
            double[] error_vector = new double[OutputCount];
            for (int i = 0; i < OutputCount; i++)
            {
                Node n = Outputs[i];
                if (i == type)
                    error_vector[i] = diff;
                else if (n.output > ValueOfDesired)
                    error_vector[i] = -diff;
                else
                    error_vector[i] = 0;
            }

            int iter = 0;
            while (MaxGotten !=ValueOfDesired)
            {
                iter++;
                if (iter > 8)
                    break;
                for (int i = 0; i < OutputCount; i++)
                {
                    Outputs[i].error = error_vector[i];
                }
                CalculateError();
                ReWeight();
                Run(input);
                ValueOfDesired = Outputs[type].output;
                MaxGotten = Outputs.Max(n => n.output);

            }
            
            

        }

        
        // backpropogates error, error must be set for output
        private void CalculateError()
        {
            for (int i = LAST_HIDDEN_IND; i >= 0; i--)
            {
                for (int j = 0; j < Layers[i].Length; j++)
                {
                    Node n = Layers[i][j];
                    n.error = 0;
                    for (int k = 0; k < n.cnt; k++)
                    {
                        n.error += n.nextLayer[k].error * n.weights[k];
                    }

                }
            }
        }

        // reavaluate weights between nodes
        private void ReWeight() {
            for (int i = 0; i < LAST_HIDDEN_IND; i++)
            {
                for (int j = 0; j < Layers[i].Length; j++)
                {
                    Node n = Layers[i][j];
                    for (int k = 0; k < n.cnt; k++)
                    {
                        Node next = n.nextLayer[k];
                        double deltaw = LearningSpeed *next.error * n.output * (next.output * (1 - next.output));
                        n.weights[k] += deltaw;

                    }
                }
            }
        }


       

    }
}
