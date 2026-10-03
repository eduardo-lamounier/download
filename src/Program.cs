using Downloader.Cli;
using Downloader.Util;

namespace Downloader;

public class Program
{
  static void Main(string[] args)
  {
    ICommand? command = null;
    Parse(args)
      .Match(
        inSuccess: (ICommand c) => command = c,
        inFailure: (Error err) =>
        {
          Console.WriteLine("ERROR: " + err.Message);
          Environment.ExitCode = 1;
        }
      );

    command
      ?.Execute()
      .Match(
        inFailure: (Error err) =>
        {
          Console.WriteLine("ERROR: " + err.Message);
          Environment.ExitCode = 1;
        }
      );
  }

  static Result<ICommand> Parse(string[] args)
  {
    if (args.Length == 0)
    {
      return Result<ICommand>.Failure("expected at least some argument or flag");
    }

    switch (args[0])
    {
      default:
        if (args[0].Length < 2 || !args[0].StartsWith("--"))
        {
          return Result<ICommand>.Failure($"unknown command {args[0]}");
        }

        return Result<ICommand>.Success(new RootCommand(args[0]));
    }
  }
}
