using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.ObjectModel;
using System.Threading;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace CitiBank
{
    class Program
    {
        static void Main(string[] args)
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            IWebDriver driver = new ChromeDriver();

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Url = "https://www.online.citibank.co.in/";
            
            driver.FindElement(By.XPath("//img[@class='appClose']")).Click();
            driver.FindElement(By.XPath("//span[@class='txtSign']")).Click();

            ReadOnlyCollection<string> windows = driver.WindowHandles;

            int noOfWindow = windows.Count;
            Console.WriteLine(noOfWindow);
            for (int i = 0; i < noOfWindow; i++)
            {
                Console.WriteLine(windows[i]);
                driver.SwitchTo().Window(windows[i]);
                string title = driver.Title;
                Console.WriteLine(title);

                if (title.Equals("Citibank India"))
                {
                    driver.FindElement(By.XPath("//div[@class='cl fl ls_login']")).Click();


                }

            }
        
            //string currentwindow = driver.CurrentWindowHandle;
            //Console.WriteLine(currentwindow);

            ReadOnlyCollection<string> newwindows = driver.WindowHandles;
            int noOfnewwindows = newwindows.Count;
            Console.WriteLine(noOfnewwindows);
            Console.WriteLine(newwindows[2]);

            driver.SwitchTo().Window(newwindows[2]);
            driver.FindElement(By.LinkText("Close this window")).Click();

            //driver.Quit();
           





        }
    }
}
