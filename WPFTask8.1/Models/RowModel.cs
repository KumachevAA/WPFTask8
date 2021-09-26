using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPFTask8._1.Models
{
    public class RowModel : DependencyObject
    {
        public static readonly DependencyProperty IdProperty = DependencyProperty.Register(
            nameof(Id),
            typeof(int),
            typeof(RowModel)
            );
        public static readonly DependencyProperty NameProperty = DependencyProperty.Register(
            nameof(Name),
            typeof(string),
            typeof(RowModel)
            );
        public static readonly DependencyProperty CountProperty = DependencyProperty.Register(
            nameof(Count),
            typeof(int),
            typeof(RowModel)
            );
        public static readonly DependencyProperty PriceProperty = DependencyProperty.Register(
            nameof(Price),
            typeof(decimal),
            typeof(RowModel)
            );
        public static readonly DependencyProperty TotalProperty = DependencyProperty.Register(
            nameof(Total),
            typeof(decimal),
            typeof(RowModel)
            );

        public int Id
        {
            get => (int)GetValue(IdProperty);
            set
            {
                SetValue(IdProperty, value);
            }
        }
        public string Name
        {
            get => (string)GetValue(NameProperty);
            set
            {
                SetValue(NameProperty, value);
            }
        }
        public int Count
        {
            get => (int)GetValue(CountProperty);
            set
            {
                SetValue(CountProperty, value);
            }
        }
        public decimal Price
        {
            get => (decimal)GetValue(PriceProperty);
            set
            {
                SetValue(PriceProperty, value);
            }
        }
        public decimal Total
        {
            get => (decimal)GetValue(TotalProperty);
            set
            {
                SetValue(TotalProperty, value);
            }
        }
    }
}
