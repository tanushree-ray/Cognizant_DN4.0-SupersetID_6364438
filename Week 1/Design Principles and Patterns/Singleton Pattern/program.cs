using System;

public class SingletonPattern
{
    public class Logger
    {
        private static Logger instance = new Logger();

        private Logger()
        {
            Console.WriteLine("Logger started");
        }

        public static Logger GetInstance()
        {
            return instance;
        }

        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }

    public static void Main(string[] args)
    {
        Logger log = Logger.GetInstance();
        log.Log("Logger 1 message");

        Logger anotherLog = Logger.GetInstance();
        anotherLog.Log("Logger 2 message");

        if (log == anotherLog)
        {
            Console.WriteLine("Both are same logger");
        }
    }
}
