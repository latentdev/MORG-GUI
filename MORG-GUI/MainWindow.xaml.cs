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

            Field field = new Field(3, 3);
            for (int x = 0; x < 1; x++)
            {
                textBox.Text = (a.PerformMove(a, field) + "\n" + b.PerformMove(b, field) + "\n" + c.PerformMove(c, field) + "\n");
            }
            //Canvas myCanvas = new Canvas();

            for (int i = 1; i < field.Getx_size(); i++)
            {
                Line line = new Line();
                line.Stroke = Brushes.Black;
                line.X1 = 1;
                line.X2 = 400;
                line.Y1 = (400 / field.Getx_size()) * i;
                line.Y2 = (400 / field.Getx_size()) * i;


                line.StrokeThickness = 2;
                myCanvas.Children.Add(line);
            }

            for (int i = 1; i < field.Gety_size(); i++)
            {
                Line line = new Line();
                line.Stroke = Brushes.Black;
                line.X1 = (400 / field.Gety_size()) * i;
                line.X2 = (400 / field.Gety_size()) * i;
                line.Y1 = 1 ;
                line.Y2 = 400 ;


                line.StrokeThickness = 2;
                myCanvas.Children.Add(line);
            }
            var color = (Color)ColorConverter.ConvertFromString("Red");
            Text(a.Getx() * (400 / field.Getx_size() / 2), a.Gety()*(400/field.Gety_size()/2), "A", color);
            Text(b.Getx() * ((400 / field.Getx_size()) / 2), b.Gety() * (400 / field.Gety_size() / 2), "B", color);
            Text(c.Getx() * (400 / field.Getx_size() / 2), c.Gety() * (400 / field.Gety_size() / 2), "C", color);

            //textbox.Text("Location of A is: " + a.Getx() * ((400 / field.Getx_size()) / 2) + "," + a.Gety() * ((400 / field.Gety_size()) / 2) + "/n" + "Location of B is: " + a.Getx() * ((400 / field.Getx_size()) / 2));
        }
        private void Text(double x, double y, string text,Color color)
        {

            TextBlock textBlock = new TextBlock();

            textBlock.Text = text;

            textBlock.Foreground = new SolidColorBrush(color);

            Canvas.SetLeft(textBlock, x);

            Canvas.SetTop(textBlock, y);

            myCanvas.Children.Add(textBlock);

        }
    }
}
