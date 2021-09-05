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
    /// Interaction logic for Pond.xaml
    /// </summary>
    public partial class Pond : Page
    {
        MainWindow w;
        public Pond(MainWindow w)
        {
            InitializeComponent();
            this.w = w;
            PondOne.Text = w.Pond[0].ToString();
            PondTwo.Text = w.Pond[1].ToString();
            PondThree.Text = w.Pond[2].ToString();
        }

        private void AddAssignature_Click(object sender, RoutedEventArgs e)
        {
            double pond1;
            double pond2;
            double pond3;
            bool pond1Valid = double.TryParse(PondOne.Text, out pond1);
            bool pond2Valid = double.TryParse(PondTwo.Text, out pond2);
            bool pond3Valid = double.TryParse(PondThree.Text, out pond3);
            if(pond1Valid && pond2Valid && pond3Valid )
            {
                if (pond1 + pond2 + pond3 == 100)
                {
                    w.Pond[0] = pond1;
                    w.Pond[1] = pond2;
                    w.Pond[2] = pond3;
                    w.setActive(1);
                }
                else
                {
                    errorMsg.Text = "Error : la suma de las 3 debe dar 100";
                }
                   
            }
            else
            {
                errorMsg.Text = "Error : Numero no valido";
            }
        }
    }
}
