namespace Download.Util;

public class Error(string msg)
{
  public string Message => msg;

  public void Println()
  {
    Console.WriteLine(Message);
  }
}
