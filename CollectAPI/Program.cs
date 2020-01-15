using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace CollectAPI
{
    class Program
    {
        static void Main(string[] args)
        {

            string url = "https://api.collectapi.com/health/dutyPharmacy?il=Gaziantep&Şahinbey";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            request.Credentials = CredentialCache.DefaultCredentials;
            request.Headers.Add("Authorization", "apikey 6jmo****************:7gw3***************");

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream receiveStream = response.GetResponseStream();
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);

            string responseString = readStream.ReadToEnd();

            response.Close();
            readStream.Close();

            JObject json = JObject.Parse(responseString);

            Console.WriteLine("Nöbetçi eczaneler listesi");
            Console.WriteLine("-------------------------");

            foreach (var item in json["result"])
            {
                Console.WriteLine("Adı: " + item["name"]);
                Console.WriteLine("Adresi: " + item["address"]);
                Console.WriteLine("Telefonu: " + item["phone"]);
                Console.WriteLine("Konum: " + item["loc"]);
                Console.WriteLine();
            }
            Console.ReadKey();
        }

    }
}
