using BasarsoftFirst.congrate;
using static System.Runtime.InteropServices.JavaScript.JSType;
using BasarsoftFirst.Service;

namespace BasarsoftFirst.Home

{
    public class Response
    {
        //value-obje / result-bool / message-string
        public object? Value { get; set; }
        public bool Result { get; set; }
        public string Message { get; set; }
        //public Response(object data, bool success, string message)
        //{
        //    Value = data;
        //    Result = success;
        //    Message = message;
        //}
    }
}
