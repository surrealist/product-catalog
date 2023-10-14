namespace CPF.ProductCatalog.APIs.Services
{
    public class LoggingService : ILoggingService
    {
        private int count;
        private readonly object countLock = new object();

        public void Info(string message)
        {
            lock (countLock)
            {
                count++;
            }
            
            using var writer = new StreamWriter("log.txt", append: true);
            writer.WriteLine($"{count} {DateTimeOffset.Now:o} INFO {message}");
        }

        public void Warn(string message)
        {
            lock (countLock)
            {
                count++;
            }

            using var writer = new StreamWriter("log.txt", append: true);
            writer.WriteLine($"{count} {DateTimeOffset.Now:o} WARN {message}");
        }
    }
}
