# MiniConsoleUtils

A collection of lightweight command-line utilities for Windows, built with .NET 8.

## Tools

### ClipboardInfo
Retrieves basic information about the format of the current content on the Windows clipboard.

### ScrubClipboardText
Replaces formatted text in the Windows clipboard with plain text.

## Development and Installation

### Prerequisites
- .NET 8 SDK or later
- Windows 11
- PowerShell 5.1+

### Quick Install
```powershell
git clone https://github.com/yorkrj/MiniConsoleUtils.git
cd MiniConsoleUtils
.\install.ps1
```

The install script:
- Builds the solution in Release configuration
- Installs to `C:\tools`
- Adds the install directory to your user PATH
- Cleans up build artifacts

### Manual Build
```powershell
# Build and publish
dotnet publish MiniConsoleUtils.sln -c Release -o .\publish

# Install (optional)
Copy-Item -Path ".\publish\*" -Destination "C:\tools" -Force -Recurse
```

### Development
```powershell
# Build and run tests
dotnet build
dotnet test

# Run a specific tool
dotnet run --project ClipboardInfo
```
