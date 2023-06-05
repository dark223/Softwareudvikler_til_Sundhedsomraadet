using RestSharp;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Logger;
using System.Diagnostics;

namespace ApiUsageChallenge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Adds MemoryCache to the list of services
            using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services => services.AddMemoryCache())
    .Build();

            try
            {
                RestClient client = new RestClient("https://swapi.dev/api/");
                // Gets a MemoryCache object from the servicecollection 
                IMemoryCache MemoryCache = host.Services.GetRequiredService<IMemoryCache>();
                // Instantiates the ApiDataRetriver with a MemoryCache which later will be used for caching the results of valid api responses 
                ApiUsageTester ApiDataRetriver = new ApiUsageTester(MemoryCache);
                // Gets a person by id if no person is found it returns null and writes to the console that it does not exist
                Task<Person?> res = ApiDataRetriver.GetPersonByIdAsync(1, client);
                if(res.Result != null)
                {
                Print(res.Result);
                }

                Task<Person?> res2 = ApiDataRetriver.GetPersonByIdAsync(2, client);
               
                if (res2.Result != null)
                {
                    Print(res2.Result);
                }
                Task<Person?> res3 = ApiDataRetriver.GetPersonByIdAsync(1, client);
               
                if (res3.Result != null)
                {
                    Print(res3.Result);
                }
                Task<Person?> res4 = ApiDataRetriver.GetPersonByIdAsync(2, client);
               
                if (res4.Result != null)
                {
                    Print(res4.Result);
                }

                Task<Person?> res5 = ApiDataRetriver.GetPersonByIdAsync(99, client);
                if (res5.Result != null)
                {
                    Print(res5.Result);
                }

                Task<Person?> res6 = ApiDataRetriver.GetPersonByIdAsync(9, client);
                if (res6.Result != null)
                {
                    Print(res6.Result);
                }

                Task<Person?> res7 = ApiDataRetriver.GetPersonByIdAsync(40, client);
                if (res7.Result != null)
                {
                    Print(res7.Result);
                }
            }
            catch (InvalidOperationException e)
            {
                SimpleLogger.Log(e);
                throw;
            }
            catch (AggregateException e)
            {
                SimpleLogger.Log(e);
                throw;
            }
            catch (Exception e)
            {
                SimpleLogger.Log(e);
                throw;
            }
        }
        /// <summary>
        /// printing function.
        /// it prints all data stored in a person object
        /// </summary>
        /// <param name="person"></param>
        public static void Print(Person person)
        {
            try
            {
                Console.WriteLine($"Name: {person.Name}, Gender: {person.Gender}, HairColor: {person.HairColor}, SkinColor: {person.SkinColor},Mass: {person.Mass}, BirthYear: {person.BirthYear}, EyeColor: {person.EyeColor}, Height: {person.Height}, Homeworld: {person.Homeworld}, Created: {person.Created}, Edited: {person.Edited}\n");
                Console.WriteLine("species: ");
                foreach (var item in person.Species)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("\n starships: ");
                foreach (var item in person.Starships)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("\n vehicles: ");
                foreach (var item in person.Vehicles)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("\n films: ");
                foreach (var item in person.Films)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("---------------\n");
            }
            catch (IOException e)
            {
                SimpleLogger.Log(e);
                throw;
            }
            catch (Exception e)
            {
                SimpleLogger.Log(e);
                throw;
            }
        }
    }
}