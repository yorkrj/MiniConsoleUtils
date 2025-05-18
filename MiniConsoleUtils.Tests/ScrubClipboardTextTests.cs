using System.Windows.Forms;
using Xunit;
using ScrubClipboardText;

namespace MiniConsoleUtils.Tests;

public class ScrubClipboardTextTests
{
    [StaFact]
    public void ScrubClipboardText_WhenEmpty_ReturnsNoTextMessage()
    {
        // Arrange
        Clipboard.Clear();

        // Act
        var result = ClipboardScrubber.ScrubClipboardText();

        // Assert
        Assert.Equal("Clipboard does not contain text.", result);
    }

    [StaFact]
    public void ScrubClipboardText_WhenContainsText_ReturnsSuccessMessage()
    {
        // Arrange
        Clipboard.Clear();
        var rtfText = @"{\rtf1\ansi\deff0{\colortbl;\red255\green0\blue0;}\cf1 This is red text}";
        Clipboard.SetText(rtfText, TextDataFormat.Rtf);
        
        // Verify the text was set
        Assert.True(Clipboard.ContainsText(TextDataFormat.Rtf), "RTF text should be in clipboard");

        // Act
        var result = ClipboardScrubber.ScrubClipboardText();

        // Assert
        Assert.Equal("Text in clipboard has been scrubbed of formatting.", result);
        Assert.True(Clipboard.ContainsText(TextDataFormat.Text), "Plain text should be in clipboard");
        Assert.False(Clipboard.ContainsText(TextDataFormat.Rtf), "RTF should be removed from clipboard");
    }
} 