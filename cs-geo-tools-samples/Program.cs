using System;
namespace GeoTools
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(CountryCodeManager.Instance.GetCountryNameByCode("us"));
            string address = "NTU, Singapore";
            double lat, lng;
            GeoTool.FindLatLngByAddress(address, out lat, out lng);
            Console.WriteLine("{0} is at ({1}, {2})", address, lat, lng);
            string address2 = "NUS, Singapore";
            double lat2, lng2;
            GeoTool.FindLatLngByAddress(address2, out lat2, out lng2);
            Console.WriteLine("{0} is at ({1}, {2})", address2, lat2, lng2);
            Console.WriteLine("{0} is {1} away from {2}", address, GeoTool.GetDistance_km(lat, lng, lat2, lng2), address2);
        }
    }
}
