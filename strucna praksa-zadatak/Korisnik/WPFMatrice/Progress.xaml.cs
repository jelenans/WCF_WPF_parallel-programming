using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace WPFMatrice
{
    /// <summary>
    /// Interaction logic for Progress.xaml
    /// </summary>
    public partial class Progress : Window
    {
        public Progress()
        {
            InitializeComponent();

            ProgressBar PBar2 = new ProgressBar();

            PBar2.IsIndeterminate = false;

            PBar2.Orientation = Orientation.Horizontal;

            PBar2.Width = 200;

            PBar2.Height = 20;

            Duration duration = new Duration(TimeSpan.FromSeconds(20));

            DoubleAnimation doubleanimation = new DoubleAnimation(200.0, duration);

            PBar2.BeginAnimation(ProgressBar.ValueProperty, doubleanimation);

            SBar.Items.Add(PBar2);
        }
    }
}
