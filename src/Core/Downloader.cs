using Download.Util;

namespace Download.Core;

public class Downloader(string[] urls)
{
  static readonly HttpClient client = new HttpClient();

  private string[] Urls = urls;

  public async Task<Result> DownloadAsync()
  {
    foreach (var url in Urls)
    {
      string fileName = url.Split("/").Last();

      try
      {
        var content = await client.GetByteArrayAsync(url);
        using var file = File.Create(fileName);
        await file.WriteAsync(content);
      }
      catch
      {
        return Result.Failure($"something went wrong for url \"{url}\"");
      }
    }

    return Result.Success();
  }
}
