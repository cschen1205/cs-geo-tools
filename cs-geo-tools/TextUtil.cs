/// \file TextUtil.cs
/// <summary>
/// Contains the class that serves as a utility for convert string between ASCII format and base64 format
/// </summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeoTools
{
    /// <summary>
    /// Class that serves as a utility for convert string between ASCII format and base64 format
    /// </summary>
    public class TextUtil
    {
        /// <summary>
        /// Method that converts a ASCII string to a base64 string
        /// </summary>
        /// <param name="toEncode">The ASCII string</param>
        /// <returns>The converted base64 string</returns>
        static public string EncodeTo64(string toEncode)
        {
            byte[] toEncodeAsBytes
                  = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);
            string returnValue
                  = System.Convert.ToBase64String(toEncodeAsBytes);
            return returnValue;
        }

        /// <summary>
        /// Method that converts a base64 string to a ASCII string
        /// </summary>
        /// <param name="encodedData">The base64 string</param>
        /// <returns>The converted ASCII string</returns>
        static public string DecodeFrom64(string encodedData)
        {
            byte[] encodedDataAsBytes
                = System.Convert.FromBase64String(encodedData);
            string returnValue =
               System.Text.ASCIIEncoding.ASCII.GetString(encodedDataAsBytes);
            return returnValue;
        }
    }
}
