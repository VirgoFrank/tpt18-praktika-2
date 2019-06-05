using System;
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
using System.Windows.Threading;

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
        Ellipse söök = new Ellipse();
        DispatcherTimer timer;
        Snake snake = new Snake; // millegi pärast visual studio ei leia neid classe üles

        public MainWindow()
        {
            InitializeComponent();
            Drawboard();
            snake = new Snake(RISTKÜLIK, cellsize, cellcount);

            snake.Init();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(2);
            timer.Tick += Timer_Tick;
            timer.Start();

            Canvas.SetLeft(RISTKÜLIK, 0);
            Canvas.SetTop(RISTKÜLIK, 0);
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            snake.Move();
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
        /*
        private void toit()
        {



            söök.Width = cellsize;
            söök.Height = cellsize;
            söök.Fill = Brushes.Red;

            int top = rnd.Next(8);
            int left = rnd.Next(16);
            Canvas.SetTop(söök, top * 50);
            Canvas.SetLeft(söök, left * 50);
            int k = top * 50;

            canvas.Children.Add(söök);



        }
        */



        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            Direction direction;
            switch (e.Key)
            {
                case Key.Up:
                    direction = Direction.Up;
                    break;
                case Key.Down:
                    direction = Direction.Down;
                    break;
                case Key.Left:
                    direction = Direction.Left;
                    break;
                case Key.Right:
                    direction = Direction.Right;
                    break;
                default:

/*---kodutöö---->*/ if (Canvas.GetTop(RISTKÜLIK) < 0 || Canvas.GetTop(RISTKÜLIK) > 400 || Canvas.GetLeft(RISTKÜLIK) > 750 
                        || Canvas.GetLeft(RISTKÜLIK) < 0 || e.Key == Key.R) // Saadab ussi vasakule üless nurka
                    {
                        Canvas.SetLeft(RISTKÜLIK, 0);
                        Canvas.SetTop(RISTKÜLIK, 10);

                    }
                    return;
                    /*
                    if (Canvas.GetLeft(RISTKÜLIK) == Canvas.GetLeft(söök) && Canvas.GetTop(RISTKÜLIK) == Canvas.GetTop(söök))
                        söök.Fill = Brushes.Black;


                    // if (Canvas.GetLeft(RISTKÜLIK) == )
                    */
                    
                  
                    
                    /*
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
                    }*/
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
