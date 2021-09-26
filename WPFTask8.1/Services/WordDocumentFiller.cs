using System;
using System.Collections.Generic;
using WPFTask8._1.Models;
using Microsoft.Office.Interop.Word;
using System.Reflection;

namespace WPFTask8._1.Services
{
    public class WordDocumentFiller : IFiller
    {
        private static readonly WordDocumentFactory appFactory = new WordDocumentFactory();
        private static object missing = Missing.Value;

        public string Path { get; set; }

        public void Fill(string supplier, string customer, int number, IEnumerable<RowModel> table, decimal total)
        {
            Application app = appFactory.Application;
            Document document = app.Documents.Add(System.IO.Path.Combine(Environment.CurrentDirectory, "Resources\\Templates\\default.dotx"));

            Table tb = document.Tables[1];

            foreach (RowModel rowModel in table)
            {
                Row newRow = tb.Rows.Add();

                newRow.Cells[1].Range.Text = rowModel.Id.ToString();
                newRow.Cells[2].Range.Text = rowModel.Name;
                newRow.Cells[3].Range.Text = rowModel.Count.ToString();
                newRow.Cells[4].Range.Text = $"{rowModel.Price} р.";
                newRow.Cells[5].Range.Text = $"{rowModel.Total} р.";
            }

            document.ContentControls[1].Range.Text = number.ToString();
            document.ContentControls[2].Range.Text = DateTime.Now.ToString("dd.MM.yyyy");
            document.ContentControls[3].Range.Text = supplier;
            document.ContentControls[4].Range.Text = customer;
            document.ContentControls[5].Range.Text = $"{total} р.";

            document.SaveAs2(Path);
            document.Close();
        }
    }
}
