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
        
        public int Width { get; set; }
        public int Height { get; set; }
        public int Left { get; set; }
        public int Top { get; set; }
        //public Rect Bounds { get; set; }
        public SolidColorBrush Color { get; set; }
    }
}
