using EaApplicationTest.Models;
using EaFramework.Driver;
using EaFramework.Extensions;
using OpenQA.Selenium;

namespace EaApplicationTest.Pages;

public class ProductPage
{
    private readonly IDriverFixture _driverFixture;

    public ProductPage(IDriverFixture driverFixture)
    {
        _driverFixture = driverFixture;
    }
    
    private IWebElement txtName => _driverFixture.Driver.FindElement(By.Id("Name"));
    private IWebElement txtDescription => _driverFixture.Driver.FindElement(By.Name("Description"));
    private IWebElement txtPrice => _driverFixture.Driver.FindElement(By.Id("Price"));
    private IWebElement ddlProductType => _driverFixture.Driver.FindElement(By.Id("ProductType"));
    private IWebElement lnkCreate => _driverFixture.Driver.FindElement(By.LinkText("Create"));
    
    private IWebElement btnCreate => _driverFixture.Driver.FindElement(By.Id("Create"));
    
    private IWebElement tblList => _driverFixture.Driver.FindElement(By.CssSelector(".table"));

    public void ClickCreateButton() => lnkCreate.Click();
    
    
    public void CreateProduct(Product product)
    {
        txtName.SendKeys(product.Name);
        txtDescription.SendKeys(product.Description);
        txtPrice.SendKeys(product.Price.ToString());
        ddlProductType.SelectDropDownByText(product.ProductType.ToString());
        btnCreate.Click();
    }
    
    public void PerformClickOnSpecialValue(string name, string operation)
    {
        tblList.PerformActionOnCell("5", "Name", name, operation);
    }

}