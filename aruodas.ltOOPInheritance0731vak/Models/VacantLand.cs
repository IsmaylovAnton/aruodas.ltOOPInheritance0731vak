using aruodas.ltOOPInheritance0731vak.Helpers;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V114.Input;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;

namespace aruodas.ltOOPInheritance0731vak.Models
{
    internal class VacantLand : RealEstate
    {
        public string City { get; set; }
        public string Settlement {  get; set; } 
        public string Quarter {  get; set; }    
        public string Street {  get; set; } 
        public string Number {  get; set; }
        public string Area { get; set; }
        public string Price { get; set; }
        public string PhoNo { get; set; }
        public string Email { get; set; }
        public string Video { get; set; }
        public string Tour { get; set; }
        public string RC { get; set; }
        public string Description { get; set; }
        public string[] CheckBoxes { get; set; }

        public VacantLand(string city, string settlement, string quarter, string street, string number, string area, string price, string phoNo, string email, string video, string tour, string rc, string description, string[] checkBoxes) : base()
        {
            this.City = city;
            this.Settlement = settlement;
            this.Quarter = quarter;
            this.Street = street;
            this.Number = number;
            this.Area = area;
            this.Price = price;
            this.PhoNo = phoNo;
            this.Email = email;
            this.Video = video;
            this.Tour = tour;
            this.RC = rc;
            this.Description = description;
            this.CheckBoxes = checkBoxes;
        }

        public void fill()
        {
            Driver.Navigate().GoToUrl("https://en.aruodas.lt/ideti-skelbima/?obj=11&offer_type=1");
            FillLocation();
            ChoosePurpose();
            Driver.FindElement(By.Name("RCNumber")).SendKeys(this.RC);
            Driver.FindElement(By.Id("fieldFAreaOverAll")).SendKeys(this.Area);
            Driver.FindElement(By.Name("notes_lt")).SendKeys(this.Description);
            Driver.FindElement(By.Name("Video")).SendKeys(this.Video);
            Driver.FindElement(By.Name("tour_3d")).SendKeys(this.Tour);
            Driver.FindElement(By.Id("priceField")).SendKeys(this.Price);
            Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[34]/span[1]/input")).SendKeys(this.PhoNo);
            Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[35]/span[1]/input")).Clear();
            Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[35]/span[1]/input")).SendKeys(this.Email);
            Final3CheckBox();
            Photo();
            //MarkDetails();
            Driver.FindElement(By.XPath("//*[@id=\"submitFormButton\"]")).Click();
        }
        public void FillLocation()
        {
            int cityCount = Driver.FindElement(By.Id("regionDropdown")).FindElements(By.TagName("li")).Count;
        
            //Region (city)
            Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[3]/span[1]/input[2]")).Click();
            Driver.FindElement(By.XPath("//*[@id=\"regionDropdown\"]/li[1]/input")).SendKeys(this.City);
            Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"regionDropdown\"]/li[" + (cityCount + 1) + "]"))).Click();

            //District(settlement)
            Driver.FindElement(By.XPath("//*[@id=\"district\"]/span")).Click();
            IWebElement districtUL = Driver.FindElements(By.ClassName("dropdown-input-search-value"))[1];
            IList<IWebElement> DistrictLis = districtUL.FindElements(By.TagName("li"));
            if(DistrictLis.Count > 15) 
            {
                districtUL.FindElement(By.TagName("input")).SendKeys(this.Settlement);
                Thread.Sleep(1000);
                districtUL.FindElement(By.TagName("input")).SendKeys(Keys.Enter);
            }
            else
            {
                for (int i = 0; i < DistrictLis.Count; i++)
                {
                    DistrictLis[i].Click();
                    break;
                }
            }

            //quarter(Microdistrict)
            Driver.FindElement(By.XPath("//*[@id=\"quartalField\"]/span[1]/span[2]")).Click();
            IWebElement quarterUL = Driver.FindElements(By.ClassName("dropdown-input-values-address"))[2];
            IList<IWebElement> quarterLis = quarterUL.FindElements(By.TagName("li"));

            if (quarterLis.Count > 15)
            {
                quarterUL.FindElement(By.TagName("input")).SendKeys(this.Quarter);
                Thread.Sleep(1000);
                quarterUL.FindElement(By.TagName("input")).SendKeys(Keys.Enter);
            }

            else
            {
                for (int i = 0; i < quarterLis.Count; i++)
                {
                    if (quarterLis[i].Text.Contains(this.Quarter))
                    {
                        quarterLis[i].Click();
                        break;
                    }
                }

            }

            //Street
            Driver.FindElement(By.Id("streetTitle")).Click();
            IWebElement streetUL = Driver.FindElements(By.ClassName("dropdown-input-values-address"))[3];
            IList<IWebElement> streetLis = streetUL.FindElements(By.TagName("li"));

            if (streetLis.Count > 15)
            {
                streetUL.FindElement(By.TagName("input")).SendKeys(this.Street);
                Thread.Sleep(1000);
                streetUL.FindElement(By.TagName("input")).SendKeys(Keys.Enter);
            }

            else
            {
                for (int i = 0; i < streetLis.Count; i++)
                {
                    if (streetLis[i].Text.Contains(this.Street))
                    {
                        streetLis[i].Click();
                        break;
                    }
                }

            }

            //WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            //Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"regionDropdown\"]/li[" + (quarterLis.Count + 1) + "]"))).Click();

            //Driver.FindElement(By.Id("districtTitle")).SendKeys("anta");
            //Driver.FindElement(By.XPath("//*[@id=\"quartals_6\"]/li[1]/input")).SendKeys(this.Quarter);
            //Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"quartals_6\"]/li[" + (quarterCount + 1) + "]"))).Click();

            //Driver.FindElement(By.XPath("//*[@id=\"streetTitle\"]")).Click();
            //Driver.FindElement(By.XPath("//*[@id=\"streets_6\"]/li[1]/input")).SendKeys(this.Street);
            //Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"streets_6\"]/li[" + (streetCount + 1) + "]"))).Click();

            Driver.FindElement(By.Name("FHouseNum")).SendKeys(this.Number);
        }

        public void ChoosePurpose()
        {
            for (int i = 0; i < CheckBoxes.Length; i++) 
            {
                switch(CheckBoxes[i]) 
                {
                    case "Factory":
                        Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[16]/div/div[6]/label")).Click();
                        break;
                    case "Storage":
                        IWebElement StorageLabel = Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[16]/div/div[7]/label"));
                        StorageLabel.Click();
                        break;

                                                
                }
            }
        }

        public void SiauliaiZaliukiuFillLocation()
        {
            string city = "Siauliai";
            //string settlement = "Zaliukiu";
            string street = "Maluno";
            string number = "8";
            int cityCount = Driver.FindElement(By.Id("regionDropdown")).FindElements(By.TagName("li")).Count;
            int settlementCount = Driver.FindElement(By.XPath("districts_259")).FindElements(By.TagName("li")).Count;
            int streetCount = Driver.FindElement(By.XPath("//*[@id=\"streets_6\"]")).FindElements(By.TagName("li")).Count;

            Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[3]/span[1]/input[2]")).Click();
            Driver.FindElement(By.XPath("//*[@id=\"regionDropdown\"]/li[1]/input")).SendKeys(city);
            Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"regionDropdown\"]/li[" + (cityCount + 1) + "]"))).Click();
            try
            {
                Driver.FindElement(By.XPath("//*[@id=\"districtTitle\"]")).Click();
                Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"districts_259\"]" + (settlementCount + 1) + "]"))).Click();
            }catch(Exception e) { }

            Driver.FindElement(By.XPath("//*[@id=\"streetTitle\"]")).Click();
            Driver.FindElement(By.XPath("//*[@id=\"streets_6\"]/li[1]/input")).SendKeys(street);
            Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"streets_6\"]/li[" + (streetCount + 1) + "]"))).Click();

            Driver.FindElement(By.Name("FHouseNum")).SendKeys(number);
        }

        public void Photo()
        {
            IWebElement chooseFile = Driver.FindElement(By.XPath("//*[@id=\"uploadPhotoBtn\"]/input"));
            chooseFile.SendKeys("C:\\Users\\user\\Desktop\\kauno-r-sav-virbaliskiu-k-metu-g-namu.jpg");
        }

        public void Final3CheckBox()
        {
            IWebElement emailCheckbox = Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[36]/div/div/div/label"));

            if (!emailCheckbox.Selected)
            {
                emailCheckbox.Click();
            }
           
            IWebElement chatCheckbox = Driver.FindElement(By.Id("cbdont_want_chat"));
            IWebElement emailCheckboxLabel = Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[37]/div/div/div/label"));

            if (!chatCheckbox.Selected)
            {
                emailCheckboxLabel.Click();
            }
           
            IWebElement agreeToRulesCheckbox = Driver.FindElement(By.Id("cbagree_to_rules"));
            IWebElement agreeToRulesCheckboxLabel = Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[38]/span[1]/div/div/label/span"));

            if (!agreeToRulesCheckbox.Selected)
            {
                agreeToRulesCheckboxLabel.Click();
            }
        }

        //public void MarkDetails()
        //{
        //    Driver.FindElement(By.Id("showMoreFields")).Click();

        //IWebElement Electricity = Driver.FindElement(By.Id("cb_SpecialLot_1"));
        //IWebElement ElectricityLabel = Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[20]/div/div[1]/label"));

        //    if (!Electricity.Selected)
        //    {
        //      ElectricityLabel.Click();
        //    }

        //    IWebElement Gas = Driver.FindElement(By.Id("cb_SpecialLot_2"));
        //    IWebElement GasLabel = Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[20]/div/div[2]/label"));

        //    if(!Gas.Selected)
        //    {
        //        GasLabel.Click();
        //    }

        //    IWebElement Sewage = Driver.FindElement(By.Id("cb_SpecialLot_3"));
        //    IWebElement SewageLabel = Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[20]/div/div[3]/label"));

        //    if (!Sewage.Selected)
        //    {
        //        SewageLabel.Click();
        //    }

        //    IWebElement NearForest = Driver.FindElement(By.Id("cb_SpecialLot_5"));
        //    IWebElement NearForestLabel = Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[20]/div/div[5]/label"));

        //    if (!NearForest.Selected)
        //    {
        //        NearForestLabel.Click();
        //    }

        //    IWebElement Exchange = Driver.FindElement(By.Id("cbInterestedChange"));
        //    IWebElement ExchangeLabel = Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[22]/div/div/div/label"));

        //    if (!Exchange.Selected)
        //    {
        //        ExchangeLabel.Click();
        //    }

        //    IWebElement Manufactoring = Driver.FindElement(By.Id("cb_FIntendance_manufacturingland"));
        //    IWebElement ManufactoringLabel = Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[16]/div/div[2]/label"));

        //    if (!Manufactoring.Selected)
        //    {
        //        ManufactoringLabel.Click();
        //    }

        //    IWebElement Storage = Driver.FindElement(By.Id("cb_FIntendance_storage"));
        //    IWebElement StorageLabel = Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[16]/div/div[7]/label"));

        //    if (!Storage.Selected)
        //    {
        //        StorageLabel.Click();
        //    }










  //  }

    }
}
 




