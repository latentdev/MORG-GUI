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
using System.Windows.Threading;

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
            Field field = new Field(20, 20);
            button.Tag = field;
             
            TextBlock[] textBlock = new TextBlock[field.orgs.Count];
            field.morgs = textBlock;
            for (int i=0;i<field.orgs.Count;i++)
            {
                textBlock[i] = new TextBlock();
                textBlock[i].Text = field.orgs[i].Gettype();
                textBlock[i].FontWeight = FontWeights.Bold;
                myCanvas.Children.Add(textBlock[i]);
            }

            DrawGrid(field);
            DrawOrganism(field, field.orgs, textBlock);
            myCanvas.UpdateLayout();
        }

        private void Text(double x, double y, string text,Color color, TextBlock textBlock)
        {

            textBlock.Foreground = new SolidColorBrush(color);

            Canvas.SetLeft(textBlock, x);

            Canvas.SetTop(textBlock, y);

        }
        private void DrawGrid(Field field)
        {
            for (int i = 1; i < field.Getx_size(); i++)
            {
                Line line = new Line();
                line.Stroke = Brushes.Black;
                line.X1 = 1;
                line.X2 = 500;
                line.Y1 = (500 / field.Getx_size()) * i;
                line.Y2 = (500 / field.Getx_size()) * i;


                line.StrokeThickness = 2;
                myCanvas.Children.Add(line);
            }

            for (int i = 1; i < field.Gety_size(); i++)
            {
                Line line = new Line();
                line.Stroke = Brushes.Black;
                line.X1 = (500 / field.Gety_size()) * i;
                line.X2 = (500 / field.Gety_size()) * i;
                line.Y1 = 1;
                line.Y2 = 500;


                line.StrokeThickness = 2;
                myCanvas.Children.Add(line);
            }
        }
        private void DrawOrganism(Field field, List <Organism> a,TextBlock[] textBlock)
        {
            var color = (Color)ColorConverter.ConvertFromString("Red");
            int width = 500 / field.Getx_size();
            string t;
            for (int m = 0; m < a.Count; m++)
            {
                t = a[m].Gettype();
                Text(a[m].Getx() * width + (width / 2)-(textBlock[m].ActualWidth/2), a[m].Gety() * width + (width / 2)-(textBlock[m].ActualHeight/2), t, color, textBlock[m]);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Field x = (sender as FrameworkElement).Tag as Field;

            TextBlock[] m = x.morgs;

            x.sim_field();
            DrawOrganism(x, x.orgs, m);
            string text = null;

            for (int i=0;i<x.orgs.Count;i++)
            {
                text += x.orgs[i].getFinal_script() + "\n";
            }
            text += "\n";

            textBox.AppendText(text);
            myCanvas.Dispatcher.Invoke(DispatcherPriority.Normal,new Action(delegate()
            {
                button.Content = button.Content;
            })) ;
        }
    }
}
