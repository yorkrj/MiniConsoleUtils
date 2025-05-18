namespace ClipboardInfo;

public class ClipboardInfo
{
    public static string GetClipboardFormats()
    {
        IDataObject clipboardData = Clipboard.GetDataObject();

        if (clipboardData == null)
        {
            return "Clipboard is empty.";
        }

        var formats = clipboardData.GetFormats(false);
        if (formats.Length == 0)
        {
            return "Clipboard is empty.";
        }

        var result = "Clipboard contains the following formats:\n";
        foreach (var format in formats)
        {
            result += $"{format}\n";
        }
        return result.TrimEnd();
    }
} 