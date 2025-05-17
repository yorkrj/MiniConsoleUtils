using System;
using System.Windows.Forms;

namespace ScrubClipboardText;

class Program
{
    [STAThread]
    static void Main()
    {
        if (Clipboard.ContainsText())
        {
            Clipboard.SetText(Clipboard.GetText(), TextDataFormat.Text);

            Console.WriteLine("Text in clipboard has been scrubbed of formatting.");
        }
        else
        {
            Console.WriteLine("Clipboard does not contain text.");
        }

#if DEBUG
        Console.Write("\nPress any key to quit.");
        Console.ReadKey();
#endif
    }
}
