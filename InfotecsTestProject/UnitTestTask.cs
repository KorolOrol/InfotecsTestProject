using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace InfotecsTestProject
{
    public class Tests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
        }

        [Test]
        public void Test1()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Navigate().GoToUrl("https://www.gosuslugi.ru/");
            wait.Until(driver => driver.FindElement(By.XPath(".//button[contains(text(),'�����')]")))
                .Click();
            wait.Until(driver => driver.FindElement(By.XPath(".//button[contains(text(),'�� ������ �����?')]")))
                .Click();
            wait.Until(driver => driver.FindElement(By.XPath(".//button[contains(text(),'�������������� ������')]")))
                .Click();
            if (wait.Until(driver => driver.FindElement(By.XPath(".//*[contains(text(),'�������������� ������')]")))
                               .Displayed)
            {
                Assert.Pass("��������� �������� �������������� ������");
            }
            else
            {
                Assert.Fail("�� ��������� �������� �������������� ������");
            }
        }
    }
}