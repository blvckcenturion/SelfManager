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

namespace SelfManager_SantiagoSarabia
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        byte current = 1;
        static int assignaturesLength = 0;
        Assignature[] assignatures = new Assignature[assignaturesLength];
        double[,] grades = new double[assignaturesLength, 3];
        double[] pond = new double[3] {35,35,30};

        public double[] Pond {
            get {
                return pond;
            }
            set {
                pond = value;
            }
        }

        public int AssignaturesLength
        {
            get
            {
                return assignaturesLength;
            }
            set
            {
                assignaturesLength = value;
            }
        }
        public Assignature[] Assignatures
        {
            get
            {
                return assignatures;
            }
            set
            {
                assignatures = value;
            }
        }
        public double[,] Grades
        {
            get
            {
                return grades;
            }
            set
            {
                grades = value;
            }
        }







        Color activeColor = (Color)ColorConverter.ConvertFromString("#EE5044");
        Color nonActiveColor = (Color)ColorConverter.ConvertFromString("#F5F5F5");
        
        public void setActive(byte curr)
        {
            Button[] btnArray = { HomeBtn, AddBtn,PondBtn, AnalyticsBtn };
            current = curr;
            foreach (Button b in btnArray) b.Foreground = new SolidColorBrush(nonActiveColor);
            switch (curr)
            {
                case 1:
                    HomeBtn.Foreground = new SolidColorBrush(activeColor);
                    MainContent.Content = new HomePage(this);
                    break;
                case 2:
                    AddBtn.Foreground = new SolidColorBrush(activeColor);
                    MainContent.Content = new AddPage(this);
                    break;
                case 3:
                    PondBtn.Foreground = new System.Windows.Media.SolidColorBrush(activeColor);
                    MainContent.Content = new Pond(this);
                    break;
                case 4:
                    AnalyticsBtn.Foreground = new System.Windows.Media.SolidColorBrush(activeColor);
                    MainContent.Content = new AnalyticsPage(this);  
                    break;
                default:
                    break;
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            setActive(1);
        }

        private void HomeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (current != 1) setActive(1);
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (current != 2) setActive(2);
        }

        private void AnalitycsBtn_Click(object sender, RoutedEventArgs e)
        {
            if (current != 4) setActive(4);
        }

        private void PondBtn_Click(object sender, RoutedEventArgs e)
        {
            if (current != 3) setActive(3);
        }
    }
}
