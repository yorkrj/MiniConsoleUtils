using System;
using System.Windows.Forms;

namespace ClipboardInfo;

class Program
{
    [STAThread]
    static void Main()
    {
        IDataObject clipboardData = Clipboard.GetDataObject();

        if (clipboardData == null)
        {
            Console.WriteLine("Clipboard is empty.");
        }
        else
        {
            Console.WriteLine("Clipboard contains the following formats:\n");

            foreach (var format in clipboardData.GetFormats(false))
            {
                Console.WriteLine("    {0}", format);
            }
        }
    }
}
