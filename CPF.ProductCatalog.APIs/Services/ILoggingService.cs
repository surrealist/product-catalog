namespace CPF.ProductCatalog.APIs.Services
{
    public interface ILoggingService
    {
        void Info(string message);
        void Warn(string message);
    }
}