namespace ClipboardInfo;

class Program
{
    [STAThread]
    static void Main()
    {
        Console.WriteLine(ClipboardInfo.GetClipboardFormats());
    }
}
