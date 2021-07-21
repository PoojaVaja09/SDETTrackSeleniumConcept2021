using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace OpenEMR
{
    class Program
    {
        static void Main(string[] args)
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            IWebDriver driver = new ChromeDriver();

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Url = "https://demo.openemr.io/b/openemr/interface/login/login.php?site=default";

            driver.FindElement(By.Id("authUser")).SendKeys("admin");
            driver.FindElement(By.Id("clearPass")).SendKeys("pass");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();

            //Thread.Sleep(5000);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            wait.Until(x => x.FindElement(By.XPath("//div[contains(text(),'Patient/Client')]")));

            Actions actions = new Actions(driver);
            actions.MoveToElement(driver.FindElement(By.XPath("//div[contains(text(),'Patient/Client')]"))).Build().Perform();
            driver.FindElement(By.XPath("(//div[text()='Patients'])[1]")).Click();

            //move to frame fin
            driver.SwitchTo().Frame("fin");

            driver.FindElement(By.Id("create_patient_btn1")).Click();

            driver.SwitchTo().DefaultContent();

            //move to pat frame
            driver.SwitchTo().Frame("pat");

            driver.FindElement(By.Id("form_fname")).SendKeys("John");
            driver.FindElement(By.Id("form_lname")).SendKeys("Smith");
            driver.FindElement(By.Id("form_DOB")).SendKeys("2021-07-20");

            SelectElement selectSex = new SelectElement(driver.FindElement(By.Id("form_sex")));
            selectSex.SelectByText("Male");

            driver.FindElement(By.Id("create")).Click();
            driver.SwitchTo().DefaultContent();

            //move to modalframe
            driver.SwitchTo().Frame("modalframe");

            driver.FindElement(By.XPath("//input[@value='Confirm Create New Patient']")).Click();
            driver.SwitchTo().DefaultContent();



            //fluent wait
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.Timeout = TimeSpan.FromSeconds(50);
            wait.PollingInterval = TimeSpan.FromSeconds(5);
            wait.IgnoreExceptionTypes(typeof(NoAlertPresentException));//ignore no alert exception

            string actualValueOfAlert = wait.Until(x => x.SwitchTo().Alert()).Text;
            Console.WriteLine(actualValueOfAlert);

            wait.Until(x => x.SwitchTo().Alert()).Accept();

            if (driver.FindElements(By.XPath("//div[@class='closeDlgIframe']")).Count > 0) // check element present or not
            {
                driver.FindElement(By.XPath("//div[@class='closeDlgIframe']")).Click();
            }



            //close pop up

            driver.FindElement(By.XPath("//div[@class='closeDlgIframe']")).Click();

            driver.SwitchTo().Frame("pat");

            
            string actualText = driver.FindElement(By.XPath("//h2[contains(text(),'Medical Record Dashboard')]")).Text;
            Console.WriteLine(actualText);

            //public bool IsElementPresent()
            //{
            //    try
            //    {
            //        driver.FindElement(By.XPath("//div[@class='closeDlgIframe']"));
            //        return true;
            //    }
            //    catch
            //    {
            //        return false
            //    }
            //}



        }
    }
}
