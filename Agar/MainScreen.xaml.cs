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
        List<Ellipse> cellsOnScreen = new List<Ellipse>();

        public MainScreen()
        {
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CellA.KeyDown += new KeyEventHandler(OnKeyDown);
            //Blue.KeyDown += new KeyEventHandler(OnKeyDown2);
            
            //Blue.Focus();
            CellA.Focus();
            
            CreateFood();
            CreateFood();
            CreateFood();
            CreateFood();
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
                    for (int i = 0; i < gamePlay.foods.Count; i++)
                    {
                        gamePlay.EatCell(CellA, gamePlay.foods[i]);
                        if (gamePlay.CheckCollision(CellA, gamePlay.foods[i]) == true)
                        {
                            RemoveCell(cellsOnScreen[i]);
                            CreateFood();
                            gamePlay.RemoveFood(gamePlay.foods[i]);
                            gamePlay.AddAllCells();
                        }
                    }
                    break;
                case Key.Right:
                    Canvas.SetLeft(element, Canvas.GetLeft(element) + 8);
                    for (int i = 0; i < gamePlay.foods.Count; i++)
                    {
                        gamePlay.EatCell(CellA, gamePlay.foods[i]);
                        if (gamePlay.CheckCollision(CellA, gamePlay.foods[i]) == true)
                        {
                            RemoveCell(cellsOnScreen[i]);
                            CreateFood();
                            gamePlay.RemoveFood(gamePlay.foods[i]);
                            gamePlay.AddAllCells();
                        }
                    }
                    break;
                case Key.Up:
                    if (Canvas.GetTop(element) > 0) Canvas.SetTop(element, Canvas.GetTop(element) - 8);
                    for (int i = 0; i < gamePlay.foods.Count; i++)
                    {
                        gamePlay.EatCell(CellA, gamePlay.foods[i]);
                        if (gamePlay.CheckCollision(CellA, gamePlay.foods[i]) == true)
                        {
                            RemoveCell(cellsOnScreen[i]);
                            CreateFood();
                            gamePlay.RemoveFood(gamePlay.foods[i]);
                            gamePlay.AddAllCells();
                        }
                    }
                    break;
                case Key.Down:
                    Canvas.SetTop(element, Canvas.GetTop(element) + 8);

                   
                    for (int i = 0; i < gamePlay.foods.Count; i++)
                    {
                        gamePlay.EatCell(CellA, gamePlay.foods[i]);
                        if (gamePlay.CheckCollision(CellA, gamePlay.foods[i]) == true)
                        {
                            RemoveCell(cellsOnScreen[i]);
                            CreateFood();
                            gamePlay.RemoveFood(gamePlay.foods[i]);
                            gamePlay.AddAllCells();
                        }
                    }
                    break;
                    default:
                    return;
            }

        }

        public void CreatePlayer()
        {
            int left = rnd.Next(1, 800);
            int top = rnd.Next(1, 600);
            DrawCell(30, 30, left, top, "#E74C3C");
            gamePlay.AddPlayer(30, 30, left, top, el, "#E74C3C");
        }

        public void CreateFood()
        {
            int left = rnd.Next(1, 800);
            int top = rnd.Next(1, 600);
            DrawCell(15, 15, left, top, "#27AE60");
            gamePlay.AddFood(15, 15, left, top, el, "#27AE60");
        }

        public void CreateVirus()
        {
            int left = rnd.Next(1, 800);
            int top = rnd.Next(1, 600);
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
            cellsOnScreen.Add(ellipse);
            MainCanvas.Children.Add(ellipse);
        }

        public void RemoveCell(Ellipse cell)
        {
            MainCanvas.Children.Remove(cell);
        }

    }
}
