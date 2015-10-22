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
    class Cell
    {
        
        public double Width { get; set; }
        public double Height { get; set; }
        public int Left { get; set; }
        public int Top { get; set; }
        public string Color { get; set; }
        public Cell(int width, int height, int left, int top, string color)
        {
            this.Width = width;
            this.Height = height;
            this.Left = left;
            this.Top = top;
            this.Color = color;
        }
    }


}
