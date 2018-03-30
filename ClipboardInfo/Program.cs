using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;

namespace ClipboardInfo
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
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

#if DEBUG
            Console.Write("\nPress any key to quit.");
            Console.ReadKey();
#endif
        }
    }
}
