using System.Diagnostics;
using Download.Util;

namespace Download.Cli;

public class RootCommand(string flag) : ICommand
{
  const string HELP_MESSAGE = """
    usage: downloader [ -h | --help ] [ -v | --version ] <command> [args]

    NOTE: Commands still in development.

    Options:
      -h, --help      Show this help.
      -v, --version   Show the installed program's version.
    """;
  const string VERSION = "1.0.0";

  private bool ShowHelp = flag == "-h" || flag == "--help";
  private bool ShowVersion = flag == "-v" || flag == "--version";

  public Result Execute()
  {
    if (ShowHelp)
    {
      Console.WriteLine(HELP_MESSAGE);
    }
    else
    {
      Console.WriteLine("downloader " + VERSION);
    }

    Debug.Assert(ShowHelp || ShowVersion);

    return Result.Success();
  }
}
