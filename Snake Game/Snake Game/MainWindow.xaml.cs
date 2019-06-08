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
        int pikkus = 3;
        double TimeInterval = 0.5;
        List<int> sabapikkus = new List<int>();
        Direction direction;
        int startingTime = 0;
        int snakeHeadRow;
        int snakeHeadCol;
        LinkedList<Rectangle> snakeparts = new LinkedList<Rectangle>();

        public MainWindow()
        {
            InitializeComponent();
            Drawboard();
           
            Init();
            snakeHeadCol = 2;
            snakeHeadRow = 2;

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
            startingTime++;
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
            int index =  2;
            for (int i = 0; i < 3; i++)
            {
                int row = index;
                int col = index + i;


                Rectangle r = new Rectangle();
                r.Tag = new Location(row, col);
                r.Width = cellsize;
                r.Height = cellsize;
                r.Fill = Brushes.Red;
                Panel.SetZIndex(r, 10);
                Setshape(r, index, index);
                snakeparts.AddLast(r);
                canvas.Children.Add(r);
            }  

            
            ChangeDirection(Direction.right);
            

        }
        private void saba()
        {
          
            int index = 2;
            int row = index;
            int col = index;
            Rectangle saba = new Rectangle();
            saba.Tag = new Location(row, col);
            saba.Width = cellsize;
            saba.Height = cellsize;
           
            Setshape(saba, snakeHeadRow, snakeHeadCol);
            Panel.SetZIndex(saba, 10);
            canvas.Children.Add(saba);
            snakeparts.AddLast(saba);
            saba.Fill = Brushes.Red;
            
         
            
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
            if (snakedirection == Direction.left &&
                direction == Direction.right)
            {
                return;
            }

            if (snakedirection == Direction.right &&
                direction == Direction.left)
            {
                return;
            }

            if (snakedirection == Direction.up &&
                direction == Direction.down)
            {
                return;
            }

            if (snakedirection == Direction.down &&
                direction == Direction.up)
            {
                return;
            }
            snakedirection = newDirection;
            lbldirection.Content = $"direction: {newDirection}";
        }

        private void MoveSnake()
        {

            Rectangle currentHead = snakeparts.First.Value;

            Location currentHeadLocation =
                (Location)currentHead.Tag;

            int newHeadRow = currentHeadLocation.Row;
            int newHeadCol = currentHeadLocation.Col;

            Rectangle newHead = snakeparts.Last.Value;

            switch (snakedirection)
            {
                case Direction.up:
                    snakeHeadRow--;
                    snakeparts.AddFirst(newHead);
                    break;
                case Direction.down:
                    snakeHeadRow++;
                    snakeparts.AddFirst(newHead);
                    break;
                case Direction.left:
                    snakeHeadCol--;
                    snakeparts.AddFirst(newHead);
                    break;
                case Direction.right:
                    snakeHeadCol++;
                    snakeparts.AddFirst(newHead);
                    break;

            }
            snakeparts.RemoveLast();

            Setshape(newHead, snakeHeadRow, snakeHeadCol);



            if (Canvas.GetLeft(söök) == Canvas.GetLeft(newHead) && Canvas.GetTop(söök) == Canvas.GetTop(newHead))
            {


                int top = rnd.Next(8);
                int left = rnd.Next(16);
                Canvas.SetTop(söök, top * 50);
                Canvas.SetLeft(söök, left * 50);
                Score++;
                score.Content = $" Score: {Score}";
                Foodinterval.Interval = TimeSpan.FromSeconds(4);
                pikkus++;
                saba();


            }
            if (snakeHeadRow < 0 || snakeHeadRow >= 9 ||
                snakeHeadCol < 0 || snakeHeadCol >= cellcount)
            {
                ChangeGameStatus(GameStatus.GameOver);
                MessageBox.Show("game over");


                timer.Stop();
                pikkus = 0;
                Score = 0;
                snakeHeadCol = 2;
                snakeHeadRow = 2;
                score.Content = $" Score: {Score}";
                ChangeDirection(Direction.right);
            }
            if ( startingTime > 4)
            {
                foreach (Rectangle r in snakeparts)
                {

                    Location location = (Location)r.Tag;
                    if (location.Row == newHeadRow &&
                       location.Col == newHeadCol)
                    {
                        ChangeGameStatus(GameStatus.GameOver);

                        return;
                    }


                }
            }
           
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            
            
            switch (e.Key)
            {
                case Key.Up:
                        direction = Direction.up;
                    break;
                case Key.Down:
                        direction = Direction.down;
                    break;
                case Key.Left:
                   
                        direction = Direction.left;
                    break;
                case Key.Right:

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
