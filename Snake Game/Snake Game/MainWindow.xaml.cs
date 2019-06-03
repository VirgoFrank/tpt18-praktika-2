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

namespace Snake_Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                double currentleft = Canvas.GetLeft(RISTKÜLIK);
                double newleft = currentleft + 20;
                Canvas.SetLeft(RISTKÜLIK, newleft);
            }

            if (e.RightButton == MouseButtonState.Pressed)
            {
                double currentleft = Canvas.GetLeft(RISTKÜLIK);
                double newleft = currentleft - 20;
                Canvas.SetLeft(RISTKÜLIK, newleft);
            }
            if (e.MiddleButton == MouseButtonState.Pressed)
            {
                double currentleft = Canvas.GetTop(RISTKÜLIK);
                double newleft = currentleft + 20;
                Canvas.SetTop(RISTKÜLIK, newleft);
            }

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if ( e.Key == Key.Right ||e.Key == Key.D)
            {
                double currentleft = Canvas.GetLeft(RISTKÜLIK);
                double newleft = currentleft + 20;
                Canvas.SetLeft(RISTKÜLIK, newleft);
            }
            if (e.Key == Key.Left || e.Key == Key.A)
            {
                double currentleft = Canvas.GetLeft(RISTKÜLIK);
                double newleft = currentleft - 20;
                Canvas.SetLeft(RISTKÜLIK, newleft);
            }
            if (e.Key == Key.Up || e.Key == Key.W)
            {
                double currentleft = Canvas.GetTop(RISTKÜLIK);
                double newleft = currentleft - 20;
                Canvas.SetTop(RISTKÜLIK, newleft);
            }
            if (e.Key == Key.Down || e.Key == Key.S)
            {
                double currentleft = Canvas.GetTop(RISTKÜLIK);
                double newleft = currentleft + 20;
                Canvas.SetTop(RISTKÜLIK, newleft);
            }

        }
    }
}
