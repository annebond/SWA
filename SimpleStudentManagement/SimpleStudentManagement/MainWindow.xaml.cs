using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
using SimpleStudentManagement.Models;

namespace SimpleStudentManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Student> Studenten = new List<Student>();
        List<string> Studiengange = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void InputData_Change(object sender, TextChangedEventArgs e)
        {
            btnSpeichern.IsEnabled = !string.IsNullOrWhiteSpace(tboVorname.Text) &&
                                     !string.IsNullOrWhiteSpace(tboNachname.Text) &&
                                     !string.IsNullOrWhiteSpace(tboAlter.Text);
        }

        private void SpeichernButton_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Studenten.Add(new Student()
                {
                    Alter = Convert.ToInt32(tboAlter.Text),
                    Vorname = tboVorname.Text,
                    Nachname = tboNachname.Text,
                    Studiengang = cboStudiengang.SelectionBoxItemStringFormat,
                    Bezahlt = chkBezahlt.IsChecked.GetValueOrDefault()
                });
                UpdateStudentenDataGrid();
            }
            catch (System.FormatException)
            {
                //alter zurücksetzen, wenn keine zahlen eingegeben werden
                tboAlter.Text = "";
            }
            
        }

        private void UpdateStudentenDataGrid()
        {
            dtgStudentenData.ItemsSource = null;
            dtgStudentenData.ItemsSource = Studenten;

        }

        private void RemoveFromStudentenDataGrid()
        {
            Studenten.RemoveAt(dtgStudentenData.SelectedIndex);
            UpdateStudentenDataGrid();
        }

        private void EditierenButton_OnClick(object sender, RoutedEventArgs e)
        {
            var selected = dtgStudentenData.SelectedItem as Student;
            if (selected != null)
            {
                //werte aus liste in inputdata übernehmen
                tboAlter.Text = selected.Alter + "";
                tboNachname.Text = selected.Nachname;
                tboVorname.Text = selected.Vorname;
                chkBezahlt.IsChecked = selected.Bezahlt;
                cboStudiengang.SelectedItem = selected.Studiengang;

                //eintrag aus liste löschen
                RemoveFromStudentenDataGrid();
            }
        }

        private void DeleteButton_OnClick(object sender, RoutedEventArgs e)
        {
            RemoveFromStudentenDataGrid();
        }

        private void Stammdaten_SpeichernButton_OnClick(object sender, RoutedEventArgs e)
        {
            Studiengange.Add(tboNeuerStudiengang.Text);
            lboStudiengange.ItemsSource = null;
            lboStudiengange.ItemsSource = Studiengange;
            cboStudiengang.ItemsSource = null;
            cboStudiengang.ItemsSource = Studiengange;

        }

        private void Stammdaten_InputData_Change(object sender, TextChangedEventArgs e)
        {
            Masterdata_Speichern.IsEnabled = !string.IsNullOrWhiteSpace(tboNeuerStudiengang.Text);
        }
    }
}
