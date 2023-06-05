using Logger;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using RestSharp;

namespace ApiUsageChallenge
{
    /// <summary>
    /// Goal 
    /// Create a Console app that will look up people in the SWAPI(https://swapi.dev/) based upon their ID number.
    /// Handle missing IDs/errors and load all the data for successful entries. 
    /// The data should be parsed into a class that represent the data structure from the API, so that it’s possible to access
    ///the properties on the class e.g.PersonClass.Name(and all other properties on “people” from the API) can be used
    ///like this PersonClass.Name (and all other properties on “people” from the API) 
    ///Create a cache (in memory) so that if you make the same API call again, the request will be fetched from the cache and not the API. 
    ///The cache should store the parsed class and not the raw response from the API.
    /// </summary>
    public class ApiUsageTester
    {
        private IMemoryCache _cache;

        public ApiUsageTester(IMemoryCache cache)
        {
            _cache= cache;
        }

        public  async Task<Person?> GetPersonByIdAsync(int id, RestClient client)
        {
            try
            {
                //Checks if a person with the given id already is in the cache
                //if it is the that object is returned
                // else it requests the api for that person
                // and then converts it to a person object
                Person? ChachedPerson = _cache.Get<Person?>(id);
                if (ChachedPerson is null)
                {
                 var request = new RestRequest("people/" + id, Method.Get);

                    RestResponse response = await client.GetAsync(request);
                    if (!string.IsNullOrEmpty(response.Content) && !response.Content.Contains("Not found"))
                    {
                        return ConvertToObject(response.Content, id);
                    }
                    else
                    {
                        Console.WriteLine($"person with id: {id} does not exist\n");
                        return null;
                    }
                }
                else
                {
                    return ChachedPerson;
                }
            }
            catch (IOException e)
            {
                SimpleLogger.Log(e);
                throw;
            }
            catch (ArgumentNullException e)
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

        // First the json string is converted to a person object and 
        // then it is stored in the cache for 1 minute before it is evicted from the cache.
        // This is to make sure that we do not use to much of the space in the cache and minimizing the risk of having stale cache entries
        public Person? ConvertToObject(string json, int id)
        {
            try
            {
                if (!string.IsNullOrEmpty(json))
                {
                       Person? PersonObject = JsonConvert.DeserializeObject<Person>(json);
                    _cache.Set(id, PersonObject, TimeSpan.FromMinutes(1));

                    return PersonObject;
                }
                return null;
            }
            catch (ArgumentException e)
            {
                SimpleLogger.Log(e);
                throw;
            }
            catch (OverflowException e)
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