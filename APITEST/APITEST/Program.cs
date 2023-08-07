using System;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace APITEST
{

    public class Program
    {
        

        public static void Main(string[] args)
        { 

            CityBikeApi.GetLocationInfo();

        }
        

    }
}



