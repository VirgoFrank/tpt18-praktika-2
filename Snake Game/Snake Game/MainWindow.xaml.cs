using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SnakeGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const double CellSize = 30D;
        const int CellCount = 16;
        Ellipse söök = new Ellipse();
        DispatcherTimer timer;
        Snake snake;
        

        public MainWindow()
        {
            InitializeComponent();
            Drawboard();
            snake = new Snake(snakeShape, CellSize, CellCount);

            snake.Init();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(2);
            timer.Tick += Timer_Tick;
            timer.Start();


        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        public void Drawboard()
        {
            for (int j = 0; j < CellCount; j++)
            {

                for (int i = 0; i < CellCount; i++)
                {
                    if (i % 2 == 0 && j % 2 == 0 || i % 2 == 1 && j % 2 == 1)
                    {
                        Rectangle tile = new Rectangle();
                        tile.Height = CellSize;
                        tile.Width = CellSize;
                        tile.Fill = Brushes.Lime;
                        Canvas.SetTop(tile, j * CellSize);
                        Canvas.SetLeft(tile, i * CellSize);
                         board.Children.Add(tile);

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

        //private void DirectSnake(Direction direction)
        //{
        //    snakeDirection = direction;
        //    lblSnakeDirection.Content =
        //        $"Direction: {direction}";
        //}


        private void Timer_Tick(object sender, EventArgs e)
        {
            snake.Move();
        }

        private void Window_KeyDown(
            object sender, KeyEventArgs e)
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
                    return;
            }

            snake.ChangeDirection(direction);
        }
    }
}