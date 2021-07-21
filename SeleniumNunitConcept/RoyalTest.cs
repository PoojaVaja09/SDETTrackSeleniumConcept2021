using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumNunitConcept
{
    class RoyalTest
    {

        [Test]
        public void CreateAccountTest()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Url = "https://www.royalcaribbean.com/";

            if (driver.FindElements(By.XPath("//*[@class='email-capture__close']")).Count > 0)
            {
                driver.FindElement(By.XPath("//*[@class='email-capture__close']")).Click();
            }


            driver.FindElement(By.Id("rciHeaderSignIn")).Click();
            driver.FindElement(By.LinkText("Create an account")).Click();

            driver.FindElement(By.XPath("//input[@data-placeholder='First name/Given name']")).SendKeys("Denis");
            driver.FindElement(By.XPath("//input[@data-placeholder='Last name/Surname']")).SendKeys("Rich");

            //month april   
            string month = "December";
            driver.FindElement(By.XPath("//span[text()='Month']")).Click();
            driver.FindElement(By.XPath("//span[text()=' " + month + " ']")).Click();

            //30
            driver.FindElement(By.XPath("//span[text()='Day']")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//span[text()=' 30 ']")).Click();

            //year 1990
            driver.FindElement(By.XPath("//input[@data-placeholder='Year']")).SendKeys("1990");

            //country India
            driver.FindElement(By.XPath("//span[text()='Country/Region of residence']")).Click();
            driver.FindElement(By.XPath("//span[text()=' India ']")).Click();

            driver.FindElement(By.XPath("//input[@aria-labelledby='agreements']/..")).Click();
        }
    }
}
