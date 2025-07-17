using System.Data;
using System.Windows.Forms;

// Alternative to [STAThread] using top level statements.
Thread.CurrentThread.SetApartmentState(ApartmentState.Unknown); // It is unfortunate but we have to set it to Unknown first.
Thread.CurrentThread.SetApartmentState(ApartmentState.STA); // This is the only way to use Clipboard.SetText.

if (args.Length == 0)
{
    Console.WriteLine("No arguments provided. Simply enter a formula to be calculated, and the result will be displayed and copied to the clipboard.");
    // TODO Consider an interactive mode.
}
else
{
    string formula = string.Join(" ", args);
    Console.WriteLine("Formula: " + formula);
    decimal result = Convert.ToDecimal(new DataTable().Compute(formula, null));
    Console.WriteLine("Result: " + result);
    Clipboard.SetText(result.ToString());
}
