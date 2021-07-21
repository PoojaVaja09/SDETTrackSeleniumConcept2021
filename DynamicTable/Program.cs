using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace DynamicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            IWebDriver driver = new ChromeDriver();

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Url = "https://datatables.net/extensions/select/examples/initialisation/checkbox.html";

            SelectElement selectEntries = new SelectElement(driver.FindElement(By.Name("example_length")));
            selectEntries.SelectByText("50");

            ReadOnlyCollection<IWebElement> rowEles=driver.FindElements(By.XPath("//table[@id='example']/tbody/tr"));
            int rowCount = rowEles.Count;


            int sum = 0;
            for (int i = 1; i < rowCount; i++)
            {
                string salary=driver.FindElement(By.XPath("//table[@id='example']/tbody/tr[" + i + "]/td[6]")).Text;
                Console.WriteLine(salary);

                string salWithoutDollar = salary.Replace("$", " ");
                Console.WriteLine(salWithoutDollar);
                string SalWithoutComa = salWithoutDollar.Replace(",", "");
                Console.WriteLine(SalWithoutComa);

                int finalSal = Convert.ToInt32(SalWithoutComa);
                Console.WriteLine(SalWithoutComa);

                sum = sum + finalSal;
                Console.WriteLine(sum);

             

            }

        }
    }
}
