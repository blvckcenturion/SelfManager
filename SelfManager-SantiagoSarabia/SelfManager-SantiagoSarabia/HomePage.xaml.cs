using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SelfManager_SantiagoSarabia
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        MainWindow w;
        public HomePage(MainWindow w)
        {
            InitializeComponent();
            this.w = w;
            Color DefaultColor = (Color)ColorConverter.ConvertFromString("#ff7157");

            if (w.AssignaturesLength == 0)
            {
                ScrollViewer.Visibility = Visibility.Hidden;
                NoAssignaturesText.Visibility = Visibility.Visible;
            }
            else
            {
                ScrollViewer.Visibility = Visibility.Visible;
                NoAssignaturesText.Visibility = Visibility.Hidden;
                for(int i =0; i< w.AssignaturesLength; i++)
                {
                    TextBlock Assig = new TextBlock();
                    Assig.Text = w.Assignatures[i].AssignatureName;
                    
                    Assig.Height = 50;
                    Assig.TextAlignment = TextAlignment.Center;
                    Assig.FontSize = 20;
                    Assig.Foreground = new SolidColorBrush(DefaultColor);
                    Assignature.Children.Add(Assig);
                    TextBlock N1 = new TextBlock();
                    N1.Text = w.Grades[i,0].ToString();
                    N1.Height = 50;
                    N1.Foreground = new SolidColorBrush(DefaultColor);
                    N1.TextAlignment = TextAlignment.Center;
                    N1.FontSize = 20;
                    Note1.Children.Add(N1);
                    TextBlock N2 = new TextBlock();
                    N2.Text = w.Grades[i, 1].ToString();
                    N2.Height = 50;
                    N2.FontSize = 20;
                    N2.Foreground = new SolidColorBrush(DefaultColor);
                    N2.TextAlignment = TextAlignment.Center;
                    Note2.Children.Add(N2);
                    TextBlock N3 = new TextBlock();
                    N3.Text = w.Grades[i, 2].ToString();
                    
                    N3.Height = 50;
                    N3.FontSize = 20;
                    N3.Foreground = new SolidColorBrush(DefaultColor);
                    N3.TextAlignment = TextAlignment.Center;
                    Note3.Children.Add(N3);
                    TextBlock Prom = new TextBlock();
                    Prom.Text = (w.Grades[i, 0]*(w.Pond[0]/100) + w.Grades[i, 1] * (w.Pond[1] / 100) + w.Grades[i, 2] * (w.Pond[2] / 100)).ToString();
                    
                    Prom.Height = 50;
                    Prom.FontSize = 20;
                    Prom.Foreground = new SolidColorBrush(DefaultColor);
                    Prom.TextAlignment = TextAlignment.Center;
                    Average.Children.Add(Prom);
                }
            }
            
        }
    }
}
