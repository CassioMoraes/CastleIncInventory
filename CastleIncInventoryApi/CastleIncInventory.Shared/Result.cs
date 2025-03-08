namespace CastleIncInventory.Shared
{
    public class Result(bool isSuccess = true, string error = "")
    {
        public bool IsFailure => !IsSuccess;
        public bool IsSuccess { get; } = isSuccess;
        public string Error { get; } = error;
    }

}