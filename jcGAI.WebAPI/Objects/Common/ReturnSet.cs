namespace jcGAI.WebAPI.Objects.Common
{
    public class ReturnSet<T>
    {
        public T? Value { get; private set; }

        public bool InError => ReturnedException != null;

        public Exception? ReturnedException { get; private set; }

        public string? AdditionalErrorInformation { get; private set; }

        public ReturnSet(T val, string? additionalErrorInformation = null) {
            Value = val;

            AdditionalErrorInformation = additionalErrorInformation;
        }

        public ReturnSet(Exception ex, string? additionalErrorInformation = null)
        {
            ReturnedException = ex;

            AdditionalErrorInformation = additionalErrorInformation;
        }
    }
}