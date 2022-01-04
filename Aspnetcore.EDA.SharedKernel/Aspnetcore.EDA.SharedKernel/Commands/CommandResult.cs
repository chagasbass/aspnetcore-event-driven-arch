namespace Aspnetcore.EDA.SharedContext.Base.Commands
{
    public class CommandResult : ICommandResult
    {
        public object Data { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }

        public CommandResult(object data, string message = "", bool success = false)
        {
            Data = data;
            Message = message;
            Success = success;
        }

        public CommandResult()
        {

        }

    }
}
