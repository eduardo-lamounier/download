using Download.Core;
using Download.Util;

namespace Download.Cli;

public class RootCommand : ICommand
{
  const string HELP_MESSAGE = """
    usage: downloader [ -h | --help ] [ -v | --version ] [urls]

    NOTE: Commands still in development.

    Options:
      -h, --help      Show this help.
      -v, --version   Show the installed program's version.
    """;
  const string VERSION = "1.0.0";

  private bool ShowHelp;
  private bool ShowVersion;

  private string[] Urls = [];

  public async Task<Result> ExecuteAsync()
  {
    if (ShowHelp)
    {
      Console.WriteLine(HELP_MESSAGE);
    }
    else if (ShowVersion)
    {
      Console.WriteLine("downloader " + VERSION);
    }
    else
    {
      Downloader d = new(Urls);
      return await d.DownloadAsync();
    }

    return Result.Success();
  }

  public RootCommand(string[] parameters)
  {
    ShowHelp = parameters.Contains("-h") || parameters.Contains("--help");
    ShowVersion = parameters.Contains("-v") || parameters.Contains("--version");

    if (!ShowHelp && !ShowVersion)
    {
      Urls = parameters;
    }
  }
}
