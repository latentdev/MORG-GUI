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

namespace MORG_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Organism a = new ORG_A();
            Organism b = new ORG_B();
            Organism c = new ORG_C();

            Field field = new Field(10, 10);
            textBox.Text = (a.PerformMove(a,field) + "\n" + b.PerformMove(b,field) + "\n" + c.PerformMove(c, field) + "\n");
            //Canvas myCanvas = new Canvas();
            Line line = new Line();
            line.Stroke = Brushes.LightSteelBlue;

            line.X1 = 1;
            line.X2 = 100;
            line.Y1 = 1;
            line.Y2 = 100;

            line.StrokeThickness = 3;
            myCanvas.Children.Add(line);
        }
    }
}
