namespace _0_Framework.Application
{
    public class OperationResult
    {
        public string Message = string.Empty;
        public bool IsSucceeded;

        public OperationResult Successful(string message = "operation was successfully.")
        {
            Message = message;
            return this;
        }
        public OperationResult Failed(string message = "operation was Failed.")
        {
            Message = message;
            return this;
        }
    }
}
