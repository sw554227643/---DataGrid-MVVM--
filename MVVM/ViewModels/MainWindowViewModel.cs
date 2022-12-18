using Prism.Commands;
using Prism.Mvvm;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Data;
using 带筛选的DataGrid.Core;

namespace MVVM.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
        {
            AddEmployeeCommand = new DelegateCommand(AddEmployee);
            this.employees = new List<Employee>(Employee.FakeMany(10));
            CollectionView = CollectionViewSource.GetDefaultView(employees);
            CollectionView.Filter = (item) =>
            {
                if (string.IsNullOrEmpty(FilterText)) return true;
                var em = item as Employee;
                return em.FirstName.Contains(FilterText) || em.LastName.Contains(FilterText);
            };
        }

        List<Employee> employees;
        public DelegateCommand AddEmployeeCommand { get; set; }

        private ICollectionView collectionView;
        public ICollectionView CollectionView
        {
            get { return collectionView; }
            set { SetProperty(ref collectionView, value); }
        }

        private string filterText;
        public string FilterText
        {
            get { return filterText; }
            set { SetProperty(ref filterText, value,OnFilterTextChanged); }
        }

        public void OnFilterTextChanged()
        {
            CollectionView.Refresh();
        }

        public void AddEmployee()
        {
            employees.Add(Employee.FakeOne());
            CollectionView.Refresh();
        }
    }
}
