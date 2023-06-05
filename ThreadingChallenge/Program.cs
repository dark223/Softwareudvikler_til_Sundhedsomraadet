using Logger;
using Microsoft.VisualBasic;
using System;
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
        private static SemaphoreSlim Semaphore;
        public static void Main()
        {
            List<string> ItemList =  new List<string>{ "item 1", "item 2", "item 3", "item 4", "item 5", "item 6",
                                                            "item 7", "item 8", "item 9", "item 10", "item 11", "item 12", 
                                                            "item 13", "item 14", "item 15", "item 16", "item 17", "item 18",
                                                            "item 19", "item 20" };
            try
            {
                // Creates the semaphore and starts with 3 open spots for threads to enter.
                // it has a maximum of 3 spots.
                Semaphore = new SemaphoreSlim(3, 3);

                // I create a list to store all created tasks so we later can find them
                //Then i create a task for each of the strings in the itemlist
                //and then process them using the worker method
                List<Task> tasks = new List<Task>();
                foreach (var item in ItemList)
                {
                    tasks.Add(Task.Run(() =>
                    {
                        Worker(item);
                    }));
                }
                // Waits for all tasks to be completed
                // ends the program delcaring that all tasks have completed their job
                Task.WaitAll(tasks.ToArray());
                Console.WriteLine("all tasks have completed");
            }
            catch (AggregateException e)
            {
                SimpleLogger.Log(e);
                throw;
            }
            catch (ObjectDisposedException e)
            {
                SimpleLogger.Log(e);
                throw;
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

        static void Worker(string item)
        {
            // blocks current thread from entering semaphore until another thread has released it
            Semaphore.Wait();
            try
            {
                Console.WriteLine($"thread with id {Thread.CurrentThread.ManagedThreadId} has entered the semaphore");
                Random random = new Random();
                int ProcessingTime = random.Next(1000, 5001);

                Console.WriteLine(item + $" processing time was: {ProcessingTime} and thread id was: {Thread.CurrentThread.ManagedThreadId}");
 
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
                Semaphore.Release();
                Console.WriteLine($"thread with id {Thread.CurrentThread.ManagedThreadId} has released the semaphore. The current count is {Semaphore.CurrentCount}");
            }
        }
    }
}