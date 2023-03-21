using System.IO;
using System.Text;

namespace Logger
{
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


                if (File.Exists(projectDirectory + "/log.txt"))
                {
                    await File.AppendAllTextAsync(projectDirectory + "/log.txt", sb.ToString());
                }
                else
                {
                    
                    await File.AppendAllTextAsync(projectDirectory + "/log.txt", sb.ToString());
                }
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



                if (File.Exists(projectDirectory + "/log.txt"))
                {
                    await File.AppendAllTextAsync(projectDirectory + "/log.txt", sb.ToString());
                }
                else
                {
                    File.Create(projectDirectory + "log.txt");
                    await File.AppendAllTextAsync(projectDirectory + "/log.txt", sb.ToString());
                }

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