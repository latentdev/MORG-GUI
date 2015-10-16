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
            Field field = new Field(15, 15);
            button.Tag = field;
             
            TextBlock[] textBlock = new TextBlock[3];
            textBlock[0] = textBlock0;
            textBlock[1] = textBlock1;
            textBlock[2] = textBlock2;

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
        private void DrawOrganism(Field field, Organism[] a,TextBlock[] textBlock)
        {
            var color = (Color)ColorConverter.ConvertFromString("Red");
            int width = 500 / field.Getx_size();
            string t;
            for (int m = 0; m < 3; m++)
            {
                t = a[m].Gettype();
                Text(a[m].Getx() * width + (width / 2)-(textBlock[m].ActualWidth/2), a[m].Gety() * width + (width / 2)-(textBlock[m].ActualHeight/2), t, color, textBlock[m]);
            }
        }
        private void DrawTextBox(Field field,Organism[] x, Canvas control,TextBlock[] textBlock)
        {
            
            textBox.AppendText(x[0].getFinal_script() + "\n" + x[1].getFinal_script()+ "\n" + x[2].getFinal_script() + "\n"+"\n");
            //textBox.Focus();
            //textBox.CaretIndex = textBox.Text.Length;
            //textBox.ScrollToEnd();


        }

        private void step(Organism[] a,Field field)
        {
            for (int m = 0; m < 3; m++)
            {
                a[m].PerformMove(a[m], field);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Field x = (sender as FrameworkElement).Tag as Field;
            TextBlock[] m = new TextBlock[3];
            m[0] = textBlock0;
            m[1] = textBlock1;
            m[2] = textBlock2;
            x.sim_field();
            DrawOrganism(x, x.orgs, m);
            textBox.AppendText(x.orgs[0].getFinal_script() + "\n" + x.orgs[1].getFinal_script() + "\n" + x.orgs[2].getFinal_script() + "\n"+"\n");
            myCanvas.Dispatcher.Invoke(DispatcherPriority.Normal,new Action(delegate()
            {
                button.Content = button.Content;
            })) ;
        }
    }
}
