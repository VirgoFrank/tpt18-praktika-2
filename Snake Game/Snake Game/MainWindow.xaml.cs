﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Snake_Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Random rnd = new Random();
        Rectangle tile = new Rectangle();
        double cellsize = 50;
        double cellcount = 16;
       
       

        public MainWindow()
        {
            InitializeComponent();
           Drawboard();
          
            int top = rnd.Next(8);
            int left = rnd.Next(16);
            toit(top, left);
            Canvas.SetLeft(RISTKÜLIK, 0);
            Canvas.SetTop(RISTKÜLIK, 0);
        }
        public void Drawboard()
        {
            for (int j = 0; j < cellcount; j++)
            {

                for (int i = 0; i < cellcount; i++)
                {
                    if (i % 2 == 0 && j % 2 == 0 || i % 2 == 1 && j % 2 == 1)
                    {
                        Rectangle tile = new Rectangle();
                        tile.Height = cellsize;
                        tile.Width = cellsize;
                        tile.Fill = Brushes.Lime;
                        Canvas.SetTop(tile, j * cellsize);
                        Canvas.SetLeft(tile, i * cellsize);
                        canvas.Children.Add(tile);

                    }
                }
            }
        }

       public int toit(int top, int left)
        {
            Ellipse söök = new Ellipse();


            söök.Width = cellsize;
            söök.Height = cellsize;
            söök.Fill = Brushes.Red;
           // int top = rnd.Next(8);
          //  int left = rnd.Next(16);
            Canvas.SetTop(söök, top*50);
            Canvas.SetLeft(söök, left*50);
            int k = top * 50;
        
            canvas.Children.Add(söök);
            return top;
           

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
           
           
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                //toit();
               
            }

           

        }
        private void Movesnake(direction direction)
        {


            if (direction == direction.up || direction == direction.down)
            {
                double currentTop = Canvas.GetTop(RISTKÜLIK);
                double newtop = direction == direction.up
                    ? currentTop - cellsize
                    : currentTop + cellsize;
                Canvas.SetTop(RISTKÜLIK, newtop);
            }
            if (direction == direction.left || direction == direction.right)
            {
                double currentLeft = Canvas.GetLeft(RISTKÜLIK);
                double newLeft = direction ==direction.right
                    ? currentLeft + cellsize
                    : currentLeft - cellsize;
                Canvas.SetLeft(RISTKÜLIK, newLeft);
            }
        }


        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            direction direction;
            if (e.Key == Key.Up || e.Key == Key.W)
                direction = direction.up;
            else if (e.Key == Key.Down || e.Key == Key.S)
                direction = direction.down;
            else if (e.Key == Key.Left || e.Key == Key.A)
                direction = direction.left;
            else if (e.Key == Key.Right || e.Key == Key.D)
                direction = direction.right;
            else
                return;
            Movesnake(direction);

            Ellipse söök = new Ellipse();


            // if (Canvas.GetLeft(RISTKÜLIK) == )

            /*
            if (Canvas.GetTop(RISTKÜLIK) < 0 || Canvas.GetTop(RISTKÜLIK) > 400 || Canvas.GetLeft(RISTKÜLIK) > 750 || Canvas.GetLeft(RISTKÜLIK) < 0 || e.Key == Key.R)
             {
                 Canvas.SetLeft(RISTKÜLIK, 0);
                 Canvas.SetTop(RISTKÜLIK, 0);

             }
            */

            if (Canvas.GetTop(RISTKÜLIK) < 0)
            {
                Canvas.SetTop(RISTKÜLIK, 400);
            }
            if (Canvas.GetTop(RISTKÜLIK) > 400)
            {
                Canvas.SetTop(RISTKÜLIK, 0);
            }
            if (Canvas.GetLeft(RISTKÜLIK) < 0)
            {
                Canvas.SetLeft(RISTKÜLIK, 750);
            }
            if (Canvas.GetLeft(RISTKÜLIK) > 750)
            {
                Canvas.SetLeft(RISTKÜLIK, 0);
            }
        }
        public enum direction
        {
            up,
            down,
            left,
            right
        }
    }
}
