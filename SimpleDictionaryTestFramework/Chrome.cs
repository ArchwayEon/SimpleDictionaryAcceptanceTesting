using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDictionaryTestFramework;

public class Chrome : IBrowser
{
    private IWebDriver? _webDriver;
    private WebDriverWait? _wait;

    public void Click(string inputValue)
    {
        _webDriver?
           .FindElement(By.CssSelector($"input[value=\"{inputValue}\"]"))
           .Click();
    }

    public void Create()
    {
        _webDriver = new ChromeDriver(@"C:\Drivers\chromedriver_win32");
        _wait = new WebDriverWait(_webDriver, new TimeSpan(0, 0, 30));
    }

    public void Input(string inputId, string data)
    {
        var input = _webDriver?.FindElement(By.Id(inputId));
        input?.Clear();
        input?.SendKeys(data);
    }

    public void Quit()
    {
        //_webDriver?.Quit();
        //_webDriver?.Dispose();
    }

    public int ReadNumberOfTableRowsByXPath(string xPath)
    {
        var count = 0;
        xPath += "/tbody/tr";
        var rows = _webDriver?.FindElements(By.XPath(xPath));
        if(rows != null)
        {
            count = rows.Count();
        }
        return count;
    }

    public string? ReadTextByXPath(string xPath)
    {
        return _webDriver?.FindElement(By.XPath(xPath)).Text;
    }

    public void Request(string url)
    {
        _webDriver?.Navigate().GoToUrl(url);
    }

    public void WaitForPage()
    {
        _wait?.Until(d => d.Title);
    }
}
