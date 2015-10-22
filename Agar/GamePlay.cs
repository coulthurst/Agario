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
    class GamePlay
    {
        
        public List<Player> players = new List<Player>();
        public List<Food> foods = new List<Food>();
        public List<Virus> viruses = new List<Virus>();
        Random rnd = new Random();
        public Ellipse el = new Ellipse();
        public List<Cell> allCells = new List<Cell>();

        public GamePlay()
        {
        }
        

        public List<Food> AddFood(int width, int height, int left, int top, string color)
        {
            foods.Add(new Food(width, height, left, top, color));
            return foods;
        }

        public List<Player> AddPlayer(int width, int height, int left, int top, string color)
        {
            players.Add(new Player(width, height, left, top, color));
            return players;
         }

        public List<Virus> AddVirus(int width, int height, int left, int top, string color)
        {
            viruses.Add(new Virus(width, height, left, top, color));
            return viruses;
         }

        public List<Cell> AddAllCells()
        {
            allCells.AddRange(foods);
            allCells.AddRange(players);
            allCells.AddRange(viruses);
            return allCells;
        }
        public bool CheckCollision(Ellipse e1, Ellipse e2)
        {
            bool collision = false;
            var r1 = e1.ActualWidth / 2;
            var x1 = Canvas.GetLeft(e1) + r1;
            var y1 = Canvas.GetTop(e1) + r1;
            var r2 = e2.ActualWidth / 2;
            var x2 = Canvas.GetLeft(e2) + r2;
            var y2 = Canvas.GetTop(e2) + r2;
            var d = new Vector(x2 - x1, y2 - y1);
            return (collision = (d.Length <= ((r1 + r2) / 2) && r1 * .9 > r2));
        }        

        public void EatCell(Ellipse e1, Ellipse e2)
        {
            if (CheckCollision(e1, e2) == true)
                {
                 e1.Width = e1.Width + Math.Sqrt(e2.Width);
                 e1.Height = e1.Height + Math.Sqrt(e2.Height);
                }
            }
        }
       
    }

