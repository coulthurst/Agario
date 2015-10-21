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
        

        //public void CheckCollisionFood(Ellipse e1, Ellipse e2)
        //{
        //    var r1 = e1.ActualWidth / 2;
        //    var x1 = Canvas.GetLeft(e1) + r1;
        //    var y1 = Canvas.GetTop(e1) + r1;
        //    var r2 = e2.ActualWidth / 2;
        //    var x2 = Canvas.GetLeft(e2) + r2;
        //    var y2 = Canvas.GetTop(e2) + r2;
        //    var d = new Vector(x2 - x1, y2 - y1);
        //    if (d.Length <= r1 + r2)
        //    {
        //        Canvas.SetLeft(CellB, rnd.Next(30, 770));
        //        Canvas.SetTop(CellB, rnd.Next(30, 570));
        //        CellA.Width = CellA.Width + 7.5;
        //        CellA.Height = CellA.Height + 7.5;
        //    }
        //}
        //public void CheckCollisionBetweenCells(Ellipse e1, Ellipse e2)
        //{
        //    var r1 = e1.ActualWidth / 2;
        //    var x1 = Canvas.GetLeft(e1) + r1;
        //    var y1 = Canvas.GetTop(e1) + r1;
        //    var r2 = e2.ActualWidth / 2;
        //    var x2 = Canvas.GetLeft(e2) + r2;
        //    var y2 = Canvas.GetTop(e2) + r2;
        //    var d = new Vector(x2 - x1, y2 - y1);
        //    if (d.Length <= ((r1 + r2) / 2) && r1 * .9 > r2)
        //    {
        //        if (r1 > r2)
        //        {
        //            CellA.Width = CellA.Width + Math.Sqrt(Blue.Width);
        //            CellA.Height = CellA.Height + Math.Sqrt(Blue.Height);
        //            Blue.Height = 0;
        //            Blue.Width = 0;
        //        }
        //    }
        //    if (d.Length <= ((r2 + r1) / 2) && r2 * .9 > r1)
        //    {
        //        Blue.Width = Blue.Width + Math.Sqrt(CellA.Width);
        //        Blue.Height = Blue.Height + Math.Sqrt(CellA.Height);
        //        CellA.Height = 0;
        //        CellA.Width = 0;
        //    }
        //}

        //public void CreatePlayer()
        //{
        //    List<Player> player = new List<Player>();
        //    player.Add(new Player(75, 75, 0, 0) { Color = (SolidColorBrush)(new BrushConverter().ConvertFrom("#E74C3C")), });

        //    foreach (Player cell in player)
        //    {
        //        //create player object
        //        Ellipse el = new Ellipse();
        //        el.Width = cell.Width;
        //        el.Height = cell.Height;
        //        el.Fill = cell.Color;

        //        Canvas.SetLeft(el, rnd.Next(1, 800));
        //        Canvas.SetTop(el, rnd.Next(1, 600));

        //        canvasPanel.Children.Add(el);
        //    }
        //}


        //public void CreateVirus()
        //{
        //    List<Virus> virus = new List<Virus>();

        //    virus.Add(new Virus(150, 150, 0, 0) { Color = (SolidColorBrush)(new BrushConverter().ConvertFrom("#87d37c")), });

        //    foreach (Virus blob in virus)
        //    {
        //        // ... Create virus object.
        //        Ellipse el = new Ellipse();
        //        el.Width = blob.Width;
        //        el.Height = blob.Height;
        //        el.Fill = blob.Color;

        //        Canvas.SetLeft(el, rnd.Next(1, 800));
        //        Canvas.SetTop(el, rnd.Next(1, 600));

        //        canvasPanel.Children.Add(el);
        //    }
        //}
       

        //public void CreateFood()
        //{
        //    List<Food> food = new List<Food>();

        //    food.Add(new Food(15, 15, 0, 0) { Color = (SolidColorBrush)(new BrushConverter().ConvertFrom("#27AE60")), });

        //    foreach (Food dot in food)
        //    {
        //        // ... Create food object.
        //        Ellipse el = new Ellipse();
        //        el.Width = dot.Width;
        //        el.Height = dot.Height;
        //        el.Fill = dot.Color;
        //        canvasPanel.Children.Add(el);
        //        Canvas.SetLeft(el, rnd.Next(1, 800));
        //        Canvas.SetTop(el, rnd.Next(1, 600));

                
        //    }
        //}
    }
}
