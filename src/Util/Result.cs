namespace Download.Util;

public class Result<T>
{
  private T? Value { get; init; } = default;
  private Error? Error { get; init; } = null;

  public bool Successful => Error is null;

  public void Match(Action<T>? inSuccess = null, Action<Error>? inFailure = null)
  {
    if (Successful)
    {
      inSuccess?.Invoke(Value!);
    }
    else
    {
      inFailure?.Invoke(Error!);
    }
  }

  public static Result<T> Success(T value) => new() { Value = value };

  public static Result<T> Failure(Error err) => new() { Error = err };

  public static Result<T> Failure(string errMsg) => new() { Error = new(errMsg) };
}

public class Result
{
  private Error? Error { get; init; } = null;

  public bool Successful => Error is null;

  public void Match(Action? inSuccess = null, Action<Error>? inFailure = null)
  {
    if (Successful)
    {
      inSuccess?.Invoke();
    }
    else
    {
      inFailure?.Invoke(Error!);
    }
  }

  public static Result Success() => new();

  public static Result Failure(Error err) => new() { Error = err };

  public static Result Failure(string errMsg) => new() { Error = new(errMsg) };
}
