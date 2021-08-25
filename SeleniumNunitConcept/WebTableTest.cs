using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumNunitConcept
{
    class WebTableTest
    {
        [Test]
        [TestCase("Bala", 41, "$132,000")]
        public void CheckAgeTest(string empName, int expectedAge, String expectedSalary)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Url = "https://datatables.net/extensions/select/examples/initialisation/checkbox.html";

            int rowCount = driver.FindElements(By.XPath("//table[@id='example']/tbody/tr")).Count;
            Console.WriteLine(rowCount);
            bool check = false;
            for (int i = 1; i <= rowCount; i++)
            {
                string name = driver.FindElement(By.XPath("//table[@id='example']/tbody/tr[" + i + "]/td[2]")).Text;

                if (name.Equals(empName))
                {
                    string age = driver.FindElement(By.XPath("//table[@id='example']/tbody/tr[" + i + "]/td[5]")).Text;

                    string sal = driver.FindElement(By.XPath("//table[@id='example']/tbody/tr[" + i + "]/td[6]")).Text;

                    Assert.AreEqual(expectedAge, Convert.ToInt32(age));
                    Assert.AreEqual(expectedSalary, sal);

                    String rowText = driver.FindElement(By.XPath("//table[@id='example']/tbody/tr[" + i + "]")).Text;

                    Assert.True(rowText.Contains(Convert.ToString(expectedAge)) && rowText.Contains(expectedSalary));
                    check = true;
                    break;
                }

            }

            Assert.True(check, "Name is not available");
            //if(!check)
            //{
            //    Assert.Fail("Name not available");
            //}

        }


        [Test]
        public void PrintFirstNameTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Url = "https://datatables.net/extensions/select/examples/initialisation/checkbox.html";

            string name = driver.FindElement(By.XPath("//table[@id='example']/tbody/tr[1]/td[2]")).Text;

            Console.WriteLine(name);
            name = driver.FindElement(By.XPath("//table[@id='example']/tbody/tr[2]/td[2]")).Text;

            Console.WriteLine(name);
        }

        [Test]
        public void PrintAllNameTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Url = "https://datatables.net/extensions/select/examples/initialisation/checkbox.html";

            int rowCount = driver.FindElements(By.XPath("//table[@id='example']/tbody/tr")).Count;
            Console.WriteLine(rowCount);
            for (int i = 1; i <= rowCount; i++)
            {
                string name = driver.FindElement(By.XPath("//table[@id='example']/tbody/tr[" + i + "]/td[2]")).Text;
                string sal = driver.FindElement(By.XPath("//table[@id='example']/tbody/tr[" + i + "]/td[6]")).Text;
                Console.WriteLine(name + " & " + sal);
            }

        }

        [Test]
        public void WorkingOnTableTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Url = "https://datatables.net/extensions/select/examples/initialisation/checkbox.html";

            int rowCount = driver.FindElements(By.XPath("//table[@id='example']/tbody/tr")).Count;

            Console.WriteLine(rowCount);
            for (int i = 1; i <= rowCount; i++)
            {
                string name = driver.FindElement(By.XPath("//table[@id='example']/tbody/tr[" + i + "]/td[2]")).Text;

                if (name.Equals("Brenden Wagner"))
                {
                    Console.WriteLine(driver.FindElement(By.XPath("//table[@id='example']/tbody/tr[" + i + "]/td[6]")).Text);
                    driver.FindElement(By.XPath("//table[@id='example']/tbody/tr[" + i + "]/td[1]")).Click();
                    break;
                }
            }
        }

        [Test]
        public void PrintAllPageNamesTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Url = "https://datatables.net/extensions/select/examples/initialisation/checkbox.html";

            string pageDetail = driver.FindElement(By.XPath("//div[@id='example_info']")).Text;
            Console.WriteLine(pageDetail);
            //String sample = "Showing 1 to 10 of 57 entries";
            int pageCount = driver.FindElements(By.XPath("//div[@id='example_paginate']/span/a")).Count;

            for (int p = 1; p <= pageCount; p++) //page navigation
            {
                int rowCount = driver.FindElements(By.XPath("//table[@id='example']/tbody/tr")).Count;
                Console.WriteLine(rowCount);
                for (int i = 1; i <= rowCount; i++) //for row navigation
                {
                    string name = driver.FindElement(By.XPath("//table[@id='example']/tbody/tr[" + i + "]/td[2]")).Text;
                    string sal = driver.FindElement(By.XPath("//table[@id='example']/tbody/tr[" + i + "]/td[6]")).Text;
                    Console.WriteLine(name + " & " + sal);
                }
                if (p != 6)
                {
                    driver.FindElement(By.LinkText("Next")).Click();
                }
            }
        }

        [Test]
        public void WorkingOnTableAllPagesTest()
        {
            string checkname = "Paul Byrd";
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Url = "https://datatables.net/extensions/select/examples/initialisation/checkbox.html";



            int pageCount = driver.FindElements(By.XPath("//div[@id='example_paginate']/span/a")).Count;
            bool check = false;
            for (int p = 1; p <= pageCount; p++) //page navigation
            {
                int rowCount = driver.FindElements(By.XPath("//table[@id='example']/tbody/tr")).Count;

                for (int i = 1; i <= rowCount; i++)
                {
                    string name = driver.FindElement(By.XPath("//table[@id='example']/tbody/tr[" + i + "]/td[2]")).Text;

                    if (name.Equals(checkname))
                    {
                        Console.WriteLine(driver.FindElement(By.XPath("//table[@id='example']/tbody/tr[" + i + "]/td[6]")).Text);
                        driver.FindElement(By.XPath("//table[@id='example']/tbody/tr[" + i + "]/td[1]")).Click();
                        check = true;
                        //p = pageCount + 1;
                        break;

                    }
                }
                if (check)
                {
                    break;
                }
                if (p != pageCount)
                {
                    driver.FindElement(By.LinkText("Next")).Click();
                }
            }

        }



        [Test]
        public void ScrollAndPrintAllPageNamesTest()
        {
            IWebDriver driver = new ChromeDriver();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Url = "https://datatables.net/examples/basic_init/scroll_y.html";

            string pageDetail = driver.FindElement(By.XPath("//div[@id='example_info']")).Text;
            Console.WriteLine(pageDetail);

            int rowCount = driver.FindElements(By.XPath("//table[@id='example']/tbody/tr")).Count;
            Console.WriteLine(rowCount);
            for (int i = 1; i <= rowCount; i++) //for row navigation
            {
                IWebElement ele = driver.FindElement(By.XPath("//table[@id='example']/tbody/tr[" + i + "]/td[2]"));
                js.ExecuteScript("arguments[0].scrollIntoView();", ele);


                string name = driver.FindElement(By.XPath("//table[@id='example']/tbody/tr[" + i + "]/td[2]")).Text;
                string sal = driver.FindElement(By.XPath("//table[@id='example']/tbody/tr[" + i + "]/td[6]")).Text;
                Console.WriteLine(name + " & " + sal);
            }

        }

        [Test]
        public void DownArrowAndPrintAllPageNamesTest()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Url = "https://datatables.net/examples/basic_init/scroll_y.html";

            string pageDetail = driver.FindElement(By.XPath("//div[@id='example_info']")).Text;
            Console.WriteLine(pageDetail);

            int rowCount = driver.FindElements(By.XPath("//table[@id='example']/tbody/tr")).Count;
            Console.WriteLine(rowCount);
            for (int i = 1; i <= rowCount; i++) //for row navigation
            {
                IWebElement ele = driver.FindElement(By.XPath("//table[@id='example']/tbody/tr[" + i + "]/td[2]"));
                Actions action = new Actions(driver);
                action.MoveToElement(ele).Click().SendKeys(Keys.ArrowDown).Build().Perform();

                string name = driver.FindElement(By.XPath("//table[@id='example']/tbody/tr[" + i + "]/td[2]")).Text;
                string sal = driver.FindElement(By.XPath("//table[@id='example']/tbody/tr[" + i + "]/td[6]")).Text;
                Console.WriteLine(name + " & " + sal);
            }

        }





    }
}

