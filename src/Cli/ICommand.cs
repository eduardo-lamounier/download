using Download.Util;

namespace Download.Cli;

public interface ICommand
{
  public abstract Task<Result> ExecuteAsync();
}
