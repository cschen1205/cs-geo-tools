/// \file CountryCodeManager.cs
/// <summary>
/// Contains the class representing a utility that returns the name of the country given its country code
/// </summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GeoTools
{    
    /// <summary>
    /// Singleton class representing a utility that returns the name of the country given its country code
    /// </summary>
    public class CountryCodeManager
    {
        /// <summary>
        /// Class variable representing the singleton instance of the CountryCodeManager class
        /// </summary>
        private static CountryCodeManager mInstance = null;
        /// <summary>
        /// Class variable that serves as the lock during creating the singleton instance of CountryCodeManager
        /// </summary>
        private static object mSycObj = new object();
        /// <summary>
        /// Member variable that map a country code to the corresponding country name
        /// </summary>
        private Dictionary<string, string> mCountryCodeToNameMapping = new Dictionary<string, string>();

        /// <summary>
        /// Constructor
        /// </summary>
        private CountryCodeManager()
        {
            mCountryCodeToNameMapping["ZW"] = "Zimbabwe";
            mCountryCodeToNameMapping["ZM"] = "Zambia";
            mCountryCodeToNameMapping["ZA"] = "South Africa";
            mCountryCodeToNameMapping["YT"] = "Mayotte";
            mCountryCodeToNameMapping["YE"] = "Yemen";
            mCountryCodeToNameMapping["WS"] = "Samoa";
            mCountryCodeToNameMapping["WF"] = "Wallis and Futuna";
            mCountryCodeToNameMapping["VU"] = "Vanuatu";
            mCountryCodeToNameMapping["VN"] = "Viet Nam";
            mCountryCodeToNameMapping["VI"] = "Virgin Islands, U.S.";
            mCountryCodeToNameMapping["VG"] = "Virgin Islands, British";
            mCountryCodeToNameMapping["VE"] = "Venezuela, Bolivarian Republic of";
            mCountryCodeToNameMapping["VC"] = "Saint Vincent and the Grenadines";
            mCountryCodeToNameMapping["VA"] = "Holy See (Vatican City State)";
            mCountryCodeToNameMapping["UZ"] = "Uzbekistan";
            mCountryCodeToNameMapping["UY"] = "Uruguay";
            mCountryCodeToNameMapping["US"] = "United States";
            mCountryCodeToNameMapping["UM"] = "United States Minor Outlying Islands";
            mCountryCodeToNameMapping["UG"] = "Uganda";
            mCountryCodeToNameMapping["UA"] = "Ukraine";
            mCountryCodeToNameMapping["TZ"] = "Tanzania, United Republic of";
            mCountryCodeToNameMapping["TW"] = "Taiwan, Province of China";
            mCountryCodeToNameMapping["TV"] = "Tuvalu";
            mCountryCodeToNameMapping["TT"] = "Trinidad and Tobago";
            mCountryCodeToNameMapping["TR"] = "Turkey";
            mCountryCodeToNameMapping["TO"] = "Tonga";
            mCountryCodeToNameMapping["TN"] = "Tunisia";
            mCountryCodeToNameMapping["TM"] = "Turkmenistan";
            mCountryCodeToNameMapping["TL"] = "Timor-Leste";
            mCountryCodeToNameMapping["TK"] = "Tokelau";
            mCountryCodeToNameMapping["TJ"] = "Tajikistan";
            mCountryCodeToNameMapping["TH"] = "Thailand";
            mCountryCodeToNameMapping["TG"] = "Togo";
            mCountryCodeToNameMapping["TF"] = "French Southern Territories";
            mCountryCodeToNameMapping["TD"] = "Chad";
            mCountryCodeToNameMapping["TC"] = "Turks and Caicos Islands";
            mCountryCodeToNameMapping["SZ"] = "Swaziland";
            mCountryCodeToNameMapping["SY"] = "Syrian Arab Republic";
            mCountryCodeToNameMapping["SX"] = "Sint Maarten (Dutch part)";
            mCountryCodeToNameMapping["SV"] = "El Salvador";
            mCountryCodeToNameMapping["ST"] = "Sao Tome and Principe";
            mCountryCodeToNameMapping["SS"] = "South Sudan";
            mCountryCodeToNameMapping["SR"] = "Suriname";
            mCountryCodeToNameMapping["SO"] = "Somalia";
            mCountryCodeToNameMapping["SN"] = "Senegal";
            mCountryCodeToNameMapping["SM"] = "San Marino";
            mCountryCodeToNameMapping["SL"] = "Sierra Leone";
            mCountryCodeToNameMapping["SK"] = "Slovakia";
            mCountryCodeToNameMapping["SJ"] = "Svalbard and Jan Mayen";
            mCountryCodeToNameMapping["SI"] = "Slovenia";
            mCountryCodeToNameMapping["SH"] = "Saint Helena, Ascension and Tristan da Cunha";
            mCountryCodeToNameMapping["SG"] = "Singapore";
            mCountryCodeToNameMapping["SE"] = "Sweden";
            mCountryCodeToNameMapping["SD"] = "Sudan";
            mCountryCodeToNameMapping["SC"] = "Seychelles";
            mCountryCodeToNameMapping["SB"] = "Solomon Islands";
            mCountryCodeToNameMapping["SA"] = "Saudi Arabia";
            mCountryCodeToNameMapping["RW"] = "Rwanda";
            mCountryCodeToNameMapping["RU"] = "Russia";
            mCountryCodeToNameMapping["RS"] = "Serbia";
            mCountryCodeToNameMapping["RO"] = "Romania";
            mCountryCodeToNameMapping["RE"] = "Reunion";
            mCountryCodeToNameMapping["QA"] = "Qatar";
            mCountryCodeToNameMapping["PY"] = "Paraguay";
            mCountryCodeToNameMapping["PW"] = "Palau";
            mCountryCodeToNameMapping["PT"] = "Portugal";
            mCountryCodeToNameMapping["PS"] = "Palestinian Territory, Occupied";
            mCountryCodeToNameMapping["PR"] = "Puerto Rico";
            mCountryCodeToNameMapping["PN"] = "Pitcairn";
            mCountryCodeToNameMapping["PM"] = "Saint Pierre and Miquelon";
            mCountryCodeToNameMapping["PL"] = "Poland";
            mCountryCodeToNameMapping["PK"] = "Pakistan";
            mCountryCodeToNameMapping["PH"] = "Philippines";
            mCountryCodeToNameMapping["PG"] = "Papua New Guinea";
            mCountryCodeToNameMapping["PF"] = "French Polynesia";
            mCountryCodeToNameMapping["PE"] = "Peru";
            mCountryCodeToNameMapping["PA"] = "Panama";
            mCountryCodeToNameMapping["OM"] = "Oman";
            mCountryCodeToNameMapping["NZ"] = "New Zealand";
            mCountryCodeToNameMapping["NU"] = "Niue";
            mCountryCodeToNameMapping["NR"] = "Nauru";
            mCountryCodeToNameMapping["NP"] = "Nepal";
            mCountryCodeToNameMapping["NO"] = "Norway";
            mCountryCodeToNameMapping["NL"] = "Netherlands";
            mCountryCodeToNameMapping["NI"] = "Nicaragua";
            mCountryCodeToNameMapping["NG"] = "Nigeria";
            mCountryCodeToNameMapping["NF"] = "Norfolk Island";
            mCountryCodeToNameMapping["NE"] = "Niger";
            mCountryCodeToNameMapping["NC"] = "New Caledonia";
            mCountryCodeToNameMapping["NA"] = "Namibia";
            mCountryCodeToNameMapping["MZ"] = "Mozambique";
            mCountryCodeToNameMapping["MY"] = "Malaysia";
            mCountryCodeToNameMapping["MX"] = "Mexico";
            mCountryCodeToNameMapping["MW"] = "Malawi";
            mCountryCodeToNameMapping["MV"] = "Maldives";
            mCountryCodeToNameMapping["MU"] = "Mauritius";
            mCountryCodeToNameMapping["MT"] = "Malta";
            mCountryCodeToNameMapping["MS"] = "Montserrat";
            mCountryCodeToNameMapping["MR"] = "Mauritania";
            mCountryCodeToNameMapping["MQ"] = "Martinique";
            mCountryCodeToNameMapping["MP"] = "Northern Mariana Islands";
            mCountryCodeToNameMapping["MO"] = "Macao";
            mCountryCodeToNameMapping["MN"] = "Mongolia";
            mCountryCodeToNameMapping["MM"] = "Myanmar";
            mCountryCodeToNameMapping["ML"] = "Mali";
            mCountryCodeToNameMapping["MK"] = "Macedonia, the former Yugoslav Republic of";
            mCountryCodeToNameMapping["MH"] = "Marshall Islands";
            mCountryCodeToNameMapping["MG"] = "Madagascar";
            mCountryCodeToNameMapping["MF"] = "Saint Martin (French part)";
            mCountryCodeToNameMapping["ME"] = "Montenegro";
            mCountryCodeToNameMapping["MD"] = "Moldova, Republic of";
            mCountryCodeToNameMapping["MC"] = "Monaco";
            mCountryCodeToNameMapping["MA"] = "Morocco";
            mCountryCodeToNameMapping["LY"] = "Libya";
            mCountryCodeToNameMapping["LV"] = "Latvia";
            mCountryCodeToNameMapping["LU"] = "Luxembourg";
            mCountryCodeToNameMapping["LT"] = "Lithuania";
            mCountryCodeToNameMapping["LS"] = "Lesotho";
            mCountryCodeToNameMapping["LR"] = "Liberia";
            mCountryCodeToNameMapping["LK"] = "Sri Lanka";
            mCountryCodeToNameMapping["LI"] = "Liechtenstein";
            mCountryCodeToNameMapping["LC"] = "Saint Lucia";
            mCountryCodeToNameMapping["LB"] = "Lebanon";
            mCountryCodeToNameMapping["LA"] = "Lao People's Democratic Republic";
            mCountryCodeToNameMapping["KZ"] = "Kazakhstan";
            mCountryCodeToNameMapping["KY"] = "Cayman Islands";
            mCountryCodeToNameMapping["KW"] = "Kuwait";
            mCountryCodeToNameMapping["KR"] = "Korea, Republic of";
            mCountryCodeToNameMapping["KP"] = "Korea, Democratic People's Republic of";
            mCountryCodeToNameMapping["KN"] = "Saint Kitts and Nevis";
            mCountryCodeToNameMapping["KM"] = "Comoros";
            mCountryCodeToNameMapping["KI"] = "Kiribati";
            mCountryCodeToNameMapping["KH"] = "Cambodia";
            mCountryCodeToNameMapping["KG"] = "Kyrgyzstan";
            mCountryCodeToNameMapping["KE"] = "Kenya";
            mCountryCodeToNameMapping["JP"] = "Japan";
            mCountryCodeToNameMapping["JO"] = "Jordan";
            mCountryCodeToNameMapping["JM"] = "Jamaica";
            mCountryCodeToNameMapping["JE"] = "Jersey";
            mCountryCodeToNameMapping["IT"] = "Italy";
            mCountryCodeToNameMapping["IS"] = "Iceland";
            mCountryCodeToNameMapping["IR"] = "Iran";
            mCountryCodeToNameMapping["IQ"] = "Iraq";
            mCountryCodeToNameMapping["IO"] = "British Indian Ocean Territory";
            mCountryCodeToNameMapping["IN"] = "India";
            mCountryCodeToNameMapping["IM"] = "Isle of Man";
            mCountryCodeToNameMapping["IL"] = "Israel";
            mCountryCodeToNameMapping["IE"] = "Ireland";
            mCountryCodeToNameMapping["ID"] = "Indonesia";
            mCountryCodeToNameMapping["HU"] = "Hungary";
            mCountryCodeToNameMapping["HT"] = "Haiti";
            mCountryCodeToNameMapping["HR"] = "Croatia";
            mCountryCodeToNameMapping["HN"] = "Honduras";
            mCountryCodeToNameMapping["HM"] = "Heard Island and McDonald Islands";
            mCountryCodeToNameMapping["HK"] = "Hong Kong";
            mCountryCodeToNameMapping["GY"] = "Guyana";
            mCountryCodeToNameMapping["GW"] = "Guinea-Bissau";
            mCountryCodeToNameMapping["GU"] = "Guam";
            mCountryCodeToNameMapping["GT"] = "Guatemala";
            mCountryCodeToNameMapping["GS"] = "South Georgia and the South Sandwich Islands";
            mCountryCodeToNameMapping["GR"] = "Greece";
            mCountryCodeToNameMapping["GQ"] = "Equatorial Guinea";
            mCountryCodeToNameMapping["GP"] = "Guadeloupe";
            mCountryCodeToNameMapping["GN"] = "Guinea";
            mCountryCodeToNameMapping["GM"] = "Gambia";
            mCountryCodeToNameMapping["GL"] = "Greenland";
            mCountryCodeToNameMapping["GI"] = "Gibraltar";
            mCountryCodeToNameMapping["GH"] = "Ghana";
            mCountryCodeToNameMapping["GG"] = "Guernsey";
            mCountryCodeToNameMapping["GF"] = "French Guiana";
            mCountryCodeToNameMapping["GE"] = "Georgia";
            mCountryCodeToNameMapping["GD"] = "Grenada";
            mCountryCodeToNameMapping["GB"] = "United Kingdom";
            mCountryCodeToNameMapping["GA"] = "Gabon";
            mCountryCodeToNameMapping["FR"] = "France";
            mCountryCodeToNameMapping["FO"] = "Faroe Islands";
            mCountryCodeToNameMapping["FM"] = "Micronesia, Federated States of";
            mCountryCodeToNameMapping["FK"] = "Falkland Islands (Malvinas)";
            mCountryCodeToNameMapping["FJ"] = "Fiji";
            mCountryCodeToNameMapping["FI"] = "Finland";
            mCountryCodeToNameMapping["ET"] = "Ethiopia";
            mCountryCodeToNameMapping["ES"] = "Spain";
            mCountryCodeToNameMapping["ER"] = "Eritrea";
            mCountryCodeToNameMapping["EH"] = "Western Sahara";
            mCountryCodeToNameMapping["EG"] = "Egypt";
            mCountryCodeToNameMapping["EE"] = "Estonia";
            mCountryCodeToNameMapping["EC"] = "Ecuador";
            mCountryCodeToNameMapping["DZ"] = "Algeria";
            mCountryCodeToNameMapping["DO"] = "Dominican Republic";
            mCountryCodeToNameMapping["DM"] = "Dominica";
            mCountryCodeToNameMapping["DK"] = "Denmark";
            mCountryCodeToNameMapping["DJ"] = "Djibouti";
            mCountryCodeToNameMapping["DE"] = "Germany";
            mCountryCodeToNameMapping["CZ"] = "Czech Republic";
            mCountryCodeToNameMapping["CY"] = "Cyprus";
            mCountryCodeToNameMapping["CX"] = "Christmas Island";
            mCountryCodeToNameMapping["CW"] = "Cura?ao";
            mCountryCodeToNameMapping["CV"] = "Cape Verde";
            mCountryCodeToNameMapping["CU"] = "Cuba";
            mCountryCodeToNameMapping["CR"] = "Costa Rica";
            mCountryCodeToNameMapping["CO"] = "Colombia";
            mCountryCodeToNameMapping["CN"] = "China";
            mCountryCodeToNameMapping["CM"] = "Cameroon";
            mCountryCodeToNameMapping["CL"] = "Chile";
            mCountryCodeToNameMapping["CK"] = "Cook Islands";
            mCountryCodeToNameMapping["CI"] = "C?te d'Ivoire";
            mCountryCodeToNameMapping["CH"] = "Switzerland";
            mCountryCodeToNameMapping["CG"] = "Congo";
            mCountryCodeToNameMapping["CF"] = "Central African Republic";
            mCountryCodeToNameMapping["CD"] = "Democratic Republic of the Congo";
            mCountryCodeToNameMapping["CC"] = "Cocos (Keeling) Islands";
            mCountryCodeToNameMapping["CA"] = "Canada";
            mCountryCodeToNameMapping["BZ"] = "Belize";
            mCountryCodeToNameMapping["BY"] = "Belarus";
            mCountryCodeToNameMapping["BW"] = "Botswana";
            mCountryCodeToNameMapping["BV"] = "Bouvet Island";
            mCountryCodeToNameMapping["BT"] = "Bhutan";
            mCountryCodeToNameMapping["BS"] = "Bahamas";
            mCountryCodeToNameMapping["BR"] = "Brazil";
            mCountryCodeToNameMapping["BQ"] = "Bonaire, Sint Eustatius and Saba";
            mCountryCodeToNameMapping["BO"] = "Bolivia";
            mCountryCodeToNameMapping["BN"] = "Brunei Darussalam";
            mCountryCodeToNameMapping["BM"] = "Bermuda";
            mCountryCodeToNameMapping["BL"] = "Saint Barth¡§?lemy";
            mCountryCodeToNameMapping["BJ"] = "Benin";
            mCountryCodeToNameMapping["BI"] = "Burundi";
            mCountryCodeToNameMapping["BH"] = "Bahrain";
            mCountryCodeToNameMapping["BG"] = "Bulgaria";
            mCountryCodeToNameMapping["BF"] = "Burkina Faso";
            mCountryCodeToNameMapping["BE"] = "Belgium";
            mCountryCodeToNameMapping["BD"] = "Bangladesh";
            mCountryCodeToNameMapping["BB"] = "Barbados";
            mCountryCodeToNameMapping["BA"] = "Bosnia and Herzegovina";
            mCountryCodeToNameMapping["AZ"] = "Azerbaijan";
            mCountryCodeToNameMapping["AX"] = "?land Islands";
            mCountryCodeToNameMapping["AW"] = "Aruba";
            mCountryCodeToNameMapping["AU"] = "Australia";
            mCountryCodeToNameMapping["AT"] = "Austria";
            mCountryCodeToNameMapping["AS"] = "American Samoa";
            mCountryCodeToNameMapping["AR"] = "Argentina";
            mCountryCodeToNameMapping["AQ"] = "Antarctica";
            mCountryCodeToNameMapping["AO"] = "Angola";
            mCountryCodeToNameMapping["AM"] = "Armenia";
            mCountryCodeToNameMapping["AL"] = "Albania";
            mCountryCodeToNameMapping["AI"] = "Anguilla";
            mCountryCodeToNameMapping["AG"] = "Antigua and Barbuda";
            mCountryCodeToNameMapping["AF"] = "Afghanistan";
            mCountryCodeToNameMapping["AE"] = "United Arab Emirates";
        }

        /// <summary>
        /// Property that returns the singleton instance of the CountryCodeManager
        /// </summary>
        public static CountryCodeManager Instance
        {
            get
            {
                if (mInstance == null)
                {
                    lock (mSycObj)
                    {
                        mInstance = new CountryCodeManager();
                    }
                }
                return mInstance;
            }
        }

        /// <summary>
        /// Method that returns name of a country given its country code
        /// </summary>
        /// <param name="country_code">The country code of a country</param>
        /// <returns>The name of the country corresponding to the country code</returns>
        public string GetCountryNameByCode(string country_code)
        {
            country_code = country_code.ToUpper();
            if (mCountryCodeToNameMapping.ContainsKey(country_code))
            {
                return mCountryCodeToNameMapping[country_code];
            }
            else
            {
                return null;
            }
        }
    }
}
