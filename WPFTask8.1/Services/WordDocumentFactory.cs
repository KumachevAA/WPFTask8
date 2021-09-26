using Microsoft.Office.Interop.Word;

namespace WPFTask8._1.Services
{
    public class WordDocumentFactory
    {
        public Application Application
        {
            get
            {
                Application application = new Application
                {
                    ShowAnimation = false,
                    Visible = false
                };

                return application;
            }
        }
    }
}
