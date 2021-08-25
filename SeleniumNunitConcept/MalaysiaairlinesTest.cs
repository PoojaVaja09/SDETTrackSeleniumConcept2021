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
    class MalaysiaairlinesTest
    {
        [Test]
        public void FlightTest()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Url = "https://www.malaysiaairlines.com/in/en.html";

            
            driver.FindElement(By.XPath("//input[@aria-label='fromLocation selectize input']")).Click();
            driver.FindElement(By.XPath("//div[@data-group='With Malaysia Airlines']/div[@data-value='MAA']")).Click();

            driver.FindElement(By.XPath("//input[@aria-label='toLocation selectize input']")).Click();
            driver.FindElement(By.XPath("//div[@data-group='online']/div[@data-value='AKL']")).Click();
           
            driver.FindElement(By.XPath("//div[contains(@class, 'ui-datepicker-group-first')]/table[1]/tbody[1]/tr[5]/td[5]/a[1]")).Click();
            driver.FindElement(By.XPath("//div[contains(@class, 'ui-datepicker-group-last')]/table[1]/tbody[1]/tr[4]/td[4]/a[1]")).Click();

            driver.FindElement(By.XPath("(//div[@class='total-passengers'])[1]")).Click();

            driver.FindElement(By.XPath("//div[contains(@class,'col-lg-4 col-md-4 col-sm-4')]//div[contains(@class,'col-lg-12 col-md-12 col-sm-12 booking-person adult-cat')]//button[contains(@aria-label,'Increment Adult')]")).Click();

            driver.FindElement(By.XPath("//div[contains(@class,'col-lg-4 col-md-4 col-sm-4')]//div[contains(@class,'col-lg-12 col-md-12 col-sm-12 booking-person child-cat')]//i[contains(@class,'fa fa-plus')]")).Click();
            driver.FindElement(By.XPath("//div[contains(@class,'col-lg-4 col-md-4 col-sm-4')]//div[contains(@class,'col-lg-12 col-md-12 col-sm-12 booking-person child-cat')]//i[contains(@class,'fa fa-plus')]")).Click();
            driver.FindElement(By.XPath("//div[contains(@class,'col-lg-4 col-md-4 col-sm-4')]//div[contains(@class,'col-lg-12 col-md-12 col-sm-12 booking-person child-cat')]//i[contains(@class,'fa fa-plus')]")).Click();

            driver.FindElement(By.XPath("//label[@for='cabinClass'][text()='Cabin Class']")).Click();
            //driver.FindElement(By.XPath("//div[@class='item'][text()='Business']")).Click();
            driver.FindElement(By.XPath("//div[text()='Business']")).Click();






        }

    }
}
