using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
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
        }
    }
}
