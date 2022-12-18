using EaFramework.Driver;
using OpenQA.Selenium;

namespace EaApplicationTest.Pages;

public class HomePage
{
    private readonly IDriverFixture _driverFixture;


    public HomePage(IDriverFixture driverFixture)
    {
        _driverFixture = driverFixture;
    }


    private IWebElement lnkHome => _driverFixture.Driver.FindElement(By.LinkText("Home"));
    private IWebElement lnkPrivacy => _driverFixture.Driver.FindElement(By.LinkText("Privacy"));
    private IWebElement lnkProduct => _driverFixture.Driver.FindElement(By.LinkText("Product"));


    public void ClickProduct() => lnkProduct.Click();
}