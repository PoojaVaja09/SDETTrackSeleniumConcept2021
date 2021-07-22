using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumNunitConcept
{
    class PepperfryTest
    {
        [Test]
        public void searchTest()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Url = "https://www.pepperfry.com/";

            if (driver.FindElements(By.XPath("//div[@id='regPopUp']/a")).Count > 0)
            {
                driver.FindElement(By.XPath("//div[@id='regPopUp']/a")).Click();
            }

            driver.FindElement(By.Id("search")).SendKeys("bedsheets");
            driver.FindElement(By.Id("searchButton")).Click();
            driver.FindElement(By.XPath("//label[text()='Sleep Dove']")).Click();

            Thread.Sleep(5000);

            driver.SwitchTo().Frame("webklipper-publisher-widget-container-notification-frame");
            driver.FindElement(By.Id("webklipper-publisher-widget-container-notification-close-div")).Click();
            driver.SwitchTo().DefaultContent();

            Actions actions = new Actions(driver);
            actions.MoveToElement(driver.FindElement(By.XPath("(//div[@unbxdattr='product'])[1]"))).Build().Perform();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("(//a[text()='Add To Cart'])[1]")).Click();


            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//a[text()='Proceed to pay securely ']")).Click();
            driver.FindElement(By.LinkText("PLACE ORDER")).Click();

            driver.FindElement(By.Id("name")).SendKeys("John");
            driver.FindElement(By.Id("postcode")).SendKeys("400059");
            driver.FindElement(By.Id("street")).SendKeys("MetroPark");
            driver.FindElement(By.Id("city")).SendKeys("Mumbai");

            driver.FindElement(By.Id("btn_guestform_save_shipping")).Click();

            string actualErrorMsg = driver.FindElement(By.XPath("//div[contains(text(),'Enter valid 10 digit number')]")).Text;
            Assert.AreEqual("Enter valid 10 digit number", actualErrorMsg);

            driver.Quit();




        }

    }
}
