using System;
namespace ADVOOP
{
    public class LoggingBroker
    {
        
        //writes into log file
        public static void LogError(Exception ex)
        {
            string path = "./LogFiles/ErrorLogs.txt";
            if(!File.Exists(path))
            {
                Directory.CreateDirectory("LogFiles");
                File.AppendAllText(path, "==================================================================================================\n");
                File.AppendAllText(path,  "[" + DateTime.Now +"]" + ": " +  ex.ToString() + "\n");
                File.AppendAllText(path, "==================================================================================================\n");
                System.Console.WriteLine(ex.ToString());
            }
            else
            {
                File.AppendAllText(path, "=================================================================================================\n");
                File.AppendAllText(path,  "[" + DateTime.Now + "]" + ": " + ex.ToString() + "\n");
                File.AppendAllText(path, "=================================================================================================\n");
                
                System.Console.WriteLine("=================================================================================================");
                System.Console.WriteLine("[" + DateTime.Now + "]" + ": " + ex.ToString());
                System.Console.WriteLine("=================================================================================================");

            }
        }

        //writes into log file
    }
}