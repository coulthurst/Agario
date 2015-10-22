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

namespace Agar
{
    /// <summary>
    /// Interaction logic for MainScreen.xaml
    /// </summary>
    public partial class MainScreen : Page
    {
        GamePlay gamePlay = new GamePlay();


        public MainScreen()
        {
            InitializeComponent();

        }
        //public void CreateCanvas()
        //{
        //    Screen.Background = new SolidColorBrush(Colors.AntiqueWhite);
        //}





        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            //CreateCanvas();
            //CreatePlayer();

            //Virus v = CreateVirus();
            //Children.Add(v.ellipse);
            CellA.KeyDown += new KeyEventHandler(OnKeyDown);
            //Blue.KeyDown += new KeyEventHandler(OnKeyDown2);
            Blue.Focus();
            CellA.Focus();
          
            CreatePlayer();
            CreateFood();
            CreateVirus();
        }



        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)e.OriginalSource;
            
            switch (e.Key)
            { 
                case Key.Left:
                    if (Canvas.GetLeft(element) > 0) Canvas.SetLeft(element, Canvas.GetLeft(element) - 8);
                    
                    for (int i = 0; i < gamePlay.allCells.Count; i++)
                    {
                        CheckCollisionFood(CellA, gamePlay.allCells[i]);
                    }
                    break;
                case Key.Right:
                    Canvas.SetLeft(element, Canvas.GetLeft(element) + 8);
                    for (int i = 0; i < gamePlay.allCells.Count; i++)
                    {
                        CheckCollisionFood(CellA, CellB);
                    }
                    break;
                case Key.Up:
                    if (Canvas.GetTop(element) > 0) Canvas.SetTop(element, Canvas.GetTop(element) - 8);
                    for (int i = 0; i < gamePlay.allCells.Count; i++)
                    {
                        CheckCollisionFood(CellA, CellB);
                    }
                    break;
                case Key.Down:
                    Canvas.SetTop(element, Canvas.GetTop(element) + 8);
                    for (int i = 0; i < gamePlay.allCells.Count; i++)
                    {
                        CheckCollisionFood(CellA, CellB);
                    }
                    break;
                default:
                    return;
            }
        }
        

        private Random rnd = new Random();
        //BFT TODO: Logic functions don't belong here. This file should only contain UI (input/output) functions.
        public void CheckCollisionFood(Ellipse e1, Ellipse e2)
        {
            var r1 = e1.ActualWidth / 2;
            var x1 = Canvas.GetLeft(e1) + r1;
            var y1 = Canvas.GetTop(e1) + r1;
            var r2 = e2.ActualWidth / 2;
            var x2 = Canvas.GetLeft(e2) + r2;
            var y2 = Canvas.GetTop(e2) + r2;
            var d = new Vector(x2 - x1, y2 - y1);
            if (d.Length <= r1 + r2)
            {
                Canvas.SetLeft(CellB, rnd.Next(30, 770));
                Canvas.SetTop(CellB, rnd.Next(30, 570));
                CellA.Width = CellA.Width + 7.5;
                CellA.Height = CellA.Height + 7.5;
            }
        }
        public void CheckCollisionBetweenCells(Ellipse e1, Ellipse e2)
        {
            var r1 = e1.ActualWidth / 2;
            var x1 = Canvas.GetLeft(e1) + r1;
            var y1 = Canvas.GetTop(e1) + r1;
            var r2 = e2.ActualWidth / 2;
            var x2 = Canvas.GetLeft(e2) + r2;
            var y2 = Canvas.GetTop(e2) + r2;
            var d = new Vector(x2 - x1, y2 - y1);
            if (d.Length <= ((r1 + r2) / 2) && r1 * .9 > r2)
            {
                if (r1 > r2)
                {
                    CellA.Width = CellA.Width + Math.Sqrt(Blue.Width);
                    CellA.Height = CellA.Height + Math.Sqrt(Blue.Height);
                    Blue.Height = 0;
                    Blue.Width = 0;
                }
            }
            if (d.Length <= ((r2 + r1) / 2) && r2 * .9 > r1)
            {
                Blue.Width = Blue.Width + Math.Sqrt(CellA.Width);
                Blue.Height = Blue.Height + Math.Sqrt(CellA.Height);
                CellA.Height = 0;
                CellA.Width = 0;
            }
        }

        public void CreatePlayer()
        {
            int left;
            int top;
            left = rnd.Next(1, 800);
            top = rnd.Next(1, 600);
            DrawPlayer(30, 30, left, top, "#E74C3C");
            gamePlay.AddFood(15, 15, left, top, "#E74C3C");

        }
        public void DrawPlayer(int width, int height, int left, int top, string color)
        {
            Ellipse ellipse = new Ellipse();
            ellipse.Height = height;
            ellipse.Width = width;
            ellipse.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom(color));
            Canvas.SetLeft(ellipse, left);
            Canvas.SetTop(ellipse, top);

            MainCanvas.Children.Add(ellipse);
        }

        public void CreateFood()
        {
            int left;
            int top;
            left = rnd.Next(1, 800);
            top = rnd.Next(1, 600);
            DrawFood(15, 15, left, top, "#27AE60");
            gamePlay.AddFood(15, 15, left, top, "#27AE60");

        }
        public void DrawFood(int width, int height, int left, int top, string color)
        {
            Ellipse ellipse = new Ellipse();
            ellipse.Height = height;
            ellipse.Width = width;
            ellipse.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom(color));
            Canvas.SetLeft(ellipse, left);
            Canvas.SetTop(ellipse, top);

            MainCanvas.Children.Add(ellipse);
        }

        public void CreateVirus()
        {
            int left;
            int top;
            left = rnd.Next(1, 800);
            top = rnd.Next(1, 600);
            DrawVirus(130, 130, left, top, "#87d37c");
            gamePlay.AddFood(15, 15, left, top, "#87d37c");

        }
        public void DrawVirus(int width, int height, int left, int top, string color)
        {
            Ellipse ellipse = new Ellipse();
            ellipse.Height = height;
            ellipse.Width = width;
            ellipse.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom(color));
            Canvas.SetLeft(ellipse, left);
            Canvas.SetTop(ellipse,top);

            MainCanvas.Children.Add(ellipse);
        }


    }
}
