/// \file GeoTool.cs
/// <summary>
/// Contains the class that serves as the utility for geocoding, reverse geocoding, geo distance calculation and so on
/// </summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*! \mainpage SimuKit.Toolkits.Geo Source Code Documentation
 *
 * SimuKit.Toolkits.Geo provides the utility functions for performing various tasks such as geocoding, reverse coding, country code translation, geo distance calculation, etc.
 *
 * The library currently contains the following utility classes:
 * <ol>
 * <li>GeoTool: for geocoding, reverse geocoding, geo distance calculation</li>
 * <li>CountryCodeManager: for translating between country code and country name</li>
 * <li>TextUtil: for translating between ASCII and base64 strings (used to implement the cache for the GeoTool class methods</li>
 * </ol>
 */

namespace GeoTools
{
    using System.IO;
    using System.Net;
    using System.Xml.Linq;

    /// <summary>
    /// Class that serves as the utility for
    /// <ul>
    /// <li>Geo coding: convert a human-readable address into the geographic coordinates</li>
    /// <li>Reverse geo coding: convert the geographic coordinates into a human-readable address</li>
    /// <li>Calculate distance between two geo locations</li>
    /// </ul>
    /// </summary>
    public class GeoTool
    {
        /// <summary>
        /// Method that return the address of a geo location given the (latitude, longitude) of the location.
        /// The method also provides read/write to cache once the address is obtained so that once the address is retrieved from Internet,
        /// so that the address can be directly read from cache for the same latitude and longitude in the future
        /// (therefore does not need to be retrieved again from Internet in the future)
        /// </summary>
        /// <param name="lat">The latitude of a geo location</param>
        /// <param name="lng">The longitude of a geo location</param>
        /// <returns>The address of the geo location if successful; null if the reverse geocoding is not successful</returns>
        public static string FindAddress(double lat, double lng)
        {
            int latE6 = (int)(lat * 1000000);
            int lngE6 = (int)(lng * 1000000);

            string foldername = "location_cache";
            if (!Directory.Exists(foldername))
            {
                Directory.CreateDirectory(foldername);
            }

            string filename = string.Format("{0}\\{1}_{2}.txt", foldername, latE6, lngE6);

            if (File.Exists(filename))
            {
                StreamReader reader = new StreamReader(filename);
                string data=reader.ReadToEnd();
                reader.Close();
                return data;
            }

            string address = "";

            bool success = false;

            if (!success)
            {
                try
                {
                    var requestUri = string.Format("http://maps.googleapis.com/maps/api/geocode/xml?latlng={0},{1}&sensor=false", lat, lng);

                    var request = WebRequest.Create(requestUri);
                    var response = request.GetResponse();
                    var xdoc = XDocument.Load(response.GetResponseStream());

                    var status = xdoc.Element("GeocodeResponse").Element("status");
                    if(status.FirstNode.ToString()=="OK")
                    {
                        var result = xdoc.Element("GeocodeResponse").Element("result");
                        address = result.Element("formatted_address").FirstNode.ToString();
                        success = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("GeoTool.Error:"+ex.ToString());
                }
            }

          
           
            if(success)
            {
                StreamWriter writer = new StreamWriter(filename);
                writer.WriteLine(address);
                writer.Close();
            }

            return address;
        }

        /// <summary>
        /// Method that returns the (latitude, longitude) of a geo location given its associated address.
        /// The method also implements read/write to cache once the (latitude, longitude) is retrieved from Internet for the address,
        /// so that in the future the (latitude, longitude) can be directly read from cached (instead of from Internet) for the same address
        /// </summary>
        /// <param name="address">The input address associated with the geo location</param>
        /// <param name="lat">The output latitude associated with the geo location</param>
        /// <param name="lng">The output longitude associated with the geo location</param>
        /// <returns>True if the the geo coding is successful; False otherwise</returns>
        public static bool FindLatLngByAddress(string address, out double lat, out double lng)
        {
            string address64 = TextUtil.EncodeTo64(address);

            string foldername = "address_cache";
            if (!Directory.Exists(foldername))
            {
                Directory.CreateDirectory(foldername);
            }

            string filename = string.Format("{0}\\{1}.txt", foldername, address64);

            if (File.Exists(filename))
            {
                StreamReader reader = new StreamReader(filename);
                string data = reader.ReadToEnd();
                reader.Close();
                string[] latlng=data.Split(new char[]{','});
                lat = double.Parse(latlng[0].Trim());
                lng = double.Parse(latlng[1].Trim());
                return true;
            }

            lat = 0;
            lng = 0;
            bool success=false;


            if (!success)
            {
                try
                {
                    var requestUri = string.Format("http://maps.googleapis.com/maps/api/geocode/xml?address={0}&sensor=false", Uri.EscapeDataString(address));

                    var request = WebRequest.Create(requestUri);
                    var response = request.GetResponse();
                    var xdoc = XDocument.Load(response.GetResponseStream());

                    var result = xdoc.Element("GeocodeResponse").Element("result");
                    var locationElement = result.Element("geometry").Element("location");

                    lat = Convert.ToDouble(locationElement.Element("lat").FirstNode.ToString());
                    lng = Convert.ToDouble(locationElement.Element("lng").FirstNode.ToString());
                    success = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }



            if(success)
            {
                StreamWriter writer = new StreamWriter(filename);
                writer.WriteLine(string.Format("{0},{1}", lat, lng));
                writer.Close();
            }

            return success;
        }

        /// <summary>
        /// Method that convert degree to radian
        /// </summary>
        /// <param name="deg">The degree</param>
        /// <returns>The converted radians</returns>
        public static double Deg2Rad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }

        /// <summary>
        /// Method that convert radian to degree
        /// </summary>
        /// <param name="rad">The radians</param>
        /// <returns>The degrees</returns>
        public static double Rad2Deg(double rad)
        {
            return (rad / Math.PI * 180.0);
        }


        /// <summary>
        /// Method that returns the distance (in meters) between two geo locations, taking into consideration of the Earth curvature
        /// </summary>
        /// <param name="lat1">The latitude of the first geo location</param>
        /// <param name="lon1">The longitude of the first geo location</param>
        /// <param name="lat2">The latitude of the second geo location</param>
        /// <param name="lon2">The longitude of the second geo location</param>
        /// <returns>Distance in meters</returns>
        public static double GetDistance_m(double lat1, double lon1, double lat2, double lon2)
        {
            double theta = lon1 - lon2;

            double dist = Math.Sin(Deg2Rad(lat1)) * Math.Sin(Deg2Rad(lat2)) + Math.Cos(Deg2Rad(lat1)) * Math.Cos(Deg2Rad(lat2)) * Math.Cos(Deg2Rad(theta));
            if (dist > 1)
                dist = 1;
            if (dist < -1)
                dist = -1;
            dist = Math.Acos(dist);
            dist = Rad2Deg(dist);
            dist = dist * 60 * 1.1515;
            dist = dist * 1609.344;
            return (dist);
        }

        /// <summary>
        /// Method that returns the distance (in kilometers) between two geo locations, taking into consideration of the Earth curvature
        /// </summary>
        /// <param name="lat1">The latitude of the first geo location</param>
        /// <param name="lon1">The longitude of the first geo location</param>
        /// <param name="lat2">The latitude of the second geo location</param>
        /// <param name="lon2">The longitude of the second geo location</param>
        /// <returns>Distance in kilometers</returns>
        public static double GetDistance_km(double lat1, double lon1, double lat2, double lon2)
        {
            double theta = lon1 - lon2;

            double dist = Math.Sin(Deg2Rad(lat1)) * Math.Sin(Deg2Rad(lat2)) + Math.Cos(Deg2Rad(lat1)) * Math.Cos(Deg2Rad(lat2)) * Math.Cos(Deg2Rad(theta));
            if (dist > 1)
                dist = 1;
            if (dist < -1)
                dist = -1;
            dist = Math.Acos(dist);
            dist = Rad2Deg(dist);
            dist = dist * 60 * 1.1515;
            dist = dist * 1609.344 / 1000;
            return (dist);
        }
    }
}
