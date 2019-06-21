# Attenti
interview work from Attenti 

1. the projects starts with seeting up the TestList.xml
      1.1 the xml contians test nodes and each node contain the test name,value that we want to test and expected result(if we have one)
2. the main program read the xml and create a testList
i run over the TestList and by the name of the test i decide which test method to choose.
3. the Tests class initialize the IWebDriver and  contains all tests methods .
      3.1 TestCelsiusToFahrenheit
      3.2 TestMeterToFeet
      3.3 TestOuncesToGrams
      3.4 TestValidTemp - this test uses the openweathermap API in order to set the expected result 
4. the result of evert test is being send to the log
5. the log object create an html file that will pop up at the end of running.

