// Generated by Selenium IDE
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
[TestFixture]
public class Test23Test {
  private IWebDriver driver;
  public IDictionary<string, object> vars {get; private set;}
  private IJavaScriptExecutor js;
  [SetUp]
  public void SetUp() {
    driver = new ChromeDriver();
    js = (IJavaScriptExecutor)driver;
    vars = new Dictionary<string, object>();
  }
  [TearDown]
  protected void TearDown() {
    driver.Quit();
  }
  [Test]
  public void test23() {
    driver.Navigate().GoToUrl("https://pharmastock.azurewebsites.net/Persons");
    driver.Manage().Window.Size = new System.Drawing.Size(1600, 984);
    driver.FindElement(By.CssSelector(".btn-primary")).Click();
    driver.FindElement(By.Id("IDCode")).Click();
    driver.FindElement(By.Id("IDCode")).SendKeys("49702101513");
    driver.FindElement(By.Id("FirstName")).Click();
    driver.FindElement(By.Id("FirstName")).SendKeys("Mihkel");
    driver.FindElement(By.Id("LastName")).Click();
    driver.FindElement(By.Id("LastName")).SendKeys("Anton");
    driver.FindElement(By.Id("Address")).Click();
    driver.FindElement(By.Id("Address")).SendKeys("Peetri2, Keila");
    driver.FindElement(By.Id("Email")).Click();
    driver.FindElement(By.Id("Email")).SendKeys("beres.timothy@gmail.com");
    driver.FindElement(By.Id("PhoneNumber")).Click();
    driver.FindElement(By.Id("PhoneNumber")).SendKeys("5 66");
    driver.FindElement(By.Id("GetMedicineInfo")).Click();
    {
      var dropdown = driver.FindElement(By.Id("GetMedicineInfo"));
      dropdown.FindElement(By.XPath("//option[. = 'Email']")).Click();
    }
    driver.FindElement(By.Id("GetMedicineInfo")).Click();
    driver.FindElement(By.Id("ValidFrom")).Click();
    driver.FindElement(By.Id("ValidFrom")).SendKeys("0001-02-10");
    driver.FindElement(By.Id("ValidFrom")).SendKeys("0019-02-10");
    driver.FindElement(By.Id("ValidFrom")).SendKeys("0199-02-10");
    driver.FindElement(By.Id("ValidFrom")).SendKeys("1997-02-10");
    driver.FindElement(By.CssSelector(".btn-sm")).Click();
  }
}