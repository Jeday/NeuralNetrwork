using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

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
            public double[] DeltaW;
            public double[] weights;
            public Node[] nextLayer;
            

            public Node(int c)
            {
                cnt = c;
                weights = new double[c];
                nextLayer = new Node[c];
                DeltaW = weights.Select(w => 0.0).ToArray(); 
                
            }


            public void Activate()
            {
                output = ActivationFunction(charge, bias);
                if (Double.IsNaN(output))
                    output = 0;
                for (int i = 0; i < cnt; i++)
                {
                    nextLayer[i].charge += output * weights[i];
                }
                charge = 0;
            }
            
            public void Fire(double inp)
            {
                output = inp;
                if (Double.IsNaN(output))
                    output = 0;
                for (int i = 0; i < cnt; i++)
                {
                    nextLayer[i].charge += output * weights[i];
                }
                

            }

            public static  double ActivationFunction(double inp,double bias)
            {
                return 1 / (1 + Math.Exp(-inp - bias));

            }

            public static  double ActivationFunctionDerivative(double inp, double bias)
            {
                double t = ActivationFunction(inp, bias);
                return t * (1 - t);

            }
            public double Derivative()
            {
                return output * (1 - output);

            }



        }



        private static double INIT_MAX_WEIGHT = 0.1;
        private static double INIT_MIN_WEIGHT = -0.1;
        private int LAST_HIDDEN_IND;
        private int COUNT_LAYERS;
        public int SencorCount;
        public double HiddenLayerMagnifyer; 
        public int HiddenNeuronsCount;
        public int OutputCount;
        public int HiddenLayersCount;
        public double LearningSpeed = 0.1;
        public double BiasSpeed = 0.001;
        private int AllNeuronCount;
        public double EPS = 0.01;
        public double Moment = 0.01;


        public int current_class = -1;
        public double[] error_vector;



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
                Sensors[i] = new Node((int)HiddenLayerMagnifyer*2);


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
                    int n =rand.Next(0, HiddenNeuronsCount);
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


        public double  WorkResults(int type)
        {
            /* double dest = Outputs[type].output;
             double diff = Outputs.Max(n => n.output) - dest;
             double max_wrong = Outputs.Where((n, i) => i != type).Max(n => n.output);
             if(Math.Abs(dest - max_wrong)<EPS)
                 error_vector = Outputs.Select((t, i) => i == type ? EPS : 0.0).ToArray();
             else
                 error_vector = Outputs.Select((t, i) => i == type ? diff  :  t.output>dest ? dest - t.output: 0.0).ToArray();

             //error_vector = Outputs.Select((t, i) => i == type ? 1 - t.output  : 0 - t.output).ToArray();


             return  Math.Sqrt(error_vector.Sum(e => e * e)/error_vector.Length);*/

            double necessary_value = Outputs[type].output;
            double received_value = Outputs.Max(n => n.output);
            if (necessary_value >= received_value)
                return 0;

            double difference = (received_value - necessary_value);
            error_vector = new double[OutputCount];

            for (int i = 0; i < OutputCount; i++)
            {
                Node cur = Outputs[i];
                if (i == type)
                    error_vector[i] = difference;
                else if (cur.output > necessary_value)
                    error_vector[i] = necessary_value - cur.output;
                else
                    error_vector[i] = 0;
            }
            return difference;

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

        public int Train(double[] input, int iter_count, int type,double acceptable_error)
        {

            var res =predict(input);
            if (res == type)
                return res;
            double error = WorkResults(type);
            CalculateError();
            ReWeight();
            return res;

        }

        
        // backpropogates error, error must be set for output
        private void CalculateError()
        {
            for (int i = 0; i < OutputCount; i++)
            {
                Outputs[i].error =  error_vector[i];
            }
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

            //foreach(var n in Outputs)
                //n.bias += BiasSpeed * n.error;
            for (int i = 0; i < Layers.Length; i++)
            {
                for (int j = 0; j < Layers[i].Length; j++)
                {
                    Node n = Layers[i][j];
                    for (int k = 0; k < n.cnt; k++)
                    {
                        Node next = n.nextLayer[k];
                        n.weights[k] += LearningSpeed * next.error* n.output * (next.output * (1 - next.output));

                    }
                    n.bias += BiasSpeed * n.error;
                }
            }
        }

        public double[] getOutput()
        {
            return Outputs.Select(n => n.output).ToArray();


        }

        public double TrainOnDataSet(List<double[]> data, List<int>  outputs,int epochs_count, double acceptable_erorr)
        {
            // succes
            List<bool> succeces = new List<bool>(data.Count);
            foreach (var d in data)
                succeces.Add(false);
            double succeces_percent;


            void UpdateSuccesPercent()
            {
                succeces_percent = succeces.Count(t => t == true) / (double)succeces.Count();
            }


            UpdateSuccesPercent();
            int ind = 0;
            while(epochs_count > 0 && 1 - succeces_percent > acceptable_erorr)
            {
                // last ind marks end of epoch
                if (ind == data.Count - 1)
                    epochs_count--;
                // get training data
                double[] input = data[ind];
                int type = outputs[ind];
                // run network on it
                Run(input);
                // parse output
                double ValueOfDesired = Outputs[outputs[ind]].output;
                double MaxGotten = Outputs.Max(n => n.output);
                // network is right
                if (ValueOfDesired >= MaxGotten)
                {
                    succeces[ind] = true;
                    UpdateSuccesPercent();
                    ind++;
                    if (ind == data.Count)
                        ind = 0;
                    continue;
                }
                //network is  wrong, backpropogation is needed
                succeces[ind] = false;
                UpdateSuccesPercent();
                WorkResults(outputs[ind]);
                
                

                // bp error and reweight
                CalculateError();
                ReWeight();
                // get next training data
                ind += 1;
                if (ind == data.Count)
                    ind = 0;

            }

            // networks was succesfuly trained on training set
            return succeces_percent;

        }

        public double TrainOnDataSetSimple(List<double[]> data, List<int> outputs)
        {
            for (int i = 0; i < data.Count; i++)
            {
                Run(data[i]);
                int res = 0;
                double max = Outputs[0].output;
                for (int j = 1; j < OutputCount; j++)
                {
                    if (Outputs[j].output > max)
                    {
                        res = j;
                        max = Outputs[j].output;
                    }
                }
                if (res == outputs[i])
                    continue;
                WorkResults(outputs[i]);
                CalculateError();
                ReWeight();


            }

            int test_count = data.Count / 10;
            if (test_count == 0)
                return 0;
            int right_count = 0;
            for (int i = data.Count - test_count; i < data.Count && i>=0 ; i++)
            {
                Run(data[i]);
                int res = 0;
                double max = Outputs[0].output;
                for (int j = 1; j < OutputCount; j++)
                {
                    if (Outputs[j].output > max)
                    {
                        res = j;
                        max = Outputs[j].output;
                    }
                }
                if (res == outputs[i])
                    right_count++;
            }
            
            return (double)right_count / test_count;

        }
        
    }
}
