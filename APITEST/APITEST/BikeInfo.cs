using System;
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

            foreach (Network network in networksResponse.networks) //iterating through List of networks
            {

                if (network.location.country == "IT") //if the country is Italy
                {
                    Console.WriteLine("Italy has a bike location in this city: ");
                    Console.WriteLine(network.location.city);  //view Italian city where bike location is
                    Console.WriteLine();
                }
                //Console.WriteLine($"ID: {network.id}, Name: {network.name}, \n" +
                //    $" Company: {network.company}, \n" +
                //    $" City: {network.location.city} \n" +
                //    $" Country: {network.location.country}");

            }






        }
    }
}