using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace APITEST
{
    public static class BikeInfo
    {
        public static void CallBikeAPI()
        {
            HttpClient client = new HttpClient(); //client

            string apiUrl = "http://api.citybik.es/v2/networks"; //endpoint

            string jsonResponse = client.GetStringAsync(apiUrl).Result; //calling endpoint with client


            NetworksResponse networksResponse = JsonConvert.DeserializeObject<NetworksResponse>(jsonResponse); //converting string into object

            //Console.WriteLine(networksResponse.networks[0].location);

            Console.WriteLine("Here are the Names and Locations of the CityBikes in the United States! : ");
            Console.WriteLine();

            foreach (Network network in networksResponse.networks) //iterating through List of networks
            {

                if (network.location.country == "US") //if the country is Italy
                {

                    if (network.location.country == "US") //Locations in USA
                    {
                        Console.WriteLine(network.company);
                        Console.WriteLine();
                        Console.WriteLine(network.name);
                        Console.WriteLine();
                        Console.WriteLine(network.location.city);
                        Console.WriteLine();
                        Console.WriteLine(network.source);
                        Console.WriteLine();

                    }
                    if (network.ebikes == true)
                    {
                        Console.WriteLine("There are E-Bikes available at this location!");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, there are no E-Bikes available at this location");
                    }

                    Console.WriteLine();


                }
            }
        }
    }
}