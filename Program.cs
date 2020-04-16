using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

namespace IraqCOVID19Stats
{
    public class COVIDRootObject
    {
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string CityCode { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
        public int Confirmed { get; set; }
        public int Deaths { get; set; }
        public int Recovered { get; set; }
        public int Active { get; set; }
        public DateTime Date { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {

            ////using https://covid19api.com/ FREE COVID19 API
            var PassURLtoAPI = new RestClient("https://api.covid19api.com/live/country/iraq");
            var restRequest = new RestRequest(Method.GET);
            restRequest.RequestFormat = DataFormat.Json;
            IRestResponse RDataResult = PassURLtoAPI.Execute(restRequest);
            Console.WriteLine("Calling the API");
            Console.WriteLine("*******************");
            Console.WriteLine("\n");
            if (RDataResult.StatusCode != HttpStatusCode.OK)
            {
                Console.WriteLine("There is a problem with the API, please try again later");
            }
            else
            {
                var cOVIDs = JsonConvert.DeserializeObject<List<COVIDRootObject>>(RDataResult.Content);
                string result =
                    "Country: " + cOVIDs[cOVIDs.Count - 1].Country + "\n" +
                    "Confirmed: " + cOVIDs[cOVIDs.Count - 1].Confirmed + "\n" +
                  "Active: " + cOVIDs[cOVIDs.Count - 1].Active + "\n" +
                  "Deaths: " + cOVIDs[cOVIDs.Count - 1].Deaths + "\n" +
                  "Recovered: " + cOVIDs[cOVIDs.Count - 1].Recovered + "\n" +
                   "As of date: "+ cOVIDs[cOVIDs.Count - 1].Date.ToShortDateString() + "\n" +
                  "Data is sourced from Johns Hopkins CSSE ";

                Console.WriteLine(result);
            }

            Console.ReadKey();
        }
    }
}
