using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq; 
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace attentiTest
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("****  Attenti Test ****");
            Console.WriteLine("Start Testing");

            log.getL();
            Tests T = new Tests();
            
            XDocument doc = XDocument.Load("TestList.xml");
            var tests = doc.Descendants("test");
            foreach (var test in tests)
            {
                var name =  test.Element("name").Value;
                var value = test.Element("value").Value;
                var expectedResult = test.Element("expectedResult").Value;

                switch (name)
                {
                    case "CelsiusToFahrenheit" :
                            T.TestCelsiusToFahrenheit(value, expectedResult);
                            break;
                    case "MetersToFeet":
                            T.TestMeterToFeet(value, expectedResult);
                            break;
                    case "OuncesToGrams":
                            T.TestOuncesToGrams(value, expectedResult);
                            break;
                    case "ValidTemp":
                            T.TestValidTemp(value);
                            break;
                }
            }


            Console.WriteLine("Attenti Test is finished ");
            Console.WriteLine("finishe Testing ");

            //Console.Read();
            log.SaveLogToFile();
            Tests.driver.Quit();
        }

        
    }
}
