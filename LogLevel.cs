using System;

namespace design_pattern
{
    public enum LogLevel
    {
        ERROR = 0,
        SUCCESS = 1,
        PENDING = 2
    }
    public abstract class Logger
    {
        protected LogLevel logLevel;
        protected Logger nextlogger; // The next Handler in the chain

        public Logger(LogLevel logLevel)
        {
            this.logLevel = logLevel;
        }

        // Set the next logger to make a list/chain of Handlers.
        public Logger setNext(Logger nextlogger)
        {
            this.nextlogger = nextlogger;
            return nextlogger;
        }

        public void log(LogLevel severity, String msg)
        {
            if (logLevel == severity)
            {
                writeMessage(msg);
            }
            if (nextlogger != null)
            {
                nextlogger.log(severity, msg);
            }
        }

        protected abstract void writeMessage(String msg);
    }
    public class SuccessLogger : Logger
    {

        public SuccessLogger(LogLevel logLevel) : base(logLevel)
        {
        }

        protected override void writeMessage(String msg)
        {
            Console.WriteLine("Success logger: " + msg);
        }
    }
    public class PendingLogger : Logger
    {

        public PendingLogger(LogLevel logLevel) : base(logLevel)
        {

        }

        protected override void writeMessage(String msg)
        {
            Console.WriteLine("Pending logger: " + msg);
        }
    }
    public class ErrorLogger : Logger
    {

        public ErrorLogger(LogLevel logLevel) : base(logLevel)
        {
        }

        protected override void writeMessage(String msg)
        {
            Console.WriteLine("Error logger: " + msg);
        }
    }
    public class AppLogger
    {

        public static Logger getLogger()
        {
            Logger successLogger = new SuccessLogger(LogLevel.SUCCESS);
            Logger pendingLogger = successLogger.setNext(new PendingLogger(LogLevel.PENDING));
            pendingLogger.setNext(new ErrorLogger(LogLevel.ERROR));
            return successLogger;
        }
    }
}
