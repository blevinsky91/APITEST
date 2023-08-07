using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace APITEST
{
	internal class CityBikeApi
	{
        public static async Task GetLocation()
		{
            /*var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            string api = configuration.GetSection("networks");
            */


            var client = new HttpClient();


           //HttpResponseMessage response = await client.GetAsync("http://api.citybik.es/v2/networks");
            //response.EnsureSuccessStatusCode();
            //string responseBody = await response.Content.ReadAsStringAsync();

            //var data = JsonConvert.DeserializeObject<Dictionary<string, List<Network>>>(responseBody);

            string city = "Paris";  // Replace with the city you're interested in

            //var filteredData = data["networks"].Where(network => network.location.city == city);

            //foreach (var network in filteredData)
            //{
                //Console.WriteLine($"ID: {network.id}, Name: {network.name}, Href: {network.href}");
            //}






            

            Console.WriteLine("Enter the name of the country you are riding in.");
            var countryName = Console.ReadLine();

            var bikesUrl = $"http://api.citybik.es/v2/networks";

            string responseBody = await bikesUrl.Content.ReadAsStringAsync();

            var bikeResponse = client.GetStringAsync(bikesUrl).Result;

            var bikeParse = JObject.Parse(bikeResponse);

            var data = JsonConvert.DeserializeObject<Dictionary<string, List<Network>>>(responseBody);

            var filteredData = data["networks"].Where(network => network.location.city == city);

            foreach (var item in data)
            {
                Console.WriteLine($"You chose {bikeParse}");
                Console.WriteLine($"Name: {item.name}");
                Console.WriteLine($"Location: {item.city}, {item.country}");
            }





            


        {
            static async Task Main()
            {
                try
                {
                    using (HttpClient client = new HttpClient())
                    {
                        string apiUrl = "http://api.citybik.es/v2/networks";
                        HttpResponseMessage response = await client.GetAsync(apiUrl);

                        if (response.IsSuccessStatusCode)
                        {
                            string jsonResponse = await response.Content.ReadAsStringAsync();
                            NetworksResponse networksResponse = JsonConvert.DeserializeObject<NetworksResponse>(jsonResponse);

                            // Now you can access the data and display it as needed
                            foreach (Network network in networksResponse.networks)
                            {
                                Console.WriteLine($"ID: {network.id}, Name: {network.name}");
                                // Display other properties as needed
                            }
                        }
                        else
                        {
                            Console.WriteLine($"API request failed with status code: {response.StatusCode}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }


    }
}
}

