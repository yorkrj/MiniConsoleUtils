namespace ScrubClipboardText;

public class ClipboardScrubber
{
    public static string ScrubClipboardText()
    {
        bool success = false;
        
        if (Clipboard.ContainsText())
        {
            Clipboard.SetText(Clipboard.GetText(), TextDataFormat.Text);
            success = true;
        }
        else if (Clipboard.ContainsText(TextDataFormat.Rtf))
        {
            Clipboard.SetText(Clipboard.GetText(TextDataFormat.Rtf), TextDataFormat.Text);
            success = true;
        }
        else if (Clipboard.ContainsText(TextDataFormat.Html))
        {
            Clipboard.SetText(Clipboard.GetText(TextDataFormat.Html), TextDataFormat.Text);
            success = true;
        }
        else if (Clipboard.ContainsText(TextDataFormat.UnicodeText))
        {
            Clipboard.SetText(Clipboard.GetText(TextDataFormat.UnicodeText), TextDataFormat.Text);
            success = true;
        }

        return success ? "Text in clipboard has been scrubbed of formatting." : "Clipboard does not contain text.";
    }
} 