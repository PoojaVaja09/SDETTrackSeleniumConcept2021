using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumNunitConcept
{
    class RoyalTest
    {

        [Test]
        public void WebElements3Test()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Url = "https://www.google.com/";

            ReadOnlyCollection<IWebElement> elements = driver.FindElements(By.XPath("//a"));
            int linkCount = elements.Count;

            foreach (IWebElement ele in elements)
            {
                if (ele.Text.Equals("Images"))
                {
                    ele.Click();
                    break;
                }

            }

            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.Timeout = TimeSpan.FromSeconds(50);
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));

            wait.Until(x => x.FindElement(By.XPath(""))).Click();


            Console.WriteLine("completed");
        }
        [Test]
        public void WebElements2Test()
        {

            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Url = "https://www.google.com/";

            ReadOnlyCollection<IWebElement> elements = driver.FindElements(By.XPath("//a"));
            int linkCount = elements.Count;

            for (int i = 0; i < linkCount; i++)
            {
                IWebElement ele = elements[i];

                string text = ele.Text;
                Console.WriteLine(text);
                String href = ele.GetAttribute("href");
                Console.WriteLine(href);
            }

            foreach (IWebElement ele in elements)
            {
                string text = ele.Text;
                Console.WriteLine(text);
                String href = ele.GetAttribute("href");
                Console.WriteLine(href);
            }

            foreach (var ele in elements)
            {
                var text = ele.Text;
                Console.WriteLine(text);
                var href = ele.GetAttribute("href");
                Console.WriteLine(href);
            }
        }
        [Test]
        public void WebElements1Test()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Url = "https://www.google.com/";

            ReadOnlyCollection<IWebElement> elements = driver.FindElements(By.XPath("//a"));
            int linkCount = elements.Count;


            String href0 = elements[0].GetAttribute("href");
            Console.WriteLine(href0);

            String href1 = elements[1].GetAttribute("href");
            Console.WriteLine(href1);



            //IWebElement ele0=  elements[0];
            //IWebElement ele0 = driver.FindElement(By.XPath("(//a)[1]"));

        }


        [Test]
        public void ElementCountTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Url = "https://www.royalcaribbean.com/";



            int xpathCount = driver.FindElements(By.XPath("//*[@class='email-capture__close']")).Count;

            if (driver.FindElements(By.XPath("//MM")).Count > 0)
            {
                driver.FindElement(By.XPath("//*[@class='email-capture__close']")).Click();
            }

            int linkcount = driver.FindElements(By.TagName("a")).Count;
        }


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
