namespace ScrubClipboardText;

class Program
{
    [STAThread]
    static void Main()
    {
        Console.WriteLine(ClipboardScrubber.ScrubClipboardText());
    }
}
