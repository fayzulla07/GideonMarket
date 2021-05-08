using System;


namespace GideonMarket.UseCases.Exceptions
{
    public class ValidatorException<T> : Exception
    {
        public T Error { get; set; }
        public ValidatorException(T error, string messsage) : base(messsage)
        {
            this.Error = error;
        }
        public ValidatorException(T error)
        {
            this.Error = error;
        }
    }
}
