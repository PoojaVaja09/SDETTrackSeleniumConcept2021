using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace MagentoApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            IWebDriver driver = new ChromeDriver();

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Url = "https://magento.com/";

            driver.FindElement(By.XPath("//span[contains(text(),'Sign in')]")).Click();
            driver.FindElement(By.Name("login[username]")).SendKeys("balaji0017@gmail.com");
            driver.FindElement(By.Name("login[password]")).SendKeys("balaji@12345");
            driver.FindElement(By.XPath("//div[@class='login-form__bottom']//button[@id='send2']")).Click();
            driver.FindElement(By.LinkText("Log Out")).Click();

            driver.Quit();
        }
    }
}
