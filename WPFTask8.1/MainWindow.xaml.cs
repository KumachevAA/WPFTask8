using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using WPFTask8._1.Models;
using WPFTask8._1.Services;

namespace WPFTask8._1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public ObservableCollection<RowModel> Rows { get; } = new ObservableCollection<RowModel>();

        public string Provider { get; set; }

        public string Customer { get; set; }

        public string OrderNumber { get; set; }

        public decimal Total { get => Rows.Sum(r => r.Total); }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void FillTable(string Path)
        {
            IFiller filler = new WordDocumentFiller
            {
                Path = Path
            };

            filler.Fill(Provider, Customer, int.Parse(OrderNumber), Rows, Total);
            MessageBox.Show("Отчет экспортирован");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (RowModel row in Rows)
            {
                row.Total = row.Price * row.Count;
            }

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Total)));

            FillTable(System.IO.Path.Combine(Environment.CurrentDirectory, $"Отчет {OrderNumber} от {DateTime.Now.ToString("dd.MM.yyyy")}.docx"));
        }
    }
}
