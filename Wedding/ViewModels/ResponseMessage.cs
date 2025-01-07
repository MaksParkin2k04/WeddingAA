using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Wedding.ViewModels
{
    public class ResponseMessage
    {

        public ResponseMessage(string message, string[]? errors = null)
        {
            Message = message;
            Errors = errors;
        }


        public string Message { get; private set; }
        public string[]? Errors { get; private set; }
    }
}
