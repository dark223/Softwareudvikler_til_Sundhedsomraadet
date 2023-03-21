using Logger;
using Microsoft.VisualBasic;
using System.Runtime.CompilerServices;

namespace ThreadingChallenge
{
    /// <summary>
    /// Goal Create a console app that uses threading to process all items in a list of strings (min 20 items in list). In this 
    ///challenge you must use SemaphoreSlim class. There is only allowed to run a max of 3 simultaneous threads at one
    ///time to simulate limited resources.
    ///The process function can simply write the string to console or possible call the swapi API used in the last challenge
    ///and output the data from the API call.
    ///There should be inserted a random delay in the process function between 1-5 seconds to simulate actual processing of data.
    /// </summary>
    internal class Program
    {

        private static SemaphoreSlim semaphore;
        public static void Main()
        {
            List<string> itemlistsize20 =  new List<string>{ "item 1", "item 2", "item 3", "item 4", "item 5", "item 6",
                                                            "item 7", "item 8", "item 9", "item 10", "item 11", "item 12", 
                                                            "item 13", "item 14", "item 15", "item 16", "item 17", "item 18",
                                                            "item 19", "item 20" };
            try
            {
                
                // Creates the semaphore and starts with 3 open spots for threads to enter.
                // it has a maximum of 3 spots.
                semaphore = new SemaphoreSlim(3, 3);

                List<string> ProcessNow= new List<string>();
                int processingamount = (itemlistsize20.Count)/5;
         

                for (int i = 0; i <= 4; i++)
                {
                // creates 5 threads each with a subset of the itemlistsize20 list
                // each thread is started with a method used to process the list
                ProcessNow = itemlistsize20.GetRange(0, processingamount);
                itemlistsize20.RemoveRange(0, processingamount);
            
                Thread thread = new Thread(new ParameterizedThreadStart(WorkerThread));
                    thread.Start(ProcessNow);
                }
            }
            catch (InvalidOperationException e)
            {
                SimpleLogger.Log(e);
                throw;
            }
            catch (OutOfMemoryException e)
            {
                SimpleLogger.Log(e);
                throw;
            }
            catch (ThreadStateException e)
            {
                SimpleLogger.Log(e);
                throw;
            }
            catch (ArgumentNullException e)
            {
                SimpleLogger.Log(e);
                throw;
            }
            catch (ArgumentOutOfRangeException e)
            {
                SimpleLogger.Log(e);
                throw;
            }
            catch (ArgumentException e)
            {
                SimpleLogger.Log(e);
                throw;
            }

        }



        static void WorkerThread(object list)
        {

            // blocks current thread from entering semaphore until another thread has released it
            semaphore.Wait();
            try
            {
                
                Random random = new Random();
                int ProcessingTime = random.Next(1, 6) * 1000;
                foreach (var item in (List<string>)list)
                {
                    Console.WriteLine(item +$" processing time was: {ProcessingTime} and thread used had id: {Thread.CurrentThread.ManagedThreadId}" );
                }
                
                Thread.Sleep(ProcessingTime);

            }
            catch (IOException e)
            {
                SimpleLogger.Log(e);
                throw;
            }
            catch (ArgumentOutOfRangeException e)
            {
                SimpleLogger.Log(e);
                throw;
            }
            catch (ObjectDisposedException e)
            {
                SimpleLogger.Log(e);
                throw;
            }
            catch (Exception e)
            {
                SimpleLogger.Log(e);
                throw;

            }
            finally
            {
                // releases semaphore, this makes space for another thread 
                semaphore.Release();
            }
            

        }
        
    }
}