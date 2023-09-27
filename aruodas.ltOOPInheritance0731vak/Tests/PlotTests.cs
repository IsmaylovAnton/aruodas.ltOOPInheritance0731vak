using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.DevTools.V114.FedCm;
using aruodas.ltOOPInheritance0731vak.Helpers;
using aruodas.ltOOPInheritance0731vak.Models;
using OpenQA.Selenium.Support.UI;

namespace aruodas.ltOOPInheritance0731vak.Tests
{
    internal class PlotTests
    {
        public static IWebDriver driver;

        [Test]
        public void fillAddPositiveVilniusTest()
        {
            VacantLand v = new VacantLand("Kaunas", "Kauno", "Dainava", "Savanoriu", "5", "50", "5000000", "+37065432107", "nesakysiu@niekam.ut", "https://www.youtube.com/watch?v=31gM5gjw8A8", "https://www.youtube.com/watch?v=31gM5gjw8A8", "1234 - 5678 - 9011:4660", Description.LongDescription, new string[]{"Factory", "Storage"});

            v.fill();
        }
        [Test]
        public void fillAddPositiveKaunasTest()
        {
            VacantLand v = new VacantLand("Klaipeda", "Klaipėdos", "Dainava", "Savanoriu", "300", "50", "5000000", "+37065432107", "nesakysiu@niekam.ut", "https://www.youtube.com/watch?v=31gM5gjw8A8", "https://www.youtube.com/watch?v=31gM5gjw8A8", "1234 - 5678 - 9011:4660", Description.LongDescription, new string[] { "Factory", "Storage" });

            v.fill();
        }
        [Test]
        public void fillAddPositiveSiauliaisTest()
        {
            VacantLand v = new VacantLand("Siauliai", "Žaliūkių", "Dainava", "Savanoriu", "300", "50", "5000000", "+37065432107", "nesakysiu@niekam.ut", "https://www.youtube.com/watch?v=31gM5gjw8A8", "https://www.youtube.com/watch?v=31gM5gjw8A8", "1234 - 5678 - 9011:4660", Description.LongDescription, new string[] { "Factory", "Storage" });

            v.fill();
        }

        [OneTimeSetUp]
        public void Initialize()
        {
            if (DriverClass.Driver is not null)
            {
                return;
            }

            DriverClass.Driver = new ChromeDriver();
            DriverClass.Wait = new WebDriverWait(DriverClass.Driver, TimeSpan.FromSeconds(5));

            driver = DriverClass.Driver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.Manage().Window.Maximize();
            AcceptCookies();
            Login();
        }

        [OneTimeTearDown]
        public void Clenaup()
        {
            //driver.Quit();
        }
        public void AcceptCookies()
        {
            driver.Navigate().GoToUrl("https://en.aruodas.lt/");
            driver.FindElement(By.Id("onetrust-accept-btn-handler")).Click();
        }
        public void Login()
        {
            driver.FindElement(By.XPath("/html/body/div[1]/div[3]/div[2]/div[2]/div[1]/div[1]/div/div[2]/div")).Click();
            driver.FindElement(By.Id("userName")).SendKeys("jijojon659@ipniel.com");
            driver.FindElement(By.Id("password")).SendKeys("59959gdgf");
            driver.FindElement(By.Id("loginAruodas")).Click();
        }
    }
}

//[Test]
//public void address()
//{
//    VacantLand v = new VacantLand("46");
//    v.fill();
//    VacantLand v2 = new VacantLand("465");
//    v2.fill();
//}