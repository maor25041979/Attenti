using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace attentiTest
{
    class Tests
    {
        public static IWebDriver initWebDriver()
        {
            string ChromeDriverPath = Directory.GetCurrentDirectory() + @"\chromedriver";                               
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddExcludedArgument("ignore-certificate-errors");
            //ChromeDriver driver = new ChromeDriver(@"C:\SeleniumDrivers\C#", options);
            //ChromeDriver driver = new ChromeDriver(@"C:\Users\ma_al\Downloads\Attenti-master\Attenti-master\attentiTest\attentiTest\bin\Release\chromedriver", options);
            ChromeDriver driver = new ChromeDriver(ChromeDriverPath, options);
            return driver;
        }

        public static IWebDriver driver = initWebDriver();
        public static WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
        public string failMessage = "Test Faile, result doesnt match the expected result";

        public void TestCelsiusToFahrenheit(string value,string expectedRes)
        {
            string res = string.Empty;
            Console.WriteLine("Start Test : TestCelsiusToFahrenhei");
            try
            {
                driver.Navigate().GoToUrl("https://www.metric-conversions.org/");

                wait.Until(d => d.FindElement(By.Id("queryFrom")));

               // wait.Until(d => d.FindElement(By.CssSelector("a[href='/temperature-conversion.htm']")));
                driver.FindElement(By.CssSelector("a[href='/temperature-conversion.htm']")).Click();
                

                wait.Until(d => d.FindElement(By.CssSelector("a[href='/temperature/celsius-conversion.htm']")));
                driver.FindElement(By.CssSelector("a[href='/temperature/celsius-conversion.htm']")).Click();

                wait.Until(d => d.FindElement(By.CssSelector("a[href='/temperature/celsius-to-fahrenheit.htm']")));
                driver.FindElement(By.CssSelector("a[href='/temperature/celsius-to-fahrenheit.htm']")).Click();

                Thread.Sleep(2000);
                wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("argumentConv")));
                driver.FindElement(By.Id("argumentConv")).SendKeys("10");

                Thread.Sleep(2000);
                res = wait.Until(d => d.FindElement(By.Id("answer")).Text);
                res = res.Substring(res.IndexOf('=') + 2);

                if (string.Equals(expectedRes, res))
                {
                    Console.WriteLine("    TestCelsiusToFahrenhei :   pass");
                    log.addToHtml("TestCelsiusToFahrenheit", value, expectedRes, res, "pass");
                }

                else
                {
                    Console.WriteLine("    TestCelsiusToFahrenhei :  Test Faile, result doesnt match the expected result");
                    log.addToHtml("TestCelsiusToFahrenheit", value, expectedRes, res, failMessage);
                }
                   
            }
            catch (NoSuchElementException x)
            {
                Console.WriteLine("    TestCelsiusToFahrenhei :   Fail");
                Console.WriteLine(x.Message);
                log.addToHtml("TestCelsiusToFahrenheit", value, expectedRes, res, x.Message);
            }
            catch (Exception x)
            {
                Console.WriteLine("    TestCelsiusToFahrenhei :   Fail");
                Console.WriteLine(x.Message);
                log.addToHtml("TestCelsiusToFahrenheit", value, expectedRes, res, x.Message);
            }

            finally
            {
                //driver.Quit();
            }
            

        }
        public void TestMeterToFeet(string value, string expectedRes)
        {
            Console.WriteLine("Start Test : TestMeterToFeet");
            string res = string.Empty;
            try
            {
                driver.Navigate().GoToUrl("https://www.metric-conversions.org/");

                wait.Until(d => d.FindElement(By.Id("queryFrom")));

                wait.Until(d => d.FindElement(By.CssSelector("a[href='/length-conversion.htm']")));
                driver.FindElement(By.CssSelector("a[href='/length-conversion.htm']")).Click();


                wait.Until(d => d.FindElement(By.CssSelector("a[href='/length/meters-conversion.htm']")));
                driver.FindElement(By.CssSelector("a[href='/length/meters-conversion.htm']")).Click();

                wait.Until(d => d.FindElement(By.CssSelector("a[href='/length/meters-to-feet.htm']")));
                driver.FindElement(By.CssSelector("a[href='/length/meters-to-feet.htm']")).Click();
         
                wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("argumentConv")));
                driver.FindElement(By.Id("argumentConv")).SendKeys(value);

                Thread.Sleep(2000);
                res = wait.Until(d => d.FindElement(By.Id("answer")).Text);
                res = res.Substring(res.IndexOf('=') + 2);

                if (string.Equals(expectedRes, res))
                {
                    Console.WriteLine("    TestMeterToFeet :   pass");
                    log.addToHtml("TestMeterToFeet", value, expectedRes, res, "pass");
                }

                else
                {
                    Console.WriteLine("    TestMeterToFeet :  Test Faile, result doesnt match the expected result");
                    log.addToHtml("TestMeterToFeet", value, expectedRes, res, failMessage);
                }

            }
            catch (NoSuchElementException x)
            {
                Console.WriteLine("    TestMeterToFeet :   Fail");
                Console.WriteLine(x.Message);
                log.addToHtml("TestMeterToFeet", value, expectedRes, res, x.Message);
            }
            catch (Exception x)
            {
                Console.WriteLine("    TestMeterToFeet :   Fail");
                Console.WriteLine(x.Message);
                log.addToHtml("TestMeterToFeet", value, expectedRes, res, x.Message);
            }

        }
        public void TestOuncesToGrams(string value, string expectedRes)
        {
            Console.WriteLine("Start Test : TestOuncesToGrams");
            string res = string.Empty;
            try
            {
                driver.Navigate().GoToUrl("https://www.metric-conversions.org/");

                wait.Until(d => d.FindElement(By.Id("queryFrom")));

                wait.Until(d => d.FindElement(By.CssSelector("a[href='/weight-conversion.htm']")));
                driver.FindElement(By.CssSelector("a[href='/weight-conversion.htm']")).Click();


                wait.Until(d => d.FindElement(By.CssSelector("a[href='/weight/ounces-conversion.htm']")));
                driver.FindElement(By.CssSelector("a[href='/weight/ounces-conversion.htm']")).Click();

                wait.Until(d => d.FindElement(By.CssSelector("a[href='/weight/ounces-to-grams.htm']")));
                driver.FindElement(By.CssSelector("a[href='/weight/ounces-to-grams.htm']")).Click();

                wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("argumentConv")));
                driver.FindElement(By.Id("argumentConv")).SendKeys(value);

                Thread.Sleep(2000);
                res = wait.Until(d => d.FindElement(By.Id("answer")).Text);
                res = res.Substring(res.IndexOf('=') + 2);

                if (string.Equals(expectedRes, res))
                {
                    Console.WriteLine("    TestOuncesToGrams :   pass");
                    log.addToHtml("TestOuncesToGrams", value, expectedRes, res, "pass");
                }

                else
                {
                    Console.WriteLine("    TestOuncesToGrams :  Test Faile, result doesnt match the expected result");
                    log.addToHtml("TestOuncesToGrams", value, expectedRes, res, failMessage);
                }

            }
            catch (NoSuchElementException x)
            {
                Console.WriteLine("    TestOuncesToGrams :   Fail");
                Console.WriteLine(x.Message);
                log.addToHtml("TestOuncesToGrams", value, expectedRes, res, x.Message);
            }
            catch (Exception x)
            {
                Console.WriteLine("    TestOuncesToGrams :   Fail");
                Console.WriteLine(x.Message);
                log.addToHtml("TestOuncesToGrams", value, expectedRes, res, x.Message);
            }

        }
        public void TestValidTemp(string value)
        {
            Console.WriteLine("Start Test : TestValidTemp");
            string res = string.Empty;
            weather W = new weather(value);


            try
            {
                var response = W.GetResponse();
                var expectedRes = W.GetTemp(response);
                
                driver.Navigate().GoToUrl("https://weather.com/");

                wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//*[@classname='styles__locationName__2hkcY']")));
                wait.Until(d => d.FindElement(By.XPath("//*[@classname='theme__inputElement__4bZUj input__inputElement__1GjGE']")));
                var E =  driver.FindElement(By.XPath("//*[@class='theme__inputElement__4bZUj input__inputElement__1GjGE']"));
                E.Click();
                Thread.Sleep(1000);
                E.SendKeys(value);
                Thread.Sleep(1000);

                wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//*[@class='styles__item__3sdr8 styles__selected__SEH0e']")));
                driver.FindElement(By.XPath("//*[@class='styles__item__3sdr8 styles__selected__SEH0e']")).Click();

                wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//*[@class='styles__temperature__1ZAmd']")));
    
                res = driver.FindElement(By.XPath("//*[@class='styles__temperature__1ZAmd']")).Text;
                res = res.Remove(res.Length-1);
                float newRes = float.Parse(res);

                if (expectedRes * 0.9 <= newRes && newRes <= expectedRes * 1.1)
                {
                        Console.WriteLine("    TestValidTemp :   pass");
                        log.addToHtml("TestValidTemp", value, expectedRes.ToString(), res, "pass");
                }
                else
                {
                    Console.WriteLine("    TestValidTemp :  Test Faile, result doesnt match the expected result");
                    log.addToHtml("TestValidTemp", value, expectedRes.ToString(), res, failMessage);
                }

            }

           catch (Exception x)
            {
                Console.WriteLine("    TestValidTemp :   Fail");
                Console.WriteLine(x.Message);
                log.addToHtml("TestValidTemp", value, "", res, x.Message);
            }
        }
    }
}
