using System.Windows.Forms;
using Xunit;
using ClipboardInfo;

namespace MiniConsoleUtils.Tests;

public class ClipboardInfoTests
{
    [StaFact]
    public void GetClipboardFormats_WhenEmpty_ReturnsEmptyMessage()
    {
        // Arrange
        Clipboard.Clear();

        // Act
        var result = ClipboardInfo.ClipboardInfo.GetClipboardFormats();

        // Assert
        Assert.Equal("Clipboard is empty.", result);
    }

    [StaFact]
    public void GetClipboardFormats_WhenContainsText_ReturnsFormats()
    {
        // Arrange
        Clipboard.Clear();
        Clipboard.SetText("Test text");

        // Act
        var result = ClipboardInfo.ClipboardInfo.GetClipboardFormats();

        // Assert
        Assert.Contains("Clipboard contains the following formats:", result);
        Assert.Contains("Text", result);
    }
} 