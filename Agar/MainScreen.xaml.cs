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
using System.ComponentModel;

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
        List<Ellipse> playersInGame = new List<Ellipse>();
        List<Ellipse> viruses = new List<Ellipse>();
        List<string> colors = new List<string>();
        Client client = new Client();
        Server server = new Server();

        public MainScreen()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            colors.Add("1488c7");
            colors.Add("20518a");
            colors.Add("f5dd42");
            colors.Add("e0423f");
            colors.Add("e81321");
            colors.Add("31a342");
            colors.Add("8acf65");
            //client.Connect("192.168.101.153", "deh");
            //server.Listen();


            CreatePlayer();
            CreatePlayer();
            CreateVirus();
            CreateFood();
            CreateFood();
            CreateFood();
            CreateFood();
            CreateFood();
            gamePlay.UpdateCells();
            for (int i = 0; i < playersInGame.Count; i++)
            {
                MainCanvas.Children[i].Focus();
            }
        }
        public void CreatePlayer()
        {
            //colors([rnd.Next(0, colors.Count)]);
            //int color = rnd.Next(0, colors.Count);

            int left = rnd.Next(1, 800);
            int top = rnd.Next(1, 600);
            DrawPlayer(30, 30, left, top, "#FFE74C3C");
            gamePlay.AddCell(30, 30, left, top, el, "#FFE74C3C");
        }
        
        public void DrawPlayer(int width, int height, int left, int top, string color)
        {
            Ellipse ellipse = new Ellipse();
            ellipse.Focusable = true;
            Canvas.SetZIndex(ellipse, 2);
            ellipse.Height = height;
            ellipse.Width = width;
            ellipse.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom(color));
            Canvas.SetLeft(ellipse, left);
            Canvas.SetTop(ellipse, top);
            cellsOnScreen.Add(ellipse);
            playersInGame.Add(ellipse);
            MainCanvas.Children.Add(ellipse);
            playersInGame.Add(ellipse);
            ellipse.KeyDown += new KeyEventHandler(OnKeyDown);
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {

            FrameworkElement element = (FrameworkElement)e.OriginalSource;

            switch (e.Key)
            {
                case Key.Left:
                    if (Canvas.GetLeft(element) > 0) Canvas.SetLeft(element, Canvas.GetLeft(element) - 8);
                    for (int i = 0; i < viruses.Count; i++ )
                    {
                        foreach (Ellipse player in playersInGame)
                        {
                            gamePlay.EatVirus(player, viruses[i]);
                            if (gamePlay.CheckCollision(player, viruses[i]) == true)
                            {
                                RemoveVirus(viruses[i]);
                                gamePlay.RemoveVirus(i);
                                gamePlay.UpdateCells();
                            }
                        }
                    }
                        for (int i = 0; i < cellsOnScreen.Count; i++)
                        {
                            foreach (Ellipse player in playersInGame)
                            {
                                gamePlay.EatCell(player, cellsOnScreen[i]);
                                if (gamePlay.CheckCollision(player, cellsOnScreen[i]) == true)
                                {
                                    RemoveCell(cellsOnScreen[i]);
                                    gamePlay.RemoveCell(i);
                                    gamePlay.UpdateCells();
                                }
                            }
                        }
                    break;
                case Key.Right:
                    Canvas.SetLeft(element, Canvas.GetLeft(element) + 8);
                     for (int i = 0; i < viruses.Count; i++ )
                    {
                        foreach (Ellipse player in playersInGame)
                        {
                            gamePlay.EatVirus(player, viruses[i]);
                            if (gamePlay.CheckCollision(player, viruses[i]) == true)
                            {
                                RemoveVirus(viruses[i]);
                                gamePlay.RemoveVirus(i);
                                gamePlay.UpdateCells();
                            }
                        }
                    }
                        for (int i = 0; i < cellsOnScreen.Count; i++)
                        {
                            foreach (Ellipse player in playersInGame)
                            {
                                gamePlay.EatCell(player, cellsOnScreen[i]);
                                if (gamePlay.CheckCollision(player, cellsOnScreen[i]) == true)
                                {
                                    RemoveCell(cellsOnScreen[i]);
                                    gamePlay.RemoveCell(i);
                                    gamePlay.UpdateCells();
                                }
                            }
                        }
                    break;
                case Key.Up:
                    if (Canvas.GetTop(element) > 0) Canvas.SetTop(element, Canvas.GetTop(element) - 8);
                    for (int i = 0; i < viruses.Count; i++ )
                    {
                        foreach (Ellipse player in playersInGame)
                        {
                            gamePlay.EatVirus(player, viruses[i]);
                            if (gamePlay.CheckCollision(player, viruses[i]) == true)
                            {
                                RemoveVirus(viruses[i]);
                                gamePlay.RemoveVirus(i);
                                gamePlay.UpdateCells();
                            }
                        }
                    }
                        for (int i = 0; i < cellsOnScreen.Count; i++)
                        {
                            foreach (Ellipse player in playersInGame)
                            {
                                gamePlay.EatCell(player, cellsOnScreen[i]);
                                if (gamePlay.CheckCollision(player, cellsOnScreen[i]) == true)
                                {
                                    RemoveCell(cellsOnScreen[i]);
                                    gamePlay.RemoveCell(i);
                                    gamePlay.UpdateCells();
                                }
                            }
                        }
                    break;
                case Key.Down:
                    Canvas.SetTop(element, Canvas.GetTop(element) + 8);
                    for (int i = 0; i < viruses.Count; i++ )
                    {
                        foreach (Ellipse player in playersInGame)
                        {
                            gamePlay.EatVirus(player, viruses[i]);
                            if (gamePlay.CheckCollision(player, viruses[i]) == true)
                            {
                                RemoveVirus(viruses[i]);
                                gamePlay.RemoveVirus(i);
                                gamePlay.UpdateCells();
                            }
                        }
                    }
                        for (int i = 0; i < cellsOnScreen.Count; i++)
                        {
                            foreach (Ellipse player in playersInGame)
                            {
                                gamePlay.EatCell(player, cellsOnScreen[i]);
                                if (gamePlay.CheckCollision(player, cellsOnScreen[i]) == true)
                                {
                                    RemoveCell(cellsOnScreen[i]);
                                    gamePlay.RemoveCell(i);
                                    gamePlay.UpdateCells();
                                }
                            }
                        }
                    break;
                    default:
                    return;
            }
        }

        public void CreateFood()
        {
            int left = rnd.Next(1, 800);
            int top = rnd.Next(1, 600);
            DrawCell(15, 15, left, top, "#27AE60");
            gamePlay.AddCell(15, 15, left, top, el, "#27AE60");
        }

        public void CreateVirus()
        {
            int left = rnd.Next(1, 800);
            int top = rnd.Next(1, 600);
            DrawVirus(60, 60, left, top, "#090909");
            gamePlay.AddVirus(60, 60, left, top, el, "#090909");
        }
        public void DrawVirus(int width, int height, int left, int top, string color)
        {
            Ellipse ellipse = new Ellipse();
            ellipse.Height = height;
            ellipse.Width = width;
            Canvas.SetZIndex(ellipse, 3);
            ellipse.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom(color));
            Canvas.SetLeft(ellipse, left);
            Canvas.SetTop(ellipse, top);
            viruses.Add(ellipse);
            MainCanvas.Children.Add(ellipse);
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
            cellsOnScreen.Remove(cell);
            MainCanvas.Children.Remove(cell);
            CreateFood();
        }
        public void RemoveVirus(Ellipse cell)
        {
            viruses.Remove(cell);
            MainCanvas.Children.Remove(cell);
            CreateVirus();
        }
    }
}
