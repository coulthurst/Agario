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
   
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            

        }

        private void Canvas_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {

            //BFT TODO: get calc code out of UI
            //BFT TODO: stop using var keyword
            var pos = e.GetPosition((Canvas)sender);
            var xDistance = pos.X;
            var yDistance = pos.Y;
            var distance = (xDistance * xDistance + yDistance + yDistance);
            if (distance > 1)
            {
                Canvas.SetLeft(cell, pos.X);
                Canvas.SetTop(cell, pos.Y);
            }
        }
        
        
       
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //BFT TODO: get calc code out of UI
            List<Virus> virus = new List<Virus>();

            virus.Add(new Virus()
            {
                Width = 100,
                Height = 100,
                Left = 0,
                Top = 0,
                Color = (SolidColorBrush)(new BrushConverter().ConvertFrom("#87d37c")),
            });
          
            List<Food> food = new List<Food>();

            // ... Add Rect objects.
            food.Add(new Food()
            {
                Width = 10,
                Height = 10,
                Left = 0,
                Top = 0,
                Color = (SolidColorBrush)(new BrushConverter().ConvertFrom("#27AE60")),
            });
            food.Add(new Food()
            {
                Width = 10,
                Height = 10,
                Left = 0,
                Top = 0,
                Color = (SolidColorBrush)(new BrushConverter().ConvertFrom("#2980B9")),
            });
            food.Add(new Food()
            {
                Width = 10,
                Height = 10,
                Left = 0,
                Top = 0,
                Color = (SolidColorBrush)(new BrushConverter().ConvertFrom("#8E44AD")),
            });


            Random rnd = new Random();
            foreach (Food dot in food)
            {

                
                // ... Create food object.
                Ellipse el = new Ellipse();
                el.Width = dot.Width;
                el.Height = dot.Height;
                el.Fill = dot.Color;
                
                Canvas.SetLeft(el, rnd.Next(1, 800));
                Canvas.SetTop(el, rnd.Next(1, 600));

                Canvas1.Children.Add(el);

            }
            
            foreach (Virus blob in virus)
            {


                // ... Create food object.
                Ellipse el = new Ellipse();
                el.Width = blob.Width;
                el.Height = blob.Height;
                el.Fill = blob.Color;

                Canvas.SetLeft(el, rnd.Next(1, 800));
                Canvas.SetTop(el, rnd.Next(1, 600));

                Canvas1.Children.Add(el);

            }
            
        }
        
    }
}
    


