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
    class Cell
    {

        public double ActualWidth { get; set; }
        public double ActualHeight { get; set; }
        public int Left { get; set; }
        public int Top { get; set; }
        public Ellipse Surface { get; set; }
        public string Color { get; set; }
        public Cell(int width, int height, int left, int top, Ellipse shape, string color)
        {
            this.ActualWidth = width;
            this.ActualHeight = height;
            this.Left = left;
            this.Top = top;
            this.Surface = shape;
            this.Color = color;
        }

        public double CellWidth
        {
            get 
            { 
                return ActualWidth; 
            }
            set
            {
                ActualWidth = value;
                OnPropertyChanged("CellWidth");
            }
        }
         public double CellHeight
        {
            get 
            { 
                 return ActualHeight; 
            }
            set
            {
                ActualHeight = value;
                OnPropertyChanged("CellHeight");
            }
        }
         public int CellLeft
        {
            get 
            { 
                return Left; 
            }
            set
            {
                Left = value;
                OnPropertyChanged("CellLeft");
            }
        }
         public int CellTop
        {
            get 
            { 
                return Top; 
            }
            set
            {
                Top = value;
                OnPropertyChanged("CellTop");
            }
        }

    }
}
