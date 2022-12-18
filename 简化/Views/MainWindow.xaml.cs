using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using 带筛选的DataGrid.Core;

namespace 简化.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Employee> employees;

        private ICollectionView collectionView;

        public MainWindow()
        {
            InitializeComponent();
            employees = new(Employee.FakeMany(10));
            collectionView = CollectionViewSource.GetDefaultView(employees);
            dataGrid.ItemsSource = collectionView;
            collectionView.Filter = (item) =>
            {
                var em = item as Employee;
                return em.FirstName.Contains(filterTextBox.Text) || em.LastName.Contains(filterTextBox.Text);
            };
        }

        private void filterTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            collectionView.Refresh();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            employees.Add(Employee.FakeOne());
            collectionView.Refresh();
        }
    }
}
