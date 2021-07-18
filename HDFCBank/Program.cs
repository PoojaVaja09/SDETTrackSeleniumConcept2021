using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace HDFCBank
{
    class Program
    {
        static void Main(string[] args)
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            IWebDriver driver = new ChromeDriver();

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Url = "https://netbanking.hdfcbank.com/netbanking/";

            driver.SwitchTo().Frame("login_page");
            driver.FindElement(By.Name("fldLoginUserId")).SendKeys("abs");

            //click on continue
            driver.FindElement(By.XPath("(//img[@alt='continue'])[1]")).Click();

            //Comeout of frame

            driver.SwitchTo().DefaultContent();

        }
    }
}
