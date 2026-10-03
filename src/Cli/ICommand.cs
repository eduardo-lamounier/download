using Download.Util;

namespace Download.Cli;

public interface ICommand
{
  public abstract Result Execute();
}
