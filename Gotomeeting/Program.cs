using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Gotomeeting
{
    class Program
    {
        static void Main(string[] args)
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            IWebDriver driver = new ChromeDriver();

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Url = "https://www.gotomeeting.com/en-in";
            driver.Manage().Cookies.DeleteAllCookies();

            driver.FindElement(By.XPath("//button[text()='Go']")).Click();

            driver.FindElement(By.XPath("//img[@alt='close icon']")).Click();

            driver.FindElement(By.LinkText("Start for Free")).Click();
            driver.FindElement(By.XPath("//img[@alt='close icon']")).Click();
            driver.FindElement(By.Id("first-name")).SendKeys("abd");
            driver.FindElement(By.Id("last-name")).SendKeys("acd");
            driver.FindElement(By.Id("login__email")).SendKeys("abd@abc.com");

            SelectElement selectJobTitle = new SelectElement(driver.FindElement(By.Id("JobTitle")));
            selectJobTitle.SelectByText("Help Desk");

            driver.FindElement(By.Id("login__password")).SendKeys("ewdwqer");
            driver.FindElement(By.XPath("//input[@value='10 - 99']")).Click();
            driver.FindElement(By.XPath("//button[text()='Sign Up']")).Click();
        }
    }
}
