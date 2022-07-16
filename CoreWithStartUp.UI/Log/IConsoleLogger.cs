namespace CoreWithStartUp.UI.Log
{
    public interface IConsoleLogger
    {
        void Error(string logInfo);
        void Info(string logInfo);
        void Success(string logInfo);
        void Warning(string logInfo);
    }
}