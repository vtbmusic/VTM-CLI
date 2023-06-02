using System.Text;

namespace VTMCLI.Text;

internal class HelpText
{
    enum HelpType
    {
        Main = 0, Search = 1
    }
    public StringBuilder MainHelpText = new StringBuilder("");
    public HelpText()
    {
        MainHelpText.AppendLine("VTM-CLI " + VTMCLI.Program.Version);
        MainHelpText.AppendLine("This program is under the MIT license.");
        MainHelpText.AppendLine("-------------------------------------------");
        MainHelpText.AppendLine("Main Manual Page 1");
        MainHelpText.AppendLine("-------------------------------------------");
        MainHelpText.AppendLine("Usage: vtmcli [command] [arguments] [command-options] ");
        MainHelpText.AppendLine("");
        MainHelpText.AppendLine("");
        MainHelpText.AppendLine("command:");
        MainHelpText.AppendLine("    about   Show the About text.");
        MainHelpText.AppendLine("    cli     Enter the GUI powered by Gui.cs.");
        MainHelpText.AppendLine("    help    Get help of this program.");
        MainHelpText.AppendLine("    search  Search for the results from VtbMusic Server.");
        MainHelpText.AppendLine("    version Get the version of this program.");
        MainHelpText.AppendLine("-------------------------------------------");
    }
}