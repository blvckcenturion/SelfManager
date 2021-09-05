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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SelfManager_SantiagoSarabia
{
    /// <summary>
    /// Interaction logic for AddPage.xaml
    /// </summary>
    public partial class AddPage : Page
    {
        MainWindow w;
        public AddPage(MainWindow w)
        {
            InitializeComponent();
            this.w = w;
        }

        private void AddAssignature_Click(object sender, RoutedEventArgs e)
        {
            if(assignatureName.Text != "")
            {
                bool repeated = false;
                foreach (Assignature a in w.Assignatures)
                {
                    if (a.AssignatureName == assignatureName.Text.ToLower()) repeated = true;
                }
                if (!repeated)
                {
                    double first;
                    bool firstN = double.TryParse(firstNote.Text, out first);
                    double second;
                    bool secondN = double.TryParse(secondNote.Text, out second);
                    double third;
                    bool thirdN = double.TryParse(thirdNote.Text, out third);
                    if (firstN && secondN && thirdN )
                    {
                        if(first >= 0 && first < 101 && second >= 0 && second < 101 && third >= 0 && third < 101)
                        {
                            w.AssignaturesLength += 1;
                            var tempA = w.Assignatures;
                            var tempG = w.Grades;
                            w.Assignatures = new Assignature[w.AssignaturesLength];
                            w.Grades = new double[w.AssignaturesLength, 3];
                            for (int i = 0; i < w.AssignaturesLength; i++)
                            {
                                if (i < w.AssignaturesLength - 1)
                                {
                                    w.Assignatures[i] = tempA[i];
                                    w.Grades[i,0] = tempG[i,0] ;
                                    w.Grades[i, 1] = tempG[i, 1];
                                    w.Grades[i, 2] = tempG[i, 2];
                                }
                                else
                                {
                                    w.Assignatures[i] = new Assignature();
                                    w.Assignatures[i].AssignatureName = assignatureName.Text.ToLower();
                                    w.Assignatures[i].Id = i;
                                    w.Grades[i, 0] = first;
                                    w.Grades[i, 1] = second;
                                    w.Grades[i, 2] = third;
                                }
                                
                            }
                            w.setActive(1);
                        }

                        
                    }
                    else
                    {
                        errorMsg.Text = "Error : Nota no valida";
                    }
                }
                else
                {
                    errorMsg.Text = "Error : Ya existe una materia con este nombre";
                }
            }
            else
            {
                errorMsg.Text = "Error : Materia sin nombre";
            }
        }
    }
}
