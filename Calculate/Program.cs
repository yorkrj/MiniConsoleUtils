using System;
using System.Data;

// Since we are using top level statements, this alternative to [STAThread] is needed to use Clipboard.SetText.
Thread.CurrentThread.SetApartmentState(ApartmentState.Unknown); // Yes, this has to be set first in order for STA to work.
Thread.CurrentThread.SetApartmentState(ApartmentState.STA);

var helpArgs = new[] { "-h", "--help", "/?" };
if (args.Length > 0 && Array.Exists(args, arg => helpArgs.Contains(arg)))
{
    DisplayHelp();
    return;
}

var formula = string.Empty;

if (args.Length == 0)
{
    Console.WriteLine("Enter a mathematical formula to be calculated, and the result will be displayed and copied to the clipboard or you can get further help by entering 'help'."
    + Environment.NewLine);
    Console.Write("Enter a formula or 'help': ");
    formula = Console.ReadLine();
    if (formula == "help") {
        DisplayHelp();
        return;
    }
}
else
{
    formula = string.Join(" ", args);
}

if (String.IsNullOrWhiteSpace(formula)) {
    Console.WriteLine("A formula was not provided.");
    return;
}

decimal result = Decimal.MinValue;
try
{
    result = Convert.ToDecimal(new DataTable().Compute(formula, null));
} catch(Exception e) {
    Console.Error.WriteLine($"There was an error solving this formula: {e.Message}");
    Environment.Exit(1);
}

var solvedFormula = $"{formula} = {result}";
Console.WriteLine(solvedFormula);
Clipboard.SetText(solvedFormula);


static void DisplayHelp()
{
    Console.WriteLine("Calculate - Command Line Calculator");
    Console.WriteLine("Evaluates mathematical expressions and copies the result to the clipboard." + Environment.NewLine);
    
    Console.WriteLine("Usage:");
    Console.WriteLine("  calculate [mathematical expression]");
    Console.WriteLine("  calculate [options]" + Environment.NewLine);
    
    Console.WriteLine("Options:");
    Console.WriteLine("  -h, --help, /?   Display help." + Environment.NewLine);
    
    Console.WriteLine("Examples:");
    Console.WriteLine("  calculate 2 + 2");
    Console.WriteLine("  calculate \"10 * 5 / 2\"");
    Console.WriteLine("  calculate 1.5 * 3.7" + Environment.NewLine);
    
    Console.WriteLine("Supported Operations:");
    Console.WriteLine("  +    Addition");
    Console.WriteLine("  -    Subtraction");
    Console.WriteLine("  *    Multiplication");
    Console.WriteLine("  /    Division");
    Console.WriteLine("  %    Modulus");
    Console.WriteLine("  ()   Parentheses for grouping" + Environment.NewLine);
    
    Console.WriteLine("Notes:");
    Console.WriteLine("- Warning: Only use this tool with trusted input. Do not expose it as a service or use it in environments where untrusted users can provide input.");
    Console.WriteLine("- Results are automatically copied to the clipboard.");
    Console.WriteLine("- Decimal precision is supported.");
    Console.WriteLine("- When providing an expression as a command-line argument, enclose expressions with parentheses or special characters in quotes to ensure correct parsing.");
    Console.WriteLine("  Example: calculate \"(2 + 2) * 3\"");
    Console.WriteLine("- When using interactive mode (no arguments), you can type any mathematical expression, including those with spaces, parentheses, or special characters.");
    Console.WriteLine();
}