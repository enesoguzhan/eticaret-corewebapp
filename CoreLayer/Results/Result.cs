using CoreLayer.Results.ComplexTypes;

namespace CoreLayer.Results
{
    public class Result : IResult
    {
        public StatusCode StatusCode { get; }
        public string UserMessage { get; }
        public Exception Exception { get; }

        public Result(StatusCode status, string userMessage)
        {
            StatusCode = status;
            UserMessage = userMessage;
        }

        public Result(StatusCode status, string userMessage, Exception exception)
        {
            StatusCode = status;
            UserMessage = userMessage;
            Exception = exception;
        }
        /*Sınıfın Türetiminde Sınıfın içerisindeki metot sorumlu ise buna Factory Pattern denir
          Factory Pattern sayesinde sınıflar program yaşam döngüsü boyunca herkes için 1 adet türetilir static keywordu ile birlikte kullanılır
        */
        public static IResult FactoryResult(StatusCode status, string userMessage)
        {
            return new Result(status, userMessage);
        }
        public static IResult FactoryResult(StatusCode status, string userMessage, Exception exception)
        {
            return new Result(status, userMessage, exception);
        }
    }
}
