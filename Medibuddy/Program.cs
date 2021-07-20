using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Medibuddy
{
    class Program
    {
        static void Main(string[] args)
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            IWebDriver driver = new ChromeDriver();

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Url = "https://www.medibuddy.in/";

            driver.FindElement(By.LinkText("Signup")).Click();
            driver.FindElement(By.Id("mobile")).SendKeys("432543253");
            driver.FindElement(By.Id("name")).SendKeys("efdsf");
            driver.FindElement(By.Id("email")).SendKeys("abc@abc.com");
            driver.FindElement(By.XPath("(//button[@type='submit'])[1]")).Click();
        }
    }
}
