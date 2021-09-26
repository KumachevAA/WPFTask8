using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WPFTask8._1.Models;

namespace WPFTask8._1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<RowModel> Rows { get; } = new ObservableCollection<RowModel>();

        public string Provider { get; set; }

        public string Customer { get; set; }

        public decimal Total { get => Rows.Sum(r => r.Total); }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (RowModel row in Rows)
            {
                row.Total = row.Price * row.Count;
            }
        }
    }
}
