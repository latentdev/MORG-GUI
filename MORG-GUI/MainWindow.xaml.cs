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
            Field field = new Field(10, 10);
            Organism[] x = new Organism[3];
            TextBlock[] textBlock = new TextBlock[3];
            x[0] = new ORG_A();
            x[1] = new ORG_B();
            x[2] = new ORG_C();
            textBlock[0] = new TextBlock();
            textBlock[0].Text = null;
            textBlock[1] = new TextBlock();
            textBlock[1].Text = null;
            textBlock[2] = new TextBlock();
            textBlock[2].Text = null;


            DrawGrid(field);
            for (int i=0;i<3; i++)
            step(x, field);

            DrawTextBox(field, x, myCanvas, textBlock);

            //Canvas myCanvas = new Canvas();
            DrawOrganism(field, x, textBlock);

            //System.Threading.Thread.Sleep(3000);
            myCanvas.UpdateLayout();
        }

        private void Text(double x, double y, string text,Color color, TextBlock textBlock)
        {

            

            textBlock.Text = text;

            textBlock.Foreground = new SolidColorBrush(color);

            Canvas.SetLeft(textBlock, x);

            Canvas.SetTop(textBlock, y);

            myCanvas.Children.Add(textBlock);

        }
        private void DrawGrid(Field field)
        {
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
                line.Y1 = 1;
                line.Y2 = 400;


                line.StrokeThickness = 2;
                myCanvas.Children.Add(line);
            }
        }
        private void DrawOrganism(Field field, Organism[] a,TextBlock[] textBlock)
        {
            var color = (Color)ColorConverter.ConvertFromString("Red");
            int width = 400 / field.Getx_size();
            string t;
            for (int m = 0; m < 3; m++)
            {
                t = a[m].Gettype();
                Text(a[m].Getx() * width + (width / 2), a[m].Gety() * width + (width / 2), t, color, textBlock[m]);
            }
        }
        private void DrawTextBox(Field field,Organism[] x, Canvas control,TextBlock[] textBlock)
        {
            
            textBox.AppendText(x[0].getFinal_script() + "\n" + x[1].getFinal_script()+ "\n" + x[2].getFinal_script() + "\n");


        }

        private void step(Organism[] a,Field field)
        {
            for (int m = 0; m < 3; m++)
            {
                a[m].PerformMove(a[m], field);
            }
        }
    }
}
