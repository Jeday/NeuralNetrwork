using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork1
{
    public class GenerateImage
    {
        public Point start_point;
        public bool[,] img;
        private int margin = 20;
        private Random rand;
        public int current_figure;
        public int figure_count = 4;

        private int center_margin = 50;


        
        public void ClearImage()
        {
            for (int i = 0; i < 200; ++i)
                for (int j = 0; j < 200; ++j)
                    img[i, j] = false;

        }

        public GenerateImage(Point start)
        {
            start_point = start;
            img = new bool[200, 200];
            rand = new Random();

            ClearImage();
        }


        public void GenInputOutput(out double[] input,out int type)
        {
            input = new double[400];
            for (int i = 0; i < 400; i++)
            {
                input[i] = 0;
            }
            type = current_figure;
            
            for (int i = 0; i < 200; i++)
            {
                for (int j = 0; j < 200; j++)
                {
                    if (img[i, j])
                    {
                        input[i] += 1;
                        input[200 + j] += 1;
                    }
                }
            }

            double norm = input.Max();
            if (norm == 0)
                norm = 1;
            for (int i = 0; i < 400; i++)
            {
                
                input[i] /= 200;
            }


            



        }


        public GenerateImage() {
            img = new bool[200, 200];
            rand = new Random();
            ClearImage();

        }

        public void get_random_figure()
        {

            ClearImage();
            int type = rand.Next(0, 4);
            switch (type)
            {
                case 0:
                    create_sin();
                    break;
                case 1:
                    create_rectangle();
                    break;
                case 2:
                    create_triangle();
                    break;
                default:
                case 3:
                    create_circle();
                    break;
            }
        }

        private void bresenham(int x, int y, int x2, int y2)
        {
            int w = x2 - x;
            int h = y2 - y;
            int dx1 = 0, dy1 = 0, dx2 = 0, dy2 = 0;
            if (w < 0) dx1 = -1; else if (w > 0) dx1 = 1;
            if (h < 0) dy1 = -1; else if (h > 0) dy1 = 1;
            if (w < 0) dx2 = -1; else if (w > 0) dx2 = 1;
            int longest = Math.Abs(w);
            int shortest = Math.Abs(h);

            if (!(longest > shortest))
            {
                longest = Math.Abs(h);
                shortest = Math.Abs(w);
                if (h < 0) dy2 = -1; else if (h > 0) dy2 = 1;
                dx2 = 0;
            }

            int numerator = longest >> 1;
            for (int i = 0; i <= longest; i++)
            {
                img[x, y] = true;
                numerator += shortest;
                if (!(numerator < longest))
                {
                    numerator -= longest;
                    x += dx1;
                    y += dy1;
                }
                else
                {
                    x += dx2;
                    y += dy2;
                }
            }
        }

        public bool create_triangle()
        {
            current_figure = 0;
            if (start_point.X > (200 - margin) || start_point.Y > (200 - margin) || start_point.X < margin || start_point.Y < margin)
                return false;

            int minhor = Math.Min(200 - start_point.X - margin, start_point.X - margin);
            int minvert = Math.Min(minhor,200 - start_point.Y - margin);

            int dist = margin + rand.Next(0,minvert);
            int right_pointX = start_point.X - dist;
            int left_pointX = start_point.X + dist;
            int up_pointY = start_point.Y + dist;


            //int right_pointX = rand.Next(start_point.X + margin, 200 - margin);
            //int left_pointX = rand.Next(margin, start_point.X - margin);
            //int dist = rand.Next(margin,  200  - start_point.Y - margin);
            //int up_pointY;

            //up_pointY = start_point.Y + dist;



            bresenham(left_pointX, start_point.Y, right_pointX, start_point.Y);
            bresenham(left_pointX, start_point.Y, start_point.X, up_pointY);
            bresenham(start_point.X, up_pointY, right_pointX, start_point.Y);

            return true;
        }

        public bool create_rectangle()
        {
            current_figure = 1;
            if (start_point.X > (200 - margin) || start_point.Y > (200 - margin) || start_point.X < margin || start_point.Y < margin)
                return false;

            int minhor = Math.Min(200 - start_point.X - 2 * margin, start_point.X - 2 * margin);
            int minvert = Math.Min(minhor, 200 - start_point.Y - 2 * margin);
            if (minvert < 0)
                return false;
            int dist = margin + rand.Next(0, minvert);

            int right_pointX = start_point.X + dist;
            int left_pointX = start_point.X - dist;
            int up_pointY = start_point.Y + dist;

            bresenham(left_pointX, start_point.Y, right_pointX, start_point.Y);
            bresenham(left_pointX, start_point.Y, left_pointX, up_pointY);
            bresenham(left_pointX, up_pointY, right_pointX, up_pointY);
            bresenham(right_pointX, up_pointY, right_pointX, start_point.Y);
            return true;
        }

        public bool create_circle()
        {
            current_figure = 2;
            if (start_point.X > (200 - margin) || start_point.Y > (200 - margin) || start_point.X < margin || start_point.Y < margin)
                return false;

            int min_r = 10;
            int distToBorderY = Math.Min(start_point.Y, 200 - start_point.Y);
            int distToBorderX = Math.Min(start_point.X, 200 - start_point.X);

            int radius = rand.Next(min_r, Math.Min(distToBorderY, distToBorderX));

            for (double t = 0; t < 2 * Math.PI; t += 0.01)
            {
                double x = start_point.X + radius * Math.Cos(t);
                double y = start_point.Y + radius * Math.Sin(t);
                img[(int)x, (int)y] = true;
            }
            
           
            return true;
        }

        public bool create_sin()
        {
            current_figure = 3;
            if (start_point.X > (200 - margin) || start_point.Y > (200 - margin) || start_point.X < margin || start_point.Y < margin)
                return false;


            int min_dist = Math.Min(200 - margin - start_point.X, start_point.X - margin);
            if (min_dist < margin)
                return false;
            int offset = rand.Next(margin, min_dist);

            int x2 = start_point.X + offset;
            int x1 = start_point.X - offset;

            double sx = 0.5;
            double sy = 20;
            for (double t = x1; t < x2; t += 0.1)
            {
                double x = t;
                double y = sy * Math.Sin(sx * t) + start_point.Y;
                img[(int)x, (int)y] = true;
            }
            GenInputOutput(out double[] d, out int g);
            return true;
        }


        public void generate_figure(int type, bool random = false )
        {

            if(random)
                start_point = new Point(rand.Next(100 - center_margin, 100 + center_margin), rand.Next(100 - center_margin, 100 + center_margin));
            ClearImage();
            switch (type)
            {
                case 0:
                    if (random)
                        while (!create_triangle()) {
                            start_point = new Point(rand.Next(100 - center_margin, 100 + center_margin), rand.Next(100 - center_margin, 100 + center_margin));
                        }
                    else
                    create_triangle();
                    break;
                case 1:
                    if (random)
                        while (!create_rectangle()) { start_point = new Point(rand.Next(100 - center_margin, 100 + center_margin), rand.Next(100 - center_margin, 100 + center_margin)); }
                    else
                        create_rectangle();
                    break;
                case 2:
                    if (random)
                        while (!create_circle()) { start_point = new Point(rand.Next(100 - center_margin, 100 + center_margin), rand.Next(100 - center_margin, 100 + center_margin)); }
                    else
                        create_circle();
                    break;
                case 3:
                    if (random)
                        while (!create_sin()) { start_point = new Point(rand.Next(100 - center_margin, 100 + center_margin), rand.Next(100 - center_margin, 100 + center_margin)); }
                    else
                        create_sin();
                    break;

                default:
                    break;
            }
        }

        public Bitmap genBitmap()
        {
            Bitmap DrawArea = new Bitmap(200, 200);
            for (int i = 0; i < 200; ++i)
                for (int j = 0; j < 200; ++j)
                {
                    if (img[i, j])
                        DrawArea.SetPixel(i, j, Color.Black);
                }
            return DrawArea;
        }
    }

}
