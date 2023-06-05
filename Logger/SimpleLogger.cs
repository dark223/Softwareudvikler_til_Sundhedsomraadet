using System.IO;
using System.Text;

namespace Logger
{
    /// <summary>
    /// A simple logger that will either create a file or write to an exsisting file named log.txt in the project folder of the running project
    /// e.g PalindromeChallenge\bin
    /// In this file it will write the time, source, message and stacktrace of the exception
    /// or write a text specified by the user.
    /// </summary>
    public static class SimpleLogger
    {
        public static async void Log(Exception e)
        {
            try
            {
                string workingDirectory = Environment.CurrentDirectory;
                string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;

                StringBuilder sb = new StringBuilder();
                sb.Append("Time: " + DateTime.Now + "\n");
                sb.Append("Source: " + e.Source + "\n");
                sb.Append("Message: " + e.Message + "\n");
                sb.Append("StackTrace: " + e.StackTrace + "\n");

                await File.AppendAllTextAsync(projectDirectory + "/log.txt", sb.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                throw;
            }
        }

        public static async void Log(string text)
        {
            try
            {
                string workingDirectory = Environment.CurrentDirectory;
                string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;

                StringBuilder sb = new StringBuilder();
                sb.Append("Time: " + DateTime.Now + "\n");
                sb.Append("Text: " + text + "\n");

                await File.AppendAllTextAsync(projectDirectory + "/log.txt", sb.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }
    }
}