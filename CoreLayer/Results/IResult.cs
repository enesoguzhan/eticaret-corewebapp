using CoreLayer.Results.ComplexTypes;

namespace CoreLayer.Results
{
    public interface IResult
    {
        public StatusCode StatusCode { get; }
        public string UserMessage { get; }
        public Exception Exception { get; }
    }
}
