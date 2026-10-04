using Download.Cli;
using Download.Util;

namespace Download;

public class Program
{
  static async Task Main(string[] args)
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

    if (command is not null)
    {
      (await command.ExecuteAsync()).Match(
        inFailure: (Error err) =>
        {
          Console.WriteLine("ERROR: " + err.Message);
          Environment.ExitCode = 1;
        }
      );
    }
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
        return Result<ICommand>.Success(new RootCommand(args));
    }
  }
}
