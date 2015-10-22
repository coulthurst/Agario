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
        public Ellipse el = new Ellipse();
        private Random rnd = new Random();
        

        public MainScreen()
        {
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CellA.KeyDown += new KeyEventHandler(OnKeyDown);
            Blue.KeyDown += new KeyEventHandler(OnKeyDown2);
            
            Blue.Focus();
            CellA.Focus();
            
            CreateFood();
            
            gamePlay.AddAllCells();
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
                        gamePlay.EatCell(CellA, gamePlay.allCells[i]);
                    }
                    break;
                case Key.Right:
                    Canvas.SetLeft(element, Canvas.GetLeft(element) + 8);
                    for (int i = 0; i < gamePlay.allCells.Count; i++)
                    {
                        gamePlay.EatCell(CellA, gamePlay.allCells[i]);
                    }
                    break;
                case Key.Up:
                    if (Canvas.GetTop(element) > 0) Canvas.SetTop(element, Canvas.GetTop(element) - 8);
                    for (int i = 0; i < gamePlay.allCells.Count; i++)
                    {
                        gamePlay.EatCell(CellA, gamePlay.allCells[i]);
                    }
                    break;
                case Key.Down:
                    Canvas.SetTop(element, Canvas.GetTop(element) + 8);
                    for (int i = 0; i < gamePlay.allCells.Count; i++)
                    {
                        gamePlay.EatCell(CellA, gamePlay.allCells[i]);
                    }
                    break;
                default:
                    return;
            }

        }
        
        private void OnKeyDown2(object sender, KeyEventArgs e)
        {
            
                FrameworkElement element = (FrameworkElement)e.OriginalSource;

                switch (e.Key)
                {
                    case Key.A:
                        if (Canvas.GetLeft(element) > 0) Canvas.SetLeft(element, Canvas.GetLeft(element) - 8);

                        for (int i = 0; i < gamePlay.allCells.Count; i++)
                        {
                            gamePlay.EatCell(Blue, gamePlay.allCells[i]);
                        }
                        break;
                    case Key.D:
                        Canvas.SetLeft(element, Canvas.GetLeft(element) + 8);
                        for (int i = 0; i < gamePlay.allCells.Count; i++)
                        {
                            gamePlay.EatCell(Blue, gamePlay.allCells[i]);
                        }
                        break;
                    case Key.W:
                        if (Canvas.GetTop(element) > 0) Canvas.SetTop(element, Canvas.GetTop(element) - 8);
                        for (int i = 0; i < gamePlay.allCells.Count; i++)
                        {
                            gamePlay.EatCell(Blue, gamePlay.allCells[i]);
                        }
                        break;
                    case Key.S:
                        Canvas.SetTop(element, Canvas.GetTop(element) + 8);
                        for (int i = 0; i < gamePlay.allCells.Count; i++)
                        {
                            gamePlay.EatCell(Blue, gamePlay.allCells[i]);

                        }
                        break;
                    default:
                        return;

                }
            }

        public void CreatePlayer()
        {
            int left;
            int top;
            left = rnd.Next(1, 800);
            top = rnd.Next(1, 600);
            DrawCell(30, 30, left, top, "#E74C3C");
            gamePlay.AddPlayer(30, 30, left, top, el, "#E74C3C");
        }

        public void CreateFood()
        {
            int left;
            int top;
            left = rnd.Next(1, 800);
            top = rnd.Next(1, 600);
            DrawCell(15, 15, left, top, "#27AE60");
            gamePlay.AddFood(15, 15, left, top, el, "#27AE60");
        }

        public void CreateVirus()
        {
            int left;
            int top;
            left = rnd.Next(1, 800);
            top = rnd.Next(1, 600);
            DrawCell(130, 130, left, top, "#87d37c");
            gamePlay.AddVirus(130, 130, left, top, el, "#87d37c");
        }
       
        public void DrawCell(int width, int height, int left, int top, string color)
        {
            Ellipse ellipse = new Ellipse();
            ellipse.Height = height;
            ellipse.Width = width;
            ellipse.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom(color));
            Canvas.SetLeft(ellipse, left);
            Canvas.SetTop(ellipse, top);

            MainCanvas.Children.Add(ellipse);
        }


    }
}
