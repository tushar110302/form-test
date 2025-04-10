using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FormTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using IWebDriver driver = new ChromeDriver();

            try
            {
                driver.Manage().Window.Maximize();

                driver.Navigate().GoToUrl("https://app.cloudqa.io/home/AutomationPracticeForm");

                var firstName = driver.FindElement(By.Id("fname"));
                firstName.Clear();
                firstName.SendKeys("Tushar");

                var lastName = driver.FindElement(By.Id("lname"));
                lastName.Clear();
                lastName.SendKeys("Ranjan");

                var email = driver.FindElement(By.Id("email"));
                email.Clear();
                email.SendKeys("tushar@example.com");

                bool isValid =
                    firstName.GetAttribute("value") == "Tushar" &&
                    lastName.GetAttribute("value") == "Ranjan" &&
                    email.GetAttribute("value") == "tushar@example.com";

                Console.WriteLine(isValid
                    ? "All fields filled and validated successfully!"
                    : "Field validation failed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Test failed with error: {ex.Message}");
            }
            finally
            {
                System.Threading.Thread.Sleep(3000);
                driver.Quit();
            }
        }
    }
}
