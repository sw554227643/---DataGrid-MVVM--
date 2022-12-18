using System.Collections.Generic;
using System.Windows;
using System.Windows.Data;
using 带筛选的DataGrid.Core;

namespace 带筛选的DataGrid.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Employee> employees;
        public MainWindow()
        {
            InitializeComponent();
            employees = new(Employee.FakeMany(10));
            var cvs = this.FindResource("view") as CollectionViewSource;
            cvs.Source = employees;
        }

        private void CollectionViewSource_Filter(object sender, FilterEventArgs e)
        {
            var em = e.Item as Employee;
            var text = filterTextBox.Text;
            e.Accepted = em.FirstName.Contains(text) || em.LastName.Contains(text);
        }

        private void filterTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dataGrid.ItemsSource).Refresh();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            employees.Add(Employee.FakeOne());
            CollectionViewSource.GetDefaultView(dataGrid.ItemsSource).Refresh();
        }
    }
}
