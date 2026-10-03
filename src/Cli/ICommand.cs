using Downloader.Util;

namespace Downloader.Cli;

public interface ICommand
{
  public abstract Result Execute();
}
