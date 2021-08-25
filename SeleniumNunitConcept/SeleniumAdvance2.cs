using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SeleniumNunitConcept
{
    class SeleniumAdvance2
    {

        //public void nunit

        [Test, Ignore("skip")]
        public void WindowsAuthAutoITTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            driver.Url = "https://www.softwaretesting.com/";

            Process.Start(@"D:\B-Mine\Company\Company\ABC\Doc\loginsollers.exe");


        }
        //input[@type='file']

        [Test]
        public void Upload1Test()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Url = "https://www.naukri.com/";

            driver.FindElement(By.XPath("//input[@type='file' and @id='file_upload']")).SendKeys(@"D:\B-Mine\Company\Company\Sollers\Selenium Session Notes.docx");

            Assert.True(driver.PageSource.Contains("uploaded Successfully"));
        }


        [Test]
        public void Upload2Test()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Url = "https://smallpdf.com/pdf-to-word";

            driver.FindElement(By.XPath("//input[@type='file']")).SendKeys(@"D:\B-Mine\Company\Company\Sollers\Selenium Session Notes.docx");
        }

        [Test]
        public void Upload3Test()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Url = "https://smallpdf.com/pdf-to-word";

            driver.FindElement(By.XPath("//input[@type='file']")).SendKeys(@"D:\B-Mine\Company\Company\Sollers\Selenium Session Notes.docx");
        }

        [Test]
        public void AutoITUploadTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Url = "https://smallpdf.com/pdf-to-word";

            driver.FindElement(By.XPath("//*[text()='Choose Files']")).Click();

            Process.Start(@"D:\B-Mine\Company\Company\ABC\Doc\uploadsollers.exe");
        }


        [Test]
        public void WindowsAuthTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            //https://username:password@www.naukri.com/
            driver.Url = "https://bala:bala123@www.softwaretesting.com/";
        }

        [Test]
        public void ActionsClassTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Url = "http://google.com/";

            Actions action = new Actions(driver);
            action.KeyDown(Keys.Shift).SendKeys("hello").KeyUp(Keys.Shift).SendKeys(Keys.Enter).Build().Perform();
        }
        [Test]
        public void JSGetValueTest()
        {
            IWebDriver driver = new ChromeDriver();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Url = "https://atozgrocery.in/my-account/";

            driver.FindElement(By.XPath("//input[@id='reg_email']")).SendKeys("king");

            js.ExecuteScript("arguments[0].scrollIntoView();", driver.FindElement(By.Name("register")));
            driver.FindElement(By.Name("register")).Click();


            string res = js.ExecuteScript("return document.querySelectorAll(\"[id = 'reg_email']\")[0].validationMessage").ToString();
            Console.WriteLine(res);

            res = js.ExecuteScript("return document.title").ToString();
            Console.WriteLine(res);

            //windows scroll
            js.ExecuteScript("window.scrollBy(0,100)");
        }





        [Test]
        public void OptionTest()
        {
            //disable notifications
            //change download dir
            //accept SSL certificate
            //pick chromebrowser installed in different directory


            ChromeOptions opt = new ChromeOptions();

            opt.AddArgument("--Headless");

            //Dictionary<String, Object> prefs = new Dictionary<String, Object>();
            //prefs.Add("download.default_directory", "D:\\");
            opt.AddUserProfilePreference("download.default_directory", "D:\\");


            //opt.AcceptInsecureCertificates = true;
            //opt.BinaryLocation = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
            //opt.AddArgument("--disable-notifications");

            IWebDriver driver = new ChromeDriver(opt);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            driver.Url = "https://www.malaysiaairlines.com/in/en.html";

            Console.WriteLine(driver.Title);
        }

        [Test]
        public void ActionsTest()
        {


            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Url = "http://demo.openemr.io/b/openemr/interface/login/login.php?site=default";

            driver.FindElement(By.CssSelector("#authUser")).SendKeys("admin");
            driver.FindElement(By.Id("clearPass")).SendKeys("pass");


            SelectElement select = new SelectElement(driver.FindElement(By.CssSelector("[name='languageChoice']")));
            select.SelectByText("English (Indian)");

            driver.FindElement(By.CssSelector("[type='submit']")).Click();

            Actions actions = new Actions(driver);
            actions
                .MoveToElement(driver.FindElement(By.XPath("//div[text()='Reports']")))
                .MoveToElement(driver.FindElement(By.XPath("//div[text()='Clients']"))).Build().Perform();


            driver.FindElement(By.XPath("//div[text()='List']")).Click();

        }
        [Test]
        public void JSTest1()
        {
            ChromeOptions opt = new ChromeOptions();

            opt.AddArgument("--Headless");

            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Url = "http://demo.openemr.io/b/openemr/interface/login/login.php?site=default";

            driver.FindElement(By.CssSelector("#authUser")).SendKeys("admin");
            driver.FindElement(By.Id("clearPass")).SendKeys("pass");


            SelectElement select = new SelectElement(driver.FindElement(By.CssSelector("[name='languageChoice']")));
            select.SelectByText("English (Indian)");

            driver.FindElement(By.CssSelector("[type='submit']")).Click();



            IWebElement ele = driver.FindElement(By.XPath("//div[text()='List']"));

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click()", ele);

            //js.ExecuteScript("arguments[0].value='bala';", ele);
            //document.querySelector("#dp1627929394343").value = "20 Sep 2021"; document.querySelector("dp1627929394343").value = "28 Sep 2021"
            //js.ExecuteScript("arguments[0].click();arguments[1].value='hello'", ele, ele1) ;
        }

        [Test]
        public void JSTest()
        {

            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Url = "https://www.pepperfry.com/";

            //driver.FindElement(By.Id("registerPopupLink")).Click();


            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("document.querySelector('#registerPopupLink').click()");
        }
    }
}
