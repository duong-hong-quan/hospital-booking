namespace BookingHospital.Services.Shared;

public record Result<T>(T? Value, bool IsSuccess, string Error = "");

public record Result(bool IsSuccess, string Error = "")
{
    public static Result Success() => new(true);
    public static Result Failure(string error) => new(false, error);
    public static Result<T> Success<T>(T value) => new(value, true);
    public static Result<T> Failure<T>(string error) => new(default, false, error);
}