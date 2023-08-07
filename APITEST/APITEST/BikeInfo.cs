using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace APITEST
{
    public static class BikeInfo
    {
        public static void CallBikeAPI()
        {

            HttpClient client = new HttpClient();
            
                string apiUrl = "http://api.citybik.es/v2/networks";
            //HttpResponseMessage response = await client.GetAsync(apiUrl);
            //var bikeParse = JObject.Parse(response);

            try
            {
                string jsonResponse = client.GetStringAsync(apiUrl).Result;
                
                //var response = await client.GetStringAsync(baseUrl);
                int errorPosition = 181;
                int contextLength = 50;  // Number of characters before and after the error position
                string errorContext = jsonResponse.Substring(Math.Max(0, errorPosition - contextLength), contextLength * 2);
                Console.WriteLine(errorContext);

                //var bikeObject = JObject.Parse(jsonResponse);
                //   Console.WriteLine(bikeObject);
                NetworksResponse networksResponse = JsonConvert.DeserializeObject<NetworksResponse>(jsonResponse);

                Console.WriteLine(networksResponse.networks[0].location);

               // foreach (Network network in networksResponse.networks)
               // {
               //     Console.WriteLine($"ID: {network.id}, Name: {network.name}, Company: {network.company}, Location: {network.location}");

              //  }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
                
                    
        }
    }
}