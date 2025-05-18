namespace ScrubClipboardText;

public class ClipboardScrubber
{
    public static string ScrubClipboardText()
    {
        if (Clipboard.ContainsText())
        {
            Clipboard.SetText(Clipboard.GetText(), TextDataFormat.Text);
            return "Text in clipboard has been scrubbed of formatting.";
        }
        return "Clipboard does not contain text.";
    }
} 