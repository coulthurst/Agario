﻿using System;
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
    class Virus : Cell
    {
        public Virus(int width, int height, int left, int top)
        {
            this.Width = width;
            this.Height = height;
            this.Left = left;
            this.Top = top;
        }
    }
}
