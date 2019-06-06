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
        int Score = 0;
        Random rnd = new Random();
        Rectangle tile = new Rectangle();
       int cellsize = 50;
        int cellcount = 16;
        Ellipse söök = new Ellipse();
        DispatcherTimer timer , Foodinterval;
        Direction snakedirection;
        GameStatus gameStatus;
        int snakeRow;
        int snakeCol;
        double TimeInterval = 0.5;
        List<int> sabapikkus = new List<int>();
        Direction direction;
        int count = 1;

        public MainWindow()
        {
            InitializeComponent();
            Drawboard();
          
            Init();
            Foodinterval = new DispatcherTimer();
            toit();
            if (MessageBox.Show("Do you want to Play on hardmode?", "Confirm",
           MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {

                Foodinterval.Interval = TimeSpan.FromSeconds(4);
                Foodinterval.Start();
                TimeInterval = 0.25;
            }
            timer = new DispatcherTimer();
           
            timer.Interval = TimeSpan.FromSeconds(TimeInterval);
            Foodinterval.Tick += Foodint;
            timer.Tick += Timer_Tick;
            timer.Start();
           

            Canvas.SetLeft(RISTKÜLIK, 0);
            Canvas.SetTop(RISTKÜLIK, 0);
            ChangeGameStatus(GameStatus.Ongoing);
           


        }
        private void Foodint(object sender, EventArgs e)
        {

            int top = rnd.Next(8);
            int left = rnd.Next(16);
            Canvas.SetTop(söök, top * 50);
            Canvas.SetLeft(söök, left * 50);
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            MoveSnake();

        }
        private void ChangeGameStatus(GameStatus NewGameStatus)
        {
            gameStatus = NewGameStatus;
            lblGameStatus.Content =
                $"Status: {gameStatus}";
        }

        private void toit()
        {
            söök.Width = cellsize;
            söök.Height = cellsize;
            söök.Fill = Brushes.Red;

            int top = rnd.Next(8);
            int left = rnd.Next(16);
            Canvas.SetTop(söök, top * 50);
            Canvas.SetLeft(söök, left * 50);
           
            

            canvas.Children.Add(söök);
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
        private void Init()
        {
            int index = cellcount / 2;
            int snakerow = index, snakecol = 0;
            RISTKÜLIK.Height = cellsize;
            RISTKÜLIK.Width = cellsize;
            double coord = cellcount * cellsize / 2;
            Setshape(RISTKÜLIK, snakerow, snakecol);
            ChangeDirection(Direction.right);
            ChangeGameStatus(GameStatus.Ongoing);
            Canvas.SetLeft(RISTKÜLIK, 0);
            Canvas.SetTop(RISTKÜLIK, 0);

        }
        private void Setshape(Shape shape, int row, int col)
        {
            double top = row * cellsize;
            double left = col * cellsize;

            Canvas.SetTop(shape, top);
            Canvas.SetLeft(shape, left);

        }
        private void ChangeDirection(Direction newDirection)
        {
            snakedirection = newDirection;
            lbldirection.Content = $"direction: {newDirection}";
        }

        private void MoveSnake()
        {
           
            count++;
            switch (snakedirection)
            {
                case Direction.up:
                    snakeRow--;
                    break;
                case Direction.down:
                    snakeRow++;
                    break;
                case Direction.left:
                    snakeCol--;
                    break;
                case Direction.right:
                    snakeCol++;
                    break;

            }
           
           
            if (snakeRow < 0 || snakeRow >=9 ||
                snakeCol < 0 || snakeCol >= cellcount)
            {
                ChangeGameStatus(GameStatus.GameOver);
                MessageBox.Show("game over");
                Canvas.SetLeft(RISTKÜLIK, 0);
                Canvas.SetTop(RISTKÜLIK, 0);
                ChangeDirection(Direction.right);
                Score = 0;
                snakeCol = 0;
                snakeRow = 0;
                score.Content = $" Score: {Score}";
            }
             Setshape(RISTKÜLIK, snakeRow, snakeCol);
           
            if (Canvas.GetLeft(söök) == Canvas.GetLeft(RISTKÜLIK) && Canvas.GetTop(söök) == Canvas.GetTop(RISTKÜLIK))
            {
                Saba();
               
                int top = rnd.Next(8);
                int left = rnd.Next(16);
                Canvas.SetTop(söök, top * 50);
                Canvas.SetLeft(söök, left * 50);
                Score++;
                score.Content = $" Score: {Score}";
                Foodinterval.Interval = TimeSpan.FromSeconds(4);
               
               

            }
        }
        private void Saba()
        {
            
            Rectangle saba = new Rectangle();
            Canvas.SetLeft(saba, Canvas.GetLeft(RISTKÜLIK));
            Canvas.SetTop(saba, Canvas.GetTop(RISTKÜLIK));
            saba.Width = cellsize;
            saba.Height = cellsize;
           
           
            saba.Fill = Brushes.Blue;
            
            canvas.Children.Add(saba);
            

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            
            
            switch (e.Key)
            {
                case Key.Up:
                    if(direction == Direction.down)
                        direction = Direction.down;
                    else
                        direction = Direction.up;
                    break;
                case Key.Down:
                    if (direction == Direction.up)
                        direction = Direction.up;
                    else
                        direction = Direction.down;
                    break;
                case Key.Left:
                    if (direction == Direction.right)
                        direction = Direction.right;
                    else
                        direction = Direction.left;
                        break;
                case Key.Right:
                    if (direction == Direction.left)
                        direction = Direction.left;
                    else
                        direction = Direction.right;
                    break;
                default:
                    return;
            }
            ChangeDirection(direction);
        }

        public enum Direction
        {
            up,
            down,
            left,
            right
        }

       
    }
}
