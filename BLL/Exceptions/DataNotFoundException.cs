namespace BusinessLogic.Exceptions
{
    internal class DataNotFoundException : Exception
    {
        public DataNotFoundException()
        {
        }

        public DataNotFoundException(string? message) : base(message)
        {
        }
    }
}