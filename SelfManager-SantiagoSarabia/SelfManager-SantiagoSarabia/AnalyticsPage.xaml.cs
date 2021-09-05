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
    /// Interaction logic for AnalyticsPage.xaml
    /// </summary>
    public partial class AnalyticsPage : Page
    {
        MainWindow w;
        public AnalyticsPage(MainWindow w)
        {
            this.w = w;
            InitializeComponent();
            double averageScore =0;
            int approvedQuant = 0;
            int failedQuant = 0;
            if(w.AssignaturesLength == 0)
            {
                InfoGrid.Visibility = Visibility.Hidden;
                NoAssignaturesText.Visibility = Visibility.Visible;
            }
            else
            {
                InfoGrid.Visibility = Visibility.Visible;
                NoAssignaturesText.Visibility = Visibility.Hidden;
                for (int i = 0; i < w.AssignaturesLength; i++)
                {
                    double current = 0;
                    for (int j = 0; j < 3; j++)
                    {
                        current += w.Grades[i, j] * (w.Pond[j] / 100);
                    }
                    averageScore += current;
                    if (current >= 51) approvedQuant += 1;
                    else failedQuant += 1;
                }
                averageScore /= w.AssignaturesLength;
                AverageScore.Text = Math.Round(averageScore).ToString();
                Approved.Text = approvedQuant.ToString() + " / " + w.AssignaturesLength.ToString();
                Failed.Text = failedQuant.ToString() + " / " + w.AssignaturesLength.ToString();
            }
        }
    }
}
