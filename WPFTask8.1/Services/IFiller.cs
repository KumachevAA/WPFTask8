using System.Collections.Generic;
using WPFTask8._1.Models;

namespace WPFTask8._1.Services
{
    public interface IFiller
    {
        void Fill(string supplier, string customer, int number, IEnumerable<RowModel> table, decimal total);
    }
}
