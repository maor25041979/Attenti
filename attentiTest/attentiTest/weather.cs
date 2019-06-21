using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Xml;

namespace attentiTest
{
    class weather
    {
        private string zip;
        private string CurrentURL;
        private const string APIKEY = "e74424ceb8468312b7c008869ebdb162";


        public weather(string zipCode)
        {
            zip = zipCode;
            setUrl();
        }
        
        private void setUrl()
        {
            CurrentURL = "http://api.openweathermap.org/data/2.5/weather?zip=" + zip + "&mode=xml&units=imperial&APPID=" + APIKEY;  
        }

        public XmlDocument GetResponse()
        {
            using (WebClient client = new WebClient())
            {
                string xmlContent = client.DownloadString(CurrentURL);
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(xmlContent);
                return xmlDocument;
            }
        }

        public float GetTemp(XmlDocument xmlDocument)
        {
            XmlNode temp_node = xmlDocument.SelectSingleNode("//temperature");
            XmlAttribute temp_value = temp_node.Attributes["value"];
            string temp_string = temp_value.Value;
            return float.Parse(temp_string);
        }

    }

    class weatherApi
    {

        private string city;
        private float temp;
        private float tempMax;
        private float tempMin;

        public string City
        {
            get { return city; }
            set { city = value; }
        }
        public float Temp
        {
            get { return temp; }
            set { temp = value; }
        }
        public float TempMax
        {
            get { return tempMax; }
            set { tempMax = value; }
        }
        public float TempMin
        {
            get { return tempMin; }
            set { tempMin = value; }
        }

        public weatherApi(string City)
        {
            city = City;
        }

        public void CheckWeather()
        {
            WeatherAPI DataAPI = new WeatherAPI(City);
            temp = DataAPI.GetTemp();
        }

    }
    class WeatherAPI
    {
        public WeatherAPI(string city)
        {
            SetCurrentURL(city);
            xmlDocument = GetXML(CurrentURL);
        }

        public float GetTemp()
        {
            XmlNode temp_node = xmlDocument.SelectSingleNode("//temperature");
            XmlAttribute temp_value = temp_node.Attributes["value"];
            string temp_string = temp_value.Value;
            return float.Parse(temp_string);
        }

        private const string APIKEY = "API KEY HERE";
        private string CurrentURL;
        private XmlDocument xmlDocument;

        private void SetCurrentURL(string location)
        {
            CurrentURL = "http://api.openweathermap.org/data/2.5/weather?q="
                + location + "&mode=xml&units=metric&APPID=" + APIKEY;
        }

        private XmlDocument GetXML(string CurrentURL)
        {
            using (WebClient client = new WebClient())
            {
                string xmlContent = client.DownloadString(CurrentURL);
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(xmlContent);
                return xmlDocument;
            }
        }
    }
 }
