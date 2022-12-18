using AutoFixture.Xunit2;
using EaApplicationTest.Models;
using EaApplicationTest.Pages;
using EaFramework.Config;
using EaFramework.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace EaApplicationTest
{
    public class UnitTest1 : IDisposable
    {

        private IDriverFixture _driverFixture;  
        
        public UnitTest1()
        {
            //var testSettings = new TestSettings()
            //{
            //    BrowserType = BrowserType.Chrome,
            //    ApplicationUrl = new Uri("http://www.localhost:8000"),
            //    TimeoutInterval = 30
            //};


            var testSettings = ConfigReader.ReadConfig();
            
            _driverFixture = new DriverFixture(testSettings);
        }
        
        
        [Theory]
        [AutoData]
        public void Test1(Product product)
        {
            //HomePage
            var homePage = new HomePage(_driverFixture);
            var productPage = new ProductPage(_driverFixture);

            //Click the Create link
            homePage.ClickProduct();

            //Create product
            productPage.ClickCreateButton();
            productPage.CreateProduct(product);
            
            productPage.PerformClickOnSpecialValue(product.Name, "Details");
        }

        public void Dispose()
        {
            _driverFixture.Driver.Quit();
        }
    }
}