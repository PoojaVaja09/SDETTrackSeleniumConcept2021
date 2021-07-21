using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SeleniumNunitConcept
{
    class SeleniumAdvance
    {
        [Test]
        public void HandleAlertExplcitWaitTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Url = "http://www.echoecho.com/javascript4.htm";

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            wait.Until(x => x.FindElement(By.Name("B1"))).Click();

            //driver.FindElement(By.Name("B1")).Click();

            string alertText = wait.Until(x => x.SwitchTo().Alert()).Text;

            wait.Until(x => x.SwitchTo().Alert()).Accept();

            Console.WriteLine(alertText);

            String text = driver.FindElement(By.XPath("//div[@class='headline']")).Text;
            Console.WriteLine(text);

            //wait.Until(driver => driver.FindElement(By.XPath("//div[@class='headline']")));
            text = wait.Until(x => x.FindElement(By.XPath("//div[@class='headline']"))).Text;
            Console.WriteLine(text);

            //driver.FindElement(By.Id("")).SendKeys("2021-07-19");
        }

        [Test]
        public void HandleAlertTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Url = "http://www.echoecho.com/javascript4.htm";

            driver.FindElement(By.Name("B1")).Click();

            string alertText = driver.SwitchTo().Alert().Text;

            driver.SwitchTo().Alert().Accept();

            Console.WriteLine(alertText);
        }

        [Test]
        public void MultipleTabsOrWindowsTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Url = "https://www.db4free.net/";

            driver.FindElement(By.XPath("//b[contains(text(),'phpMy')]")).Click();

            //switch to new tab
            driver.SwitchTo().Window(driver.WindowHandles[1]);

            driver.FindElement(By.Id("input_username")).SendKeys("hello123");
            driver.FindElement(By.Id("input_password")).SendKeys("hello123");
            driver.FindElement(By.Id("input_username")).Submit();

        }

        [Test]
        public void MultipleTabsOrWindowsPrintSessionDetail()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Url = "https://www.db4free.net/";

            driver.FindElement(By.XPath("//b[contains(text(),'phpMy')]")).Click();

            var parent = driver.CurrentWindowHandle;
            Console.WriteLine(parent);
            Console.WriteLine("-----------------------");
            ReadOnlyCollection<string> windows = driver.WindowHandles;

            Console.WriteLine(windows[0]);
            Console.WriteLine(windows[1]);

            for (int i = 0; i < windows.Count; i++)
            {
                Console.WriteLine(windows[i]);
            }

            foreach (string win in windows)
            {
                Console.WriteLine(win);
            }

            foreach (var win in windows)
            {
                Console.WriteLine(win);
            }
        }



        [Test]
        public void ValidCredentialTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Url = "https://magento.com/";

            driver.FindElement(By.XPath("//span[text()='Sign in']")).Click();
            driver.FindElement(By.Id("email")).SendKeys("balaji0017@gmail.com");
            driver.FindElement(By.Id("pass")).SendKeys("balaji@12345");
            driver.FindElement(By.Name("send")).Click();

            //condition 
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            wait.Until(x => x.FindElement(By.LinkText("Log Out")));

            string actualValue = driver.Title;
            Console.WriteLine(actualValue);

            //verification
            Assert.AreEqual("Account Information", actualValue);

        }

    }
}
