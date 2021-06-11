using System;

namespace design_pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger logger = AppLogger.getLogger();

            logger.log(LogLevel.PENDING, "Pending message");
            logger.log(LogLevel.SUCCESS, "Success message");
            logger.log(LogLevel.ERROR, "Error message");
        }
    }
}
