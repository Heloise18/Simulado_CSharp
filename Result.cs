namespace simulado;

public record Result<T>(
    T? Value,
    bool IsSuccessfull,
    string? Reason
)
{
    public static Result<T> Success(T Value)
        => new(Value, true, null);

    public static Result<T> Fail(string reason)
        => new(default, false, reason);
}