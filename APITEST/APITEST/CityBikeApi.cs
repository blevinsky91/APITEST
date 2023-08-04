using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Configuration;

namespace APITEST
{
	internal class CityBikeApi
	{
		public static void GetLocation()
		{
            /*var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            string api = configuration.GetSection("networks");
            */

            var client = new HttpClient();

            Console.WriteLine("Enter the name of the country you are riding in.");
            var countryName = Console.ReadLine();

            var bikesUrl = $"http://api.citybik.es/v2/networks";

            var bikeResponse = client.GetStringAsync(bikesUrl).Result;

            var bikeParse = JObject.Parse(bikeResponse);

            Console.WriteLine($"You chose {bikeParse}");
        }
	}
}

