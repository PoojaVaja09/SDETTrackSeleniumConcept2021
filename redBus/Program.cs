using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace redBus
{
    class Program
    {
        static void Main(string[] args)
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            IWebDriver driver = new ChromeDriver();

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Url = "https://www.redbus.in/";

            driver.FindElement(By.Id("sign-in-icon-down")).Click();
            driver.FindElement(By.Id("signInLink")).Click();

            //switch to frame
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//div[@class='modal']//iframe[@class='modalIframe']")));

            driver.FindElement(By.Id("mobileNoInp")).SendKeys("787878");

            driver.Quit();

        }
    }
}
